using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using ActionFitness.Controller;

namespace ActionFitness.View
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();

            txtUserName.Text = "Tyler";
            txtPassword.Text = "1234";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Login_Click(object sender, EventArgs e)
        {
            UserController controller = new UserController();

            bool isValidUser = controller.IsValidUser(txtUserName.Text, txtPassword.Text);
            if (isValidUser)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void Batal_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
