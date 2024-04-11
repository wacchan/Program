Public Module M_RankCheck
    Private intHandsMax As Integer = 4
    Private intHands()() As Integer
    Dim intJoker As Integer

    Public Function RankCheck(ByVal i_intHands As IReadOnlyList(Of Integer())) As String
        If i_intHands.Count <> intHandsMax + 1 Then
            Return "No Pair"
        Else
            intHands = i_intHands.ToArray()
        End If

        intJoker = intHands.Count(Function(s) s(0) = 4)

        Dim intRank As Integer = Flush() + Straight()
        If intRank = 0 Then
            intRank += Pairs()
        End If

        If intJoker = 0 Then

        End If

        Select Case intRank
            Case 0
                Select Case intJoker
                    Case 0
                        Return "No Pair"
                    Case 1
                        Return "One Pair"
                    Case 2
                        Return "Two Pair"
                End Select
            Case 1
                Select Case intJoker
                    Case 0
                        Return "One Pair"
                    Case 1
                        Return "Three of a Kind"
                    Case 2
                        Return "Four of a Kind"
                End Select
            Case 2
                Select Case intJoker
                    Case 0
                        Return "Two Pair"
                    Case 1
                        Return "Full House"
                End Select
            Case 3
                Select Case intJoker
                    Case 0
                        Return "Three of a Kind"
                    Case 1
                        Return "Four of a Kind"
                    Case 2
                        Return "Five of a Kind"
                End Select
            Case 4
                Return "Full House"
            Case 6
                Select Case intJoker
                    Case 0
                        Return "Four of a Kind"
                    Case 1
                        Return "Five of a Kind"
                End Select
            Case 10
                Return "Flush"
            Case 20
                Return "Straight"
            Case 30
                Return "Straight Flush"
            Case Else
                Return intRank
        End Select

    End Function

    Private Function Flush() As Integer
        For Each i In intHands
            If intHands(0)(0) <> i(0) And i(0) <> 4 Then
                'マークの部分が一緒ではない　かつ　ジョーカーではない
                Return 0
            End If
        Next
        Return 10
    End Function

    Private Function Straight() As Integer
        '数字の昇順にソート
        Dim intSortedHands(intHandsMax)() As Integer
        Array.Copy(intHands, intSortedHands, intHands.Length)
        Array.Sort(intSortedHands, Function(a, b) a(1) - b(1))

        'ジョーカーの枚数
        Dim intJokerCount As Integer = intJoker

        For i As Integer = 1 To intHandsMax
            If intSortedHands(i)(1) - intSortedHands(i - 1)(1) <> 1 Then
                '差が 1 じゃない
                If intJokerCount = 0 Or intSortedHands(i)(1) - intSortedHands(i - 1)(1) <> 2 Then
                    'ジョーカーがない or 差が 2 じゃない
                    Return 0
                Else
                    intJokerCount -= 1
                End If
            End If
        Next
        Return 20
    End Function

    Private Function Pairs() As Integer
        Dim intSameCount As Integer = 0
        For i As Integer = 0 To intHandsMax
            For j As Integer = i + 1 To intHandsMax
                If intHands(i)(1) = intHands(j)(1) Then
                    intSameCount += 1
                End If
            Next
        Next
        Return intSameCount
    End Function


End Module
