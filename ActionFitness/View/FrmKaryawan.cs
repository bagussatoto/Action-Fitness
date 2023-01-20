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
    public partial class FrmKaryawan : Form
    {
        private List<Karyawan> listOfKaryawan = new List<Karyawan>();

        private KaryawanController karyawanController;

        public FrmKaryawan()
        {
            InitializeComponent();
            karyawanController = new KaryawanController();
            InisialisasiListView();
            LoadDataKaryawan();
        }

        // atur kolom listview
        private void InisialisasiListView()
        {
            lvwKaryawan.View = System.Windows.Forms.View.Details;
            lvwKaryawan.FullRowSelect = true;
            lvwKaryawan.GridLines = true;
            lvwKaryawan.Columns.Add("No.", 35, HorizontalAlignment.Center);
            lvwKaryawan.Columns.Add("ID Karyawan", 100, HorizontalAlignment.Center);
            lvwKaryawan.Columns.Add("Nama", 300, HorizontalAlignment.Center);
            lvwKaryawan.Columns.Add("Jabatan", 150, HorizontalAlignment.Center);
            lvwKaryawan.Columns.Add("Gaji", 100, HorizontalAlignment.Center);
            lvwKaryawan.Columns.Add("Shift", 80, HorizontalAlignment.Center);
            lvwKaryawan.Columns.Add("Nomor HP", 200, HorizontalAlignment.Center);
        }

        private void LoadDataKaryawan()
        {
            // kosongkan listview
            lvwKaryawan.Items.Clear();
            // panggil method ReadAll dan tampung datanya ke dalam collection
            listOfKaryawan = karyawanController.ReadAll();
            // ekstrak objek mhs dari collection
            foreach (var karyawan in listOfKaryawan)
            {
                var noUrut = lvwKaryawan.Items.Count + 1;
                var item = new ListViewItem(noUrut.ToString());
                item.SubItems.Add(karyawan.Id_Karyawan);
                item.SubItems.Add(karyawan.Nama_Karyawan);
                item.SubItems.Add(karyawan.Jabatan_Karyawan);
                item.SubItems.Add(karyawan.Gaji_Karyawan);
                item.SubItems.Add(karyawan.Shift_Karyawan);
                item.SubItems.Add(karyawan.No_Hp_Karyawan);
                // tampilkan data mem ke listview
                lvwKaryawan.Items.Add(item);
            }
        }

        // method event handler untuk merespon event OnCreate,
        private void OnCreateEventHandler(Karyawan kar)
        {
            // tambahkan objek mem yang baru ke dalam collection
            listOfKaryawan.Add(kar);
            int noUrut = lvwKaryawan.Items.Count + 1;
            // tampilkan data mem yg baru ke list view
            ListViewItem item = new ListViewItem(noUrut.ToString());
            item.SubItems.Add(kar.Id_Karyawan);
            item.SubItems.Add(kar.Nama_Karyawan);
            item.SubItems.Add(kar.Jabatan_Karyawan);
            item.SubItems.Add(kar.Gaji_Karyawan);
            item.SubItems.Add(kar.Shift_Karyawan);
            item.SubItems.Add(kar.No_Hp_Karyawan);
            // tampilkan data mhs ke listview
            lvwKaryawan.Items.Add(item);
        }

        private void OnUpdateEventHandler(Karyawan kar)
        {
            // ambil index data mem yang edit
            int index = lvwKaryawan.SelectedIndices[0];
            // update informasi mem di listview
            ListViewItem itemRow = lvwKaryawan.Items[index];
            itemRow.SubItems[1].Text = kar.Id_Karyawan;
            itemRow.SubItems[2].Text = kar.Nama_Karyawan;
            itemRow.SubItems[3].Text = kar.Jabatan_Karyawan;
            itemRow.SubItems[4].Text = kar.Gaji_Karyawan;
            itemRow.SubItems[5].Text = kar.Shift_Karyawan;
            itemRow.SubItems[6].Text = kar.No_Hp_Karyawan;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Selesai_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Cari_Click(object sender, EventArgs e)
        {
            // kosongkan listview
            lvwKaryawan.Items.Clear();
            // panggil method ReadByNama dan tampung datanya ke dalam collection
            listOfKaryawan = karyawanController.ReadByNama(txtnama.Text);
            // ekstrak objek kar dari collection
            foreach (var kar in listOfKaryawan)
            {
                var noUrut = lvwKaryawan.Items.Count + 1;
                var item = new ListViewItem(noUrut.ToString());
                item.SubItems.Add(kar.Id_Karyawan);
                item.SubItems.Add(kar.Nama_Karyawan);
                item.SubItems.Add(kar.Jabatan_Karyawan);
                item.SubItems.Add(kar.Gaji_Karyawan);
                item.SubItems.Add(kar.Shift_Karyawan);
                item.SubItems.Add(kar.No_Hp_Karyawan);
                // tampilkan data kar ke listview
                lvwKaryawan.Items.Add(item);
            }
        }

        private void Tambah_Click(object sender, EventArgs e)
        {
            // buat objek form entry data mahasiswa
            FrmEntryKaryawan frmEntry = new FrmEntryKaryawan("Tambah Data Karyawan", karyawanController);
            // mendaftarkan method event handler untuk merespon event OnCreate
            frmEntry.OnCreate += OnCreateEventHandler;
            // tampilkan form entry mahasiswa
            frmEntry.ShowDialog();
        }

        private void Perbaiki_Click(object sender, EventArgs e)
        {
            if(lvwKaryawan.SelectedItems.Count > 0)
            {
                // ambil objek mhs yang mau diedit dari collection
                Karyawan kar = listOfKaryawan[lvwKaryawan.SelectedIndices[0]];
                // buat objek form entry data mahasiswa
                FrmEntryKaryawan frmEntry = new FrmEntryKaryawan("Edit Data Karyawan", kar, karyawanController);
                // mendaftarkan method event handler untuk merespon event OnUpdate
                frmEntry.OnUpdate += OnUpdateEventHandler;
                // tampilkan form entry mahasiswa
                frmEntry.ShowDialog();
            }
            else // data belum dipilih
            {
                MessageBox.Show("Data belum dipilih", "Peringatan",
               MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation);
            }
        }

        private void Hapus_Click(object sender, EventArgs e)
        {
            if (lvwKaryawan.SelectedItems.Count > 0)
            {
                var konfirmasi = MessageBox.Show("Apakah data karyawan ingin dihapus ? ", "Konfirmasi",

                MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (konfirmasi == DialogResult.Yes)
                {
                    // ambil objek mhs yang mau dihapus dari collection
                    Karyawan kar = listOfKaryawan[lvwKaryawan.SelectedIndices[0]];
                    // panggil operasi CRUD
                    var result = karyawanController.Delete(kar);
                    if (result > 0) LoadDataKaryawan();
                }
            }
            else // data belum dipilih
            {
                MessageBox.Show("Data karyawan belum dipilih !!!", "Peringatan",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
