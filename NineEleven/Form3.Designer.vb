<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form3
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Panel1 = New Panel()
        Label3 = New Label()
        Label2 = New Label()
        PictureBox1 = New PictureBox()
        BTN_TransaksiBaru = New Button()
        BTN_BarangBaru = New Button()
        Label6 = New Label()
        PictureBox2 = New PictureBox()
        BTN_Keluar = New Button()
        Panel1.SuspendLayout()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox2, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Panel1
        ' 
        Panel1.BackColor = Color.Green
        Panel1.Controls.Add(Label3)
        Panel1.Controls.Add(Label2)
        Panel1.Controls.Add(PictureBox1)
        Panel1.Location = New Point(-9, -9)
        Panel1.Margin = New Padding(4)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(1014, 169)
        Panel1.TabIndex = 1
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Bahnschrift", 18.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label3.ForeColor = SystemColors.Control
        Label3.Location = New Point(185, 110)
        Label3.Margin = New Padding(4, 0, 4, 0)
        Label3.Name = "Label3"
        Label3.Size = New Size(203, 43)
        Label3.TabIndex = 2
        Label3.Text = "HOMEPAGE"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Bahnschrift", 36.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label2.ForeColor = SystemColors.Control
        Label2.Location = New Point(174, 20)
        Label2.Margin = New Padding(4, 0, 4, 0)
        Label2.Name = "Label2"
        Label2.Size = New Size(731, 87)
        Label2.TabIndex = 1
        Label2.Text = "9/11 STORE MANAGER"
        ' 
        ' PictureBox1
        ' 
        PictureBox1.BackgroundImage = My.Resources.Resources.logo
        PictureBox1.BackgroundImageLayout = ImageLayout.Stretch
        PictureBox1.Location = New Point(10, 10)
        PictureBox1.Margin = New Padding(4)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(156, 156)
        PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
        PictureBox1.TabIndex = 0
        PictureBox1.TabStop = False
        ' 
        ' BTN_TransaksiBaru
        ' 
        BTN_TransaksiBaru.Font = New Font("Bahnschrift", 18.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        BTN_TransaksiBaru.Location = New Point(15, 168)
        BTN_TransaksiBaru.Margin = New Padding(4)
        BTN_TransaksiBaru.Name = "BTN_TransaksiBaru"
        BTN_TransaksiBaru.Size = New Size(481, 81)
        BTN_TransaksiBaru.TabIndex = 6
        BTN_TransaksiBaru.Text = "Transaksi Baru"
        BTN_TransaksiBaru.UseVisualStyleBackColor = True
        ' 
        ' BTN_BarangBaru
        ' 
        BTN_BarangBaru.Font = New Font("Bahnschrift", 18.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        BTN_BarangBaru.Location = New Point(15, 256)
        BTN_BarangBaru.Margin = New Padding(4)
        BTN_BarangBaru.Name = "BTN_BarangBaru"
        BTN_BarangBaru.Size = New Size(481, 81)
        BTN_BarangBaru.TabIndex = 7
        BTN_BarangBaru.Text = "Barang Baru"
        BTN_BarangBaru.UseVisualStyleBackColor = True
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Font = New Font("Bahnschrift", 9.0F, FontStyle.Bold)
        Label6.Location = New Point(15, 508)
        Label6.Margin = New Padding(4, 0, 4, 0)
        Label6.Name = "Label6"
        Label6.Size = New Size(218, 22)
        Label6.TabIndex = 10
        Label6.Text = "Aplikasi Manajemen Toko"
        ' 
        ' PictureBox2
        ' 
        PictureBox2.BackgroundImage = My.Resources.Resources._7_Eleven_Oita_Matsubaramachi_Store
        PictureBox2.BackgroundImageLayout = ImageLayout.Stretch
        PictureBox2.Location = New Point(504, 168)
        PictureBox2.Margin = New Padding(4)
        PictureBox2.Name = "PictureBox2"
        PictureBox2.Size = New Size(481, 362)
        PictureBox2.TabIndex = 11
        PictureBox2.TabStop = False
        ' 
        ' BTN_Keluar
        ' 
        BTN_Keluar.Font = New Font("Bahnschrift", 18.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        BTN_Keluar.Location = New Point(15, 345)
        BTN_Keluar.Margin = New Padding(4)
        BTN_Keluar.Name = "BTN_Keluar"
        BTN_Keluar.Size = New Size(481, 81)
        BTN_Keluar.TabIndex = 12
        BTN_Keluar.Text = "Keluar"
        BTN_Keluar.UseVisualStyleBackColor = True
        ' 
        ' Form3
        ' 
        AutoScaleDimensions = New SizeF(10.0F, 25.0F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1000, 541)
        Controls.Add(BTN_Keluar)
        Controls.Add(PictureBox2)
        Controls.Add(Label6)
        Controls.Add(BTN_BarangBaru)
        Controls.Add(BTN_TransaksiBaru)
        Controls.Add(Panel1)
        Margin = New Padding(4)
        Name = "Form3"
        Text = "Form3"
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox2, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub
    Friend WithEvents Panel1 As Panel
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents BTN_TransaksiBaru As Button
    Friend WithEvents BTN_BarangBaru As Button
    Friend WithEvents Label6 As Label
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents BTN_Keluar As Button

End Class
