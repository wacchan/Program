<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows フォーム デザイナーで必要です。
    Private components As System.ComponentModel.IContainer

    'メモ: 以下のプロシージャは Windows フォーム デザイナーで必要です。
    'Windows フォーム デザイナーを使用して変更できます。  
    'コード エディターを使って変更しないでください。
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.MyCard0 = New System.Windows.Forms.PictureBox()
        Me.MyCard1 = New System.Windows.Forms.PictureBox()
        Me.MyCard2 = New System.Windows.Forms.PictureBox()
        Me.MyCard3 = New System.Windows.Forms.PictureBox()
        Me.MyCard4 = New System.Windows.Forms.PictureBox()
        Me.SurveBt = New System.Windows.Forms.Button()
        Me.Score = New System.Windows.Forms.Label()
        Me.MyCard0_Label = New System.Windows.Forms.Label()
        Me.MyCard1_Label = New System.Windows.Forms.Label()
        Me.MyCard2_Label = New System.Windows.Forms.Label()
        Me.MyCard3_Label = New System.Windows.Forms.Label()
        Me.MyCard4_Label = New System.Windows.Forms.Label()
        Me.ChangeBt = New System.Windows.Forms.Button()
        Me.CardLabelPanel = New System.Windows.Forms.Panel()
        Me.RankBt = New System.Windows.Forms.Button()
        Me.RankShadowBt = New System.Windows.Forms.Button()
        CType(Me.MyCard0, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MyCard1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MyCard2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MyCard3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MyCard4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.CardLabelPanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'MyCard0
        '
        Me.MyCard0.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.MyCard0.Location = New System.Drawing.Point(140, 180)
        Me.MyCard0.Margin = New System.Windows.Forms.Padding(0)
        Me.MyCard0.Name = "MyCard0"
        Me.MyCard0.Size = New System.Drawing.Size(60, 80)
        Me.MyCard0.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.MyCard0.TabIndex = 0
        Me.MyCard0.TabStop = False
        '
        'MyCard1
        '
        Me.MyCard1.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.MyCard1.Location = New System.Drawing.Point(220, 180)
        Me.MyCard1.Margin = New System.Windows.Forms.Padding(0)
        Me.MyCard1.Name = "MyCard1"
        Me.MyCard1.Size = New System.Drawing.Size(60, 80)
        Me.MyCard1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.MyCard1.TabIndex = 1
        Me.MyCard1.TabStop = False
        '
        'MyCard2
        '
        Me.MyCard2.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.MyCard2.Location = New System.Drawing.Point(300, 180)
        Me.MyCard2.Margin = New System.Windows.Forms.Padding(0)
        Me.MyCard2.Name = "MyCard2"
        Me.MyCard2.Size = New System.Drawing.Size(60, 80)
        Me.MyCard2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.MyCard2.TabIndex = 2
        Me.MyCard2.TabStop = False
        '
        'MyCard3
        '
        Me.MyCard3.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.MyCard3.Location = New System.Drawing.Point(380, 180)
        Me.MyCard3.Margin = New System.Windows.Forms.Padding(0)
        Me.MyCard3.Name = "MyCard3"
        Me.MyCard3.Size = New System.Drawing.Size(60, 80)
        Me.MyCard3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.MyCard3.TabIndex = 3
        Me.MyCard3.TabStop = False
        '
        'MyCard4
        '
        Me.MyCard4.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.MyCard4.Location = New System.Drawing.Point(460, 180)
        Me.MyCard4.Margin = New System.Windows.Forms.Padding(0)
        Me.MyCard4.Name = "MyCard4"
        Me.MyCard4.Size = New System.Drawing.Size(60, 80)
        Me.MyCard4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.MyCard4.TabIndex = 4
        Me.MyCard4.TabStop = False
        '
        'SurveBt
        '
        Me.SurveBt.Location = New System.Drawing.Point(537, 178)
        Me.SurveBt.Margin = New System.Windows.Forms.Padding(5, 3, 5, 3)
        Me.SurveBt.Name = "SurveBt"
        Me.SurveBt.Size = New System.Drawing.Size(67, 36)
        Me.SurveBt.TabIndex = 6
        Me.SurveBt.Text = "Surve"
        Me.SurveBt.UseVisualStyleBackColor = True
        '
        'Score
        '
        Me.Score.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Score.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Score.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Score.ForeColor = System.Drawing.Color.Black
        Me.Score.Location = New System.Drawing.Point(240, 346)
        Me.Score.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Score.Name = "Score"
        Me.Score.Size = New System.Drawing.Size(61, 16)
        Me.Score.TabIndex = 7
        Me.Score.Text = "100000"
        Me.Score.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'MyCard0_Label
        '
        Me.MyCard0_Label.BackColor = System.Drawing.Color.FromArgb(CType(CType(150, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.MyCard0_Label.ForeColor = System.Drawing.Color.White
        Me.MyCard0_Label.Location = New System.Drawing.Point(0, 0)
        Me.MyCard0_Label.Name = "MyCard0_Label"
        Me.MyCard0_Label.Size = New System.Drawing.Size(50, 15)
        Me.MyCard0_Label.TabIndex = 8
        Me.MyCard0_Label.Text = "かえる"
        Me.MyCard0_Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'MyCard1_Label
        '
        Me.MyCard1_Label.BackColor = System.Drawing.Color.FromArgb(CType(CType(150, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.MyCard1_Label.ForeColor = System.Drawing.Color.White
        Me.MyCard1_Label.Location = New System.Drawing.Point(80, 0)
        Me.MyCard1_Label.Name = "MyCard1_Label"
        Me.MyCard1_Label.Size = New System.Drawing.Size(50, 15)
        Me.MyCard1_Label.TabIndex = 9
        Me.MyCard1_Label.Text = "かえる"
        Me.MyCard1_Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'MyCard2_Label
        '
        Me.MyCard2_Label.BackColor = System.Drawing.Color.FromArgb(CType(CType(150, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.MyCard2_Label.ForeColor = System.Drawing.Color.White
        Me.MyCard2_Label.Location = New System.Drawing.Point(160, 0)
        Me.MyCard2_Label.Name = "MyCard2_Label"
        Me.MyCard2_Label.Size = New System.Drawing.Size(50, 15)
        Me.MyCard2_Label.TabIndex = 10
        Me.MyCard2_Label.Text = "かえる"
        Me.MyCard2_Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'MyCard3_Label
        '
        Me.MyCard3_Label.BackColor = System.Drawing.Color.FromArgb(CType(CType(150, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.MyCard3_Label.ForeColor = System.Drawing.Color.White
        Me.MyCard3_Label.Location = New System.Drawing.Point(240, 0)
        Me.MyCard3_Label.Name = "MyCard3_Label"
        Me.MyCard3_Label.Size = New System.Drawing.Size(50, 15)
        Me.MyCard3_Label.TabIndex = 11
        Me.MyCard3_Label.Text = "かえる"
        Me.MyCard3_Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'MyCard4_Label
        '
        Me.MyCard4_Label.BackColor = System.Drawing.Color.FromArgb(CType(CType(150, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.MyCard4_Label.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.MyCard4_Label.ForeColor = System.Drawing.Color.White
        Me.MyCard4_Label.Location = New System.Drawing.Point(320, 0)
        Me.MyCard4_Label.Name = "MyCard4_Label"
        Me.MyCard4_Label.Size = New System.Drawing.Size(50, 15)
        Me.MyCard4_Label.TabIndex = 12
        Me.MyCard4_Label.Text = "かえる"
        Me.MyCard4_Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ChangeBt
        '
        Me.ChangeBt.Location = New System.Drawing.Point(537, 222)
        Me.ChangeBt.Margin = New System.Windows.Forms.Padding(5, 3, 5, 3)
        Me.ChangeBt.Name = "ChangeBt"
        Me.ChangeBt.Size = New System.Drawing.Size(67, 36)
        Me.ChangeBt.TabIndex = 13
        Me.ChangeBt.Text = "Change"
        Me.ChangeBt.UseVisualStyleBackColor = True
        '
        'CardLabelPanel
        '
        Me.CardLabelPanel.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.CardLabelPanel.Controls.Add(Me.MyCard4_Label)
        Me.CardLabelPanel.Controls.Add(Me.MyCard0_Label)
        Me.CardLabelPanel.Controls.Add(Me.MyCard1_Label)
        Me.CardLabelPanel.Controls.Add(Me.MyCard3_Label)
        Me.CardLabelPanel.Controls.Add(Me.MyCard2_Label)
        Me.CardLabelPanel.Location = New System.Drawing.Point(145, 280)
        Me.CardLabelPanel.Name = "CardLabelPanel"
        Me.CardLabelPanel.Size = New System.Drawing.Size(370, 15)
        Me.CardLabelPanel.TabIndex = 14
        Me.CardLabelPanel.Visible = False
        '
        'RankBt
        '
        Me.RankBt.BackColor = System.Drawing.Color.Magenta
        Me.RankBt.Location = New System.Drawing.Point(220, 195)
        Me.RankBt.Name = "RankBt"
        Me.RankBt.Size = New System.Drawing.Size(240, 50)
        Me.RankBt.TabIndex = 15
        Me.RankBt.TabStop = False
        Me.RankBt.UseVisualStyleBackColor = False
        Me.RankBt.Visible = False
        '
        'RankShadowBt
        '
        Me.RankShadowBt.BackColor = System.Drawing.Color.Black
        Me.RankShadowBt.Location = New System.Drawing.Point(225, 200)
        Me.RankShadowBt.Name = "RankShadowBt"
        Me.RankShadowBt.Size = New System.Drawing.Size(240, 50)
        Me.RankShadowBt.TabIndex = 16
        Me.RankShadowBt.TabStop = False
        Me.RankShadowBt.UseVisualStyleBackColor = False
        Me.RankShadowBt.Visible = False
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.BackgroundImage = Global.Poker.My.Resources.Resources.Back
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.ClientSize = New System.Drawing.Size(656, 410)
        Me.Controls.Add(Me.Score)
        Me.Controls.Add(Me.RankBt)
        Me.Controls.Add(Me.RankShadowBt)
        Me.Controls.Add(Me.CardLabelPanel)
        Me.Controls.Add(Me.ChangeBt)
        Me.Controls.Add(Me.MyCard4)
        Me.Controls.Add(Me.MyCard3)
        Me.Controls.Add(Me.MyCard2)
        Me.Controls.Add(Me.MyCard1)
        Me.Controls.Add(Me.MyCard0)
        Me.Controls.Add(Me.SurveBt)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.Margin = New System.Windows.Forms.Padding(5, 3, 5, 3)
        Me.Name = "Form1"
        Me.Text = "Form1"
        CType(Me.MyCard0, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MyCard1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MyCard2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MyCard3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MyCard4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.CardLabelPanel.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents MyCard0 As PictureBox
    Friend WithEvents MyCard1 As PictureBox
    Friend WithEvents MyCard2 As PictureBox
    Friend WithEvents MyCard3 As PictureBox
    Friend WithEvents MyCard4 As PictureBox
    Friend WithEvents SurveBt As Button
    Friend WithEvents Score As Label
    Friend WithEvents MyCard0_Label As Label
    Friend WithEvents MyCard1_Label As Label
    Friend WithEvents MyCard2_Label As Label
    Friend WithEvents MyCard3_Label As Label
    Friend WithEvents MyCard4_Label As Label
    Friend WithEvents ChangeBt As Button
    Friend WithEvents CardLabelPanel As Panel
    Friend WithEvents RankBt As Button
    Friend WithEvents RankShadowBt As Button
End Class
