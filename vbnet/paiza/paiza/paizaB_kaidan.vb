Imports System.Runtime.Intrinsics.Arm

Module paizaB_kaidan

    Sub b_kaidan_ans()
        '入力値受け取り
        Dim inputData() As String
        'スペースで分割
        inputData = Console.ReadLine().Split()

        '漸化式dp[n] = dp[n-a] + dp[n-b] + dp[n-c]
        'dp[0] = 1 にすることで、dp[a]/dp[b]/dp[c] = 1 になり、連鎖する
        Dim ans(inputData(0)) As Integer
        Array.Clear(ans, 0, ans.Length)
        ans(0) = 1
        For i As Integer = 1 To inputData(0)
            For j As Integer = 1 To UBound(inputData)
                If inputData(j) <= i Then
                    ans(i) = ans(i) + ans(i - inputData(j))
                End If
            Next
        Next

        Console.WriteLine(ans(inputData(0)))

    End Sub


    Sub b_kaidan()
        'paiza B 階段の上り方３

        '入力値受け取り
        Dim inputData() As String
        'スペースで分割
        inputData = Console.ReadLine().Split()
        '上りたい段数
        Dim totalStair As Integer = Int(inputData(0))
        '一歩で上れる段数一覧
        Dim steps(UBound(inputData) - 1) As String
        Array.Copy(inputData, 1, steps, 0, steps.Length)

        '各stepsで上った回数
        Dim stepCount(UBound(steps)) As Integer
        '0埋め
        Array.Clear(stepCount, 0, stepCount.Length)
        Dim ans As Integer = kaidan_saiki(totalStair, 0, steps, stepCount)
        Console.WriteLine(ans)




    End Sub

    Function kaidan_saiki(i_totalStair As Integer, i_stairCount As Integer, i_steps() As String, i_stepCount() As Integer) As Integer
        ''' 階段の上り方探索プログラム（再帰）
        ''' 
        ''' Args: i_totalStair As Integer   上りたい段数
        '''       i_stairCount As Integer   上り方の数
        '''       i_steps() As String       一歩で上れる段数一覧
        '''       i_stepCount() As Integer  各stepsで上った回数
        ''' 
        ''' Returns: kaidan_saiki As Integer    上り方の数
        '''

        '今いる段
        Dim upstairs As Integer
        For i As Integer = 0 To UBound(i_steps)
            upstairs = upstairs + i_steps(i) * i_stepCount(i)
        Next
        If i_totalStair = upstairs Then
            '上りたい段数と同じなら、i_stairCount+1 を返してExit
            kaidan_saiki = i_stairCount + 1
            Exit Function
        ElseIf i_totalStair < upstairs Then
            '上りたい段数を超えたら、増やさずExit
            kaidan_saiki = i_stairCount
            Exit Function
        End If
        For i As Integer = 0 To UBound(i_stepCount)
            'i_stepCountをそれぞれ1増やして再帰呼び出し
            '一時的にコピーして1増やす
            Dim new_stepCount(UBound(i_stepCount)) As Integer
            '参照型なので、コピーしないと一緒に変わってしまう
            Array.Copy(i_stepCount, new_stepCount, i_stepCount.Length)
            new_stepCount(i) = new_stepCount(i) + 1

            '再帰呼び出し。i_stairCount更新
            i_stairCount = kaidan_saiki(i_totalStair, i_stairCount, i_steps, new_stepCount)
        Next
        '更新したi_stairCountを返す
        kaidan_saiki = i_stairCount
    End Function


End Module
