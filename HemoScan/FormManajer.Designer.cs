namespace HemoScan
{
    partial class FormManajer
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


        private void InitializeComponent()
        {
            this.lblTotalStok = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.dgvLaporan = new System.Windows.Forms.DataGridView();
            this.lblPermintaan = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLaporan)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTotalStok
            // 
            this.lblTotalStok.AutoSize = true;
            this.lblTotalStok.Location = new System.Drawing.Point(39, 404);
            this.lblTotalStok.Name = "lblTotalStok";
            this.lblTotalStok.Size = new System.Drawing.Size(127, 16);
            this.lblTotalStok.TabIndex = 1;
            this.lblTotalStok.Text = "Total Stok Global : 0";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(610, 374);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(141, 23);
            this.btnRefresh.TabIndex = 2;
            this.btnRefresh.Text = "Refresh Data";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // dgvLaporan
            // 
            this.dgvLaporan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLaporan.Location = new System.Drawing.Point(42, 74);
            this.dgvLaporan.Name = "dgvLaporan";
            this.dgvLaporan.RowHeadersWidth = 51;
            this.dgvLaporan.RowTemplate.Height = 24;
            this.dgvLaporan.Size = new System.Drawing.Size(709, 274);
            this.dgvLaporan.TabIndex = 0;
            this.dgvLaporan.Click += new System.EventHandler(this.FormManajer_Load);
            // 
            // lblPermintaan
            // 
            this.lblPermintaan.AutoSize = true;
            this.lblPermintaan.Location = new System.Drawing.Point(39, 377);
            this.lblPermintaan.Name = "lblPermintaan";
            this.lblPermintaan.Size = new System.Drawing.Size(157, 16);
            this.lblPermintaan.TabIndex = 3;
            this.lblPermintaan.Text = "Permintaan Menunggu : 0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(271, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(209, 29);
            this.label1.TabIndex = 4;
            this.label1.Text = "Laporan Manajer";
            // 
            // FormManajer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblPermintaan);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.lblTotalStok);
            this.Controls.Add(this.dgvLaporan);
            this.Name = "FormManajer";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dgvLaporan)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblTotalStok;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.DataGridView dgvLaporan;
        private System.Windows.Forms.Label lblPermintaan;
        private System.Windows.Forms.Label label1;
    }
}