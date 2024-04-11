Module paizaB_saiyasune

    Sub saiyasu()
        'paiza B 最安値を達成するには

        '入力値
        Dim inData() As String = Console.ReadLine().Split()
        '欲しい数
        Dim NumOfWant As Integer = Int(inData(0))
        '商品（売ってる個数）
        Dim goods(UBound(inData) / 2) As Integer
        '値段
        Dim goodsPrice(UBound(inData) / 2) As Integer
        '入力値から取得
        Dim i As Integer
        For i = 1 To UBound(inData) Step 2
            goods(Int(i / 2)) = inData(i)
            goodsPrice(Int(i / 2)) = inData(i + 1)
        Next

        '最大数（Paizaだと.Maxが使えなかった）
        Dim goodsMax As Integer = 0
        For Each i In goods
            goodsMax = Math.Max(goodsMax, i)
        Next
        '合計金額の配列（はみ出しokのため、欲しい数 + 最大数）
        Dim totalPrice(NumOfWant + goodsMax) As Integer
        'Dim totalPrice(NumOfWant + goods.Max) As Integer
        '0埋め
        Array.Clear(totalPrice, 0, totalPrice.Length)
        '商品の値段記録
        For i = 0 To UBound(goods)
            totalPrice(goods(i)) = goodsPrice(i)
        Next
        '最安値探索
        For i = 1 To UBound(totalPrice)
            '値段計算、安かったら更新
            For j As Integer = 0 To UBound(goods)
                If goods(j) < i Then
                    'i - goods(j)個の値段 and goods(j)個の値段
                    Dim tp As Integer = totalPrice(i - goods(j)) + goodsPrice(j)
                    'i - goods(j)個買える and ( 値段記録無し or 既存の値段より安い )
                    If totalPrice(i - goods(j)) <> 0 And (totalPrice(i) = 0 Or tp < totalPrice(i)) Then
                        '記録
                        totalPrice(i) = tp
                    End If
                End If
            Next
        Next

        '欲しい数以降で切り取り
        Dim cut_totalPrice(UBound(totalPrice) - NumOfWant) As Integer
        Array.Copy(totalPrice, NumOfWant, cut_totalPrice, 0, cut_totalPrice.Length)

        '最安値検索（0以外）
        Dim goodsMin As Integer = 2 ^ 16
        For Each i In cut_totalPrice
            If i <> 0 Then
                goodsMin = Math.Min(goodsMin, i)
            End If
        Next
        Console.WriteLine(goodsMin)
    End Sub

End Module
