using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace HemoScan
{
    public partial class FormStafRS : Form
    {
        SqlConnection conn;
        string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=HEMOSCAN;Integrated Security=True";

        public FormStafRS()
        {
            InitializeComponent();
            conn = new SqlConnection(connectionString);
        }

        // --- FUNGSI UTAMA UNTUK TAMPIL DATA ---
        private void TampilData(string queryCustom = "")
        {
            try
            {
                if (conn.State == ConnectionState.Closed) conn.Open();

                // Gunakan query default jika tidak ada pencarian
                string query = string.IsNullOrEmpty(queryCustom) ?
                               "SELECT * FROM Tabel_Kantong_Darah" : queryCustom;

                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                if (!string.IsNullOrEmpty(queryCustom))
                {
                    // Jika ini hasil pencarian, kita perlu pakai SqlCommand untuk parameter
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@search", "%" + txtCari.Text + "%");
                    da.SelectCommand = cmd;
                }

                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvDarah.DataSource = dt;

                // --- HITUNG TOTAL STOK ---
                string countQuery = "SELECT COUNT(*) FROM Tabel_Kantong_Darah";
                SqlCommand cmdCount = new SqlCommand(countQuery, conn);
                int total = (int)cmdCount.ExecuteScalar();
                lblStatus.Text = "Total Stok Darah: " + total;

                // --- WARNAI STOK KRITIS ---
                WarnaiStokKritis();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void WarnaiStokKritis()
        {
            foreach (DataGridViewRow row in dgvDarah.Rows)
            {
                if (row.Cells["Gol_Darah"].Value != null)
                {
                    string gol = row.Cells["Gol_Darah"].Value.ToString();

                    // Hitung jumlah stok untuk golongan darah tersebut di Grid
                    int count = dgvDarah.Rows.Cast<DataGridViewRow>()
                        .Count(r => r.Cells["Gol_Darah"].Value?.ToString() == gol);

                    if (count < 3)
                    {
                        row.DefaultCellStyle.BackColor = Color.Orange;
                        row.DefaultCellStyle.ForeColor = Color.Black;
                    }
                }
            }
        }

        private void FormStafRS_Load(object sender, EventArgs e)
        {
            TampilData();
        }

        private void btnCari_Click(object sender, EventArgs e)
        {
            // Panggil TampilData dengan filter pencarian
            TampilData("SELECT * FROM Tabel_Kantong_Darah WHERE Gol_Darah LIKE @search");
        }

        // --- FITUR REQUEST DARAH (YANG BELUM ADA DI KODE KAMU) ---
        private void btnRequest_Click(object sender, EventArgs e)
        {
            if (dgvDarah.SelectedRows.Count > 0)
            {
                string golDarah = dgvDarah.SelectedRows[0].Cells["Gol_Darah"].Value.ToString();

                try
                {
                    if (conn.State == ConnectionState.Closed) conn.Open();
                    string query = "INSERT INTO Tabel_Request (Golongan_Darah, Status_Permintaan, Tanggal_Request) " +
                                   "VALUES (@gol, 'Pending', GETDATE())";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@gol", golDarah);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Request Darah " + golDarah + " berhasil dikirim!", "Informasi");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal kirim request: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
            else
            {
                MessageBox.Show("Silakan pilih baris data darah yang ingin di-request!");
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }


    }
}
