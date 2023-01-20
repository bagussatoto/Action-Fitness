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
    public partial class FrmEntryKaryawan : Form
    {
        // deklarasi tipe data untuk event OnCreate dan OnUpdate
        public delegate void CreateUpdateEventHandler(Karyawan kar);
        // deklarasi event ketika terjadi proses input data baru
        public event CreateUpdateEventHandler OnCreate;
        // deklarasi event ketika terjadi proses update data
        public event CreateUpdateEventHandler OnUpdate;
        // deklarasi objek controller
        private KaryawanController controller;
        // deklarasi field untuk menyimpan status entry data (input baru atau update)
        private bool isNewData = true;
        // deklarasi field untuk meyimpan objek mahasiswa
        private Karyawan kar;


        public FrmEntryKaryawan()
        {
            InitializeComponent();
        }

        // constructor untuk inisialisasi data ketika entri data baru
        public FrmEntryKaryawan(string title, KaryawanController karcontroller)
         : this()
        {
            // ganti text/judul form
            this.Text = title;
            this.controller = karcontroller;
        }
        // constructor untuk inisialisasi data ketika mengedit data
        public FrmEntryKaryawan(string title, Karyawan obj, KaryawanController karcontroller)
         : this()
        {
            // ganti text/judul form
            this.Text = title;
            this.controller = karcontroller;
            isNewData = false; // set status edit data
            kar = obj; // set objek mhs yang akan diedit
                       // untuk edit data, tampilkan data lama
            txtidkaryawan.Text = kar.Id_Karyawan;
            txtnamakaryawan.Text = kar.Nama_Karyawan;
            txtjabatankaryawan.Text = kar.Jabatan_Karyawan;
            txtgajikaryawan.Text = kar.Gaji_Karyawan;
            txtshiftkaryawan.Text = kar.Shift_Karyawan;
            txtnohpkaryawan.Text = kar.No_Hp_Karyawan;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Simpan_Click(object sender, EventArgs e)
        {
            // jika data baru, inisialisasi objek mahasiswa
            if (isNewData) kar = new Karyawan();
            // set nilai property objek mahasiswa yg diambil dari TextBox
            kar.Id_Karyawan = txtidkaryawan.Text;
            kar.Nama_Karyawan = txtnamakaryawan.Text;
            kar.Jabatan_Karyawan = txtjabatankaryawan.Text;
            kar.Gaji_Karyawan = txtgajikaryawan.Text;
            kar.Shift_Karyawan = txtshiftkaryawan.Text;
            kar.No_Hp_Karyawan = txtnohpkaryawan.Text;
            int result = 0;
            if (isNewData) // tambah data baru, panggil method Create
            {
                // panggil operasi CRUD
                result = controller.Create(kar);
                if (result > 0) // tambah data berhasil
                {
                    OnCreate(kar); // panggil event OnCreate
                                   // reset form input, utk persiapan input data berikutnya
                    txtidkaryawan.Clear();
                    txtnamakaryawan.Clear();
                    txtjabatankaryawan.Clear();
                    txtgajikaryawan.Clear();
                    txtshiftkaryawan.Clear();
                    txtnohpkaryawan.Clear();
                    txtidkaryawan.Focus();
                }
            }
            else // edit data, panggil method Update
            {
                // panggil operasi CRUD
                result = controller.Update(kar);
                if (result > 0)
                {
                    OnUpdate(kar); // panggil event OnUpdate
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