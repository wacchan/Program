Public Module paizaB_グラフ構造1
    Sub グラフ構造1()
        Dim inData() As String = Console.ReadLine().Split()
        Dim connection(inData(0)-1)() As String
        For i As Integer = LBound(connection) To UBound(connection)
            connection(i) = Console.ReadLine().Split()
        Next
        For i As Integer = 1 To inData(1)
            inData = Console.ReadLine().Split()
            Console.WriteLine(connection(inData(0) - 1)(inData(1) - 1))
        Next
    End Sub
End Module
