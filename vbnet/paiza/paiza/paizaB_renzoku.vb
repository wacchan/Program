Public Module paizaB_renzoku

    Sub renzoku_ans()
        '自分で書いたのと大して変わらん

        '人数
        Dim people As Integer = Int(Console.ReadLine())
        '前の人の身長
        Dim tall As Integer = Integer.MaxValue
        '逆順に並んでる人数
        Dim sortCount(people) As Integer
        '0埋め
        Array.Clear(sortCount, 0, sortCount.Length)
        For i As Integer = 1 To people
            '身長取得
            Dim curTall As Integer = Int(Console.ReadLine())
            If tall < curTall Then
                '前の人より高い場合、1
                sortCount(i) = 1
            Else
                '前の人より低い場合、前の人の数字+1
                sortCount(i) = sortCount(i - 1) + 1
            End If
            '前の人の身長更新
            tall = curTall
        Next

        '最大値
        Dim sortCountMax As Integer = 0
        For Each i As Integer In sortCount
            sortCountMax = Math.Max(sortCountMax, i)
        Next
        Console.WriteLine(sortCountMax)


    End Sub

    Sub renzoku()
        'paiza B 最長減少連続部分列
        '1つ前を見て、大きかったら+1、そうじゃないなら1

        '人数
        Dim people As Integer = Int(Console.ReadLine())
        '前の人の身長
        Dim tall As Integer = Integer.MaxValue
        '逆順に並んでる人数（速度上げる為に長めの配列を作っておく）
        Dim sortCount(people) As Integer
        '0埋め
        Array.Clear(sortCount, 0, sortCount.Length)
        '逆順カウントの目印
        Dim sortCountIndex As Integer = 0
        For i As Integer = 1 To people
            '身長取得
            Dim curTall As Integer = Int(Console.ReadLine())
            If tall < curTall Then
                '前の人より高い時
                sortCountIndex = sortCountIndex + 1
            End If
            '逆順カウント
            sortCount(sortCountIndex) = sortCount(sortCountIndex) + 1
            '前の人の身長更新
            tall = curTall
        Next

        '最大値
        Dim sortCountMax As Integer = 0
        For Each i As Integer In sortCount
            sortCountMax = Math.Max(sortCountMax, i)
        Next
        Console.WriteLine(sortCountMax)
    End Sub

End Module
