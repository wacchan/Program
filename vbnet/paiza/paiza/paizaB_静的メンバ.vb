Public Module paizaB_静的メンバ

    Sub 静的メンバ()
        Dim inData() As String = Console.ReadLine().Split()
        Dim guestCount As Integer = CInt(inData(0))
        Dim orderCount As Integer = CInt(inData(1))
        Dim izakaya(guestCount - 1) As Guest
        For i As Integer = 0 To UBound(izakaya)
            izakaya(i) = New Guest(CInt(Console.ReadLine()))
        Next

        'オーダーした人
        Dim orderedGuest As Integer
        For i As Integer = 0 To orderCount - 1
            'オーダー内容取得
            inData = Console.ReadLine().Split(" ", 2)
            'オーダーした人受け取り
            orderedGuest = CInt(inData(0)) - 1
            'オーダー内容受け取り
            Dim ordered() As String = inData(1).Split()
            If ordered.Length = 1 Then
                'オーダー内容が分割できなかった場合（Aor0）
                izakaya(orderedGuest).Order(ordered(0))
            Else
                izakaya(orderedGuest).Order(ordered)
            End If
        Next
        Console.WriteLine(izakaya(0).totalSales)

    End Sub

End Module


Class Guest
    Private _age As Integer
    Private _bonus As Integer = 0
    Private Shared _totalSales As New Integer
    Property totalSales As Integer
        Get
            Return _totalSales
        End Get
        Set(value As Integer)
            _totalSales = value
        End Set
    End Property

    Private _guestSales As New Integer
    Property guestSales As Integer
        Get
            Return _guestSales
        End Get
        Set(value As Integer)
            _guestSales = value
        End Set
    End Property

    Sub New(i_age As Integer)
        _age = i_age
    End Sub

    Sub Order(i_order As String)
        If i_order = "0" And 20 <= _age Then
            guestSales += 500
            _bonus = -200
        ElseIf i_order = "A" Then
            Console.WriteLine(guestSales)
            totalSales += 1
        End If
    End Sub

    Sub Order(i_order() As String)

        If i_order(0) = "alcohol" Then
            If 20 <= _age Then
                guestSales += i_order(1)
                _bonus = -200
            End If
        Else
            guestSales += i_order(1)
        End If
        If i_order(0) = "food" Then
            guestSales += _bonus
        End If
    End Sub
End Class