namespace ActionFitness.View
{
    partial class FrmKaryawan
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.txtnama = new System.Windows.Forms.TextBox();
            this.Cari = new System.Windows.Forms.Button();
            this.Tambah = new System.Windows.Forms.Button();
            this.Perbaiki = new System.Windows.Forms.Button();
            this.Hapus = new System.Windows.Forms.Button();
            this.Selesai = new System.Windows.Forms.Button();
            this.lvwKaryawan = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cari";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // txtnama
            // 
            this.txtnama.Location = new System.Drawing.Point(68, 6);
            this.txtnama.Name = "txtnama";
            this.txtnama.Size = new System.Drawing.Size(465, 27);
            this.txtnama.TabIndex = 1;
            // 
            // Cari
            // 
            this.Cari.Location = new System.Drawing.Point(539, 6);
            this.Cari.Name = "Cari";
            this.Cari.Size = new System.Drawing.Size(94, 29);
            this.Cari.TabIndex = 2;
            this.Cari.Text = "Cari";
            this.Cari.UseVisualStyleBackColor = true;
            this.Cari.Click += new System.EventHandler(this.Cari_Click);
            // 
            // Tambah
            // 
            this.Tambah.Location = new System.Drawing.Point(12, 490);
            this.Tambah.Name = "Tambah";
            this.Tambah.Size = new System.Drawing.Size(94, 29);
            this.Tambah.TabIndex = 3;
            this.Tambah.Text = "Tambah";
            this.Tambah.UseVisualStyleBackColor = true;
            this.Tambah.Click += new System.EventHandler(this.Tambah_Click);
            // 
            // Perbaiki
            // 
            this.Perbaiki.Location = new System.Drawing.Point(112, 490);
            this.Perbaiki.Name = "Perbaiki";
            this.Perbaiki.Size = new System.Drawing.Size(94, 29);
            this.Perbaiki.TabIndex = 4;
            this.Perbaiki.Text = "Perbaiki";
            this.Perbaiki.UseVisualStyleBackColor = true;
            this.Perbaiki.Click += new System.EventHandler(this.Perbaiki_Click);
            // 
            // Hapus
            // 
            this.Hapus.Location = new System.Drawing.Point(212, 490);
            this.Hapus.Name = "Hapus";
            this.Hapus.Size = new System.Drawing.Size(94, 29);
            this.Hapus.TabIndex = 5;
            this.Hapus.Text = "Hapus";
            this.Hapus.UseVisualStyleBackColor = true;
            this.Hapus.Click += new System.EventHandler(this.Hapus_Click);
            // 
            // Selesai
            // 
            this.Selesai.Location = new System.Drawing.Point(996, 490);
            this.Selesai.Name = "Selesai";
            this.Selesai.Size = new System.Drawing.Size(94, 29);
            this.Selesai.TabIndex = 6;
            this.Selesai.Text = "Selesai";
            this.Selesai.UseVisualStyleBackColor = true;
            this.Selesai.Click += new System.EventHandler(this.Selesai_Click);
            // 
            // lvwKaryawan
            // 
            this.lvwKaryawan.Location = new System.Drawing.Point(12, 39);
            this.lvwKaryawan.Name = "lvwKaryawan";
            this.lvwKaryawan.Size = new System.Drawing.Size(1078, 445);
            this.lvwKaryawan.TabIndex = 7;
            this.lvwKaryawan.UseCompatibleStateImageBehavior = false;
            // 
            // FrmKaryawan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1102, 531);
            this.Controls.Add(this.lvwKaryawan);
            this.Controls.Add(this.Selesai);
            this.Controls.Add(this.Hapus);
            this.Controls.Add(this.Perbaiki);
            this.Controls.Add(this.Tambah);
            this.Controls.Add(this.Cari);
            this.Controls.Add(this.txtnama);
            this.Controls.Add(this.label1);
            this.Name = "FrmKaryawan";
            this.Text = "Karyawan";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private TextBox txtnama;
        private Button Cari;
        private Button Tambah;
        private Button Perbaiki;
        private Button Hapus;
        private Button Selesai;
        private ListView lvwKaryawan;
    }
}