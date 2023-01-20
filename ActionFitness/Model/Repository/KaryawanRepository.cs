using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SQLite;
using ActionFitness.Model.Entitiy;
using ActionFitness.Model.Context;

namespace ActionFitness.Model.Repository
{
    public class KaryawanRepository
    {
        private SQLiteConnection _conn;

        public KaryawanRepository(DbContextMember context)
        {
            _conn = context.Conn;
        }

        public int Create(Karyawan kar)
        {
            int result = 0;
            // deklarasi perintah SQL
            string sql = @"insert into karyawan (id_karyawan, nama_karyawan, jabatan_karyawan, gaji_karyawan, shift_karyawan, no_hp_karyawan) 
                           values (@id_karyawan, @nama_karyawan, @jabatan_karyawan, @gaji_karyawan, @shift_karyawan, @no_hp_karyawan)";
            // membuat objek command menggunakan blok using
            using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
            {
                // mendaftarkan parameter dan mengeset nilainya
                cmd.Parameters.AddWithValue("@id_karyawan", kar.Id_Karyawan);
                cmd.Parameters.AddWithValue("@nama_karyawan", kar.Nama_Karyawan);
                cmd.Parameters.AddWithValue("@jabatan_karyawan", kar.Jabatan_Karyawan);
                cmd.Parameters.AddWithValue("@gaji_karyawan", kar.Gaji_Karyawan);
                cmd.Parameters.AddWithValue("@shift_karyawan", kar.Shift_Karyawan);
                cmd.Parameters.AddWithValue("@no_hp_karyawan", kar.No_Hp_Karyawan);
                try
                {
                    // jalankan perintah INSERT dan tampung hasilnya ke dalam variabel result
                    result = cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.Print("Create error: {0}", ex.Message);
                }
            }
            return result;
        }

        public int Update(Karyawan kar)
        {
            int result = 0;

            // deklarasi perintah SQL
            string sql = @"update karyawan set nama_karyawan = @nama_karyawan, 
                            jabatan_karyawan = @jabatan_karyawan, gaji_karyawan = @gaji_karyawan, 
                            shift_karyawan = @shift_karyawan, no_hp_karyawan = @no_hp_karyawan 
                            where id_karyawan = @id_karyawan";

            // membuat objek command menggunakan blok using
            using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
            {
                // mendaftarkan parameter dan mengeset nilainya
                cmd.Parameters.AddWithValue("@id_karyawan", kar.Id_Karyawan);
                cmd.Parameters.AddWithValue("@nama_karyawan", kar.Nama_Karyawan);
                cmd.Parameters.AddWithValue("@jabatan_karyawan", kar.Jabatan_Karyawan);
                cmd.Parameters.AddWithValue("@gaji_karyawan", kar.Gaji_Karyawan);
                cmd.Parameters.AddWithValue("@shift_karyawan", kar.Shift_Karyawan);
                cmd.Parameters.AddWithValue("@no_hp_karyawan", kar.No_Hp_Karyawan);

                try
                {
                    // jalankan perintah UPDATE dan tampung hasilnya ke dalam variabel result
                    result = cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.Print("Update error: {0}", ex.Message);
                }
            }

            return result;
        }

        public int Delete(Karyawan kar)
        {
            int result = 0;

            // deklarasi perintah SQL
            string sql = @"delete from karyawan where id_karyawan = @id_karyawan";

            // membuat objek command menggunakan blok using
            using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
            {
                // mendaftarkan parameter dan mengeset nilainya
                cmd.Parameters.AddWithValue("@id_karyawan", kar.Id_Karyawan);

                try
                {
                    // jalankan perintah DELETE dan tampung hasilnya ke dalam variabel result
                    result = cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.Print("Delete error: {0}", ex.Message);
                }
            }

            return result;
        }

        public List<Karyawan> ReadAll()
        {
            // membuat objek collection untuk menampung objek mahasiswa
            List<Karyawan> list = new List<Karyawan>();
            try
            {
                // deklarasi perintah SQL
                string sql = @"select id_karyawan, nama_karyawan, jabatan_karyawan, gaji_karyawan, shift_karyawan, no_hp_karyawan
                                from karyawan order by id_karyawan";
                // membuat objek command menggunakan blok using
                using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
                {
                    // membuat objek dtr (data reader) untuk menampung result set (hasil perintah SELECT)
                    using (SQLiteDataReader dtr = cmd.ExecuteReader())
                    {
                        // panggil method Read untuk mendapatkan baris dari result set
                        while (dtr.Read())
                        {
                            // proses konversi dari row result set ke object
                            Karyawan kar = new Karyawan();
                            kar.Id_Karyawan = dtr["id_karyawan"].ToString();
                            kar.Nama_Karyawan = dtr["nama_karyawan"].ToString();
                            kar.Jabatan_Karyawan = dtr["jabatan_karyawan"].ToString();
                            kar.Gaji_Karyawan = dtr["gaji_karyawan"].ToString();
                            kar.Shift_Karyawan = dtr["shift_karyawan"].ToString();
                            kar.No_Hp_Karyawan = dtr["no_hp_karyawan"].ToString();
                            // tambahkan objek mahasiswa ke dalam collection
                            list.Add(kar);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Print("ReadAll error: {0}", ex.Message);
            }
            return list;
        }

        // Method untuk menampilkan data karyawan berdasarkan pencarian nama
        public List<Karyawan> ReadByNama(string nama)
        {
            // membuat objek collection untuk menampung objek mahasiswa
            List<Karyawan> list = new List<Karyawan>();

            try
            {
                // deklarasi perintah SQL
                string sql = @"select id_karyawan, nama_karyawan, jabatan_karyawan, gaji_karyawan, shift_karyawan, no_hp_karyawan
                                from karyawan where nama_karyawan like @nama_karyawan order by id_karyawan";

                // membuat objek command menggunakan blok using
                using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
                {
                    // mendaftarkan parameter dan mengeset nilainya
                    cmd.Parameters.AddWithValue("@nama_karyawan", string.Format("%{0}%", nama));

                    // membuat objek dtr (data reader) untuk menampung result set (hasil perintah SELECT)
                    using (SQLiteDataReader dtr = cmd.ExecuteReader())
                    {
                        // panggil method Read untuk mendapatkan baris dari result set
                        while (dtr.Read())
                        {
                            // proses konversi dari row result set ke object
                            Karyawan kar = new Karyawan();
                            kar.Id_Karyawan = dtr["id_karyawan"].ToString();
                            kar.Nama_Karyawan = dtr["nama_karyawan"].ToString();
                            kar.Jabatan_Karyawan = dtr["jabatan_karyawan"].ToString();
                            kar.Gaji_Karyawan = dtr["gaji_karyawan"].ToString();
                            kar.Shift_Karyawan = dtr["shift_karyawan"].ToString();
                            kar.No_Hp_Karyawan = dtr["no_hp_karyawan"].ToString();
                            // tambahkan objek karyawan ke dalam collection
                            list.Add(kar);

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Print("ReadByNama error: {0}", ex.Message);
            }

            return list;
        }
    }
}
