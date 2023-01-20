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
    public partial class FrmFasilitas : Form
    {
        private List<Fasilitas> listOfFas = new List<Fasilitas>();

        private FasilitasController fasController;

        public FrmFasilitas()
        {
            InitializeComponent();
            fasController = new FasilitasController();
            InisialisasiListView();
            LoadDataFas();
        }

        // atur kolom listview
        private void InisialisasiListView()
        {
            lvwfas.View = System.Windows.Forms.View.Details;
            lvwfas.FullRowSelect = true;
            lvwfas.GridLines = true;
            lvwfas.Columns.Add("No.", 35, HorizontalAlignment.Center);
            lvwfas.Columns.Add("ID Fasilitas", 91, HorizontalAlignment.Center);
            lvwfas.Columns.Add("Nama", 200, HorizontalAlignment.Left);
            lvwfas.Columns.Add("Ketersediaan", 80, HorizontalAlignment.Center);
            lvwfas.Columns.Add("ID Kelas", 91, HorizontalAlignment.Center);
        }

        private void LoadDataFas()
        {
            // kosongkan listview
            lvwfas.Items.Clear();
            // panggil method ReadAll dan tampung datanya ke dalam collection
            listOfFas = fasController.ReadAll();
            // ekstrak objek mhs dari collection
            foreach (var fas in listOfFas)
            {
                var noUrut = lvwfas.Items.Count + 1;
                var item = new ListViewItem(noUrut.ToString());
                item.SubItems.Add(fas.Id_Fasilitas);
                item.SubItems.Add(fas.Nama_Fasilitas);
                item.SubItems.Add(fas.Ketersediaan_Fasilitas);
                item.SubItems.Add(fas.Id_Kelas_Fasilitas);
                // tampilkan data mhs ke listview
                lvwfas.Items.Add(item);
            }
        }

        private void OnCreateEventHandler(Fasilitas fas)
        {
            // tambahkan objek mem yang baru ke dalam collection
            listOfFas.Add(fas);
            int noUrut = lvwfas.Items.Count + 1;
            // tampilkan data mem yg baru ke list view
            ListViewItem item = new ListViewItem(noUrut.ToString());
            item.SubItems.Add(fas.Id_Fasilitas);
            item.SubItems.Add(fas.Nama_Fasilitas);
            item.SubItems.Add(fas.Ketersediaan_Fasilitas);
            item.SubItems.Add(fas.Id_Kelas_Fasilitas);
            lvwfas.Items.Add(item);
        }

        private void OnUpdateEventHandler(Fasilitas fas)
        {
            // ambil index data mem yang edit
            int index = lvwfas.SelectedIndices[0];
            // update informasi mem di listview
            ListViewItem itemRow = lvwfas.Items[index];
            itemRow.SubItems[1].Text = fas.Id_Fasilitas;
            itemRow.SubItems[2].Text = fas.Nama_Fasilitas;
            itemRow.SubItems[3].Text = fas.Ketersediaan_Fasilitas;
            itemRow.SubItems[4].Text = fas.Id_Kelas_Fasilitas;

        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Tambah_Click(object sender, EventArgs e)
        {
            // buat objek form entry data mahasiswa
            FrmEntryFasilitas frmEntry = new FrmEntryFasilitas("Tambah Data Fasilitas", fasController);
            // mendaftarkan method event handler untuk merespon event OnCreate
            frmEntry.OnCreate += OnCreateEventHandler;
            // tampilkan form entry mahasiswa
            frmEntry.ShowDialog();
        }

        private void Perbaiki_Click(object sender, EventArgs e)
        {
            if (lvwfas.SelectedItems.Count > 0)
            {
                // ambil objek mhs yang mau diedit dari collection
                Fasilitas fas = listOfFas[lvwfas.SelectedIndices[0]];
                // buat objek form entry data mahasiswa
                FrmEntryFasilitas frmEntry = new FrmEntryFasilitas("Edit Data Fasilitas", fas, fasController);
                // mendaftarkan method event handler untuk merespon event OnUpdate
                frmEntry.OnUpdate += OnUpdateEventHandler;
                // tampilkan form entry fasilitas
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
            if (lvwfas.SelectedItems.Count > 0)
            {
                var konfirmasi = MessageBox.Show("Apakah data fasilitas ingin dihapus ? ", "Konfirmasi",

                MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (konfirmasi == DialogResult.Yes)
                {
                    // ambil objek mhs yang mau dihapus dari collection
                    Fasilitas fas = listOfFas[lvwfas.SelectedIndices[0]];
                    // panggil operasi CRUD
                    var result = fasController.Delete(fas);
                    if (result > 0) LoadDataFas();
                }
            }
            else // data belum dipilih
            {
                MessageBox.Show("Data fasilitas belum dipilih !!!", "Peringatan",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void Selesai_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Cari_Click(object sender, EventArgs e)
        {
            // kosongkan listview
            lvwfas.Items.Clear();
            // panggil method ReadByNama dan tampung datanya ke dalam collection
            listOfFas = fasController.ReadByNama(txtnama.Text);
            // ekstrak objek mhs dari collection
            foreach (var fas in listOfFas)
            {
                var noUrut = lvwfas.Items.Count + 1;
                var item = new ListViewItem(noUrut.ToString());
                item.SubItems.Add(fas.Id_Fasilitas);
                item.SubItems.Add(fas.Nama_Fasilitas);
                item.SubItems.Add(fas.Ketersediaan_Fasilitas);
                item.SubItems.Add(fas.Id_Kelas_Fasilitas);
                // tampilkan data mhs ke listview
                lvwfas.Items.Add(item);
            }
        }
    }
}
