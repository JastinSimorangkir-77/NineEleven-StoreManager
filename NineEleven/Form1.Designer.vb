<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
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
        txtIdJual = New TextBox()
        txtTanggal = New TextBox()
        Label1 = New Label()
        Label4 = New Label()
        BTN_TambahTransaksi = New Button()
        Label5 = New Label()
        Label6 = New Label()
        txtJmlTotal = New TextBox()
        txtJmlItem = New TextBox()
        BTN_Update = New Button()
        BTN_Simpan = New Button()
        BTN_Hapus = New Button()
        BTN_Kembali = New Button()
        BTN_Batal = New Button()
        CType(DataGridView1, ComponentModel.ISupportInitialize).BeginInit()
        Panel1.SuspendLayout()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' DataGridView1
        ' 
        DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridView1.Location = New Point(15, 268)
        DataGridView1.Margin = New Padding(4)
        DataGridView1.Name = "DataGridView1"
        DataGridView1.RowHeadersWidth = 51
        DataGridView1.Size = New Size(970, 464)
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
        Label3.Font = New Font("Bahnschrift", 18F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label3.ForeColor = SystemColors.Control
        Label3.Location = New Point(185, 110)
        Label3.Margin = New Padding(4, 0, 4, 0)
        Label3.Name = "Label3"
        Label3.Size = New Size(425, 43)
        Label3.TabIndex = 2
        Label3.Text = "TRANSACTION MANAGER"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Bahnschrift", 36F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
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
        ' txtIdJual
        ' 
        txtIdJual.Location = New Point(136, 180)
        txtIdJual.Margin = New Padding(4)
        txtIdJual.Name = "txtIdJual"
        txtIdJual.Size = New Size(249, 31)
        txtIdJual.TabIndex = 2
        ' 
        ' txtTanggal
        ' 
        txtTanggal.Location = New Point(136, 221)
        txtTanggal.Margin = New Padding(4)
        txtTanggal.Name = "txtTanggal"
        txtTanggal.Size = New Size(249, 31)
        txtTanggal.TabIndex = 3
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Bahnschrift", 9F, FontStyle.Bold)
        Label1.Location = New Point(15, 184)
        Label1.Margin = New Padding(4, 0, 4, 0)
        Label1.Name = "Label1"
        Label1.Size = New Size(112, 22)
        Label1.TabIndex = 4
        Label1.Text = "ID Penjualan"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Bahnschrift", 9F, FontStyle.Bold)
        Label4.Location = New Point(15, 226)
        Label4.Margin = New Padding(4, 0, 4, 0)
        Label4.Name = "Label4"
        Label4.Size = New Size(73, 22)
        Label4.TabIndex = 5
        Label4.Text = "Tanggal"
        ' 
        ' BTN_TambahTransaksi
        ' 
        BTN_TambahTransaksi.Font = New Font("Bahnschrift", 18F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        BTN_TambahTransaksi.Location = New Point(610, 174)
        BTN_TambahTransaksi.Margin = New Padding(4)
        BTN_TambahTransaksi.Name = "BTN_TambahTransaksi"
        BTN_TambahTransaksi.Size = New Size(375, 81)
        BTN_TambahTransaksi.TabIndex = 6
        BTN_TambahTransaksi.Text = "Tambah Transaksi"
        BTN_TambahTransaksi.UseVisualStyleBackColor = True
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Font = New Font("Bahnschrift", 9F, FontStyle.Bold)
        Label5.Location = New Point(15, 794)
        Label5.Margin = New Padding(4, 0, 4, 0)
        Label5.Name = "Label5"
        Label5.Size = New Size(113, 22)
        Label5.TabIndex = 10
        Label5.Text = "Jumlah Total"
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Font = New Font("Bahnschrift", 9F, FontStyle.Bold)
        Label6.Location = New Point(15, 755)
        Label6.Margin = New Padding(4, 0, 4, 0)
        Label6.Name = "Label6"
        Label6.Size = New Size(175, 22)
        Label6.TabIndex = 9
        Label6.Text = "Jumlah Item Barang"
        ' 
        ' txtJmlTotal
        ' 
        txtJmlTotal.Location = New Point(201, 789)
        txtJmlTotal.Margin = New Padding(4)
        txtJmlTotal.Name = "txtJmlTotal"
        txtJmlTotal.Size = New Size(249, 31)
        txtJmlTotal.TabIndex = 8
        ' 
        ' txtJmlItem
        ' 
        txtJmlItem.Location = New Point(201, 748)
        txtJmlItem.Margin = New Padding(4)
        txtJmlItem.Name = "txtJmlItem"
        txtJmlItem.Size = New Size(249, 31)
        txtJmlItem.TabIndex = 7
        ' 
        ' BTN_Update
        ' 
        BTN_Update.Font = New Font("Bahnschrift", 9F, FontStyle.Bold)
        BTN_Update.Location = New Point(582, 745)
        BTN_Update.Margin = New Padding(4)
        BTN_Update.Name = "BTN_Update"
        BTN_Update.Size = New Size(198, 55)
        BTN_Update.TabIndex = 11
        BTN_Update.Text = "UPDATE"
        BTN_Update.UseVisualStyleBackColor = True
        ' 
        ' BTN_Simpan
        ' 
        BTN_Simpan.Font = New Font("Bahnschrift", 24F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        BTN_Simpan.Location = New Point(582, 804)
        BTN_Simpan.Margin = New Padding(4)
        BTN_Simpan.Name = "BTN_Simpan"
        BTN_Simpan.Size = New Size(402, 88)
        BTN_Simpan.TabIndex = 13
        BTN_Simpan.Text = "SIMPAN"
        BTN_Simpan.UseVisualStyleBackColor = True
        ' 
        ' BTN_Hapus
        ' 
        BTN_Hapus.Font = New Font("Bahnschrift", 9F, FontStyle.Bold)
        BTN_Hapus.Location = New Point(788, 745)
        BTN_Hapus.Margin = New Padding(4)
        BTN_Hapus.Name = "BTN_Hapus"
        BTN_Hapus.Size = New Size(198, 55)
        BTN_Hapus.TabIndex = 14
        BTN_Hapus.Text = "HAPUS"
        BTN_Hapus.UseVisualStyleBackColor = True
        ' 
        ' BTN_Kembali
        ' 
        BTN_Kembali.Font = New Font("Bahnschrift", 9F, FontStyle.Bold)
        BTN_Kembali.Location = New Point(15, 836)
        BTN_Kembali.Margin = New Padding(4)
        BTN_Kembali.Name = "BTN_Kembali"
        BTN_Kembali.Size = New Size(216, 55)
        BTN_Kembali.TabIndex = 15
        BTN_Kembali.Text = "KEMBALI"
        BTN_Kembali.UseVisualStyleBackColor = True
        ' 
        ' BTN_Batal
        ' 
        BTN_Batal.Font = New Font("Bahnschrift", 9F, FontStyle.Bold)
        BTN_Batal.Location = New Point(235, 836)
        BTN_Batal.Margin = New Padding(4)
        BTN_Batal.Name = "BTN_Batal"
        BTN_Batal.Size = New Size(216, 55)
        BTN_Batal.TabIndex = 16
        BTN_Batal.Text = "BATAL"
        BTN_Batal.UseVisualStyleBackColor = True
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(10F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = SystemColors.ControlLight
        ClientSize = New Size(1000, 904)
        Controls.Add(BTN_Batal)
        Controls.Add(BTN_Kembali)
        Controls.Add(BTN_Hapus)
        Controls.Add(BTN_Simpan)
        Controls.Add(BTN_Update)
        Controls.Add(Label5)
        Controls.Add(Label6)
        Controls.Add(txtJmlTotal)
        Controls.Add(txtJmlItem)
        Controls.Add(BTN_TambahTransaksi)
        Controls.Add(Label4)
        Controls.Add(Label1)
        Controls.Add(txtTanggal)
        Controls.Add(txtIdJual)
        Controls.Add(Panel1)
        Controls.Add(DataGridView1)
        Margin = New Padding(4)
        Name = "Form1"
        Text = "Form1"
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
    Friend WithEvents txtIdJual As TextBox
    Friend WithEvents txtTanggal As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents BTN_TambahTransaksi As Button
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents txtJmlTotal As TextBox
    Friend WithEvents txtJmlItem As TextBox
    Friend WithEvents BTN_Update As Button
    Friend WithEvents BTN_Simpan As Button
    Friend WithEvents BTN_Hapus As Button
    Friend WithEvents BTN_Kembali As Button
    Friend WithEvents BTN_Batal As Button

End Class
