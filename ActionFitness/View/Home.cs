using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ActionFitness.View
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void memberToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmMember frmMember = new FrmMember();
            frmMember.ShowDialog();
        }

        private void refrensiToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void karyawanToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmKaryawan frmKaryawan = new FrmKaryawan();
            frmKaryawan.ShowDialog();
        }

        private void kelasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmKelas frmKelas = new FrmKelas();
            frmKelas.ShowDialog();
        }

        private void fasilitasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmFasilitas frmFas = new FrmFasilitas();
            frmFas.ShowDialog();
        }

        private void trainerToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void membershipToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmMembership frmShp = new FrmMembership();
            frmShp.ShowDialog();
        }
    }
}
