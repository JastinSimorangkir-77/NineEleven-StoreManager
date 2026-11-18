Imports MySql.Data.MySqlClient

''' <summary>
''' Modul koneksi database. Dipakai oleh Form1, Form2, dan Form3.
''' Wajib: install NuGet package "MySql.Data" di project.
''' </summary>
Module KoneksiDB

    ' Ubah sesuai pengaturan MySQL Anda (XAMPP default: root tanpa password)
    Private Const ConnStr As String =
    "Server=localhost;Port=3306;Database=db_nineleven;Uid=root;Pwd=;SslMode=Disabled;"

    ''' <summary>Membuat objek koneksi BARU (belum dibuka). Selalu pakai dengan Using.</summary>
    Public Function BukaKoneksi() As MySqlConnection
        Return New MySqlConnection(ConnStr)
    End Function

    ''' <summary>Tes koneksi, dipanggil saat aplikasi mulai.</summary>
    Public Function TesKoneksi() As Boolean
        Try
            Using conn As MySqlConnection = BukaKoneksi()
                conn.Open()
                Return True
            End Using
        Catch ex As Exception
            MessageBox.Show("Gagal terhubung ke database:" & vbCrLf & ex.Message,
                            "Koneksi Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function

End Module