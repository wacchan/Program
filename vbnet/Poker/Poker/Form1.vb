Imports System.Drawing.Drawing2D
Imports System.IO

Public Class Form1
    '最初の位置
    Dim dictOriginLocation As New Dictionary(Of String, Point)
    '最初の大きさ（Form1）
    Dim szOriginFormSize As Drawing.Size
    '最初の大きさ（Form1以外）
    Dim dictOriginSize As New Dictionary(Of String, Size)
    '最初のフォントサイズ
    Dim dictOriginFontSize As New Dictionary(Of String, Single)
    '最初の大きさと現在の大きさの比率
    Dim sglChangeScale As Single
    '交換フラグ（-1 or 1）
    Dim intClicked(4) As Integer
    'ポーカーゲームのインスタンス
    Dim player1 As C_Player
    '得点
    Dim intScore As Integer


    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'フォームが読み込まれたとき

        'インスタンス生成
        player1 = New C_Player

        '初期値
        sglChangeScale = 1
        intScore = 0
        Score.Text = intScore
        For i As Integer = 0 To UBound(intClicked)
            intClicked(i) = -1
        Next

        '自分自身の実行ファイルのパスを取得する
        Dim strCurPath As String = System.Reflection.Assembly.GetExecutingAssembly().Location
        strCurPath = strCurPath.Replace("\Poker\bin\Debug\Poker.exe", "")
        'カレントディレクトリ設定
        Directory.SetCurrentDirectory(strCurPath)

        '開始時点のフォームの大きさを記録
        szOriginFormSize = Me.Size
        '開始時点の各コントロールの位置、大きさ、フォントサイズを記録
        For Each ctrl As Control In Me.Controls
            dictOriginLocation.Add(ctrl.Name, ctrl.Location)
            dictOriginSize.Add(ctrl.Name, ctrl.Size)
            dictOriginFontSize.Add(ctrl.Name, ctrl.Font.Size)
        Next
        For Each ctrl As Control In CardLabelPanel.Controls
            dictOriginLocation.Add(ctrl.Name, ctrl.Location)
            dictOriginSize.Add(ctrl.Name, ctrl.Size)
            dictOriginFontSize.Add(ctrl.Name, ctrl.Font.Size)
        Next

    End Sub

    Private Sub Form1_SizeChanged(sender As Object, e As EventArgs) Handles MyBase.ResizeEnd
        'フォームのサイズが変わったとき

        If szOriginFormSize.Width = 0 Then
            'Form1_Loadより前に呼ばれた場合
            Exit Sub
        End If

        Me.Size = New Size(Me.Size.Width, Me.Size.Width * 5 / 8)


        '最初の大きさからの変化量
        sglChangeScale = Me.Size.Width / szOriginFormSize.Width

        '各コントロールの見た目が変わらないよう調整
        For Each ctrl As Control In Me.Controls
            '位置調整
            ctrl.Location = New Point(dictOriginLocation(ctrl.Name).X * sglChangeScale,
                                      dictOriginLocation(ctrl.Name).Y * sglChangeScale)
            'フォントサイズ調整
            ctrl.Font = New Font("MS UI Gothic",
                                 CSng(dictOriginFontSize(ctrl.Name) * sglChangeScale),
                                 FontStyle.Bold)
            '大きさ調整
            ctrl.Size = New Size(dictOriginSize(ctrl.Name).Width * sglChangeScale,
                                 dictOriginSize(ctrl.Name).Height * sglChangeScale)
        Next
        For Each ctrl As Control In CardLabelPanel.Controls
            ctrl.Location = New Point(dictOriginLocation(ctrl.Name).X * sglChangeScale,
            dictOriginLocation(ctrl.Name).Y * sglChangeScale)
            ctrl.Font = New Font("MS UI Gothic",
                                 CSng(dictOriginFontSize(ctrl.Name) * sglChangeScale),
                                 FontStyle.Bold)
            ctrl.Size = New Size(dictOriginSize(ctrl.Name).Width * sglChangeScale,
                                 dictOriginSize(ctrl.Name).Height * sglChangeScale)
        Next
    End Sub

    Private Sub SurveBt_Click(sender As Object, e As EventArgs) Handles SurveBt.Click
        'SurveBtが押されたとき

        '交換ボタン有効化
        ChangeBt.Visible = True
        CardLabelPanel.Visible = True
        RankBt.Visible = False
        RankShadowBt.Visible = False

        'ラベルリセット
        For i As Integer = 0 To UBound(intClicked)
            intClicked(i) = -1
            Call CardLabel(i, intClicked(i))
        Next

        'カード引き直し
        player1.DrawAll()
    End Sub

    Private Sub MyCard_Enter(sender As Object, e As EventArgs) Handles MyCard0.MouseEnter, MyCard4.MouseEnter, MyCard3.MouseEnter, MyCard2.MouseEnter, MyCard1.MouseEnter
        'カード画像内にカーソルが入ったとき

        '該当カードを少し上に上げる
        sender.Location = New Point(dictOriginLocation(sender.Name).X * sglChangeScale,
                                    dictOriginLocation(sender.Name).Y * sglChangeScale * 0.97)

    End Sub

    Private Sub MyCard_Leave(sender As Object, e As EventArgs) Handles MyCard0.MouseLeave, MyCard4.MouseLeave, MyCard3.MouseLeave, MyCard2.MouseLeave, MyCard1.MouseLeave
        'カード画像内からカーソルが離れたとき

        'カードの位置を元に戻す
        sender.Location = New Point(dictOriginLocation(sender.Name).X * sglChangeScale,
                                    dictOriginLocation(sender.Name).Y * sglChangeScale)

    End Sub

    Private Sub MyCard_Click(sender As Object, e As EventArgs) Handles MyCard0.Click, MyCard4.Click, MyCard3.Click, MyCard2.Click, MyCard1.Click, MyCard4_Label.Click, MyCard3_Label.Click, MyCard2_Label.Click, MyCard1_Label.Click, MyCard0_Label.Click
        'カード画像orラベルがクリックされたとき

        '数字（6文字目）を抽出
        Dim cardNo As Integer = sender.Name.Substring(6, 1)

        '交換フラグ・ラベル更新
        intClicked(cardNo) *= -1
        Call CardLabel(cardNo, intClicked(cardNo))
    End Sub

    Private Sub CardLabel(i_CardNo As Integer, i_Clicked As Integer)
        'ラベル判定
        Dim labelList() As Label = {MyCard0_Label, MyCard1_Label, MyCard2_Label, MyCard3_Label, MyCard4_Label}
        'Dim labelList As Control.ControlCollection = Panel1.Controls


        'ラベル更新
        If i_Clicked < 0 Then
            labelList(i_CardNo).Text = "かえる"
            labelList(i_CardNo).BackColor = Color.FromArgb(150, 30, 30, 30)
            labelList(i_CardNo).ForeColor = Color.White
        Else
            labelList(i_CardNo).Text = "のこす"
            labelList(i_CardNo).BackColor = Color.FromArgb(255, 250, 230, 100)
            labelList(i_CardNo).ForeColor = Color.Black
        End If
    End Sub

    Private Sub ChangeBt_Click(sender As Object, e As EventArgs) Handles ChangeBt.Click
        'ChangeBtが押されたとき

        '交換ボタン無効化
        ChangeBt.Visible = False
        CardLabelPanel.Visible = False

        '選んだカード引き直し
        Call player1.ReDraw(intClicked)

        '役判定
        Call ShowRank(RankCheck(player1.getHands()))

    End Sub

    ''' <summary>
    ''' フォーム中央に役を表示（ボタンの形を変更）
    ''' </summary>
    ''' <param name="i_strText"></param>
    Private Sub ShowRank(i_strText As String)

        '役の文字数分ボタンをX軸方向に拡大
        Dim intBtWidth As Integer = i_strText.Length * 23 * sglChangeScale
        RankBt.Size = New Size(intBtWidth, RankBt.Height)
        RankShadowBt.Size = New Size(intBtWidth, RankShadowBt.Height)

        'intBtWidthをもとにボタンをフォームX軸中央に配置
        RankBt.Location = New Point((Me.Width - intBtWidth) / 2, RankBt.Location.Y)
        RankShadowBt.Location = New Point((Me.Width - intBtWidth) / 2 + 5, RankShadowBt.Location.Y)

        RankBt.Image = gradation()

        'ボタンを文字の形に変更
        Dim gpPath As New System.Drawing.Drawing2D.GraphicsPath()
        gpPath.AddString(i_strText, New FontFamily("HGP創英角ﾎﾟｯﾌﾟ体"),
                         FontStyle.Italic Or FontStyle.Bold, 40 * sglChangeScale, New Point(0, 0),
                         StringFormat.GenericDefault)
        RankBt.Region = New Region(gpPath)
        RankShadowBt.Region = New Region(gpPath)

        '表示
        RankBt.Visible = True
        RankShadowBt.Visible = True

        'スコア更新
        If i_strText <> "No Pair" Then
            intScore += 10
            Score.Text = intScore
        End If

    End Sub

    ''' <summary>
    ''' グラデーションを返す。cotrol.Imageに適用で反映
    ''' </summary>
    ''' <returns>Button1の大きさのグラデーション</returns>
    Private Function gradation() As Bitmap

        ' ビットマップとGraphicsオブジェクトの作成
        Dim bmpGrad As New Bitmap(RankBt.Width, RankBt.Height)
        Dim gGrad As Graphics = Graphics.FromImage(bmpGrad)

        ' グラデーション・ブラシの作成
        Dim gradBrush As New LinearGradientBrush(
        gGrad.VisibleClipBounds,
        Color.Red,
        Color.Yellow,
        LinearGradientMode.Vertical)

        ' ビットマップをグラデーション・ブラシで塗る
        gGrad.FillRectangle(gradBrush, gGrad.VisibleClipBounds)

        gradBrush.Dispose()
        gGrad.Dispose()

        Return bmpGrad
    End Function
End Class
