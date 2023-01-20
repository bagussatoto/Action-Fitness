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
    public class FasilitasController
    {
        private FasilitasRepository _fasilitasRepository;

        public int Create(Fasilitas fas)
        {
            int result = 0;
            // cek id fasilitas yang diinputkan tidak boleh kosong
            if (string.IsNullOrEmpty(fas.Id_Fasilitas))
            {
                MessageBox.Show("ID Fasilitas harus diisi !!!", "Peringatan",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }
            // cek nama yang diinputkan tidak boleh kosong
            if (string.IsNullOrEmpty(fas.Nama_Fasilitas))
            {
                MessageBox.Show("Nama Fasilitas harus diisi !!!", "Peringatan",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }
            // cek Ketersediaan yang diinputkan tidak boleh kosong
            if (string.IsNullOrEmpty(fas.Ketersediaan_Fasilitas))
            {
                MessageBox.Show("Ketersediaan Fasilitas harus diisi !!!", "Peringatan",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }
            // cek ID Kelas yang diinputkan tidak boleh kosong
            if (string.IsNullOrEmpty(fas.Id_Kelas_Fasilitas))
            {
                MessageBox.Show("ID Kelas harus diisi !!!", "Peringatan",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }
            // membuat objek context menggunakan blok using
            using (DbContextMember contextMember = new DbContextMember())
            {
                // membuat objek class repository
                _fasilitasRepository = new FasilitasRepository(contextMember);
                // panggil method Create class repository untuk menambahkan data
                result = _fasilitasRepository.Create(fas);
            }
            if (result > 0)
            {
                MessageBox.Show("Data fasilitas berhasil disimpan !", "Informasi",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Data fasilitas gagal disimpan !!!", "Peringatan",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            return result;
        }

        public List<Fasilitas> ReadAll()
        {
            // membuat objek collection
            List<Fasilitas> list = new List<Fasilitas>();
            // membuat objek context menggunakan blok using
            using (DbContextMember context = new DbContextMember())
            {
                // membuat objek dari class repository
                _fasilitasRepository = new FasilitasRepository(context);
                // panggil method GetAll yang ada di dalam class repository
                list = _fasilitasRepository.ReadAll();
            }
            return list;
        }

        /// <summary>
        /// Method untuk menampilkan data mahasiwa berdasarkan nama
        /// </summary>
        /// <param name="nama"></param>
        /// <returns></returns>
        public List<Fasilitas> ReadByNama(string nama)
        {
            // membuat objek collection
            List<Fasilitas> list = new List<Fasilitas>();

            // membuat objek context menggunakan blok using
            using (DbContextMember context = new DbContextMember())
            {
                // membuat objek dari class repository
                _fasilitasRepository = new FasilitasRepository(context);

                // panggil method ReadByNama yang ada di dalam class repository
                list = _fasilitasRepository.ReadByNama(nama);
            }

            return list;
        }

        public int Update(Fasilitas fas)
        {
            int result = 0;

            if (string.IsNullOrEmpty(fas.Id_Fasilitas))
            {
                MessageBox.Show("ID Fasilitas harus diisi !!!", "Peringatan",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }
            // cek nama yang diinputkan tidak boleh kosong
            if (string.IsNullOrEmpty(fas.Nama_Fasilitas))
            {
                MessageBox.Show("Nama Fasilitas harus diisi !!!", "Peringatan",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }
            // cek Ketersediaan yang diinputkan tidak boleh kosong
            if (string.IsNullOrEmpty(fas.Ketersediaan_Fasilitas))
            {
                MessageBox.Show("Ketersediaan Fasilitas harus diisi !!!", "Peringatan",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }
            // cek ID Kelas yang diinputkan tidak boleh kosong
            if (string.IsNullOrEmpty(fas.Id_Kelas_Fasilitas))
            {
                MessageBox.Show("ID Kelas harus diisi !!!", "Peringatan",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }
            // membuat objek context menggunakan blok using
            using (DbContextMember context = new DbContextMember())
            {
                // membuat objek dari class repository
                _fasilitasRepository = new FasilitasRepository(context);

                // panggil method Update class repository untuk mengupdate data
                result = _fasilitasRepository.Update(fas);
            }

            if (result > 0)
            {
                MessageBox.Show("Data Fasilitas berhasil diupdate !", "Informasi",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Data Fasilitas gagal diupdate !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            return result;
        }

        public int Delete(Fasilitas fas)
        {
            int result = 0;

            // cek nilai npm yang diinputkan tidak boleh kosong
            if (string.IsNullOrEmpty(fas.Id_Fasilitas))
            {
                MessageBox.Show("ID Fasilitas harus diisi !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            // membuat objek context menggunakan blok using
            using (DbContextMember context = new DbContextMember())
            {
                // membuat objek dari class repository
                _fasilitasRepository = new FasilitasRepository(context);

                // panggil method Delete class repository untuk menghapus data
                result = _fasilitasRepository.Delete(fas);
            }

            if (result > 0)
            {
                MessageBox.Show("Data Fasilitas berhasil dihapus !", "Informasi",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Data Fasilitas gagal dihapus !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            return result;
        }
    }
}
