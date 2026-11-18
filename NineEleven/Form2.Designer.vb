<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form2
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
        DataGridView1 = New DataGridView()
        Panel1 = New Panel()
        Label3 = New Label()
        Label2 = New Label()
        PictureBox1 = New PictureBox()
        txtIdBrg = New TextBox()
        txtNmBrg = New TextBox()
        Label1 = New Label()
        Label4 = New Label()
        BTN_Tambah = New Button()
        BTN_Update = New Button()
        BTN_Kembali = New Button()
        Label7 = New Label()
        Label8 = New Label()
        txtHrgJual = New TextBox()
        txtHrgBeli = New TextBox()
        BTN_Batal = New Button()
        BTN_Hapus = New Button()
        BTN_Simpan = New Button()
        Label5 = New Label()
        txtStok = New TextBox()
        CType(DataGridView1, ComponentModel.ISupportInitialize).BeginInit()
        Panel1.SuspendLayout()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' DataGridView1
        ' 
        DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridView1.Location = New Point(439, 175)
        DataGridView1.Margin = New Padding(4)
        DataGridView1.Name = "DataGridView1"
        DataGridView1.RowHeadersWidth = 51
        DataGridView1.Size = New Size(546, 506)
        DataGridView1.TabIndex = 0
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
        Label3.Size = New Size(296, 43)
        Label3.TabIndex = 2
        Label3.Text = "ITEMS MANAGER"
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
        ' txtIdBrg
        ' 
        txtIdBrg.Location = New Point(144, 178)
        txtIdBrg.Margin = New Padding(4)
        txtIdBrg.Name = "txtIdBrg"
        txtIdBrg.Size = New Size(273, 31)
        txtIdBrg.TabIndex = 2
        ' 
        ' txtNmBrg
        ' 
        txtNmBrg.Location = New Point(144, 219)
        txtNmBrg.Margin = New Padding(4)
        txtNmBrg.Name = "txtNmBrg"
        txtNmBrg.Size = New Size(273, 31)
        txtNmBrg.TabIndex = 3
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Bahnschrift", 9.0F, FontStyle.Bold)
        Label1.Location = New Point(15, 184)
        Label1.Margin = New Padding(4, 0, 4, 0)
        Label1.Name = "Label1"
        Label1.Size = New Size(92, 22)
        Label1.TabIndex = 4
        Label1.Text = "ID Barang"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Bahnschrift", 9.0F, FontStyle.Bold)
        Label4.Location = New Point(15, 226)
        Label4.Margin = New Padding(4, 0, 4, 0)
        Label4.Name = "Label4"
        Label4.Size = New Size(123, 22)
        Label4.TabIndex = 5
        Label4.Text = "Nama Barang"
        ' 
        ' BTN_Tambah
        ' 
        BTN_Tambah.Font = New Font("Bahnschrift", 18.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        BTN_Tambah.Location = New Point(15, 391)
        BTN_Tambah.Margin = New Padding(4)
        BTN_Tambah.Name = "BTN_Tambah"
        BTN_Tambah.Size = New Size(402, 81)
        BTN_Tambah.TabIndex = 6
        BTN_Tambah.Text = "TAMBAH ITEM"
        BTN_Tambah.UseVisualStyleBackColor = True
        ' 
        ' BTN_Update
        ' 
        BTN_Update.Font = New Font("Bahnschrift", 9.0F, FontStyle.Bold)
        BTN_Update.Location = New Point(15, 480)
        BTN_Update.Margin = New Padding(4)
        BTN_Update.Name = "BTN_Update"
        BTN_Update.Size = New Size(198, 55)
        BTN_Update.TabIndex = 11
        BTN_Update.Text = "UPDATE"
        BTN_Update.UseVisualStyleBackColor = True
        ' 
        ' BTN_Kembali
        ' 
        BTN_Kembali.Font = New Font("Bahnschrift", 9.0F, FontStyle.Bold)
        BTN_Kembali.Location = New Point(15, 542)
        BTN_Kembali.Margin = New Padding(4)
        BTN_Kembali.Name = "BTN_Kembali"
        BTN_Kembali.Size = New Size(198, 55)
        BTN_Kembali.TabIndex = 14
        BTN_Kembali.Text = "KEMBALI"
        BTN_Kembali.UseVisualStyleBackColor = True
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.Font = New Font("Bahnschrift", 9.0F, FontStyle.Bold)
        Label7.Location = New Point(15, 314)
        Label7.Margin = New Padding(4, 0, 4, 0)
        Label7.Name = "Label7"
        Label7.Size = New Size(99, 22)
        Label7.TabIndex = 18
        Label7.Text = "Harga Jual"
        ' 
        ' Label8
        ' 
        Label8.AutoSize = True
        Label8.Font = New Font("Bahnschrift", 9.0F, FontStyle.Bold)
        Label8.Location = New Point(15, 271)
        Label8.Margin = New Padding(4, 0, 4, 0)
        Label8.Name = "Label8"
        Label8.Size = New Size(97, 22)
        Label8.TabIndex = 17
        Label8.Text = "Harga Beli"
        ' 
        ' txtHrgJual
        ' 
        txtHrgJual.Location = New Point(144, 306)
        txtHrgJual.Margin = New Padding(4)
        txtHrgJual.Name = "txtHrgJual"
        txtHrgJual.Size = New Size(273, 31)
        txtHrgJual.TabIndex = 16
        ' 
        ' txtHrgBeli
        ' 
        txtHrgBeli.Location = New Point(144, 265)
        txtHrgBeli.Margin = New Padding(4)
        txtHrgBeli.Name = "txtHrgBeli"
        txtHrgBeli.Size = New Size(273, 31)
        txtHrgBeli.TabIndex = 15
        ' 
        ' BTN_Batal
        ' 
        BTN_Batal.Font = New Font("Bahnschrift", 9.0F, FontStyle.Bold)
        BTN_Batal.Location = New Point(220, 542)
        BTN_Batal.Margin = New Padding(4)
        BTN_Batal.Name = "BTN_Batal"
        BTN_Batal.Size = New Size(198, 55)
        BTN_Batal.TabIndex = 20
        BTN_Batal.Text = "BATAL"
        BTN_Batal.UseVisualStyleBackColor = True
        ' 
        ' BTN_Hapus
        ' 
        BTN_Hapus.Font = New Font("Bahnschrift", 9.0F, FontStyle.Bold)
        BTN_Hapus.Location = New Point(220, 480)
        BTN_Hapus.Margin = New Padding(4)
        BTN_Hapus.Name = "BTN_Hapus"
        BTN_Hapus.Size = New Size(198, 55)
        BTN_Hapus.TabIndex = 19
        BTN_Hapus.Text = "HAPUS"
        BTN_Hapus.UseVisualStyleBackColor = True
        ' 
        ' BTN_Simpan
        ' 
        BTN_Simpan.Font = New Font("Bahnschrift", 18.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        BTN_Simpan.Location = New Point(15, 605)
        BTN_Simpan.Margin = New Padding(4)
        BTN_Simpan.Name = "BTN_Simpan"
        BTN_Simpan.Size = New Size(402, 81)
        BTN_Simpan.TabIndex = 21
        BTN_Simpan.Text = "SIMPAN"
        BTN_Simpan.UseVisualStyleBackColor = True
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Font = New Font("Bahnschrift", 9.0F, FontStyle.Bold)
        Label5.Location = New Point(15, 355)
        Label5.Margin = New Padding(4, 0, 4, 0)
        Label5.Name = "Label5"
        Label5.Size = New Size(47, 22)
        Label5.TabIndex = 23
        Label5.Text = "Stok"
        ' 
        ' txtStok
        ' 
        txtStok.Location = New Point(144, 348)
        txtStok.Margin = New Padding(4)
        txtStok.Name = "txtStok"
        txtStok.Size = New Size(273, 31)
        txtStok.TabIndex = 22
        ' 
        ' Form2
        ' 
        AutoScaleDimensions = New SizeF(10.0F, 25.0F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1000, 696)
        Controls.Add(Label5)
        Controls.Add(txtStok)
        Controls.Add(BTN_Simpan)
        Controls.Add(BTN_Batal)
        Controls.Add(BTN_Hapus)
        Controls.Add(Label7)
        Controls.Add(Label8)
        Controls.Add(txtHrgJual)
        Controls.Add(txtHrgBeli)
        Controls.Add(BTN_Kembali)
        Controls.Add(BTN_Update)
        Controls.Add(BTN_Tambah)
        Controls.Add(Label4)
        Controls.Add(Label1)
        Controls.Add(txtNmBrg)
        Controls.Add(txtIdBrg)
        Controls.Add(Panel1)
        Controls.Add(DataGridView1)
        Margin = New Padding(4)
        Name = "Form2"
        Text = "Form2"
        CType(DataGridView1, ComponentModel.ISupportInitialize).EndInit()
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents Panel1 As Panel
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents txtIdBrg As TextBox
    Friend WithEvents txtNmBrg As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents BTN_Tambah As Button
    Friend WithEvents BTN_Update As Button
    Friend WithEvents BTN_Kembali As Button
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents txtHrgJual As TextBox
    Friend WithEvents txtHrgBeli As TextBox
    Friend WithEvents BTN_Batal As Button
    Friend WithEvents BTN_Hapus As Button
    Friend WithEvents BTN_Simpan As Button
    Friend WithEvents Label5 As Label
    Friend WithEvents txtStok As TextBox

End Class
