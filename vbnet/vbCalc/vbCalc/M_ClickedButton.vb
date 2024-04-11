Public Class M_ClickedButton
    Private opeSign() As String
    Private calcFlag As Boolean
    Private dotFlag As Boolean
    Private kakkoCount As Integer
    Private keeps(100)() As Object
    Private keepsCount As Integer
    Private divZero() As String = {"Div Zero"}

    Sub New(i_opeSign As String())
        opeSign = i_opeSign
        Call Init()
    End Sub

    Public Sub ClickEvent(i_str As String)


        Select Case i_str
            'Case "Form1"
    '    Call Form1_Load()
            Case 0.ToString() To 9.ToString()
                '数字
                Call Num_Click(i_str)
            Case Form1.ButtonDot.Text
                '.
                Call ButtonDot_Click()
            Case opeSign(0), opeSign(1), opeSign(2), opeSign(3)
                '四則
                Call Sign_Click(i_str)
            Case opeSign(4)
                '(
                Call ButtonLeft_Click()
            Case opeSign(5)
                ')
                Call ButtonRight_Click()
            Case Form1.ButtonEqual.Text
                '=
                Call ButtonEqual_Click()
            Case Form1.ButtonBS.Text
                'BS
                Call ButtonBS_Click()
            Case Form1.ButtonAC.Text
                'AC
                Call ButtonAC_Click()
        End Select
    End Sub


    Private Sub Init()
        calcFlag = True
        dotFlag = False
        kakkoCount = 0
        Form1.ResultBox.Text = ""
        keepsCount = 0
        ReDim keeps(UBound(keeps, 1))

    End Sub

    Private Sub Adds_log()
        keeps(keepsCount) = {calcFlag, dotFlag, kakkoCount}
        keepsCount += 1
        If 100 < keepsCount Then
            ReDim Preserve keeps(keepsCount)
        End If
    End Sub

    Private Sub Num_Click(i_strNum)
        Call Adds_log()

        Form1.ResultBox.Text += i_strNum
        calcFlag = False
    End Sub

    Private Sub ButtonDot_Click()
        If Not dotFlag Then
            Call Adds_log()

            Form1.ResultBox.Text += "."
            calcFlag = True
            dotFlag = True
        End If
    End Sub

    Private Sub Sign_Click(i_strSign)
        If Not calcFlag Then
            Call Adds_log()

            Form1.ResultBox.Text += " " + i_strSign + " "
            calcFlag = True
            dotFlag = False
        End If
    End Sub

    Private Sub ButtonLeft_Click()
        If calcFlag Then
            Call Adds_log()

            Form1.ResultBox.Text += opeSign(4) + " "
            kakkoCount += 1
        End If
    End Sub

    Private Sub ButtonRight_Click()
        If Not calcFlag And 0 < kakkoCount Then
            Call Adds_log()

            Form1.ResultBox.Text += " " + opeSign(5)
            kakkoCount -= 1
        End If
    End Sub

    Private Sub ButtonEqual_Click()
        If Not calcFlag Then
            Call Calc()
        End If
    End Sub

    Private Sub ButtonBS_Click()

        If 0 < keepsCount Then
            '端の空白削除
            Dim bsStr = RTrim(Form1.ResultBox.Text)
            '一文字削除→空白削除（記号の両側に空白が挟まるため）
            bsStr = RTrim(bsStr.Remove(bsStr.Length - 1))
            Form1.ResultBox.Text = bsStr
            If Not bsStr Like "*#" Then
                '削除後の末尾が数字ではない場合、空白挿入
                Form1.ResultBox.Text += " "
            End If
            'Stop
            keepsCount -= 1
            'Stop
            calcFlag = keeps(keepsCount)(0)
            dotFlag = keeps(keepsCount)(1)
            kakkoCount = keeps(keepsCount)(2)
            keeps(keepsCount) = Nothing
        End If
    End Sub

    Private Sub ButtonAC_Click()
        Call Init()
    End Sub

    Private Sub Calc()
        Dim formula() As String = Form1.ResultBox.Text.Split()

        Dim kCount As Integer = formula.Count(Function(s As String) s = opeSign(4))
        Dim kRCount As Integer = formula.Count(Function(s As String) s = opeSign(5))
        For i As Integer = 1 To kCount - kRCount
            ReDim Preserve formula(formula.Length)
            formula(UBound(formula)) = opeSign(5)
        Next
        'Stop

        Dim calcTarget(UBound(formula)) As String
        formula.CopyTo(calcTarget, 0)
        For i As Integer = 1 To kCount
            Dim kIndex() As Integer = SearchKakko(calcTarget)

            'カッコ内の長さ
            Dim kLen As Integer = kIndex(1) - kIndex(0) - 1
            'カッコの中身
            Dim sFormula(kLen - 1) As String
            'カッコの中身を取得
            Array.Copy(calcTarget, kIndex(0) + 1, sFormula, 0, kLen)
            'Stop
            'カッコ内計算
            sFormula = CalcPrioritized(sFormula, 2)
            sFormula = CalcPrioritized(sFormula, 1)

            'Stop
            '元計算式からカッコ部分削除（計算結果挿入のため1つだけ残す）
            Dim fList As List(Of String) = calcTarget.ToList()
            fList.RemoveRange(kIndex(0), kLen + 1)
            calcTarget = fList.ToArray()
            'Stop
            '元計算式に代入
            If IsNumeric(sFormula(0)) Then
                calcTarget(kIndex(0)) = sFormula(0)
            Else
                calcTarget = sFormula
                Exit For
            End If
        Next

        calcTarget = CalcPrioritized(calcTarget, 2)
        calcTarget = CalcPrioritized(calcTarget, 1)
        'Stop

        Form1.TextLog.AppendText(vbCrLf + Join(formula) + " = ")
        For Each i In calcTarget
            Form1.TextLog.AppendText(i)
        Next
        Form1.TextLog.AppendText(vbCrLf)

        Call Init()



    End Sub

    Private Function SearchKakko(i_formula() As String) As Integer()
        'カッコの場所
        Dim kIndex(1) As Integer
        For i As Integer = LBound(i_formula) To UBound(i_formula)
            If i_formula(i) = opeSign(4) Then
                '見つかるたびに更新（一番内側のカッコを探索）
                kIndex(0) = i
            ElseIf i_formula(i) = opeSign(5) And kIndex(1) = 0 Then
                '1回だけ更新（一番内側のカッコを探索）
                kIndex(1) = i
            End If
        Next
        If kIndex(1) = 0 Then
            'Stop
            MsgBox("カッコエラー")
        End If

        SearchKakko = kIndex

    End Function

    Private Function CalcPrioritized(i_formula() As String, i_priIndex As Integer) As String()
        Dim priority() As Integer = setPriority(i_formula)
        For i As Integer = LBound(i_formula) To UBound(i_formula)
            If priority(i) = i_priIndex Then
                i_formula = PointCalc(i_formula, i)
                If i_formula Is divZero Then
                    Exit For
                End If
            End If
        Next
        Dim formulaList As List(Of String) = i_formula.ToList()
        formulaList.RemoveAll(Function(s As String) s = "")
        CalcPrioritized = formulaList.ToArray()
    End Function

    Private Function setPriority(i_formula() As String) As Integer()
        Dim p(UBound(i_formula)) As Integer
        Dim priorityData As New Dictionary(Of String, Integer) From
            {{opeSign(0), 1}, {opeSign(1), 1}, {opeSign(2), 2}, {opeSign(3), 2}}
        For i As Integer = LBound(i_formula) To UBound(i_formula)
            If priorityData.ContainsKey(i_formula(i)) Then
                p(i) = priorityData(i_formula(i))
            End If
        Next
        setPriority = p
    End Function

    Private Function PointCalc(i_formula() As String, i_target As Integer) As String()
        Dim ans As Double
        If i_formula(i_target) = opeSign(0) Then
            ans = CDbl(i_formula(i_target - 1)) + CDbl(i_formula(i_target + 1))
        ElseIf i_formula(i_target) = opeSign(1) Then
            ans = CDbl(i_formula(i_target - 1)) - CDbl(i_formula(i_target + 1))
        ElseIf i_formula(i_target) = opeSign(2) Then
            ans = CDbl(i_formula(i_target - 1)) * CDbl(i_formula(i_target + 1))
        ElseIf i_formula(i_target) = opeSign(3) Then
            If CDbl(i_formula(i_target + 1)) = 0 Then
                PointCalc = divZero
                Exit Function
            End If
            ans = CDbl(i_formula(i_target - 1)) / CDbl(i_formula(i_target + 1))
        Else
            PointCalc = i_formula
            Exit Function
        End If
        Array.Clear(i_formula, i_target - 1, 2)
        i_formula(i_target + 1) = ans
        PointCalc = i_formula
    End Function

End Class
