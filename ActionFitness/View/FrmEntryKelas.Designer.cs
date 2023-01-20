namespace ActionFitness.View
{
    partial class FrmEntryKelas
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.idkelas = new System.Windows.Forms.TextBox();
            this.namakelas = new System.Windows.Forms.TextBox();
            this.harikelas = new System.Windows.Forms.TextBox();
            this.ruangankelas = new System.Windows.Forms.TextBox();
            this.kapasitaskelas = new System.Windows.Forms.TextBox();
            this.Simpan = new System.Windows.Forms.Button();
            this.Selesai = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "ID Kelas";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nama";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 129);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Hari";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 182);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "Ruangan";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 233);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 20);
            this.label5.TabIndex = 4;
            this.label5.Text = "Kapasitas";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label6.Location = new System.Drawing.Point(221, 31);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(228, 20);
            this.label6.TabIndex = 5;
            this.label6.Text = "Contoh: L0001, L0010, atau L0100";
            // 
            // idkelas
            // 
            this.idkelas.Location = new System.Drawing.Point(81, 31);
            this.idkelas.Name = "idkelas";
            this.idkelas.Size = new System.Drawing.Size(125, 27);
            this.idkelas.TabIndex = 6;
            // 
            // namakelas
            // 
            this.namakelas.Location = new System.Drawing.Point(81, 78);
            this.namakelas.Name = "namakelas";
            this.namakelas.Size = new System.Drawing.Size(256, 27);
            this.namakelas.TabIndex = 7;
            // 
            // harikelas
            // 
            this.harikelas.Location = new System.Drawing.Point(81, 129);
            this.harikelas.Name = "harikelas";
            this.harikelas.Size = new System.Drawing.Size(153, 27);
            this.harikelas.TabIndex = 8;
            // 
            // ruangankelas
            // 
            this.ruangankelas.Location = new System.Drawing.Point(85, 182);
            this.ruangankelas.Name = "ruangankelas";
            this.ruangankelas.Size = new System.Drawing.Size(149, 27);
            this.ruangankelas.TabIndex = 9;
            // 
            // kapasitaskelas
            // 
            this.kapasitaskelas.Location = new System.Drawing.Point(85, 233);
            this.kapasitaskelas.Name = "kapasitaskelas";
            this.kapasitaskelas.Size = new System.Drawing.Size(90, 27);
            this.kapasitaskelas.TabIndex = 10;
            // 
            // Simpan
            // 
            this.Simpan.Location = new System.Drawing.Point(269, 283);
            this.Simpan.Name = "Simpan";
            this.Simpan.Size = new System.Drawing.Size(94, 29);
            this.Simpan.TabIndex = 11;
            this.Simpan.Text = "Simpan";
            this.Simpan.UseVisualStyleBackColor = true;
            this.Simpan.Click += new System.EventHandler(this.Simpan_Click);
            // 
            // Selesai
            // 
            this.Selesai.Location = new System.Drawing.Point(369, 283);
            this.Selesai.Name = "Selesai";
            this.Selesai.Size = new System.Drawing.Size(94, 29);
            this.Selesai.TabIndex = 12;
            this.Selesai.Text = "Selesai";
            this.Selesai.UseVisualStyleBackColor = true;
            this.Selesai.Click += new System.EventHandler(this.Selesai_Click);
            // 
            // FrmEntryKelas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(475, 324);
            this.Controls.Add(this.Selesai);
            this.Controls.Add(this.Simpan);
            this.Controls.Add(this.kapasitaskelas);
            this.Controls.Add(this.ruangankelas);
            this.Controls.Add(this.harikelas);
            this.Controls.Add(this.namakelas);
            this.Controls.Add(this.idkelas);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FrmEntryKelas";
            this.Text = "Entry Kelas";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private TextBox idkelas;
        private TextBox namakelas;
        private TextBox harikelas;
        private TextBox ruangankelas;
        private TextBox kapasitaskelas;
        private Button Simpan;
        private Button Selesai;
    }
}