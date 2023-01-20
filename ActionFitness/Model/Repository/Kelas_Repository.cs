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
    public class Kelas_Repository
    {
        private SQLiteConnection _conn;

        public Kelas_Repository(DbContextMember context)
        {
            _conn = context.Conn;
        }

        public int Create(Kelas kel)
        {
            int result = 0;
            // deklarasi perintah SQL
            string sql = @"insert into kelas (id_kelas, nama_kelas, hari_kelas, ruangan_kelas, kapasitas_kelas) 
                            values (@id_kelas, @nama_kelas, @hari_kelas, @ruangan_kelas, @kapasitas_kelas)";
            // membuat objek command menggunakan blok using
            using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
            {
                // mendaftarkan parameter dan mengeset nilainya
                cmd.Parameters.AddWithValue("@id_kelas", kel.Id_Kelas);
                cmd.Parameters.AddWithValue("@nama_kelas", kel.Nama_Kelas);
                cmd.Parameters.AddWithValue("@hari_kelas", kel.Hari_Kelas);
                cmd.Parameters.AddWithValue("@ruangan_kelas", kel.Ruangan_Kelas);
                cmd.Parameters.AddWithValue("@kapasitas_kelas", kel.Kapasitas_Kelas);
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

        public int Update(Kelas kel)
        {
            int result = 0;

            // deklarasi perintah SQL
            string sql = @"update kelas set nama_kelas = @nama_kelas, hari_kelas = @hari_kelas, 
                            ruangan_kelas = @ruangan_kelas, kapasitas_kelas = @kapasitas_kelas 
                            where id_kelas = @id_kelas";

            // membuat objek command menggunakan blok using
            using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
            {
                // mendaftarkan parameter dan mengeset nilainya
                cmd.Parameters.AddWithValue("@id_kelas", kel.Id_Kelas);
                cmd.Parameters.AddWithValue("@nama_kelas", kel.Nama_Kelas);
                cmd.Parameters.AddWithValue("@hari_kelas", kel.Hari_Kelas);
                cmd.Parameters.AddWithValue("@ruangan_kelas", kel.Ruangan_Kelas);
                cmd.Parameters.AddWithValue("@kapasitas_kelas", kel.Kapasitas_Kelas);

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

        public int Delete(Kelas kel)
        {
            int result = 0;

            // deklarasi perintah SQL
            string sql = @"delete from kelas where id_kelas = @id_kelas";

            // membuat objek command menggunakan blok using
            using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
            {
                // mendaftarkan parameter dan mengeset nilainya
                cmd.Parameters.AddWithValue("@id_kelas", kel.Id_Kelas);

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

        public List<Kelas> ReadAll()
        {
            // membuat objek collection untuk menampung objek mahasiswa
            List<Kelas> list = new List<Kelas>();
            try
            {
                // deklarasi perintah SQL
                string sql = @"select id_kelas, nama_kelas, hari_kelas, ruangan_kelas, kapasitas_kelas from kelas order by id_kelas";
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
                            Kelas kel = new Kelas();
                            kel.Id_Kelas = dtr["id_kelas"].ToString();
                            kel.Nama_Kelas = dtr["nama_kelas"].ToString();
                            kel.Hari_Kelas = dtr["hari_kelas"].ToString();
                            kel.Ruangan_Kelas = dtr["ruangan_kelas"].ToString();
                            kel.Kapasitas_Kelas = dtr["kapasitas_kelas"].ToString();
                            // tambahkan objek mahasiswa ke dalam collection
                            list.Add(kel);
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

        // Method untuk menampilkan data mahasiwa berdasarkan pencarian nama
        public List<Kelas> ReadByNama(string nama)
        {
            // membuat objek collection untuk menampung objek mahasiswa
            List<Kelas> list = new List<Kelas>();

            try
            {
                // deklarasi perintah SQL
                string sql = @"select id_kelas, nama_kelas, hari_kelas, ruangan_kelas, kapasitas_kelas 
                                from kelas where nama_kelas like @nama_kelas order by id_kelas";

                // membuat objek command menggunakan blok using
                using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
                {
                    // mendaftarkan parameter dan mengeset nilainya
                    cmd.Parameters.AddWithValue("@nama_kelas", string.Format("%{0}%", nama));

                    // membuat objek dtr (data reader) untuk menampung result set (hasil perintah SELECT)
                    using (SQLiteDataReader dtr = cmd.ExecuteReader())
                    {
                        // panggil method Read untuk mendapatkan baris dari result set
                        while (dtr.Read())
                        {
                            // proses konversi dari row result set ke object
                            Kelas kel = new Kelas();
                            kel.Id_Kelas = dtr["id_kelas"].ToString();
                            kel.Nama_Kelas = dtr["nama_kelas"].ToString();
                            kel.Hari_Kelas = dtr["hari_kelas"].ToString();
                            kel.Ruangan_Kelas = dtr["ruangan_kelas"].ToString();
                            kel.Kapasitas_Kelas = dtr["kapasitas_kelas"].ToString();

                            // tambahkan objek mahasiswa ke dalam collection
                            list.Add(kel);
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
