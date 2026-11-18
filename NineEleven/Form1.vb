Imports MySql.Data.MySqlClient

''' <summary>
''' Form1 = Transaction Manager (tbl_penjualan + detail_penjualan).
''' Cara pakai grid: isi kolom "idbrg" dan "jumlah" pada baris baru.
''' Kolom nama, harga, dan total terisi otomatis dari tbl_barang.
''' </summary>
Public Class Form1

    ' Jika kolom tgljual di database bertipe INT (yyyyMMdd), ubah menjadi True
    Private Const TanggalSebagaiInt As Boolean = False

    Private _idDimuat As Integer = 0   ' ID transaksi lama yang sedang diedit (0 = transaksi baru)

    Private Class ItemJual
        Public IdBrg As Integer
        Public Jumlah As Integer
    End Class

#Region "Load & Setup"

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "Transaction Manager"
        Me.StartPosition = FormStartPosition.CenterScreen
        SiapkanGrid()
        txtJmlItem.ReadOnly = True
        txtJmlTotal.ReadOnly = True
        ResetForm()
    End Sub

    Private Sub SiapkanGrid()
        With DataGridView1
            .Columns.Clear()
            .AllowUserToAddRows = True
            .AllowUserToDeleteRows = True
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            .Columns.Add("idbrg", "ID Barang")
            .Columns.Add("nmbrg", "Nama Barang")
            .Columns.Add("harga", "Harga")
            .Columns.Add("jumlah", "Jumlah")
            .Columns.Add("total", "Total")
            .Columns("nmbrg").ReadOnly = True
            .Columns("harga").ReadOnly = True
            .Columns("total").ReadOnly = True
        End With
    End Sub

    Private Sub ResetForm()
        _idDimuat = 0
        txtIdJual.Clear()
        txtTanggal.Clear()
        txtJmlItem.Text = "0"
        txtJmlTotal.Text = "0"
        DataGridView1.Rows.Clear()
        AturKontrol(aktif:=False, transaksiLama:=False)
    End Sub

    Private Sub AturKontrol(aktif As Boolean, transaksiLama As Boolean)
        txtIdJual.ReadOnly = aktif AndAlso Not transaksiLama ' ID baru dibuat otomatis
        txtTanggal.Enabled = aktif
        DataGridView1.Enabled = aktif
        BTN_Simpan.Enabled = aktif AndAlso Not transaksiLama
        BTN_Update.Enabled = transaksiLama
        BTN_Hapus.Enabled = transaksiLama
        BTN_Batal.Enabled = aktif
        BTN_TambahTransaksi.Enabled = Not aktif
    End Sub

#End Region

#Region "Helper"

    Private Function BuatIdBaru() As Integer
        Using conn As MySqlConnection = KoneksiDB.BukaKoneksi()
            conn.Open()
            Using cmd As New MySqlCommand("SELECT IFNULL(MAX(idjual), 0) + 1 FROM tbl_penjualan", conn)
                Return Convert.ToInt32(cmd.ExecuteScalar())
            End Using
        End Using
    End Function

    ''' <summary>Mengubah teks tanggal TextBox menjadi nilai parameter SQL.</summary>
    Private Function NilaiTanggal() As Object
        Dim tgl As Date
        If Not Date.TryParse(txtTanggal.Text, tgl) Then
            Throw New FormatException("Format tanggal tidak valid. Contoh: 2026-11-18")
        End If
        If TanggalSebagaiInt Then Return Integer.Parse(tgl.ToString("yyyyMMdd"))
        Return tgl.ToString("yyyy-MM-dd")
    End Function

    ''' <summary>Hitung otomatis jumlah item dan total harga dari grid.</summary>
    Private Sub HitungTotal()
        Dim jmlItem As Integer = 0
        Dim jmlTotal As Long = 0
        For Each row As DataGridViewRow In DataGridView1.Rows
            If row.IsNewRow Then Continue For
            Dim jml, tot As Integer
            If Integer.TryParse(Convert.ToString(row.Cells("jumlah").Value), jml) Then jmlItem += jml
            If Integer.TryParse(Convert.ToString(row.Cells("total").Value), tot) Then jmlTotal += tot
        Next
        txtJmlItem.Text = jmlItem.ToString()
        txtJmlTotal.Text = jmlTotal.ToString()
    End Sub

    ''' <summary>Baca isi grid menjadi daftar item yang valid.</summary>
    Private Function BacaItemGrid() As List(Of ItemJual)
        Dim daftar As New List(Of ItemJual)
        For Each row As DataGridViewRow In DataGridView1.Rows
            If row.IsNewRow Then Continue For
            Dim id, jml As Integer
            If Not Integer.TryParse(Convert.ToString(row.Cells("idbrg").Value), id) OrElse
               Not Integer.TryParse(Convert.ToString(row.Cells("jumlah").Value), jml) OrElse jml <= 0 Then
                Throw New InvalidOperationException("Baris " & (row.Index + 1) & ": ID barang/jumlah tidak valid.")
            End If
            daftar.Add(New ItemJual With {.IdBrg = id, .Jumlah = jml})
        Next
        If daftar.Count = 0 Then Throw New InvalidOperationException("Belum ada item dalam transaksi.")
        Return daftar
    End Function

