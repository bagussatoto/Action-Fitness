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
    public class KelasController
    {
        private Kelas_Repository _kelasRepository;

        public int Create(Kelas kel)
        {
            int result = 0;
            // cek ID Kelas yang diinputkan tidak boleh kosong
            if (string.IsNullOrEmpty(kel.Id_Kelas))
            {
                MessageBox.Show("ID Kelas harus diisi !!!", "Peringatan",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }
            // cek nama yang diinputkan tidak boleh kosong
            if (string.IsNullOrEmpty(kel.Nama_Kelas))
            {
                MessageBox.Show("Nama harus diisi !!!", "Peringatan",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }
            // cek Hari yang diinputkan tidak boleh kosong
            if (string.IsNullOrEmpty(kel.Hari_Kelas))
            {
                MessageBox.Show("Hari harus diisi !!!", "Peringatan",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }
            // cek Ruangan yang diinputkan tidak boleh kosong
            if (string.IsNullOrEmpty(kel.Ruangan_Kelas))
            {
                MessageBox.Show("Ruangan harus diisi !!!", "Peringatan",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }
            // cek Kapasitas yang diinputkan tidak boleh kosong
            if (string.IsNullOrEmpty(kel.Kapasitas_Kelas))
            {
                MessageBox.Show("Kapasitas harus diisi !!!", "Peringatan",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }
            // membuat objek context menggunakan blok using
            using (DbContextMember contextMember = new DbContextMember())
            {
                // membuat objek class repository
                _kelasRepository = new Kelas_Repository(contextMember);
                // panggil method Create class repository untuk menambahkan data
                result = _kelasRepository.Create(kel);
            }
            if (result > 0)
            {
                MessageBox.Show("Data kelas berhasil disimpan !", "Informasi",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Data kelas gagal disimpan !!!", "Peringatan",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            return result;
        }

        public List<Kelas> ReadAll()
        {
            // membuat objek collection
            List<Kelas> list = new List<Kelas>();
            // membuat objek context menggunakan blok using
            using (DbContextMember context = new DbContextMember())
            {
                // membuat objek dari class repository
                _kelasRepository = new Kelas_Repository(context);
                // panggil method GetAll yang ada di dalam class repository
                list = _kelasRepository.ReadAll();
            }
            return list;
        }

        /// <summary>
        /// Method untuk menampilkan data mahasiwa berdasarkan nama
        /// </summary>
        /// <param name="nama"></param>
        /// <returns></returns>
        public List<Kelas> ReadByNama(string nama)
        {
            // membuat objek collection
            List<Kelas> list = new List<Kelas>();

            // membuat objek context menggunakan blok using
            using (DbContextMember context = new DbContextMember())
            {
                // membuat objek dari class repository
                _kelasRepository = new Kelas_Repository(context);

                // panggil method ReadByNama yang ada di dalam class repository
                list = _kelasRepository.ReadByNama(nama);
            }

            return list;
        }

        public int Update(Kelas kel)
        {
            int result = 0;

            // cek ID Kelas yang diinputkan tidak boleh kosong
            if (string.IsNullOrEmpty(kel.Id_Kelas))
            {
                MessageBox.Show("ID Kelas harus diisi !!!", "Peringatan",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }
            // cek nama yang diinputkan tidak boleh kosong
            if (string.IsNullOrEmpty(kel.Nama_Kelas))
            {
                MessageBox.Show("Nama harus diisi !!!", "Peringatan",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }
            // cek Hari yang diinputkan tidak boleh kosong
            if (string.IsNullOrEmpty(kel.Hari_Kelas))
            {
                MessageBox.Show("Hari harus diisi !!!", "Peringatan",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }
            // cek Ruangan yang diinputkan tidak boleh kosong
            if (string.IsNullOrEmpty(kel.Ruangan_Kelas))
            {
                MessageBox.Show("Ruangan harus diisi !!!", "Peringatan",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }
            // cek Kapasitas yang diinputkan tidak boleh kosong
            if (string.IsNullOrEmpty(kel.Kapasitas_Kelas))
            {
                MessageBox.Show("Kapasitas harus diisi !!!", "Peringatan",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            // membuat objek context menggunakan blok using
            using (DbContextMember context = new DbContextMember())
            {
                // membuat objek dari class repository
                _kelasRepository = new Kelas_Repository(context);

                // panggil method Update class repository untuk mengupdate data
                result = _kelasRepository.Update(kel);
            }

            if (result > 0)
            {
                MessageBox.Show("Data kelas berhasil diupdate !", "Informasi",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Data kelas gagal diupdate !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            return result;
        }

        public int Delete(Kelas kel)
        {
            int result = 0;

            // cek nilai npm yang diinputkan tidak boleh kosong
            if (string.IsNullOrEmpty(kel.Id_Kelas))
            {
                MessageBox.Show("ID Kelas harus diisi !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            // membuat objek context menggunakan blok using
            using (DbContextMember context = new DbContextMember())
            {
                // membuat objek dari class repository
                _kelasRepository = new Kelas_Repository(context);

                // panggil method Delete class repository untuk menghapus data
                result = _kelasRepository.Delete(kel);
            }

            if (result > 0)
            {
                MessageBox.Show("Data kelas berhasil dihapus !", "Informasi",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Data kelas gagal dihapus !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            return result;
        }
    }
}
