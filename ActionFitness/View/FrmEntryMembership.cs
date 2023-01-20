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
    public partial class FrmEntryMembership : Form
    {
        // deklarasi tipe data untuk event OnCreate dan OnUpdate
        public delegate void CreateUpdateEventHandler(Membership shp);
        // deklarasi event ketika terjadi proses input data baru
        public event CreateUpdateEventHandler OnCreate;
        // deklarasi event ketika terjadi proses update data
        public event CreateUpdateEventHandler OnUpdate;
        // deklarasi objek controller
        private MembershipController controller;
        // deklarasi field untuk menyimpan status entry data (input baru atau update)
        private bool isNewData = true;
        // deklarasi field untuk meyimpan objek mahasiswa
        private Membership shp;

        public FrmEntryMembership()
        {
            InitializeComponent();
        }

        // constructor untuk inisialisasi data ketika entri data baru
        public FrmEntryMembership(string title, MembershipController controller)
         : this()
        {
            // ganti text/judul form
            this.Text = title;
            this.controller = controller;
        }
        // constructor untuk inisialisasi data ketika mengedit data
        public FrmEntryMembership(string title, Membership obj, MembershipController controller)
         : this()
        {
            // ganti text/judul form
            this.Text = title;
            this.controller = controller;
            isNewData = false; // set status edit data
            shp = obj; // set objek mhs yang akan diedit
                       // untuk edit data, tampilkan data lama
            txtmembermembership.Text = shp.Id_Member_Membership;
            txtmembership.Text = shp.Id_Membership;
            txtlevel.Text = shp.Level_Membership;
            txtkelas.Text = shp.Id_Kelas_Membership;
        }

        private void Simpan_Click(object sender, EventArgs e)
        {
            // jika data baru, inisialisasi objek member
            if (isNewData) shp = new Membership();
            // set nilai property objek mahasiswa yg diambil dari TextBox
            shp.Id_Membership = txtmembership.Text;
            shp.Id_Member_Membership = txtmembermembership.Text;
            shp.Level_Membership = txtlevel.Text;
            shp.Id_Kelas_Membership = txtkelas.Text;
            int result = 0;
            if (isNewData) // tambah data baru, panggil method Create
            {
                // panggil operasi CRUD
                result = controller.Create(shp);
                if (result > 0) // tambah data berhasil
                {
                    OnCreate(shp); // panggil event OnCreate
                                   // reset form input, utk persiapan input data berikutnya
                    txtmembership.Clear();
                    txtmembermembership.Clear();
                    txtlevel.Clear();
                    txtkelas.Clear();
                    txtmembership.Focus();
                }
            }
            else // edit data, panggil method Update
            {
                // panggil operasi CRUD
                result = controller.Update(shp);
                if (result > 0)
                {
                    OnUpdate(shp); // panggil event OnUpdate
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
