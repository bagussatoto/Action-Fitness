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
    public partial class FrmMember : Form
    {
        private List<Member> listOfMember = new List<Member>();

        private MemberController memberController;
        
        public FrmMember()
        {
            InitializeComponent();
            memberController = new MemberController();
            InisialisasiListView();
            LoadDataMember();
        }

        // atur kolom listview
        private void InisialisasiListView()
        {
            lvwMember.View = System.Windows.Forms.View.Details;
            lvwMember.FullRowSelect = true;
            lvwMember.GridLines = true;
            lvwMember.Columns.Add("No.", 35, HorizontalAlignment.Center);
            lvwMember.Columns.Add("ID Member", 91, HorizontalAlignment.Center);
            lvwMember.Columns.Add("Nama", 350, HorizontalAlignment.Left);
            lvwMember.Columns.Add("Alamat", 80, HorizontalAlignment.Center);
            lvwMember.Columns.Add("Nomor HP", 200, HorizontalAlignment.Center);
        }

        private void LoadDataMember()
        {
            // kosongkan listview
            lvwMember.Items.Clear();
            // panggil method ReadAll dan tampung datanya ke dalam collection
            listOfMember = memberController.ReadAll();
            // ekstrak objek mhs dari collection
            foreach (var mem in listOfMember)
            {
                var noUrut = lvwMember.Items.Count + 1;
                var item = new ListViewItem(noUrut.ToString());
                item.SubItems.Add(mem.Id_Member);
                item.SubItems.Add(mem.Nama);
                item.SubItems.Add(mem.Alamat);
                item.SubItems.Add(mem.No_Hp);
                // tampilkan data mhs ke listview
                lvwMember.Items.Add(item);
            }
        }

        // method event handler untuk merespon event OnCreate,
        private void OnCreateEventHandler(Member mem)
        {
            // tambahkan objek mem yang baru ke dalam collection
            listOfMember.Add(mem);
            int noUrut = lvwMember.Items.Count + 1;
            // tampilkan data mem yg baru ke list view
            ListViewItem item = new ListViewItem(noUrut.ToString());
            item.SubItems.Add(mem.Id_Member);
            item.SubItems.Add(mem.Nama);
            item.SubItems.Add(mem.Alamat);
            item.SubItems.Add(mem.No_Hp);
            lvwMember.Items.Add(item);
        }

        private void OnUpdateEventHandler(Member mem)
        {
            // ambil index data mem yang edit
            int index = lvwMember.SelectedIndices[0];
            // update informasi mem di listview
            ListViewItem itemRow = lvwMember.Items[index];
            itemRow.SubItems[1].Text = mem.Id_Member;
            itemRow.SubItems[2].Text = mem.Nama;
            itemRow.SubItems[3].Text = mem.Alamat;
            itemRow.SubItems[4].Text = mem.No_Hp;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // kosongkan listview
            lvwMember.Items.Clear();
            // panggil method ReadByNama dan tampung datanya ke dalam collection
            listOfMember = memberController.ReadByNama(txtNama.Text);
            // ekstrak objek mhs dari collection
            foreach (var mem in listOfMember)
            {
                var noUrut = lvwMember.Items.Count + 1;
                var item = new ListViewItem(noUrut.ToString());
                item.SubItems.Add(mem.Id_Member);
                item.SubItems.Add(mem.Nama);
                item.SubItems.Add(mem.Alamat);
                item.SubItems.Add(mem.No_Hp);
                // tampilkan data mhs ke listview
                lvwMember.Items.Add(item);
            }
        }

        private void Selesai_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Tambah_Click(object sender, EventArgs e)
        {
            // buat objek form entry data mahasiswa
            FrmEntryMember frmEntry = new FrmEntryMember("Tambah Data Member", memberController);
            // mendaftarkan method event handler untuk merespon event OnCreate
            frmEntry.OnCreate += OnCreateEventHandler;
            // tampilkan form entry mahasiswa
            frmEntry.ShowDialog();

        }

        private void Perbaiki_Click(object sender, EventArgs e)
        {
            if (lvwMember.SelectedItems.Count > 0)
            {
                // ambil objek mhs yang mau diedit dari collection
                Member mem = listOfMember[lvwMember.SelectedIndices[0]];
                // buat objek form entry data mahasiswa
                FrmEntryMember frmEntry = new FrmEntryMember("Edit Data Member", mem, memberController);
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

        private void Hapus_Click(object sender, EventArgs e)
        {
            if (lvwMember.SelectedItems.Count > 0)
            {
                var konfirmasi = MessageBox.Show("Apakah data member ingin dihapus ? ", "Konfirmasi",

                MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (konfirmasi == DialogResult.Yes)
                {
                    // ambil objek mhs yang mau dihapus dari collection
                    Member mem =
                   listOfMember[lvwMember.SelectedIndices[0]];
                    // panggil operasi CRUD
                    var result = memberController.Delete(mem);
                    if (result > 0) LoadDataMember();
                }
            }
            else // data belum dipilih
            {
                MessageBox.Show("Data member belum dipilih !!!", "Peringatan",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
