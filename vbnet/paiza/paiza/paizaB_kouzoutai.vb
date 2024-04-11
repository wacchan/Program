Imports System.Collections.Generic

Public Module paizaB_kouzoutai

    Sub kouzoutai()

        Dim inData() As String = Console.ReadLine().Split()
        Dim setNameCount As Integer = CInt(inData(0))
        Dim changeNameCount As Integer = CInt(inData(1))

        Dim users(setNameCount)() As String
        users(0) = New String(){"Name", "Old", "Birth", "Live"}

        For i As Integer = 1 To setNameCount
            users(i) = Console.ReadLine().Split()
        Next

        Dim inChange() As String
        For i As Integer = 1 To changeNameCount
            inChange = Console.ReadLine().Split()
            users = changeName(users, inChange)
        Next
        Call showUsers(users)
    End Sub

    Function changeName(i_users()() As String, i_changeData() As String) As String()()
        i_users(i_changeData(0))(0) = i_changeData(1)
        changeName = i_users
    End Function

    Sub showUsers(i_users()() As String)
        'Dim i_usersList As New List(Of String())
        For i As Integer = 1 To UBound(i_users)
            Console.WriteLine(Join(i_users(i)))
        Next
        'i_usersList.Add(i_users)
        'i_usersList.RemoveAt(0)
        'For Each i In i_usersList
        '    Console.WriteLine(Join(i))
        'Next
    End Sub

End Module
