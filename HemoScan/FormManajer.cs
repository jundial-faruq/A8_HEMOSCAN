using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;
using System.Linq;
using System.Data.SqlClient;

namespace HemoScan
{
    public partial class FormManajer : Form
    {
        // 1. Deklarasi Koneksi (Sesuaikan Initial Catalog dengan nama database kamu)
        SqlConnection conn = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=HEMOSCAN;Integrated Security=True");

        public FormManajer()
        {
            InitializeComponent();
        }

        // 2. Event saat Form dibuka
        private void FormManajer_Load(object sender, EventArgs e)
        {
            TampilkanLaporan();
        }

        // 3. Fungsi Utama untuk Menarik Data dan Statistik
        private void TampilkanLaporan()
        {
            try
            {
                // Pastikan koneksi terbuka
                if (conn.State == ConnectionState.Closed) conn.Open();

                // A. Menampilkan seluruh data request ke DataGridView (dgvLaporan)
                // Mengurutkan dari yang terbaru (DESC)
                string queryGrid = "SELECT ID_Request, Golongan_Darah, Status_Permintaan, Tanggal_Request, Nama_RS FROM Tabel_Request ORDER BY Tanggal_Request DESC";
                SqlDataAdapter da = new SqlDataAdapter(queryGrid, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                // Ganti 'dgvLaporan' sesuai dengan nama (Name) DataGridView di Design kamu
                dgvLaporan.DataSource = dt;

                // B. Hitung Statistik Permintaan yang masih 'Pending'
                string queryPending = "SELECT COUNT(*) FROM Tabel_Request WHERE Status_Permintaan = 'Pending'";
                SqlCommand cmdPending = new SqlCommand(queryPending, conn);
                int countPending = (int)cmdPending.ExecuteScalar();

                // Tampilkan ke label (Ganti 'lblPermintaan' sesuai nama label di Design)
                lblPermintaan.Text = "Permintaan Menunggu: " + countPending.ToString();

                // C. Hitung Total Stok Darah Global (PMI)
                string queryStok = "SELECT COUNT(*) FROM Tabel_Kantong_Darah";
                SqlCommand cmdStok = new SqlCommand(queryStok, conn);
                int totalStok = (int)cmdStok.ExecuteScalar();

                // Tampilkan ke label (Ganti 'lblTotalStok' sesuai nama label di Design)
                lblTotalStok.Text = "Total Stok Global: " + totalStok.ToString();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat laporan manajer: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }
        }

        // 4. Event Tombol Refresh Data
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            TampilkanLaporan();
            MessageBox.Show("Data Berhasil Diperbarui!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Tambahan: Jika ingin menutup aplikasi atau logout
        private void btnLogout_Click(object sender, EventArgs e)
        {
            FormLogin login = new FormLogin();
            login.Show();
            this.Close();
        }
    }
}