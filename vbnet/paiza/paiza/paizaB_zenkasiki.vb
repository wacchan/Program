Module paizaB_zenkasiki

    Sub b_zenkasiki()
        'paiza B 3項間漸化式

        Dim inputCount
        inputCount = Console.ReadLine()
        Dim fibo(40) As Integer
        fibo(0) = 1
        fibo(1) = 1
        Dim i As Integer
        For i = 2 To 39
            fibo(i) = fibo(i - 1) + fibo(i - 2)
        Next
        Dim inputNums(inputCount - 1) As Integer
        For i = 0 To inputCount - 1
            Console.WriteLine(fibo(Console.ReadLine() - 1))
        Next

        ' Console.WriteLine (a)
    End Sub

End Module
