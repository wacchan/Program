Imports System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar

Public Class C_Hand

    Private Shared strMark() As String = {"club", "diamond", "heart", "spade", "joker"}
    Private Shared intCardStack(53) As Integer
    ''' <summary>
    ''' カードの使用状況（山札）。0: 未使用、1: 使用済。
    ''' </summary>
    ''' <returns>カードリスト</returns>
    Public ReadOnly Property CardStack() As Integer()
        Get
            Return intCardStack
        End Get
    End Property

    Private intCard(1) As Integer
    ''' <summary>
    ''' 現在のカード
    ''' </summary>
    ''' <returns> {マーク(ジョーカーは4)、数字(ジョーカーは15,16)} </returns>
    Public ReadOnly Property Card() As Integer()
        Get
            Return intCard
        End Get
    End Property

    Private rnd As New Random


    Sub Draw()

        '自分の手札にカードを配る
        'ランダムに1枚選ぶ
        Dim intSetCard As Integer = rnd.Next(1, intCardStack.Count)
        Do Until intCardStack(intSetCard) = 0
            '未選択のカードになるまで選び直す
            intSetCard = rnd.Next(1, intCardStack.Count)
        Loop

        'カードを選択済にする
        intCardStack(intSetCard) = 1
        '手札にセットする
        intCard = {intSetCard \ 13, (intSetCard Mod 13) + 1}
        If intCard(0) = 4 Then
            intCard(1) += 14
        End If
    End Sub

    Sub Show(i_ctrl As PictureBox)
        i_ctrl.ImageLocation = "./pics/card_" + strMark(intCard(0)) + "_" + intCard(1).ToString("00") + ".png"
    End Sub

    Sub StackReset()
        Array.Clear(intCardStack, 0, intCardStack.Count)
    End Sub

End Class
