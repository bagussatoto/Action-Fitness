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
    public class User_Repository
    {
        // deklarsi objek connection
        private SQLiteConnection _conn;

        // constructor
        public User_Repository(DbContextMember context)
        {
            // inisialisasi objek connection
            _conn = context.Conn;
        }

        public bool IsValidUser(string userName, string password)
        {
            bool result = false;

            string sql = @"select count(*) as row_count from user_aplikasi where user_name = @userName and password = @password";

            // membuat objek command menggunakan blok using
            using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
            {
                // mendaftarkan parameter dan mengeset nilainya
                cmd.Parameters.AddWithValue("@userName", userName);
                cmd.Parameters.AddWithValue("@password", password);

                // membuat objek dtr (data reader) untuk menampung result set (hasil perintah SELECT)
                using (SQLiteDataReader dtr = cmd.ExecuteReader())
                {
                    // panggil method Read untuk mendapatkan baris dari result set
                    if (dtr.Read())
                    {
                        result = Convert.ToInt32(dtr["row_count"]) > 0;
                    }
                }
            }

            return result;
        }
    }
}
