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
    public class FasilitasRepository
    {
        private SQLiteConnection _conn;

        public FasilitasRepository(DbContextMember context)
        {
            _conn = context.Conn;
        }

        public int Create(Fasilitas fas)
        {
            int result = 0;
            // deklarasi perintah SQL
            string sql = @"insert into fasilitas (id_fasilitas, nama_fasilitas, ketersediaan_fasilitas, id_kelas)
                           values (@id_fasilitas, @nama_fasilitas, @ketersediaan_fasilitas, @id_kelas)";
            // membuat objek command menggunakan blok using
            using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
            {
                // mendaftarkan parameter dan mengeset nilainya
                cmd.Parameters.AddWithValue("@id_fasilitas", fas.Id_Fasilitas);
                cmd.Parameters.AddWithValue("@nama_fasilitas", fas.Nama_Fasilitas);
                cmd.Parameters.AddWithValue("@ketersediaan_fasilitas", fas.Ketersediaan_Fasilitas);
                cmd.Parameters.AddWithValue("@id_kelas", fas.Id_Kelas_Fasilitas);
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

        public int Update(Fasilitas fal)
        {
            int result = 0;

            // deklarasi perintah SQL
            string sql = @"update fasilitas set nama_fasilitas = @nama_fasilitas, 
                            ketersediaan_fasilitas = @ketersediaan_fasilitas, id_kelas = @id_kelas 
                            where id_fasilitas = @id_fasilitas";

            // membuat objek command menggunakan blok using
            using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
            {
                // mendaftarkan parameter dan mengeset nilainya
                cmd.Parameters.AddWithValue("@id_fasilitas", fal.Id_Fasilitas);
                cmd.Parameters.AddWithValue("@nama_fasilitas", fal.Nama_Fasilitas);
                cmd.Parameters.AddWithValue("@ketersediaan_fasilitas", fal.Ketersediaan_Fasilitas);
                cmd.Parameters.AddWithValue("@id_kelas", fal.Id_Kelas_Fasilitas);

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

        public int Delete(Fasilitas fas)
        {
            int result = 0;

            // deklarasi perintah SQL
            string sql = @"delete from fasilitas where id_fasilitas = @id_fasilitas";

            // membuat objek command menggunakan blok using
            using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
            {
                // mendaftarkan parameter dan mengeset nilainya
                cmd.Parameters.AddWithValue("@id_fasilitas", fas.Id_Fasilitas);

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

        public List<Fasilitas> ReadAll()
        {
            // membuat objek collection untuk menampung objek mahasiswa
            List<Fasilitas> list = new List<Fasilitas>();
            try
            {
                // deklarasi perintah SQL
                string sql = @"select id_fasilitas, nama_fasilitas, ketersediaan_fasilitas, id_kelas
                                from fasilitas order by id_fasilitas";
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
                            Fasilitas fas = new Fasilitas();
                            fas.Id_Fasilitas = dtr["id_fasilitas"].ToString();
                            fas.Nama_Fasilitas = dtr["nama_fasilitas"].ToString();
                            fas.Ketersediaan_Fasilitas = dtr["ketersediaan_fasilitas"].ToString();
                            fas.Id_Kelas_Fasilitas = dtr["id_kelas"].ToString();
                            // tambahkan objek fasilitas ke dalam collection
                            list.Add(fas);
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
        public List<Fasilitas> ReadByNama(string nama)
        {
            // membuat objek collection untuk menampung objek mahasiswa
            List<Fasilitas> list = new List<Fasilitas>();

            try
            {
                // deklarasi perintah SQL
                string sql = @"select id_fasilitas, nama_fasilitas, ketersediaan_fasilitas, id_kelas
                                from fasilitas where nama_fasilitas like @nama_fasilitas order by id_fasilitas";

                // membuat objek command menggunakan blok using
                using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
                {
                    // mendaftarkan parameter dan mengeset nilainya
                    cmd.Parameters.AddWithValue("@nama_fasilitas", string.Format("%{0}%", nama));

                    // membuat objek dtr (data reader) untuk menampung result set (hasil perintah SELECT)
                    using (SQLiteDataReader dtr = cmd.ExecuteReader())
                    {
                        // panggil method Read untuk mendapatkan baris dari result set
                        while (dtr.Read())
                        {
                            // proses konversi dari row result set ke object
                            Fasilitas fas = new Fasilitas();
                            fas.Id_Fasilitas = dtr["id_fasilitas"].ToString();
                            fas.Nama_Fasilitas = dtr["nama_fasilitas"].ToString();
                            fas.Ketersediaan_Fasilitas = dtr["ketersediaan_fasilitas"].ToString();
                            fas.Id_Kelas_Fasilitas = dtr["id_kelas"].ToString();
                            // tambahkan objek fasilitas ke dalam collection
                            list.Add(fas);
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
