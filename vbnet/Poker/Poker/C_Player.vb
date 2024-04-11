Public Class C_Player

    Private hndHands(4) As C_Hand

    Sub New()
        For i As Integer = 0 To UBound(hndHands)
            hndHands(i) = New C_Hand
        Next
    End Sub

    Public Function getHands() As List(Of Integer())
        Dim intHands As New List(Of Integer())
        For Each i As C_Hand In hndHands
            intHands.Add(i.Card)
        Next
        Return intHands
    End Function

    Sub DrawAll()

        '山札が十分な数あるか
        If hndHands(0).CardStack.Count(Function(s) s = 0) < 10 Then
            hndHands(0).StackReset()
            'Form1.
            '.Text = "Not Enough Cards."
            'Return
        End If

        '自分の手札にカードを配る
        For i As Integer = 0 To UBound(hndHands)
            hndHands(i).Draw()
        Next

        '数字順にソート
        Array.Sort(hndHands, AddressOf CompareByNum)

        Call ShowAll()
    End Sub

    Sub ReDraw(i_intClicked As IReadOnlyList(Of Integer))
        For i As Integer = 0 To UBound(i_intClicked)
            If i_intClicked(i) < 0 Then
                hndHands(i).Draw()
            End If
        Next
        Call ShowAll()
    End Sub

    Sub ShowAll()
        'セットされた手札を表示する

        '表示先のPictureBox
        Dim pbCards() As PictureBox = {Form1.MyCard0, Form1.MyCard1, Form1.MyCard2, Form1.MyCard3, Form1.MyCard4}
        For i As Integer = 0 To UBound(pbCards)
            hndHands(i).Show(pbCards(i))
        Next

    End Sub

    Private Function CompareByNum(ByVal i_hndA As C_Hand, ByVal i_hndB As C_Hand)
        Return i_hndA.Card(1) - i_hndB.Card(1)
    End Function

End Class
