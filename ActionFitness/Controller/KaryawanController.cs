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
    public class KaryawanController
    {
        private KaryawanRepository _karyawanRepository;

        public int Create(Karyawan kar)
        {
            int result = 0;
            // cek id karyawan yang diinputkan tidak boleh kosong
            if (string.IsNullOrEmpty(kar.Id_Karyawan))
            {
                MessageBox.Show("ID Karyawan harus diisi !!!", "Peringatan",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }
            // cek nama yang diinputkan tidak boleh kosong
            if (string.IsNullOrEmpty(kar.Nama_Karyawan))
            {
                MessageBox.Show("Nama Karyawan harus diisi !!!", "Peringatan",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }
            // cek jabatan yang diinputkan tidak boleh kosong
            if (string.IsNullOrEmpty(kar.Jabatan_Karyawan))
            {
                MessageBox.Show("Jabatan Karyawan harus diisi !!!", "Peringatan",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }
            // cek gaji yang diinputkan tidak boleh kosong
            if (string.IsNullOrEmpty(kar.Gaji_Karyawan))
            {
                MessageBox.Show("Gaji Karyawan harus diisi !!!", "Peringatan",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }
            // cek shift yang diinputkan tidak boleh kosong
            if (string.IsNullOrEmpty(kar.Shift_Karyawan))
            {
                MessageBox.Show("Shift Karyawan harus diisi !!!", "Peringatan",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }
            // cek no hp yang diinputkan tidak boleh kosong
            if (string.IsNullOrEmpty(kar.No_Hp_Karyawan))
            {
                MessageBox.Show("Nomor HP Karyawan harus diisi !!!", "Peringatan",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }
            // membuat objek context menggunakan blok using
            using (DbContextMember contextKaryawan = new DbContextMember())
            {
                // membuat objek class repository
                _karyawanRepository = new KaryawanRepository(contextKaryawan);
                // panggil method Create class repository untuk menambahkan data
                result = _karyawanRepository.Create(kar);
            }
            if (result > 0)
            {
                MessageBox.Show("Data Karyawan berhasil disimpan !", "Informasi",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Data Karyawan gagal disimpan !!!", "Peringatan",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            return result;
        }

        public List<Karyawan> ReadAll()
        {
            // membuat objek collection
            List<Karyawan> list = new List<Karyawan>();
            // membuat objek context menggunakan blok using
            using (DbContextMember context = new DbContextMember())
            {
                // membuat objek dari class repository
                _karyawanRepository = new KaryawanRepository(context);
                // panggil method GetAll yang ada di dalam class repository
                list = _karyawanRepository.ReadAll();
            }
            return list;
        }

        /// <summary>
        /// Method untuk menampilkan data mahasiwa berdasarkan nama
        /// </summary>
        /// <param name="nama"></param>
        /// <returns></returns>
        public List<Karyawan> ReadByNama(string nama)
        {
            // membuat objek collection
            List<Karyawan> list = new List<Karyawan>();

            // membuat objek context menggunakan blok using
            using (DbContextMember context = new DbContextMember())
            {
                // membuat objek dari class repository
                _karyawanRepository = new KaryawanRepository(context);

                // panggil method ReadByNama yang ada di dalam class repository
                list = _karyawanRepository.ReadByNama(nama);
            }

            return list;
        }

        public int Update(Karyawan kar)
        {
            int result = 0;

            // cek id karyawan yang diinputkan tidak boleh kosong
            if (string.IsNullOrEmpty(kar.Id_Karyawan))
            {
                MessageBox.Show("ID Karyawan harus diisi !!!", "Peringatan",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }
            // cek nama yang diinputkan tidak boleh kosong
            if (string.IsNullOrEmpty(kar.Nama_Karyawan))
            {
                MessageBox.Show("Nama Karyawan harus diisi !!!", "Peringatan",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }
            // cek jabatan yang diinputkan tidak boleh kosong
            if (string.IsNullOrEmpty(kar.Jabatan_Karyawan))
            {
                MessageBox.Show("Jabatan Karyawan harus diisi !!!", "Peringatan",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }
            // cek gaji yang diinputkan tidak boleh kosong
            if (string.IsNullOrEmpty(kar.Gaji_Karyawan))
            {
                MessageBox.Show("Gaji Karyawan harus diisi !!!", "Peringatan",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }
            // cek shift yang diinputkan tidak boleh kosong
            if (string.IsNullOrEmpty(kar.Shift_Karyawan))
            {
                MessageBox.Show("Shift Karyawan harus diisi !!!", "Peringatan",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }
            // cek no hp yang diinputkan tidak boleh kosong
            if (string.IsNullOrEmpty(kar.No_Hp_Karyawan))
            {
                MessageBox.Show("Nomor HP Karyawan harus diisi !!!", "Peringatan",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            // membuat objek context menggunakan blok using
            using (DbContextMember context = new DbContextMember())
            {
                // membuat objek dari class repository
                _karyawanRepository = new KaryawanRepository(context);

                // panggil method Update class repository untuk mengupdate data
                result = _karyawanRepository.Update(kar);
            }

            if (result > 0)
            {
                MessageBox.Show("Data karyawan berhasil diupdate !", "Informasi",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Data karyawan gagal diupdate !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            return result;
        }

        public int Delete(Karyawan kar)
        {
            int result = 0;

            // cek nilai npm yang diinputkan tidak boleh kosong
            if (string.IsNullOrEmpty(kar.Id_Karyawan))
            {
                MessageBox.Show("ID Karyawan harus diisi !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            // membuat objek context menggunakan blok using
            using (DbContextMember context = new DbContextMember())
            {
                // membuat objek dari class repository
                _karyawanRepository = new KaryawanRepository(context);

                // panggil method Delete class repository untuk menghapus data
                result = _karyawanRepository.Delete(kar);
            }

            if (result > 0)
            {
                MessageBox.Show("Data karyawan berhasil dihapus !", "Informasi",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Data karyawan gagal dihapus !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            return result;
        }
    }
}
