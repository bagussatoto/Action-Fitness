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
    public partial class FrmMembership : Form
    {
        private List<Membership> listOfMembership = new List<Membership>();

        private MembershipController membershipController;

        public FrmMembership()
        {
            InitializeComponent();
            membershipController = new MembershipController();
            InisialisasiListView();
            LoadDataMembership();
        }

        // atur kolom listview
        private void InisialisasiListView()
        {
            lvwmembership.View = System.Windows.Forms.View.Details;
            lvwmembership.FullRowSelect = true;
            lvwmembership.GridLines = true;
            lvwmembership.Columns.Add("No.", 35, HorizontalAlignment.Center);
            lvwmembership.Columns.Add("ID Membership", 120, HorizontalAlignment.Center);
            lvwmembership.Columns.Add("ID Member", 120, HorizontalAlignment.Center);
            lvwmembership.Columns.Add("Level Membership", 200, HorizontalAlignment.Center);
            lvwmembership.Columns.Add("ID Kelas", 120, HorizontalAlignment.Center);
        }

        private void LoadDataMembership()
        {
            // kosongkan listview
            lvwmembership.Items.Clear();
            // panggil method ReadAll dan tampung datanya ke dalam collection
            listOfMembership = membershipController.ReadAll();
            // ekstrak objek mhs dari collection
            foreach (var shp in listOfMembership)
            {
                var noUrut = lvwmembership.Items.Count + 1;
                var item = new ListViewItem(noUrut.ToString());
                item.SubItems.Add(shp.Id_Membership);
                item.SubItems.Add(shp.Id_Member_Membership);
                item.SubItems.Add(shp.Level_Membership);
                item.SubItems.Add(shp.Id_Kelas_Membership);
                // tampilkan data mhs ke listview
                lvwmembership.Items.Add(item);
            }
        }

        // method event handler untuk merespon event OnCreate,
        private void OnCreateEventHandler(Membership shp)
        {
            // tambahkan objek mem yang baru ke dalam collection
            listOfMembership.Add(shp);
            int noUrut = lvwmembership.Items.Count + 1;
            // tampilkan data mem yg baru ke list view
            ListViewItem item = new ListViewItem(noUrut.ToString());
            item.SubItems.Add(shp.Id_Membership);
            item.SubItems.Add(shp.Id_Member_Membership);
            item.SubItems.Add(shp.Level_Membership);
            item.SubItems.Add(shp.Id_Kelas_Membership);
            lvwmembership.Items.Add(item);
        }

        private void OnUpdateEventHandler(Membership shp)
        {
            // ambil index data mem yang edit
            int index = lvwmembership.SelectedIndices[0];
            // update informasi mem di listview
            ListViewItem itemRow = lvwmembership.Items[index];
            itemRow.SubItems[1].Text = shp.Id_Membership;
            itemRow.SubItems[2].Text = shp.Id_Member_Membership;
            itemRow.SubItems[3].Text = shp.Level_Membership;
            itemRow.SubItems[4].Text = shp.Id_Kelas_Membership;
        }


        private void Selesai_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Cari_Click(object sender, EventArgs e)
        {
            // kosongkan listview
            lvwmembership.Items.Clear();
            // panggil method ReadByNama dan tampung datanya ke dalam collection
            listOfMembership = membershipController.ReadByMember(txtmember.Text);
            // ekstrak objek mhs dari collection
            foreach (var shp in listOfMembership)
            {
                var noUrut = lvwmembership.Items.Count + 1;
                var item = new ListViewItem(noUrut.ToString());
                item.SubItems.Add(shp.Id_Membership);
                item.SubItems.Add(shp.Id_Member_Membership);
                item.SubItems.Add(shp.Level_Membership);
                item.SubItems.Add(shp.Id_Kelas_Membership);
                // tampilkan data mhs ke listview
                lvwmembership.Items.Add(item);
            }
        }

        private void Perbaiki_Click(object sender, EventArgs e)
        {
            if (lvwmembership.SelectedItems.Count > 0)
            {
                // ambil objek mhs yang mau diedit dari collection
                Membership shp = listOfMembership[lvwmembership.SelectedIndices[0]];
                // buat objek form entry data mahasiswa
                FrmEntryMembership frmEntry = new FrmEntryMembership("Edit Data Member", shp, membershipController);
                // mendaftarkan method event handler untuk merespon event OnUpdate
                frmEntry.OnUpdate += OnUpdateEventHandler;
                // tampilkan form entry member
                frmEntry.ShowDialog();
            }
            else // data belum dipilih
            {
                MessageBox.Show("Data belum dipilih", "Peringatan",
                MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation);
            }
        }

        private void Tambah_Click(object sender, EventArgs e)
        {
            // buat objek form entry data mahasiswa
            FrmEntryMembership frmEntry = new FrmEntryMembership("Tambah Data Membership", membershipController);
            // mendaftarkan method event handler untuk merespon event OnCreate
            frmEntry.OnCreate += OnCreateEventHandler;
            // tampilkan form entry mahasiswa
            frmEntry.ShowDialog();
        }

        private void Hapus_Click(object sender, EventArgs e)
        {
            if (lvwmembership.SelectedItems.Count > 0)
            {
                var konfirmasi = MessageBox.Show("Apakah data membership ingin dihapus ? ", "Konfirmasi",

                MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (konfirmasi == DialogResult.Yes)
                {
                    // ambil objek mhs yang mau dihapus dari collection
                    Membership shp =
                   listOfMembership[lvwmembership.SelectedIndices[0]];
                    // panggil operasi CRUD
                    var result = membershipController.Delete(shp);
                    if (result > 0) LoadDataMembership();
                }
            }
            else // data belum dipilih
            {
                MessageBox.Show("Data membership belum dipilih !!!", "Peringatan",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
