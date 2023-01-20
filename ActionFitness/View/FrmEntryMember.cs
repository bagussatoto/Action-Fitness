using ActionFitness.Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using ActionFitness.Model.Entitiy;
using ActionFitness.Controller;


namespace ActionFitness.View
{
    public partial class FrmEntryMember : Form
    {
        // deklarasi tipe data untuk event OnCreate dan OnUpdate
        public delegate void CreateUpdateEventHandler(Member mem);
        // deklarasi event ketika terjadi proses input data baru
        public event CreateUpdateEventHandler OnCreate;
        // deklarasi event ketika terjadi proses update data
        public event CreateUpdateEventHandler OnUpdate;
        // deklarasi objek controller
        private MemberController controller;
        // deklarasi field untuk menyimpan status entry data (input baru atau update)
        private bool isNewData = true;
        // deklarasi field untuk meyimpan objek mahasiswa
        private Member mem;


        public FrmEntryMember()
        {
            InitializeComponent();
        }

        // constructor untuk inisialisasi data ketika entri data baru
        public FrmEntryMember(string title, MemberController controller)
         : this()
        {
            // ganti text/judul form
            this.Text = title;
            this.controller = controller;
        }
        // constructor untuk inisialisasi data ketika mengedit data
        public FrmEntryMember(string title, Member obj, MemberController controller)
         : this()
        {
            // ganti text/judul form
            this.Text = title;
            this.controller = controller;
            isNewData = false; // set status edit data
            mem = obj; // set objek mhs yang akan diedit
                       // untuk edit data, tampilkan data lama
            txtIDMember.Text = mem.Id_Member;
            txtNama.Text = mem.Nama;
            txtAlamat.Text = mem.Alamat;
            txtNoHP.Text = mem.No_Hp;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Simpan_Click(object sender, EventArgs e)
        {
            // jika data baru, inisialisasi objek member
            if (isNewData) mem = new Member();
            // set nilai property objek mahasiswa yg diambil dari TextBox
            mem.Id_Member = txtIDMember.Text;
            mem.Nama = txtNama.Text;
            mem.Alamat = txtAlamat.Text;
            mem.No_Hp = txtNoHP.Text;
            int result = 0;
            if (isNewData) // tambah data baru, panggil method Create
            {
                // panggil operasi CRUD
                result = controller.Create(mem);
                if (result > 0) // tambah data berhasil
                {
                    OnCreate(mem); // panggil event OnCreate
                                   // reset form input, utk persiapan input data berikutnya
                    txtIDMember.Clear();
                    txtNama.Clear();
                    txtAlamat.Clear();
                    txtNoHP.Clear();
                    txtIDMember.Focus();
                }
            }
            else // edit data, panggil method Update
            {
                // panggil operasi CRUD
                result = controller.Update(mem);
                if (result > 0)
                {
                    OnUpdate(mem); // panggil event OnUpdate
                    this.Close();
                }
            }


        }

        private void Selesai_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
