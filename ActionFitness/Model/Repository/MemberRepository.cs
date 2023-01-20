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
    public class MemberRepository
    {
        private SQLiteConnection _conn;

        public MemberRepository(DbContextMember context)
        {
            _conn = context.Conn;
        }

        public int Create(Member mem)
        {
            int result = 0;
            // deklarasi perintah SQL
            string sql = @"insert into member (id_Member, nama, alamat, no_hp) values (@id_Member, @nama, @alamat, @no_hp)";
            // membuat objek command menggunakan blok using
            using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
            {
                // mendaftarkan parameter dan mengeset nilainya
                cmd.Parameters.AddWithValue("@id_Member", mem.Id_Member);
                cmd.Parameters.AddWithValue("@nama", mem.Nama);
                cmd.Parameters.AddWithValue("@alamat", mem.Alamat);
                cmd.Parameters.AddWithValue("@no_hp", mem.No_Hp);
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

        public int Update(Member mem)
        {
            int result = 0;

            // deklarasi perintah SQL
            string sql = @"update member set nama = @nama, alamat = @alamat, no_hp = @no_hp where id_Member = @id_Member";

            // membuat objek command menggunakan blok using
            using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
            {
                // mendaftarkan parameter dan mengeset nilainya
                cmd.Parameters.AddWithValue("@nama", mem.Nama);
                cmd.Parameters.AddWithValue("@alamat", mem.Alamat);
                cmd.Parameters.AddWithValue("@no_hp", mem.No_Hp);
                cmd.Parameters.AddWithValue("@id_Member", mem.Id_Member);

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

        public int Delete(Member mem)
        {
            int result = 0;

            // deklarasi perintah SQL
            string sql = @"delete from member where id_Member = @id_Member";

            // membuat objek command menggunakan blok using
            using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
            {
                // mendaftarkan parameter dan mengeset nilainya
                cmd.Parameters.AddWithValue("@id_Member", mem.Id_Member);

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

        public List<Member> ReadAll()
        {
            // membuat objek collection untuk menampung objek mahasiswa
            List<Member> list = new List<Member>();
            try
            {
                // deklarasi perintah SQL
                string sql = @"select id_Member, nama, alamat, no_hp from member order by id_Member";
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
                            Member mem = new Member();
                            mem.Id_Member = dtr["id_Member"].ToString();
                            mem.Nama = dtr["nama"].ToString();
                            mem.Alamat = dtr["alamat"].ToString();
                            mem.No_Hp = dtr["no_hp"].ToString();
                            // tambahkan objek mahasiswa ke dalam collection
                            list.Add(mem);
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
        public List<Member> ReadByNama(string nama)
        {
            // membuat objek collection untuk menampung objek mahasiswa
            List<Member> list = new List<Member>();

            try
            {
                // deklarasi perintah SQL
                string sql = @"select id_Member, nama, alamat, no_hp from member where nama like @nama order by id_Member";

                // membuat objek command menggunakan blok using
                using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
                {
                    // mendaftarkan parameter dan mengeset nilainya
                    cmd.Parameters.AddWithValue("@nama", string.Format("%{0}%", nama));

                    // membuat objek dtr (data reader) untuk menampung result set (hasil perintah SELECT)
                    using (SQLiteDataReader dtr = cmd.ExecuteReader())
                    {
                        // panggil method Read untuk mendapatkan baris dari result set
                        while (dtr.Read())
                        {
                            // proses konversi dari row result set ke object
                            Member mem = new Member();
                            mem.Id_Member = dtr["id_Member"].ToString();
                            mem.Nama = dtr["nama"].ToString();
                            mem.Alamat = dtr["alamat"].ToString();
                            mem.No_Hp = dtr["no_hp"].ToString();

                            // tambahkan objek mahasiswa ke dalam collection
                            list.Add(mem);
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
