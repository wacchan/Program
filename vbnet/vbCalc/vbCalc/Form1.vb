Imports System.Reflection

Public Class Form1
    Dim cb As M_ClickedButton
    Dim opeSign As String()

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        opeSign = {ButtonPlus.Text, ButtonSub.Text, ButtonMulti.Text,
                   ButtonDiv.Text, ButtonLeft.Text, ButtonRight.Text}
        cb = New M_ClickedButton(opeSign)
    End Sub

    Private Sub Form1_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles MyBase.KeyDown

        'MsgBox(ActiveControl.Name)
        'TextLog.Text = e.KeyData.ToString()

        Dim keyKind As String
        Select Case e.KeyData
            Case Keys.D0 To Keys.D9, Keys.NumPad0 To Keys.NumPad9
                Dim numKey As String = e.KeyData.ToString()
                keyKind = numKey.Chars(numKey.Length - 1)
            Case Keys.Add, Keys.Oemplus Or Keys.Shift
                keyKind = opeSign(0)
            Case Keys.Subtract, Keys.OemMinus
                keyKind = opeSign(1)
            Case Keys.Multiply, Keys.Oem1 Or Keys.Shift
                keyKind = opeSign(2)
            Case Keys.Divide, Keys.OemQuestion
                keyKind = opeSign(3)
            Case Keys.D8 Or Keys.Shift
                keyKind = opeSign(4)
            Case Keys.D9 Or Keys.Shift
                keyKind = opeSign(5)
            Case Keys.Decimal, Keys.OemPeriod
                keyKind = ButtonDot.Text
            Case Keys.Back
                keyKind = ButtonBS.Text
            Case Keys.Delete
                keyKind = ButtonAC.Text
            Case Keys.OemMinus Or Keys.Shift
                keyKind = ButtonEqual.Text
            Case Keys.Enter
                keyKind = ButtonEqual.Text
            Case Else
                Exit Sub
                ' ↑以外
        End Select

        Call cb.ClickEvent(keyKind)

    End Sub

    Private Sub Button1_Click(sender As Object, e As MouseEventArgs) Handles Button1.MouseClick, Button2.MouseClick, Button3.MouseClick, Button4.MouseClick, Button5.MouseClick, Button6.MouseClick, Button7.MouseClick, Button8.MouseClick, Button9.MouseClick, Button0.MouseClick, ButtonDot.MouseClick, ButtonPlus.MouseClick, ButtonDiv.MouseClick, ButtonMulti.MouseClick, ButtonSub.MouseClick, ButtonEqual.MouseClick, ButtonAC.MouseClick, ButtonRight.MouseClick, ButtonLeft.MouseClick, ButtonBS.MouseClick
        'TextLog.Text = sender.text.ToString()

        Call cb.ClickEvent(sender.text)
        ActiveControl = Nothing
    End Sub

End Class
