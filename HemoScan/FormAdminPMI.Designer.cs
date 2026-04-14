namespace HemoScan
{
    partial class FormAdminPMI
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
            this.txtCari = new System.Windows.Forms.TextBox();
            this.grpInput = new System.Windows.Forms.TextBox();
            this.lblCari = new System.Windows.Forms.Label();
            this.btnCari = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.txtRhesus = new System.Windows.Forms.TextBox();
            this.btnSimpan = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnHapus = new System.Windows.Forms.Button();
            this.btnTampli = new System.Windows.Forms.Button();
            this.dgvDarah = new System.Windows.Forms.DataGridView();
            this.lblStatus = new System.Windows.Forms.Label();
            this.cmbGol = new System.Windows.Forms.ComboBox();
            this.dgvRequestAdmin = new System.Windows.Forms.DataGridView();
            this.btnProses = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDarah)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRequestAdmin)).BeginInit();
            this.SuspendLayout();
            // 
            // txtCari
            // 
            this.txtCari.Location = new System.Drawing.Point(70, 12);
            this.txtCari.Multiline = true;
            this.txtCari.Name = "txtCari";
            this.txtCari.Size = new System.Drawing.Size(267, 24);
            this.txtCari.TabIndex = 6;
            // 
            // grpInput
            // 
            this.grpInput.Location = new System.Drawing.Point(30, 52);
            this.grpInput.Multiline = true;
            this.grpInput.Name = "grpInput";
            this.grpInput.Size = new System.Drawing.Size(408, 163);
            this.grpInput.TabIndex = 7;
            this.grpInput.Text = "From Input";
            this.grpInput.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // lblCari
            // 
            this.lblCari.AutoSize = true;
            this.lblCari.Location = new System.Drawing.Point(27, 15);
            this.lblCari.Name = "lblCari";
            this.lblCari.Size = new System.Drawing.Size(37, 16);
            this.lblCari.TabIndex = 9;
            this.lblCari.Text = "Cari :";
            this.lblCari.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // btnCari
            // 
            this.btnCari.Location = new System.Drawing.Point(343, 10);
            this.btnCari.Name = "btnCari";
            this.btnCari.Size = new System.Drawing.Size(75, 26);
            this.btnCari.TabIndex = 10;
            this.btnCari.Text = "Cari";
            this.btnCari.UseVisualStyleBackColor = true;
            this.btnCari.TextChanged += new System.EventHandler(this.btnCari_Click);
            this.btnCari.Click += new System.EventHandler(this.btnCari_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(466, 224);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(8, 8);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 16);
            this.label1.TabIndex = 12;
            this.label1.Text = "ID                              :";
            this.label1.Click += new System.EventHandler(this.label1_Click_2);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(38, 109);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 16);
            this.label2.TabIndex = 13;
            this.label2.Text = "Golongan Darah :";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(38, 143);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 16);
            this.label3.TabIndex = 14;
            this.label3.Text = "Rhesus                   :";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(156, 74);
            this.txtID.Name = "txtID";
            this.txtID.ReadOnly = true;
            this.txtID.Size = new System.Drawing.Size(181, 22);
            this.txtID.TabIndex = 15;
            // 
            // txtRhesus
            // 
            this.txtRhesus.Location = new System.Drawing.Point(156, 140);
            this.txtRhesus.Name = "txtRhesus";
            this.txtRhesus.Size = new System.Drawing.Size(181, 22);
            this.txtRhesus.TabIndex = 17;
            this.txtRhesus.TextChanged += new System.EventHandler(this.textBox4_TextChanged);
            // 
            // btnSimpan
            // 
            this.btnSimpan.Location = new System.Drawing.Point(30, 224);
            this.btnSimpan.Name = "btnSimpan";
            this.btnSimpan.Size = new System.Drawing.Size(75, 23);
            this.btnSimpan.TabIndex = 18;
            this.btnSimpan.Text = "Simpan";
            this.btnSimpan.UseVisualStyleBackColor = true;
            this.btnSimpan.Click += new System.EventHandler(this.btnSimpan_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(126, 224);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 19;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnHapus
            // 
            this.btnHapus.Location = new System.Drawing.Point(220, 224);
            this.btnHapus.Name = "btnHapus";
            this.btnHapus.Size = new System.Drawing.Size(75, 23);
            this.btnHapus.TabIndex = 20;
            this.btnHapus.Text = "Hapus";
            this.btnHapus.UseVisualStyleBackColor = true;
            this.btnHapus.Click += new System.EventHandler(this.btnHapus_Click);
            // 
            // btnTampli
            // 
            this.btnTampli.Location = new System.Drawing.Point(313, 224);
            this.btnTampli.Name = "btnTampli";
            this.btnTampli.Size = new System.Drawing.Size(83, 23);
            this.btnTampli.TabIndex = 21;
            this.btnTampli.Text = "Tampilkan";
            this.btnTampli.UseVisualStyleBackColor = true;
            this.btnTampli.Click += new System.EventHandler(this.btnTampil_Click);
            // 
            // dgvDarah
            // 
            this.dgvDarah.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDarah.Location = new System.Drawing.Point(30, 253);
            this.dgvDarah.Name = "dgvDarah";
            this.dgvDarah.RowHeadersWidth = 51;
            this.dgvDarah.RowTemplate.Height = 24;
            this.dgvDarah.Size = new System.Drawing.Size(701, 150);
            this.dgvDarah.TabIndex = 22;
            this.dgvDarah.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDarah_CellClick);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(27, 415);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(136, 16);
            this.lblStatus.TabIndex = 23;
            this.lblStatus.Text = "Total Stok Kantong : 0";
            // 
            // cmbGol
            // 
            this.cmbGol.FormattingEnabled = true;
            this.cmbGol.Location = new System.Drawing.Point(156, 106);
            this.cmbGol.Name = "cmbGol";
            this.cmbGol.Size = new System.Drawing.Size(121, 24);
            this.cmbGol.TabIndex = 24;
            // 
            // dgvRequestAdmin
            // 
            this.dgvRequestAdmin.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRequestAdmin.Location = new System.Drawing.Point(444, 52);
            this.dgvRequestAdmin.Name = "dgvRequestAdmin";
            this.dgvRequestAdmin.RowHeadersWidth = 51;
            this.dgvRequestAdmin.RowTemplate.Height = 24;
            this.dgvRequestAdmin.Size = new System.Drawing.Size(287, 150);
            this.dgvRequestAdmin.TabIndex = 25;
            this.dgvRequestAdmin.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // btnProses
            // 
            this.btnProses.Location = new System.Drawing.Point(656, 209);
            this.btnProses.Name = "btnProses";
            this.btnProses.Size = new System.Drawing.Size(75, 23);
            this.btnProses.TabIndex = 26;
            this.btnProses.Text = "Proses";
            this.btnProses.UseVisualStyleBackColor = true;
            this.btnProses.Click += new System.EventHandler(this.btnProses_Click);
            // 
            // FormAdminPMI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnProses);
            this.Controls.Add(this.dgvRequestAdmin);
            this.Controls.Add(this.cmbGol);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.dgvDarah);
            this.Controls.Add(this.btnTampli);
            this.Controls.Add(this.btnHapus);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnSimpan);
            this.Controls.Add(this.txtRhesus);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCari);
            this.Controls.Add(this.lblCari);
            this.Controls.Add(this.grpInput);
            this.Controls.Add(this.txtCari);
            this.Name = "FormAdminPMI";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDarah)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRequestAdmin)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtCari;
        private System.Windows.Forms.TextBox grpInput;
        private System.Windows.Forms.Label lblCari;
        private System.Windows.Forms.Button btnCari;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.TextBox txtRhesus;
        private System.Windows.Forms.Button btnSimpan;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnHapus;
        private System.Windows.Forms.Button btnTampli;
        private System.Windows.Forms.DataGridView dgvDarah;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ComboBox cmbGol;
        private System.Windows.Forms.DataGridView dgvRequestAdmin;
        private System.Windows.Forms.Button btnProses;
    }
}

