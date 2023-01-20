using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using ActionFitness.View;

namespace ActionFitness
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            //ApplicationConfiguration.Initialize();
            //Application.Run(new FrmMembership());
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            // buat objek form login
            FrmLogin frmLogin = new FrmLogin();

            // tampilkan form login
            if (frmLogin.ShowDialog() == DialogResult.OK) // jika user dan password benar
                Application.Run(new Home()); // jalankan form utama
            else
                Application.Exit(); // keluar dari aplikasi*/
        }
    }
}