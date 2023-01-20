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
    public partial class FrmEntryKelas : Form
    {
        // deklarasi tipe data untuk event OnCreate dan OnUpdate
        public delegate void CreateUpdateEventHandler(Kelas kel);
        // deklarasi event ketika terjadi proses input data baru
        public event CreateUpdateEventHandler OnCreate;
        // deklarasi event ketika terjadi proses update data
        public event CreateUpdateEventHandler OnUpdate;
        // deklarasi objek controller
        private KelasController controller;
        // deklarasi field untuk menyimpan status entry data (input baru atau update)
        private bool isNewData = true;
        // deklarasi field untuk meyimpan objek mahasiswa
        private Kelas kel;

        public FrmEntryKelas()
        {
            InitializeComponent();
        }

        // constructor untuk inisialisasi data ketika entri data baru
        public FrmEntryKelas(string title, KelasController kelcontroller)
         : this()
        {
            // ganti text/judul form
            this.Text = title;
            this.controller = kelcontroller;
        }
        // constructor untuk inisialisasi data ketika mengedit data
        public FrmEntryKelas(string title, Kelas obj, KelasController kelcontroller)
         : this()
        {
            // ganti text/judul form
            this.Text = title;
            this.controller = kelcontroller;
            isNewData = false; // set status edit data
            kel = obj; // set objek mhs yang akan diedit
                       // untuk edit data, tampilkan data lama
            idkelas.Text = kel.Id_Kelas;
            namakelas.Text = kel.Nama_Kelas;
            harikelas.Text = kel.Hari_Kelas;
            ruangankelas.Text = kel.Ruangan_Kelas;
            kapasitaskelas.Text = kel.Kapasitas_Kelas;
            
        }

        private void Simpan_Click(object sender, EventArgs e)
        {
            // jika data baru, inisialisasi objek mahasiswa
            if (isNewData) kel = new Kelas();
            // set nilai property objek mahasiswa yg diambil dari TextBox
            kel.Id_Kelas = idkelas.Text;
            kel.Nama_Kelas = namakelas.Text;
            kel.Hari_Kelas = harikelas.Text;
            kel.Ruangan_Kelas = ruangankelas.Text;
            kel.Kapasitas_Kelas = kapasitaskelas.Text;
            int result = 0;
            if (isNewData) // tambah data baru, panggil method Create
            {
                // panggil operasi CRUD
                result = controller.Create(kel);
                if (result > 0) // tambah data berhasil
                {
                    OnCreate(kel); // panggil event OnCreate
                                   // reset form input, utk persiapan input data berikutnya
                    idkelas.Clear();
                    namakelas.Clear();
                    harikelas.Clear();
                    ruangankelas.Clear();
                    kapasitaskelas.Clear();
                    idkelas.Focus();
                }
            }
            else // edit data, panggil method Update
            {
                // panggil operasi CRUD
                result = controller.Update(kel);
                if (result > 0)
                {
                    OnUpdate(kel); // panggil event OnUpdate
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
