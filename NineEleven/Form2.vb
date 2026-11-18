Imports MySql.Data.MySqlClient

''' <summary>Form2 = Items Manager (CRUD tabel tbl_barang).</summary>
Public Class Form2

    Private _modeTambah As Boolean = False

#Region "Load & Setup"

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "Items Manager"
        Me.StartPosition = FormStartPosition.CenterScreen
        DataGridView1.ReadOnly = True
        DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        DataGridView1.AllowUserToAddRows = False
        DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        TampilData()
        ResetForm()
    End Sub

    ''' <summary>Menampilkan seluruh data tbl_barang ke DataGridView1.</summary>
    Private Sub TampilData()
        Try
            Using conn As MySqlConnection = KoneksiDB.BukaKoneksi()
                conn.Open()
                Dim sql As String =
                    "SELECT idbrg AS 'ID', nmbrg AS 'Nama Barang', hrgbrg AS 'Harga Beli', " &
                    "hrgjual AS 'Harga Jual', stokbrg AS 'Stok' FROM tbl_barang ORDER BY idbrg"
                Using da As New MySqlDataAdapter(sql, conn)
                    Dim dt As New DataTable()
                    da.Fill(dt)
                    DataGridView1.DataSource = dt
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Gagal menampilkan data: " & ex.Message, "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ''' <summary>Membuat ID barang berikutnya (MAX + 1).</summary>
    Private Function BuatIdBaru() As Integer
        Using conn As MySqlConnection = KoneksiDB.BukaKoneksi()
            conn.Open()
            Using cmd As New MySqlCommand("SELECT IFNULL(MAX(idbrg), 0) + 1 FROM tbl_barang", conn)
                Return Convert.ToInt32(cmd.ExecuteScalar())
            End Using
        End Using
    End Function

#End Region

#Region "Pengaturan Tampilan"

    Private Sub ResetForm()
        _modeTambah = False
        txtIdBrg.Clear() : txtNmBrg.Clear()
        txtHrgBeli.Clear() : txtHrgJual.Clear() : txtStok.Clear()
        AturKontrol(inputAktif:=False, bisaSimpan:=False, bisaUbah:=False)
        DataGridView1.ClearSelection()
    End Sub

    Private Sub AturKontrol(inputAktif As Boolean, bisaSimpan As Boolean, bisaUbah As Boolean)
        txtIdBrg.ReadOnly = True ' ID dibuat otomatis
        txtNmBrg.Enabled = inputAktif
        txtHrgBeli.Enabled = inputAktif
        txtHrgJual.Enabled = inputAktif
        txtStok.Enabled = inputAktif
        BTN_Simpan.Enabled = bisaSimpan
        BTN_Update.Enabled = bisaUbah
        BTN_Hapus.Enabled = bisaUbah
        BTN_Batal.Enabled = inputAktif
        BTN_Tambah.Enabled = Not inputAktif OrElse bisaUbah
    End Sub

    ''' <summary>Validasi input; mengembalikan True jika semua valid.</summary>
    Private Function InputValid() As Boolean
        If String.IsNullOrWhiteSpace(txtNmBrg.Text) Then
            MessageBox.Show("Nama barang wajib diisi.", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtNmBrg.Focus() : Return False
        End If
        Dim angka As Integer
        If Not Integer.TryParse(txtHrgBeli.Text, angka) OrElse angka < 0 Then
            MessageBox.Show("Harga beli harus berupa angka >= 0.", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtHrgBeli.Focus() : Return False
        End If
        If Not Integer.TryParse(txtHrgJual.Text, angka) OrElse angka < 0 Then
            MessageBox.Show("Harga jual harus berupa angka >= 0.", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtHrgJual.Focus() : Return False
        End If
        If Not Integer.TryParse(txtStok.Text, angka) OrElse angka < 0 Then
            MessageBox.Show("Stok harus berupa angka >= 0.", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtStok.Focus() : Return False
        End If
        Return True
    End Function

#End Region

#Region "Event Tombol"

    ' TAMBAH ITEM: siapkan form kosong dengan ID baru
    Private Sub BTN_Tambah_Click(sender As Object, e As EventArgs) Handles BTN_Tambah.Click
        Try
            txtNmBrg.Clear() : txtHrgBeli.Clear() : txtHrgJual.Clear() : txtStok.Clear()
            _modeTambah = True
            txtIdBrg.Text = BuatIdBaru().ToString()
            AturKontrol(inputAktif:=True, bisaSimpan:=True, bisaUbah:=False)
            txtNmBrg.Focus()
        Catch ex As Exception
            MessageBox.Show("Gagal menyiapkan data baru: " & ex.Message, "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
#End Region
    End Sub

    ' SIMPAN: INSERT barang baru
    Private Sub BTN_Simpan_Click(sender As Object, e As EventArgs) Handles BTN_Simpan.Click
        If Not _modeTambah Then Return
        If Not InputValid() Then Return
        Try
            Using conn As MySqlConnection = KoneksiDB.BukaKoneksi()
                conn.Open()
                Dim sql As String =
                    "INSERT INTO tbl_barang (idbrg, nmbrg, hrgbrg, hrgjual, stokbrg) " &
                    "VALUES (@id, @nm, @beli, @jual, @stok)"
                Using cmd As New MySqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@id", Integer.Parse(txtIdBrg.Text))
                    cmd.Parameters.AddWithValue("@nm", txtNmBrg.Text.Trim())
                    cmd.Parameters.AddWithValue("@beli", Integer.Parse(txtHrgBeli.Text))
                    cmd.Parameters.AddWithValue("@jual", Integer.Parse(txtHrgJual.Text))
                    cmd.Parameters.AddWithValue("@stok", Integer.Parse(txtStok.Text))
                    cmd.ExecuteNonQuery()
                End Using
            End Using
            MessageBox.Show("Barang berhasil ditambahkan.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information)
            TampilData()
            ResetForm()
        Catch ex As MySqlException
            MessageBox.Show("Kesalahan database: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show("Gagal menyimpan: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' UPDATE: ubah data berdasarkan idbrg
    Private Sub BTN_Update_Click(sender As Object, e As EventArgs) Handles BTN_Update.Click
        If String.IsNullOrWhiteSpace(txtIdBrg.Text) OrElse _modeTambah Then
            MessageBox.Show("Pilih barang dari tabel terlebih dahulu.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If
        If Not InputValid() Then Return
        Try
            Using conn As MySqlConnection = KoneksiDB.BukaKoneksi()
                conn.Open()
                Dim sql As String =
                    "UPDATE tbl_barang SET nmbrg=@nm, hrgbrg=@beli, hrgjual=@jual, stokbrg=@stok " &
                    "WHERE idbrg=@id"
                Using cmd As New MySqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@nm", txtNmBrg.Text.Trim())
                    cmd.Parameters.AddWithValue("@beli", Integer.Parse(txtHrgBeli.Text))
                    cmd.Parameters.AddWithValue("@jual", Integer.Parse(txtHrgJual.Text))
                    cmd.Parameters.AddWithValue("@stok", Integer.Parse(txtStok.Text))
                    cmd.Parameters.AddWithValue("@id", Integer.Parse(txtIdBrg.Text))
                    If cmd.ExecuteNonQuery() = 0 Then
                        MessageBox.Show("Data tidak ditemukan.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Return
                    End If
                End Using
            End Using
            MessageBox.Show("Barang berhasil diperbarui.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information)
            TampilData()
            ResetForm()
        Catch ex As Exception
            MessageBox.Show("Gagal memperbarui: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' HAPUS: hapus barang terpilih
    Private Sub BTN_Hapus_Click(sender As Object, e As EventArgs) Handles BTN_Hapus.Click
        If String.IsNullOrWhiteSpace(txtIdBrg.Text) OrElse _modeTambah Then
            MessageBox.Show("Pilih barang dari tabel terlebih dahulu.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If
        If MessageBox.Show("Hapus barang '" & txtNmBrg.Text & "'?", "Konfirmasi",
                           MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then Return
        Try
            Using conn As MySqlConnection = KoneksiDB.BukaKoneksi()
                conn.Open()
                Using cmd As New MySqlCommand("DELETE FROM tbl_barang WHERE idbrg=@id", conn)
                    cmd.Parameters.AddWithValue("@id", Integer.Parse(txtIdBrg.Text))
                    cmd.ExecuteNonQuery()
                End Using
            End Using
            MessageBox.Show("Barang berhasil dihapus.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information)
            TampilData()
            ResetForm()
        Catch ex As Exception
            MessageBox.Show("Gagal menghapus: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' BATAL: kosongkan input
    Private Sub BTN_Batal_Click(sender As Object, e As EventArgs) Handles BTN_Batal.Click
        ResetForm()
    End Sub

    ' KEMBALI: tutup form, Form3 otomatis tampil lagi (lihat Form3)
    Private Sub BTN_Kembali_Click(sender As Object, e As EventArgs) Handles BTN_Kembali.Click
        Me.Close()
    End Sub

    ' Klik baris grid -> isi TextBox, siap Update/Hapus
    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If e.RowIndex < 0 Then Return
        Try
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            txtIdBrg.Text = Convert.ToString(row.Cells(0).Value)
            txtNmBrg.Text = Convert.ToString(row.Cells(1).Value)
            txtHrgBeli.Text = Convert.ToString(row.Cells(2).Value)
            txtHrgJual.Text = Convert.ToString(row.Cells(3).Value)
            txtStok.Text = Convert.ToString(row.Cells(4).Value)
            _modeTambah = False
            AturKontrol(inputAktif:=True, bisaSimpan:=False, bisaUbah:=True)
        Catch ex As Exception
            MessageBox.Show("Gagal membaca baris: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

End Class