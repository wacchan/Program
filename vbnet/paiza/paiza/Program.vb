Imports System
Imports System.Runtime.CompilerServices
Imports System.Collections.Generic

Module Program
    Sub main()
        'Call b_zenkasiki()
        'Call b_kaidan()
        'Call b_kaidan_ans()
        'Call saiyasu()
        'Call renzoku()
        'Call renzoku_ans()
        'Call bubun2()
        'Call bubunwa()
        'Call kouzoutai()
        'Call 静的メンバ()
        'Call ロボットの暴走()
        'Call グラフ構造1()

        Dim fruits As List(Of String) = New List(Of String)({"grape", "", "", "", "", "", "orange", "melon", "cherry", "apple"})
        fruits.RemoveAll(Function(s As String) s = "")

        Dim f() As String = {"grape", "", "", "", "", "", "orange", "melon", "cherry", "apple"}
        f.ToList().RemoveAll(Function(s As String) s = "")


        For Each fruit As String In f
            Console.WriteLine(fruit)
        Next

    End Sub


End Module
