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
    public partial class FrmKelas : Form
    {
        private List<Kelas> listOfKelas = new List<Kelas>();

        private KelasController kelasController;

        public FrmKelas()
        {
            InitializeComponent();
            kelasController = new KelasController();
            InisialisasiListView();
            LoadDataKelas();
        }

        // atur kolom listview
        private void InisialisasiListView()
        {
            listView1.View = System.Windows.Forms.View.Details;
            listView1.FullRowSelect = true;
            listView1.GridLines = true;
            listView1.Columns.Add("No.", 35, HorizontalAlignment.Center);
            listView1.Columns.Add("ID Kelas", 100, HorizontalAlignment.Center);
            listView1.Columns.Add("Nama", 200, HorizontalAlignment.Center);
            listView1.Columns.Add("Hari", 150, HorizontalAlignment.Center);
            listView1.Columns.Add("Ruangan", 150, HorizontalAlignment.Center);
            listView1.Columns.Add("Kapasitas", 80, HorizontalAlignment.Center);
        }

        private void LoadDataKelas()
        {
            // kosongkan listview
            listView1.Items.Clear();
            // panggil method ReadAll dan tampung datanya ke dalam collection
            listOfKelas = kelasController.ReadAll();
            // ekstrak objek mhs dari collection
            foreach (var kelas in listOfKelas)
            {
                var noUrut = listView1.Items.Count + 1;
                var item = new ListViewItem(noUrut.ToString());
                item.SubItems.Add(kelas.Id_Kelas);
                item.SubItems.Add(kelas.Nama_Kelas);
                item.SubItems.Add(kelas.Hari_Kelas);
                item.SubItems.Add(kelas.Ruangan_Kelas);
                item.SubItems.Add(kelas.Kapasitas_Kelas);
                // tampilkan data mem ke listview
                listView1.Items.Add(item);
            }
        }

        // method event handler untuk merespon event OnCreate,
        private void OnCreateEventHandler(Kelas kel)
        {
            // tambahkan objek mem yang baru ke dalam collection
            listOfKelas.Add(kel);
            int noUrut = listView1.Items.Count + 1;
            // tampilkan data mem yg baru ke list view
            ListViewItem item = new ListViewItem(noUrut.ToString());
            item.SubItems.Add(kel.Id_Kelas);
            item.SubItems.Add(kel.Nama_Kelas);
            item.SubItems.Add(kel.Hari_Kelas);
            item.SubItems.Add(kel.Ruangan_Kelas);
            item.SubItems.Add(kel.Kapasitas_Kelas);
            // tampilkan data mhs ke listview
            listView1.Items.Add(item);
        }

        private void OnUpdateEventHandler(Kelas kel)
        {
            // ambil index data mem yang edit
            int index = listView1.SelectedIndices[0];
            // update informasi mem di listview
            ListViewItem itemRow = listView1.Items[index];
            itemRow.SubItems[1].Text = kel.Id_Kelas;
            itemRow.SubItems[2].Text = kel.Nama_Kelas;
            itemRow.SubItems[3].Text = kel.Hari_Kelas;
            itemRow.SubItems[4].Text = kel.Ruangan_Kelas;
            itemRow.SubItems[5].Text = kel.Kapasitas_Kelas;
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Selesai_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Cari_Click(object sender, EventArgs e)
        {
            // kosongkan listview
            listView1.Items.Clear();
            // panggil method ReadByNama dan tampung datanya ke dalam collection
            listOfKelas = kelasController.ReadByNama(txtnama.Text);
            // ekstrak objek kar dari collection
            foreach (var kel in listOfKelas)
            {
                var noUrut = listView1.Items.Count + 1;
                var item = new ListViewItem(noUrut.ToString());
                item.SubItems.Add(kel.Id_Kelas);
                item.SubItems.Add(kel.Nama_Kelas);
                item.SubItems.Add(kel.Hari_Kelas);
                item.SubItems.Add(kel.Ruangan_Kelas);
                item.SubItems.Add(kel.Kapasitas_Kelas);
                // tampilkan data kar ke listview
                listView1.Items.Add(item);
            }
        }

        private void Tambah_Click(object sender, EventArgs e)
        {
            // buat objek form entry data mahasiswa
            FrmEntryKelas frmEntry = new FrmEntryKelas("Tambah Data Kelas", kelasController);
            // mendaftarkan method event handler untuk merespon event OnCreate
            frmEntry.OnCreate += OnCreateEventHandler;
            // tampilkan form entry mahasiswa
            frmEntry.ShowDialog();
        }

        private void Perbaiki_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                // ambil objek mhs yang mau diedit dari collection
                Kelas kel = listOfKelas[listView1.SelectedIndices[0]];
                // buat objek form entry data mahasiswa
                FrmEntryKelas frmEntry = new FrmEntryKelas("Edit Data Kelas", kel, kelasController);
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
            if (listView1.SelectedItems.Count > 0)
            {
                var konfirmasi = MessageBox.Show("Apakah data kelas ingin dihapus ? ", "Konfirmasi",

                MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (konfirmasi == DialogResult.Yes)
                {
                    // ambil objek mhs yang mau dihapus dari collection
                    Kelas kel = listOfKelas[listView1.SelectedIndices[0]];
                    // panggil operasi CRUD
                    var result = kelasController.Delete(kel);
                    if (result > 0) LoadDataKelas();
                }
            }
            else // data belum dipilih
            {
                MessageBox.Show("Data kelas belum dipilih !!!", "Peringatan",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
