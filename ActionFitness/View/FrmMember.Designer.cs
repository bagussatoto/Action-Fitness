namespace ActionFitness.View
{
    partial class FrmMember
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
            this.txtNama = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.lvwMember = new System.Windows.Forms.ListView();
            this.Tambah = new System.Windows.Forms.Button();
            this.Selesai = new System.Windows.Forms.Button();
            this.Perbaiki = new System.Windows.Forms.Button();
            this.Hapus = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cari";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // txtNama
            // 
            this.txtNama.Location = new System.Drawing.Point(67, 4);
            this.txtNama.Name = "txtNama";
            this.txtNama.Size = new System.Drawing.Size(584, 27);
            this.txtNama.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(657, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(94, 29);
            this.button1.TabIndex = 2;
            this.button1.Text = "Cari";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lvwMember
            // 
            this.lvwMember.Location = new System.Drawing.Point(11, 37);
            this.lvwMember.Name = "lvwMember";
            this.lvwMember.Size = new System.Drawing.Size(928, 425);
            this.lvwMember.TabIndex = 3;
            this.lvwMember.UseCompatibleStateImageBehavior = false;
            // 
            // Tambah
            // 
            this.Tambah.Location = new System.Drawing.Point(11, 468);
            this.Tambah.Name = "Tambah";
            this.Tambah.Size = new System.Drawing.Size(94, 29);
            this.Tambah.TabIndex = 4;
            this.Tambah.Text = "Tambah";
            this.Tambah.UseVisualStyleBackColor = true;
            this.Tambah.Click += new System.EventHandler(this.Tambah_Click);
            // 
            // Selesai
            // 
            this.Selesai.Location = new System.Drawing.Point(844, 468);
            this.Selesai.Name = "Selesai";
            this.Selesai.Size = new System.Drawing.Size(94, 29);
            this.Selesai.TabIndex = 5;
            this.Selesai.Text = "Selesai";
            this.Selesai.UseVisualStyleBackColor = true;
            this.Selesai.Click += new System.EventHandler(this.Selesai_Click);
            // 
            // Perbaiki
            // 
            this.Perbaiki.Location = new System.Drawing.Point(111, 468);
            this.Perbaiki.Name = "Perbaiki";
            this.Perbaiki.Size = new System.Drawing.Size(94, 29);
            this.Perbaiki.TabIndex = 6;
            this.Perbaiki.Text = "Perbaiki";
            this.Perbaiki.UseVisualStyleBackColor = true;
            this.Perbaiki.Click += new System.EventHandler(this.Perbaiki_Click);
            // 
            // Hapus
            // 
            this.Hapus.Location = new System.Drawing.Point(211, 468);
            this.Hapus.Name = "Hapus";
            this.Hapus.Size = new System.Drawing.Size(94, 29);
            this.Hapus.TabIndex = 7;
            this.Hapus.Text = "Hapus";
            this.Hapus.UseVisualStyleBackColor = true;
            this.Hapus.Click += new System.EventHandler(this.Hapus_Click);
            // 
            // FrmMember
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(966, 509);
            this.Controls.Add(this.Hapus);
            this.Controls.Add(this.Perbaiki);
            this.Controls.Add(this.Selesai);
            this.Controls.Add(this.Tambah);
            this.Controls.Add(this.lvwMember);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtNama);
            this.Controls.Add(this.label1);
            this.Name = "FrmMember";
            this.Text = "Member";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private TextBox txtNama;
        private Button button1;
        private ListView lvwMember;
        private Button Tambah;
        private Button Selesai;
        private Button Perbaiki;
        private Button Hapus;
    }
}