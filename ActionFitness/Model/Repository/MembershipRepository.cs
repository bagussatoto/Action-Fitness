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
    public class MembershipRepository
    {
        private SQLiteConnection _conn;

        public MembershipRepository(DbContextMember context)
        {
            _conn = context.Conn;
        }

        public int Create(Membership shp)
        {
            int result = 0;
            // deklarasi perintah SQL
            string sql = @"insert into membership (id_membership, id_member, level_membership, id_kelas) 
                            values (@id_membership, @id_member, @level_membership, @id_kelas)";
            // membuat objek command menggunakan blok using
            using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
            {
                // mendaftarkan parameter dan mengeset nilainya
                cmd.Parameters.AddWithValue("@id_membership", shp.Id_Membership); 
                cmd.Parameters.AddWithValue("@id_member", shp.Id_Member_Membership);
                cmd.Parameters.AddWithValue("@level_membership", shp.Level_Membership);
                cmd.Parameters.AddWithValue("@id_kelas", shp.Id_Kelas_Membership);
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

        public int Update(Membership shp)
        {
            int result = 0;

            // deklarasi perintah SQL
            string sql = @"update membership set id_member = @id_member, level_membership = @level_membership, id_kelas = @id_kelas
                          where id_membership = @id_membership";

            // membuat objek command menggunakan blok using
            using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
            {
                // mendaftarkan parameter dan mengeset nilainya
                cmd.Parameters.AddWithValue("@id_membership", shp.Id_Membership);
                cmd.Parameters.AddWithValue("@id_member", shp.Id_Member_Membership);
                cmd.Parameters.AddWithValue("@level_membership", shp.Level_Membership);
                cmd.Parameters.AddWithValue("@id_kelas", shp.Id_Kelas_Membership);

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

        public int Delete(Membership shp)
        {
            int result = 0;

            // deklarasi perintah SQL
            string sql = @"delete from membership where id_membership = @id_membership";

            // membuat objek command menggunakan blok using
            using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
            {
                // mendaftarkan parameter dan mengeset nilainya
                cmd.Parameters.AddWithValue("@id_membership", shp.Id_Membership);

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

        public List<Membership> ReadAll()
        {
            // membuat objek collection untuk menampung objek mahasiswa
            List<Membership> list = new List<Membership>();
            try
            {
                // deklarasi perintah SQL
                string sql = @"select id_membership, id_member, level_membership, id_kelas from membership order by id_membership";
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
                            Membership shp = new Membership();
                            shp.Id_Membership = dtr["id_membership"].ToString();
                            shp.Id_Member_Membership = dtr["id_member"].ToString();
                            shp.Level_Membership = dtr["level_membership"].ToString();
                            shp.Id_Kelas_Membership= dtr["id_kelas"].ToString();
                            // tambahkan objek membership ke dalam collection
                            list.Add(shp);
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
        public List<Membership> ReadByMember(string member)
        {
            // membuat objek collection untuk menampung objek mahasiswa
            List<Membership> list = new List<Membership>();

            try
            {
                // deklarasi perintah SQL
                string sql = @"select id_membership, id_member, level_membership, id_kelas 
                               from membership where id_member like @id_member order by id_membership";

                // membuat objek command menggunakan blok using
                using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
                {
                    // mendaftarkan parameter dan mengeset nilainya
                    cmd.Parameters.AddWithValue("@id_member", string.Format("%{0}%", member));

                    // membuat objek dtr (data reader) untuk menampung result set (hasil perintah SELECT)
                    using (SQLiteDataReader dtr = cmd.ExecuteReader())
                    {
                        // panggil method Read untuk mendapatkan baris dari result set
                        while (dtr.Read())
                        {
                            // proses konversi dari row result set ke object
                            Membership shp = new Membership();
                            shp.Id_Member_Membership = dtr["id_member"].ToString();
                            shp.Id_Membership = dtr["id_membership"].ToString();
                            shp.Level_Membership = dtr["level_membership"].ToString();
                            shp.Id_Kelas_Membership = dtr["id_kelas"].ToString();

                            // tambahkan objek mahasiswa ke dalam collection
                            list.Add(shp);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Print("ReadByMember error: {0}", ex.Message);
            }

            return list;
        }
    }
}
