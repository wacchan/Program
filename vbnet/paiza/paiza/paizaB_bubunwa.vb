Public Module paizaB_bubunwa
    Sub bubunwa()

        '全体の本数
        Dim inData() As String = Console.ReadLine().Split()
        Dim stoneNum As Integer = Int(inData(0))
        Dim targetWeight As Integer = Int(inData(1))
        '木の高さ
        Dim stones(stoneNum) As Integer

        '減少部分列（自分より大きい木が手前に何本あるか）
        Dim stonesCanReach(1000) As Integer

        For i As Integer = 0 To stoneNum - 1
            stones(i) = Int(Console.ReadLine())
            stonesCanReach(stones(i)) = 1
        Next

        '減少部分列の計算
        For i As Integer = 1 To targetWeight

            For j As Integer = 0 To UBound(stones)
                '自分より前の木を探索
                If stones(j) < i Then
                    '自分より木が大きい場合、減少部分列が大きければ更新
                    stonesCanReach(i) = Math.Max(stonesCanReach(i), stonesCanReach(i - stones(j)))
                End If
            Next
        Next

        If stonesCanReach(targetWeight) = 0 Then
            Console.WriteLine("no")
        Else
            Console.WriteLine("yes")
        End If

    End Sub
End Module
