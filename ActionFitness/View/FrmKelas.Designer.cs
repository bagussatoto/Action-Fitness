namespace ActionFitness.View
{
    partial class FrmKelas
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
            this.listView1 = new System.Windows.Forms.ListView();
            this.Tambah = new System.Windows.Forms.Button();
            this.Perbaiki = new System.Windows.Forms.Button();
            this.Hapus = new System.Windows.Forms.Button();
            this.Selesai = new System.Windows.Forms.Button();
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
            // 
            // txtnama
            // 
            this.txtnama.Location = new System.Drawing.Point(68, 9);
            this.txtnama.Name = "txtnama";
            this.txtnama.Size = new System.Drawing.Size(549, 27);
            this.txtnama.TabIndex = 1;
            // 
            // Cari
            // 
            this.Cari.Location = new System.Drawing.Point(632, 9);
            this.Cari.Name = "Cari";
            this.Cari.Size = new System.Drawing.Size(94, 29);
            this.Cari.TabIndex = 2;
            this.Cari.Text = "Cari";
            this.Cari.UseVisualStyleBackColor = true;
            this.Cari.Click += new System.EventHandler(this.Cari_Click);
            // 
            // listView1
            // 
            this.listView1.Location = new System.Drawing.Point(12, 42);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(860, 345);
            this.listView1.TabIndex = 3;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // Tambah
            // 
            this.Tambah.Location = new System.Drawing.Point(12, 409);
            this.Tambah.Name = "Tambah";
            this.Tambah.Size = new System.Drawing.Size(94, 29);
            this.Tambah.TabIndex = 4;
            this.Tambah.Text = "Tambah";
            this.Tambah.UseVisualStyleBackColor = true;
            this.Tambah.Click += new System.EventHandler(this.Tambah_Click);
            // 
            // Perbaiki
            // 
            this.Perbaiki.Location = new System.Drawing.Point(112, 409);
            this.Perbaiki.Name = "Perbaiki";
            this.Perbaiki.Size = new System.Drawing.Size(94, 29);
            this.Perbaiki.TabIndex = 5;
            this.Perbaiki.Text = "Perbaiki";
            this.Perbaiki.UseVisualStyleBackColor = true;
            this.Perbaiki.Click += new System.EventHandler(this.Perbaiki_Click);
            // 
            // Hapus
            // 
            this.Hapus.Location = new System.Drawing.Point(212, 409);
            this.Hapus.Name = "Hapus";
            this.Hapus.Size = new System.Drawing.Size(94, 29);
            this.Hapus.TabIndex = 6;
            this.Hapus.Text = "Hapus";
            this.Hapus.UseVisualStyleBackColor = true;
            this.Hapus.Click += new System.EventHandler(this.Hapus_Click);
            // 
            // Selesai
            // 
            this.Selesai.Location = new System.Drawing.Point(778, 409);
            this.Selesai.Name = "Selesai";
            this.Selesai.Size = new System.Drawing.Size(94, 29);
            this.Selesai.TabIndex = 7;
            this.Selesai.Text = "Selesai";
            this.Selesai.UseVisualStyleBackColor = true;
            this.Selesai.Click += new System.EventHandler(this.Selesai_Click);
            // 
            // FrmKelas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(887, 450);
            this.Controls.Add(this.Selesai);
            this.Controls.Add(this.Hapus);
            this.Controls.Add(this.Perbaiki);
            this.Controls.Add(this.Tambah);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.Cari);
            this.Controls.Add(this.txtnama);
            this.Controls.Add(this.label1);
            this.Name = "FrmKelas";
            this.Text = "Kelas";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private TextBox txtnama;
        private Button Cari;
        private ListView listView1;
        private Button Tambah;
        private Button Perbaiki;
        private Button Hapus;
        private Button Selesai;
    }
}