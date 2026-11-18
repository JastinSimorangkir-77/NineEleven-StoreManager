''' <summary>Form3 = Homepage / Menu Utama (jadikan Startup Form).</summary>
Public Class Form3

    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "9/11 Store Manager"
        Me.StartPosition = FormStartPosition.CenterScreen
        If Not KoneksiDB.TesKoneksi() Then
            ' Aplikasi tetap terbuka, tetapi pengguna sudah diberi tahu errornya
        End If
    End Sub

    ' Tombol "Transaksi Baru" -> buka Form1 (Transaction Manager)
    Private Sub BTN_TransaksiBaru_Click(sender As Object, e As EventArgs) Handles BTN_TransaksiBaru.Click
        Try
            Me.Hide()
            Using frm As New Form1()
                frm.ShowDialog()
            End Using
        Catch ex As Exception
            MessageBox.Show("Gagal membuka Transaction Manager: " & ex.Message,
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Me.Show()
        End Try
    End Sub

    ' Tombol "Barang Baru" -> buka Form2 (Items Manager)
    Private Sub BTN_BarangBaru_Click(sender As Object, e As EventArgs) Handles BTN_BarangBaru.Click
        Try
            Me.Hide()
            Using frm As New Form2()
                frm.ShowDialog()
            End Using
        Catch ex As Exception
            MessageBox.Show("Gagal membuka Items Manager: " & ex.Message,
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Me.Show()
        End Try
    End Sub

    ' Tombol "Keluar" -> tutup aplikasi
    Private Sub BTN_Keluar_Click(sender As Object, e As EventArgs) Handles BTN_Keluar.Click
        If MessageBox.Show("Yakin ingin keluar dari aplikasi?", "Konfirmasi",
                           MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Application.Exit()
        End If
    End Sub

End Class