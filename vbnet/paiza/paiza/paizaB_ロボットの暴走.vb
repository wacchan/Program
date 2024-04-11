Public Module paizaB_ロボットの暴走
    Sub ロボットの暴走()
        Dim inData() = Console.ReadLine().Split()
        Dim map(inData(1), inData(0)) As Integer
        Dim roboNum As Integer = CInt(inData(2))
        Dim roboPlace(roboNum)() As String
        Dim moveCount As Integer = CInt(inData(3))

        Dim mapy As String, mapx As String
        '工具箱設置
        For i As Integer = 0 To 9
            inData = Console.ReadLine().Split()
            map(inData(0), inData(1)) = -1
        Next
        For i As Integer = 1 To roboNum
            roboPlace(i) = Console.ReadLine().Split()
        Next
        Dim moveRobo As Integer, moveDir As String
        For i As Integer = 0 To moveCount - 1
            inData = Console.ReadLine().Split()
            moveRobo = CInt(inData(0))
            moveDir = inData(1)
            roboPlace(moveRobo) = Robo_action(roboPlace(moveRobo), moveDir, map)
        Next

        For i As Integer = 1 To roboNum
            Console.WriteLine(Join(roboPlace(i)))
        Next
    End Sub

    Function Robo_action(i_curRoboPlace() As String, i_moveDir As String, i_map(,) As Integer) As String()
        '移動
        Dim moveRange() As Integer = {0, 1, 2, 5, 10}
        If i_moveDir = "N" Then
            i_curRoboPlace(1) -= moveRange(i_curRoboPlace(2))
        ElseIf i_moveDir = "E" Then
            i_curRoboPlace(0) += moveRange(i_curRoboPlace(2))
        ElseIf i_moveDir = "W" Then
            i_curRoboPlace(0) -= moveRange(i_curRoboPlace(2))
        ElseIf i_moveDir = "S" Then
            i_curRoboPlace(1) += moveRange(i_curRoboPlace(2))
        End If

        If LBound(i_map, 1) <= i_curRoboPlace(0) And i_curRoboPlace(0) <= UBound(i_map, 1) And
           LBound(i_map, 2) <= i_curRoboPlace(1) And i_curRoboPlace(1) <= UBound(i_map, 2) Then
            If i_map(i_curRoboPlace(0), i_curRoboPlace(1)) = -1 Then
                i_curRoboPlace(2) = Math.Min(i_curRoboPlace(2) + 1, 4)
            End If
        End If
        Robo_action = i_curRoboPlace
    End Function
End Module
