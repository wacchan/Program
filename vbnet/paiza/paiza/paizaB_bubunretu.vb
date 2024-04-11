Public Module paizaB_bubunretu

    Sub bubun2()
        'paiza B 最長減少部分列
        '最長減少連続部分列の見る範囲拡大版（あっちは1つ前のみ）
        '自分より前全部見て、大きい奴のうち最大カウント+1、いなかったら1

        '全体の本数
        Dim trNum As Integer = Int(Console.ReadLine())
        '木の高さ
        Dim trs(trNum) As Integer
        '減少部分列（自分より大きい木が手前に何本あるか）
        Dim trOrderCount(trNum) As Integer

        '減少部分列の計算
        For i As Integer = 1 To trNum
            '今見る木
            trs(i) = Int(Console.ReadLine())
            '初期値（自分より大きいのが居なかったらこのまま）
            trOrderCount(i) = 1
            For j As Integer = 1 To i
                '自分より前の木を探索
                If trs(i) < trs(j) Then
                    '自分より木が大きい場合、減少部分列が大きければ更新
                    trOrderCount(i) = Math.Max(trOrderCount(i), trOrderCount(j) + 1)
                End If
            Next
        Next

        '最大値
        Dim max As Integer = 0
        For i As Integer = 0 To UBound(trOrderCount)
            max = Math.Max(max, trOrderCount(i))
        Next
        Console.WriteLine(max)

    End Sub

    Sub bubun()
        '木全体を小さな減少連続部分列に分け、それを繋げるスタイル
        '木1本ずつで判定しないので失敗

        Dim treeNum As Integer = Int(Console.ReadLine())
        Dim trees(treeNum) As Integer
        For i As Integer = 1 To UBound(trees)
            trees(i) = Int(Console.ReadLine())
        Next
        Dim trees_localTop(,) As Integer = reorder_check(trees)
        Dim trees_totalTop(trees_localTop.GetLength(0) - 1, trees_localTop.GetLength(1) - 1) As Integer
        Array.Copy(trees_localTop, 0, trees_totalTop, 0, trees_localTop.Length)

        For i As Integer = 1 To UBound(trees_localTop, 2)
            For j As Integer = i - 1 To 0 Step -1
                If trees(trees_localTop(0, i)) <= trees(trees_localTop(0, j) + trees_localTop(1, j) - 1) Then
                    Dim tt As Integer = trees_localTop(1, i) + trees_localTop(1, j)
                    trees_totalTop(1, i) = Math.Max(trees_totalTop(1, i), tt)
                End If
            Next
        Next

        'Call show_darray(trees_localTop)
        'Call show_darray(trees_totalTop)
        'Call show_darray(trees_localTop)

        '最大値
        Dim max As Integer = 0
        For i As Integer = 0 To UBound(trees_totalTop, 2)
            max = Math.Max(max, trees_totalTop(1, i))
        Next
        Console.WriteLine(max)


    End Sub

    Sub show_darray(i_array(,) As Integer)
        For i As Integer = 0 To i_array.GetLength(0) - 1

            '列の数(横)
            'GetLength(1)で列の数が取得できる
            '配列は0から始まるので -1 をする
            For k As Integer = 0 To i_array.GetLength(1) - 1
                Console.Write(i_array(i, k) & " ")
            Next

            Console.WriteLine()
        Next
    End Sub

    Function reorder_check(i_array As Integer()) As Integer(,)

        '逆順の先頭、その長さ
        Dim sortCount(1, 0) As Integer
        'Dim sortCount(1, UBound(i_array)) As Integer
        '↑のインデックス
        Dim sortCountIndex As Integer = 0
        Dim i As Integer
        For i = 1 To UBound(i_array)
            If i_array(i - 1) < i_array(i) Then
                '前の木より高い場合

                'インデックスの場所に今見てる木を記録
                ReDim Preserve sortCount(1, sortCountIndex)
                sortCount(0, sortCountIndex) = i
                If 1 <= sortCountIndex Then
                    'インデックスが1以上の時、1個前の逆順の長さを記録
                    sortCount(1, sortCountIndex - 1) = i - sortCount(0, sortCountIndex - 1)
                End If
                sortCountIndex = sortCountIndex + 1
            End If
        Next
        sortCount(1, sortCountIndex - 1) = i - sortCount(0, sortCountIndex - 1)

        reorder_check = sortCount



    End Function

End Module