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
    public partial class FrmEntryFasilitas : Form
    {
        // deklarasi tipe data untuk event OnCreate dan OnUpdate
        public delegate void CreateUpdateEventHandler(Fasilitas fas);
        // deklarasi event ketika terjadi proses input data baru
        public event CreateUpdateEventHandler OnCreate;
        // deklarasi event ketika terjadi proses update data
        public event CreateUpdateEventHandler OnUpdate;
        // deklarasi objek controller
        private FasilitasController controller;
        // deklarasi field untuk menyimpan status entry data (input baru atau update)
        private bool isNewData = true;
        // deklarasi field untuk meyimpan objek mahasiswa
        private Fasilitas fas;

        public FrmEntryFasilitas()
        {
            InitializeComponent();
        }

        // constructor untuk inisialisasi data ketika entri data baru
        public FrmEntryFasilitas(string title, FasilitasController controller)
         : this()
        {
            // ganti text/judul form
            this.Text = title;
            this.controller = controller;
        }
        // constructor untuk inisialisasi data ketika mengedit data
        public FrmEntryFasilitas(string title, Fasilitas obj, FasilitasController controller)
         : this()
        {
            // ganti text/judul form
            this.Text = title;
            this.controller = controller;
            isNewData = false; // set status edit data
            fas = obj; // set objek fas yang akan diedit
                       // untuk edit data, tampilkan data lama
            txtidfal.Text = fas.Id_Fasilitas;
            txtnamafal.Text = fas.Nama_Fasilitas;
            txtketfal.Text = fas.Ketersediaan_Fasilitas;
            txtidkel.Text = fas.Id_Kelas_Fasilitas;
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void Simpan_Click(object sender, EventArgs e)
        {
            // jika data baru, inisialisasi objek fasilitas
            if (isNewData) fas = new Fasilitas();
            // set nilai property objek mahasiswa yg diambil dari TextBox
            fas.Id_Fasilitas = txtidfal.Text;
            fas.Nama_Fasilitas = txtnamafal.Text;
            fas.Ketersediaan_Fasilitas = txtketfal.Text;
            fas.Id_Kelas_Fasilitas = txtidkel.Text;
            int result = 0;
            if (isNewData) // tambah data baru, panggil method Create
            {
                // panggil operasi CRUD
                result = controller.Create(fas);
                if (result > 0) // tambah data berhasil
                {
                    OnCreate(fas); // panggil event OnCreate
                                   // reset form input, utk persiapan input data berikutnya
                    txtidfal.Clear();
                    txtnamafal.Clear();
                    txtketfal.Clear();
                    txtidkel.Clear();
                    txtidfal.Focus();
                }
            }
            else // edit data, panggil method Update
            {
                // panggil operasi CRUD
                result = controller.Update(fas);
                if (result > 0)
                {
                    OnUpdate(fas); // panggil event OnUpdate
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
