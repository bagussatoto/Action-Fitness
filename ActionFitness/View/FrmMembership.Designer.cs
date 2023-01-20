namespace ActionFitness.View
{
    partial class FrmMembership
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
            this.txtmember = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Cari = new System.Windows.Forms.Button();
            this.Selesai = new System.Windows.Forms.Button();
            this.Tambah = new System.Windows.Forms.Button();
            this.Perbaiki = new System.Windows.Forms.Button();
            this.Hapus = new System.Windows.Forms.Button();
            this.lvwmembership = new System.Windows.Forms.ListView();
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
            // txtmember
            // 
            this.txtmember.Location = new System.Drawing.Point(53, 6);
            this.txtmember.Name = "txtmember";
            this.txtmember.Size = new System.Drawing.Size(160, 27);
            this.txtmember.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label2.Location = new System.Drawing.Point(219, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(246, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Contoh: M0001, M0010, atau M0100";
            // 
            // Cari
            // 
            this.Cari.Location = new System.Drawing.Point(471, 6);
            this.Cari.Name = "Cari";
            this.Cari.Size = new System.Drawing.Size(94, 29);
            this.Cari.TabIndex = 3;
            this.Cari.Text = "Cari";
            this.Cari.UseVisualStyleBackColor = true;
            this.Cari.Click += new System.EventHandler(this.Cari_Click);
            // 
            // Selesai
            // 
            this.Selesai.Location = new System.Drawing.Point(590, 409);
            this.Selesai.Name = "Selesai";
            this.Selesai.Size = new System.Drawing.Size(94, 29);
            this.Selesai.TabIndex = 4;
            this.Selesai.Text = "Selesai";
            this.Selesai.UseVisualStyleBackColor = true;
            this.Selesai.Click += new System.EventHandler(this.Selesai_Click);
            // 
            // Tambah
            // 
            this.Tambah.Location = new System.Drawing.Point(12, 409);
            this.Tambah.Name = "Tambah";
            this.Tambah.Size = new System.Drawing.Size(94, 29);
            this.Tambah.TabIndex = 5;
            this.Tambah.Text = "Tambah";
            this.Tambah.UseVisualStyleBackColor = true;
            this.Tambah.Click += new System.EventHandler(this.Tambah_Click);
            // 
            // Perbaiki
            // 
            this.Perbaiki.Location = new System.Drawing.Point(119, 409);
            this.Perbaiki.Name = "Perbaiki";
            this.Perbaiki.Size = new System.Drawing.Size(94, 29);
            this.Perbaiki.TabIndex = 6;
            this.Perbaiki.Text = "Perbaiki";
            this.Perbaiki.UseVisualStyleBackColor = true;
            this.Perbaiki.Click += new System.EventHandler(this.Perbaiki_Click);
            // 
            // Hapus
            // 
            this.Hapus.Location = new System.Drawing.Point(229, 409);
            this.Hapus.Name = "Hapus";
            this.Hapus.Size = new System.Drawing.Size(94, 29);
            this.Hapus.TabIndex = 7;
            this.Hapus.Text = "Hapus";
            this.Hapus.UseVisualStyleBackColor = true;
            this.Hapus.Click += new System.EventHandler(this.Hapus_Click);
            // 
            // lvwmembership
            // 
            this.lvwmembership.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lvwmembership.Location = new System.Drawing.Point(12, 39);
            this.lvwmembership.Name = "lvwmembership";
            this.lvwmembership.Size = new System.Drawing.Size(681, 364);
            this.lvwmembership.TabIndex = 8;
            this.lvwmembership.UseCompatibleStateImageBehavior = false;
            // 
            // FrmMembership
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(705, 450);
            this.Controls.Add(this.lvwmembership);
            this.Controls.Add(this.Hapus);
            this.Controls.Add(this.Perbaiki);
            this.Controls.Add(this.Tambah);
            this.Controls.Add(this.Selesai);
            this.Controls.Add(this.Cari);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtmember);
            this.Controls.Add(this.label1);
            this.Name = "FrmMembership";
            this.Text = "Membership";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private TextBox txtmember;
        private Label label2;
        private Button Cari;
        private Button Selesai;
        private Button Tambah;
        private Button Perbaiki;
        private Button Hapus;
        private ListView lvwmembership;
    }
}