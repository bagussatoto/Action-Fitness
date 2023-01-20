namespace ActionFitness.View
{
    partial class FrmEntryFasilitas
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
            this.Simpan = new System.Windows.Forms.Button();
            this.Selesai = new System.Windows.Forms.Button();
            this.txtidfal = new System.Windows.Forms.TextBox();
            this.txtnamafal = new System.Windows.Forms.TextBox();
            this.txtketfal = new System.Windows.Forms.TextBox();
            this.txtidkel = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "ID Fasilitas";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nama";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Ketersediaan";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 142);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "ID Kelas";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(249, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(228, 20);
            this.label5.TabIndex = 4;
            this.label5.Text = "Contoh: F0001, F0010, atau F0100";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(249, 142);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(228, 20);
            this.label6.TabIndex = 5;
            this.label6.Text = "Contoh: L0001, L0010, atau L0100";
            // 
            // Simpan
            // 
            this.Simpan.Location = new System.Drawing.Point(331, 217);
            this.Simpan.Name = "Simpan";
            this.Simpan.Size = new System.Drawing.Size(94, 29);
            this.Simpan.TabIndex = 6;
            this.Simpan.Text = "Simpan";
            this.Simpan.UseVisualStyleBackColor = true;
            this.Simpan.Click += new System.EventHandler(this.Simpan_Click);
            // 
            // Selesai
            // 
            this.Selesai.Location = new System.Drawing.Point(431, 217);
            this.Selesai.Name = "Selesai";
            this.Selesai.Size = new System.Drawing.Size(94, 29);
            this.Selesai.TabIndex = 7;
            this.Selesai.Text = "Selesai";
            this.Selesai.UseVisualStyleBackColor = true;
            this.Selesai.Click += new System.EventHandler(this.Selesai_Click);
            // 
            // txtidfal
            // 
            this.txtidfal.Location = new System.Drawing.Point(118, 22);
            this.txtidfal.Name = "txtidfal";
            this.txtidfal.Size = new System.Drawing.Size(125, 27);
            this.txtidfal.TabIndex = 8;
            // 
            // txtnamafal
            // 
            this.txtnamafal.Location = new System.Drawing.Point(118, 60);
            this.txtnamafal.Name = "txtnamafal";
            this.txtnamafal.Size = new System.Drawing.Size(162, 27);
            this.txtnamafal.TabIndex = 9;
            // 
            // txtketfal
            // 
            this.txtketfal.Location = new System.Drawing.Point(118, 98);
            this.txtketfal.Name = "txtketfal";
            this.txtketfal.Size = new System.Drawing.Size(67, 27);
            this.txtketfal.TabIndex = 10;
            // 
            // txtidkel
            // 
            this.txtidkel.Location = new System.Drawing.Point(118, 142);
            this.txtidkel.Name = "txtidkel";
            this.txtidkel.Size = new System.Drawing.Size(125, 27);
            this.txtidkel.TabIndex = 11;
            // 
            // FrmEntryFasilitas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(540, 258);
            this.Controls.Add(this.txtidkel);
            this.Controls.Add(this.txtketfal);
            this.Controls.Add(this.txtnamafal);
            this.Controls.Add(this.txtidfal);
            this.Controls.Add(this.Selesai);
            this.Controls.Add(this.Simpan);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FrmEntryFasilitas";
            this.Text = "Entry Fasilitas";
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
        private Button Simpan;
        private Button Selesai;
        private TextBox txtidfal;
        private TextBox txtnamafal;
        private TextBox txtketfal;
        private TextBox txtidkel;
    }
}