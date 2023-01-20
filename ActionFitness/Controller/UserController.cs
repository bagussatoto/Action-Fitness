using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
using ActionFitness.Model.Repository;
using ActionFitness.Model.Context;

namespace ActionFitness.Controller
{
    public  class UserController
    {
        private User_Repository _repository;

        public bool IsValidUser(string userName, string password)
        {
            // cek npm yang diinputkan tidak boleh kosong
            if (string.IsNullOrEmpty(userName))
            {
                MessageBox.Show("User name harus diisi !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            // cek nama yang diinputkan tidak boleh kosong
            if (string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Password harus diisi !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            bool isValidUser = false;

            // membuat objek context menggunakan blok using
            using (DbContextMember context = new DbContextMember())
            {
                // membuat objek class repository
                _repository = new User_Repository(context);

                // panggil method Create class repository untuk menambahkan data
                isValidUser = _repository.IsValidUser(userName, password);
            }

            if (!isValidUser)
            {
                MessageBox.Show("User name atau password salah !!!", "Peringatan",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return false;
            }

            return true;
        }
    }
}
