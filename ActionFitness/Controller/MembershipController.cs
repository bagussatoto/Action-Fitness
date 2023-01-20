using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
using ActionFitness.Model.Entitiy;
using ActionFitness.Model.Repository;
using ActionFitness.Model.Context;


namespace ActionFitness.Controller
{
    public class MembershipController
    {
        private MembershipRepository _membershipRepository;

        public int Create(Membership shp)
        {
            int result = 0;
            // cek ID Member yang diinputkan tidak boleh kosong
            if (string.IsNullOrEmpty(shp.Id_Member_Membership))
            {
                MessageBox.Show("ID Member harus diisi !!!", "Peringatan",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }
            // cek Id Membership yang diinputkan tidak boleh kosong
            if (string.IsNullOrEmpty(shp.Id_Membership))
            {
                MessageBox.Show("Id Membership harus diisi !!!", "Peringatan",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }
            // cek Level Membership yang diinputkan tidak boleh kosong
            if (string.IsNullOrEmpty(shp.Level_Membership))
            {
                MessageBox.Show("Level Membership harus diisi !!!", "Peringatan",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }
            // cek Id Kelas yang diinputkan tidak boleh kosong
            if (string.IsNullOrEmpty(shp.Id_Kelas_Membership))
            {
                MessageBox.Show("Id Kelas harus diisi !!!", "Peringatan",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }
            // membuat objek context menggunakan blok using
            using (DbContextMember contextMember = new DbContextMember())
            {
                // membuat objek class repository
                _membershipRepository = new MembershipRepository(contextMember);
                // panggil method Create class repository untuk menambahkan data
                result = _membershipRepository.Create(shp);
            }
            if (result > 0)
            {
                MessageBox.Show("Data membership berhasil disimpan !", "Informasi",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Data membership gagal disimpan !!!", "Peringatan",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            return result;
        }

        public List<Membership> ReadAll()
        {
            // membuat objek collection
            List<Membership> list = new List<Membership>();
            // membuat objek context menggunakan blok using
            using (DbContextMember context = new DbContextMember())
            {
                // membuat objek dari class repository
                _membershipRepository = new MembershipRepository(context);
                // panggil method GetAll yang ada di dalam class repository
                list = _membershipRepository.ReadAll();
            }
            return list;
        }

        /// <summary>
        /// Method untuk menampilkan data mahasiwa berdasarkan nama
        /// </summary>
        /// <param name="nama"></param>
        /// <returns></returns>
        public List<Membership> ReadByMember(string nama)
        {
            // membuat objek collection
            List<Membership> list = new List<Membership>();

            // membuat objek context menggunakan blok using
            using (DbContextMember context = new DbContextMember())
            {
                // membuat objek dari class repository
                _membershipRepository = new MembershipRepository(context);

                // panggil method ReadByNama yang ada di dalam class repository
                list = _membershipRepository.ReadByMember(nama);
            }

            return list;
        }

        public int Update(Membership shp)
        {
            int result = 0;

            // cek ID Member yang diinputkan tidak boleh kosong
            if (string.IsNullOrEmpty(shp.Id_Member_Membership))
            {
                MessageBox.Show("ID Member harus diisi !!!", "Peringatan",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }
            // cek Id Membership yang diinputkan tidak boleh kosong
            if (string.IsNullOrEmpty(shp.Id_Membership))
            {
                MessageBox.Show("Id Membership harus diisi !!!", "Peringatan",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }
            // cek Level Membership yang diinputkan tidak boleh kosong
            if (string.IsNullOrEmpty(shp.Level_Membership))
            {
                MessageBox.Show("Level Membership harus diisi !!!", "Peringatan",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }
            // cek Id Kelas yang diinputkan tidak boleh kosong
            if (string.IsNullOrEmpty(shp.Id_Kelas_Membership))
            {
                MessageBox.Show("Id Kelas harus diisi !!!", "Peringatan",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            // membuat objek context menggunakan blok using
            using (DbContextMember context = new DbContextMember())
            {
                // membuat objek dari class repository
                _membershipRepository = new MembershipRepository(context);

                // panggil method Update class repository untuk mengupdate data
                result = _membershipRepository.Update(shp);
            }

            if (result > 0)
            {
                MessageBox.Show("Data membership berhasil diupdate !", "Informasi",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Data membership gagal diupdate !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            return result;
        }

        public int Delete(Membership shp)
        {
            int result = 0;

            // cek nilai npm yang diinputkan tidak boleh kosong
            if (string.IsNullOrEmpty(shp.Id_Membership))
            {
                MessageBox.Show("ID Membership harus diisi !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            // membuat objek context menggunakan blok using
            using (DbContextMember context = new DbContextMember())
            {
                // membuat objek dari class repository
                _membershipRepository = new MembershipRepository(context);

                // panggil method Delete class repository untuk menghapus data
                result = _membershipRepository.Delete(shp);
            }

            if (result > 0)
            {
                MessageBox.Show("Data membership berhasil dihapus !", "Informasi",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Data membership gagal dihapus !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            return result;
        }
    }
}
