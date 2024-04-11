Public Class C_Card

    Private intCards(53) As Integer

    Private myCards(4)() As Integer
    Public ReadOnly Property Cards()
        Get
            Return myCards
        End Get
    End Property



    Private rnd As New Random

    Private strMark() As String = {"club", "diamond", "heart", "spade", "joker"}

    Sub New()
        Array.Clear(intCards, 0, intCards.Count)
    End Sub

    Sub CardSet()

        '山札が十分な数あるか
        If intCards.Count(Function(s) s = 0) < 5 Then
            Form1.Score.Text = "Not Enough Cards."
            Return
        End If

        '自分の手札にカードを配る
        For i As Integer = 0 To UBound(myCards)

            'ランダムに1枚選ぶ
            Dim intSetCaed As Integer = rnd.Next(1, intCards.Count)
            Do Until intCards(intSetCaed) = 0
                '未選択のカードになるまで選び直す
                intSetCaed = rnd.Next(1, intCards.Count)
            Loop

            'カードを選択済にする
            intCards(intSetCaed) = 1
            '手札にセットする
            myCards(i) = {intSetCaed \ 13, (intSetCaed Mod 13) + 1}
            If myCards(i)(0) = 4 Then
                myCards(i)(1) += 14
            End If
        Next

        'セットされた手札を表示する
        Form1.MyCard0.ImageLocation = "./pics/card_" + strMark(myCards(0)(0)) + "_" + myCards(0)(1).ToString("00") + ".png"
        Form1.MyCard1.ImageLocation = "./pics/card_" + strMark(myCards(1)(0)) + "_" + myCards(1)(1).ToString("00") + ".png"
        Form1.MyCard2.ImageLocation = "./pics/card_" + strMark(myCards(2)(0)) + "_" + myCards(2)(1).ToString("00") + ".png"
        Form1.MyCard3.ImageLocation = "./pics/card_" + strMark(myCards(3)(0)) + "_" + myCards(3)(1).ToString("00") + ".png"
        Form1.MyCard4.ImageLocation = "./pics/card_" + strMark(myCards(4)(0)) + "_" + myCards(4)(1).ToString("00") + ".png"

    End Sub

End Class
