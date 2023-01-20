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
    public class MemberController
    {
        private MemberRepository _memberRepository;

        public int Create(Member mem)
        {
            int result = 0;
            // cek npm yang diinputkan tidak boleh kosong
            if (string.IsNullOrEmpty(mem.Id_Member))
            {
                MessageBox.Show("ID Member harus diisi !!!", "Peringatan",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }
            // cek nama yang diinputkan tidak boleh kosong
            if (string.IsNullOrEmpty(mem.Nama))
            {
                MessageBox.Show("Nama harus diisi !!!", "Peringatan",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }
            // cek angkatan yang diinputkan tidak boleh kosong
            if (string.IsNullOrEmpty(mem.Alamat))
            {
                MessageBox.Show("Alamat harus diisi !!!", "Peringatan",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }
            // cek angkatan yang diinputkan tidak boleh kosong
            if (string.IsNullOrEmpty(mem.No_Hp))
            {
                MessageBox.Show("Nomor HP harus diisi !!!", "Peringatan",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }
            // membuat objek context menggunakan blok using
            using (DbContextMember contextMember = new DbContextMember())
            {
                // membuat objek class repository
                _memberRepository = new MemberRepository(contextMember);
                // panggil method Create class repository untuk menambahkan data
                result = _memberRepository.Create(mem);
            }
            if (result > 0)
            {
                MessageBox.Show("Data member berhasil disimpan !", "Informasi",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Data member gagal disimpan !!!", "Peringatan",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            return result;
        }

        public List<Member> ReadAll()
        {
            // membuat objek collection
            List<Member> list = new List<Member>();
            // membuat objek context menggunakan blok using
            using (DbContextMember context = new DbContextMember())
            {
                // membuat objek dari class repository
                _memberRepository = new MemberRepository(context);
                // panggil method GetAll yang ada di dalam class repository
                list = _memberRepository.ReadAll();
            }
            return list;
        }

        /// <summary>
        /// Method untuk menampilkan data mahasiwa berdasarkan nama
        /// </summary>
        /// <param name="nama"></param>
        /// <returns></returns>
        public List<Member> ReadByNama(string nama)
        {
            // membuat objek collection
            List<Member> list = new List<Member>();

            // membuat objek context menggunakan blok using
            using (DbContextMember context = new DbContextMember())
            {
                // membuat objek dari class repository
                _memberRepository = new MemberRepository(context);

                // panggil method ReadByNama yang ada di dalam class repository
                list = _memberRepository.ReadByNama(nama);
            }

            return list;
        }

        public int Update(Member mem)
        {
            int result = 0;

            // cek ID Member yang diinputkan tidak boleh kosong
            if (string.IsNullOrEmpty(mem.Id_Member))
            {
                MessageBox.Show("ID Member harus diisi !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            // cek nama yang diinputkan tidak boleh kosong
            if (string.IsNullOrEmpty(mem.Nama))
            {
                MessageBox.Show("Nama harus diisi !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            // cek angkatan yang diinputkan tidak boleh kosong
            if (string.IsNullOrEmpty(mem.Alamat))
            {
                MessageBox.Show("Angkatan harus diisi !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            if (string.IsNullOrEmpty(mem.No_Hp))
            {
                MessageBox.Show("Nomor HP harus diisi !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            // membuat objek context menggunakan blok using
            using (DbContextMember context = new DbContextMember())
            {
                // membuat objek dari class repository
                _memberRepository = new MemberRepository(context);

                // panggil method Update class repository untuk mengupdate data
                result = _memberRepository.Update(mem);
            }

            if (result > 0)
            {
                MessageBox.Show("Data member berhasil diupdate !", "Informasi",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Data member gagal diupdate !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            return result;
        }

        public int Delete(Member mem)
        {
            int result = 0;

            // cek nilai npm yang diinputkan tidak boleh kosong
            if (string.IsNullOrEmpty(mem.Id_Member))
            {
                MessageBox.Show("ID Member harus diisi !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            // membuat objek context menggunakan blok using
            using (DbContextMember context = new DbContextMember())
            {
                // membuat objek dari class repository
                _memberRepository = new MemberRepository(context);

                // panggil method Delete class repository untuk menghapus data
                result = _memberRepository.Delete(mem);
            }

            if (result > 0)
            {
                MessageBox.Show("Data member berhasil dihapus !", "Informasi",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Data member gagal dihapus !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            return result;
        }

    }
}