#End Region

#Region "Event Grid (Perhitungan Otomatis)"

    Private Sub DataGridView1_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellEndEdit
        If e.RowIndex < 0 Then Return
        Try
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            Dim namaKolom As String = DataGridView1.Columns(e.ColumnIndex).Name

            If namaKolom = "idbrg" Then
                IsiDataBarang(row)
            End If

            ' Hitung total baris = harga x jumlah
            Dim harga, jumlah As Integer
            If Integer.TryParse(Convert.ToString(row.Cells("harga").Value), harga) AndAlso
               Integer.TryParse(Convert.ToString(row.Cells("jumlah").Value), jumlah) Then
                row.Cells("total").Value = harga * jumlah
            End If
            HitungTotal()
        Catch ex As Exception
            MessageBox.Show("Gagal menghitung: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub DataGridView1_UserDeletedRow(sender As Object, e As DataGridViewRowEventArgs) Handles DataGridView1.UserDeletedRow
        HitungTotal()
    End Sub

    ''' <summary>Ambil nama & harga jual barang dari tbl_barang berdasarkan idbrg.</summary>
    Private Sub IsiDataBarang(row As DataGridViewRow)
        Dim id As Integer
        If Not Integer.TryParse(Convert.ToString(row.Cells("idbrg").Value), id) Then
            row.Cells("nmbrg").Value = Nothing
            row.Cells("harga").Value = Nothing
            Return
        End If
        Using conn As MySqlConnection = KoneksiDB.BukaKoneksi()
            conn.Open()
            Using cmd As New MySqlCommand("SELECT nmbrg, hrgjual FROM tbl_barang WHERE idbrg=@id", conn)
                cmd.Parameters.AddWithValue("@id", id)
                Using rd As MySqlDataReader = cmd.ExecuteReader()
                    If rd.Read() Then
                        row.Cells("nmbrg").Value = rd.GetString("nmbrg")
                        row.Cells("harga").Value = rd.GetInt32("hrgjual")
                    Else
                        MessageBox.Show("Barang dengan ID " & id & " tidak ditemukan.", "Info",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information)
                        row.Cells("idbrg").Value = Nothing
                        row.Cells("nmbrg").Value = Nothing
                        row.Cells("harga").Value = Nothing
                        row.Cells("total").Value = Nothing
                    End If
                End Using
            End Using
        End Using
    End Sub

#End Region

#Region "Event Tombol"

    ' TRANSAKSI BARU
    Private Sub BTN_TambahTransaksi_Click(sender As Object, e As EventArgs) Handles BTN_TambahTransaksi.Click
        Try
            ResetForm()
            txtIdJual.Text = BuatIdBaru().ToString()
            txtTanggal.Text = Date.Today.ToString("yyyy-MM-dd")
            AturKontrol(aktif:=True, transaksiLama:=False)
        Catch ex As Exception
            MessageBox.Show("Gagal membuat transaksi baru: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' Tekan ENTER di txtIdJual (kondisi form non-aktif/lama) -> muat transaksi lama
    Private Sub txtIdJual_KeyDown(sender As Object, e As KeyEventArgs) Handles txtIdJual.KeyDown
        If e.KeyCode <> Keys.Enter Then Return
        e.SuppressKeyPress = True
        Dim id As Integer
        If Not Integer.TryParse(txtIdJual.Text, id) Then Return
        MuatTransaksi(id)
    End Sub

    ''' <summary>Memuat transaksi lama ke form agar bisa di-Update / Hapus.</summary>
    Private Sub MuatTransaksi(id As Integer)
        Try
            Using conn As MySqlConnection = KoneksiDB.BukaKoneksi()
                conn.Open()
                Using cmd As New MySqlCommand("SELECT tgljual FROM tbl_penjualan WHERE idjual=@id", conn)
                    cmd.Parameters.AddWithValue("@id", id)
                    Dim tgl As Object = cmd.ExecuteScalar()
                    If tgl Is Nothing Then
                        MessageBox.Show("Transaksi tidak ditemukan.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Return
                    End If
                    Dim teks As String = Convert.ToString(tgl)
                    If TanggalSebagaiInt AndAlso teks.Length = 8 Then
                        teks = teks.Substring(0, 4) & "-" & teks.Substring(4, 2) & "-" & teks.Substring(6, 2)
                    ElseIf TypeOf tgl Is Date Then
                        teks = CType(tgl, Date).ToString("yyyy-MM-dd")
                    End If
                    txtTanggal.Text = teks
                End Using

                DataGridView1.Rows.Clear()
                Using cmd As New MySqlCommand(
                    "SELECT idbrg, nmbrg, harga, jumlah, total FROM detail_penjualan WHERE idjual=@id", conn)
                    cmd.Parameters.AddWithValue("@id", id)
                    Using rd As MySqlDataReader = cmd.ExecuteReader()
                        While rd.Read()
                            DataGridView1.Rows.Add(rd.GetInt32("idbrg"), rd.GetString("nmbrg"),
                                                   rd.GetInt32("harga"), rd.GetInt32("jumlah"), rd.GetInt32("total"))
                        End While
                    End Using
                End Using
            End Using
            _idDimuat = id
            HitungTotal()
            AturKontrol(aktif:=True, transaksiLama:=True)
        Catch ex As Exception
            MessageBox.Show("Gagal memuat transaksi: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' SIMPAN transaksi baru
    Private Sub BTN_Simpan_Click(sender As Object, e As EventArgs) Handles BTN_Simpan.Click
        SimpanTransaksi(edit:=False)
    End Sub

    ' UPDATE transaksi lama
    Private Sub BTN_Update_Click(sender As Object, e As EventArgs) Handles BTN_Update.Click
        If _idDimuat = 0 Then Return
        SimpanTransaksi(edit:=True)
    End Sub

    ' HAPUS transaksi lama (stok dikembalikan)
    Private Sub BTN_Hapus_Click(sender As Object, e As EventArgs) Handles BTN_Hapus.Click
        If _idDimuat = 0 Then Return
        If MessageBox.Show("Hapus transaksi #" & _idDimuat & "? Stok barang akan dikembalikan.", "Konfirmasi",
                           MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then Return

        Using conn As MySqlConnection = KoneksiDB.BukaKoneksi()
            Dim trx As MySqlTransaction = Nothing
            Try
                conn.Open()
                trx = conn.BeginTransaction()
                KembalikanStok(conn, trx, _idDimuat)
                ExecNonQuery(conn, trx, "DELETE FROM detail_penjualan WHERE idjual=@id", _idDimuat)
                ExecNonQuery(conn, trx, "DELETE FROM tbl_penjualan WHERE idjual=@id", _idDimuat)
                trx.Commit()
                MessageBox.Show("Transaksi berhasil dihapus.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information)
                ResetForm()
            Catch ex As Exception
                If trx IsNot Nothing Then trx.Rollback()
                MessageBox.Show("Gagal menghapus: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using
    End Sub

    Private Sub BTN_Batal_Click(sender As Object, e As EventArgs) Handles BTN_Batal.Click
        ResetForm()
    End Sub

    ' KEMBALI ke Homepage (Form3 tampil lagi otomatis)
    Private Sub BTN_Kembali_Click(sender As Object, e As EventArgs) Handles BTN_Kembali.Click
        Me.Close()
    End Sub

#End Region

#Region "Logika Penyimpanan (Database Transaction)"

    ''' <summary>
    ''' Menyimpan header (tbl_penjualan) + detail (detail_penjualan) dalam SATU transaksi database.
    ''' Jika ada error, semua perubahan dibatalkan (Rollback).
    ''' </summary>
    Private Sub SimpanTransaksi(edit As Boolean)
        Dim daftar As List(Of ItemJual)
        Dim idJual As Integer
        Dim tanggal As Object
        Try
            If Not Integer.TryParse(txtIdJual.Text, idJual) Then
                Throw New InvalidOperationException("ID penjualan tidak valid.")
            End If
            tanggal = NilaiTanggal()
            daftar = BacaItemGrid()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End Try

        Using conn As MySqlConnection = KoneksiDB.BukaKoneksi()
            Dim trx As MySqlTransaction = Nothing
            Try
                conn.Open()
                trx = conn.BeginTransaction()

                If edit Then
                    ' Kembalikan stok lama & hapus detail lama, lalu tulis ulang
                    KembalikanStok(conn, trx, idJual)
                    ExecNonQuery(conn, trx, "DELETE FROM detail_penjualan WHERE idjual=@id", idJual)
                Else
                    Using cek As New MySqlCommand("SELECT COUNT(*) FROM tbl_penjualan WHERE idjual=@id", conn, trx)
                        cek.Parameters.AddWithValue("@id", idJual)
                        If Convert.ToInt32(cek.ExecuteScalar()) > 0 Then
                            Throw New InvalidOperationException("ID penjualan sudah dipakai.")
                        End If
                    End Using
                    Using cmd As New MySqlCommand(
                        "INSERT INTO tbl_penjualan (idjual, tgljual, jmlitem, jmltotal) VALUES (@id, @tgl, 0, 0)", conn, trx)
                        cmd.Parameters.AddWithValue("@id", idJual)
                        cmd.Parameters.AddWithValue("@tgl", tanggal)
                        cmd.ExecuteNonQuery()
                    End Using
                End If

                Dim jmlItem As Integer = 0
                Dim jmlTotal As Integer = 0

                For Each item As ItemJual In daftar
                    ' Ambil data terbaru & kunci baris barang
                    Dim nama As String = ""
                    Dim harga, stok As Integer
                    Using cmd As New MySqlCommand(
                        "SELECT nmbrg, hrgjual, stokbrg FROM tbl_barang WHERE idbrg=@b FOR UPDATE", conn, trx)
                        cmd.Parameters.AddWithValue("@b", item.IdBrg)
                        Using rd As MySqlDataReader = cmd.ExecuteReader()
                            If Not rd.Read() Then
                                Throw New InvalidOperationException("Barang ID " & item.IdBrg & " tidak ditemukan.")
                            End If
                            nama = rd.GetString("nmbrg")
                            harga = rd.GetInt32("hrgjual")
                            stok = rd.GetInt32("stokbrg")
                        End Using
                    End Using

                    If stok < item.Jumlah Then
                        Throw New InvalidOperationException(
                            "Stok '" & nama & "' tidak cukup (tersedia " & stok & ", diminta " & item.Jumlah & ").")
                    End If

                    Dim total As Integer = harga * item.Jumlah

                    Using cmd As New MySqlCommand(
                        "INSERT INTO detail_penjualan (idjual, idbrg, nmbrg, harga, jumlah, total) " &
                        "VALUES (@j, @b, @n, @h, @q, @t)", conn, trx)
                        cmd.Parameters.AddWithValue("@j", idJual)
                        cmd.Parameters.AddWithValue("@b", item.IdBrg)
                        cmd.Parameters.AddWithValue("@n", nama)
                        cmd.Parameters.AddWithValue("@h", harga)
                        cmd.Parameters.AddWithValue("@q", item.Jumlah)
                        cmd.Parameters.AddWithValue("@t", total)
                        cmd.ExecuteNonQuery()
                    End Using

                    Using cmd As New MySqlCommand(
                        "UPDATE tbl_barang SET stokbrg = stokbrg - @q WHERE idbrg=@b", conn, trx)
                        cmd.Parameters.AddWithValue("@q", item.Jumlah)
                        cmd.Parameters.AddWithValue("@b", item.IdBrg)
                        cmd.ExecuteNonQuery()
                    End Using

                    jmlItem += item.Jumlah
                    jmlTotal += total
                Next

                ' Update header dengan hasil perhitungan akhir
                Using cmd As New MySqlCommand(
                    "UPDATE tbl_penjualan SET tgljual=@tgl, jmlitem=@ji, jmltotal=@jt WHERE idjual=@id", conn, trx)
                    cmd.Parameters.AddWithValue("@tgl", tanggal)
                    cmd.Parameters.AddWithValue("@ji", jmlItem)
                    cmd.Parameters.AddWithValue("@jt", jmlTotal)
                    cmd.Parameters.AddWithValue("@id", idJual)
                    cmd.ExecuteNonQuery()
                End Using

                trx.Commit()
                MessageBox.Show("Transaksi berhasil " & If(edit, "diperbarui.", "disimpan.") &
                                vbCrLf & "Total: Rp " & jmlTotal.ToString("N0"),
                                "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information)
                ResetForm()

            Catch ex As Exception
                If trx IsNot Nothing Then
                    Try : trx.Rollback() : Catch : End Try
                End If
                MessageBox.Show("Transaksi dibatalkan: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using
    End Sub

    ''' <summary>Tambahkan kembali stok dari detail lama suatu transaksi.</summary>
    Private Sub KembalikanStok(conn As MySqlConnection, trx As MySqlTransaction, idJual As Integer)
        Dim sql As String =
            "UPDATE tbl_barang b JOIN detail_penjualan d ON b.idbrg = d.idbrg " &
            "SET b.stokbrg = b.stokbrg + d.jumlah WHERE d.idjual = @id"
        ExecNonQuery(conn, trx, sql, idJual)
    End Sub

    Private Sub ExecNonQuery(conn As MySqlConnection, trx As MySqlTransaction, sql As String, id As Integer)
        Using cmd As New MySqlCommand(sql, conn, trx)
            cmd.Parameters.AddWithValue("@id", id)
            cmd.ExecuteNonQuery()
        End Using
    End Sub

#End Region

End Class