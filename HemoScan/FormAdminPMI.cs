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
    public partial class FormAdminPMI : Form
    {
        // Deklarasikan variabel koneksi di sini
        SqlConnection conn = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=HEMOSCAN;Integrated Security=True");

        public FormAdminPMI()
        {
            InitializeComponent();
        }
        private void btnTampil_Click(object sender, EventArgs e)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                string query = "SELECT * FROM Tabel_Kantong_Darah";
                SqlCommand cmd = new SqlCommand(query, conn);

                SqlDataReader reader = cmd.ExecuteReader();

                DataTable dt = new DataTable();
                dt.Load(reader); // 🔥 ini kunci biar masuk ke DataGridView

                dgvDarah.DataSource = dt;

                reader.Close(); // WAJIB ditutup

                // 🔥 hitung total
                string countQuery = "SELECT COUNT(*) FROM Tabel_Kantong_Darah";
                SqlCommand cmdCount = new SqlCommand(countQuery, conn);
                int total = (int)cmdCount.ExecuteScalar();

                lblStatus.Text = "Total Stok Kantong: " + total;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal tampil data: " + ex.Message);
            }
            TampilDataStok();      // Mengisi tabel stok (bawah)
            TampilRequestMasuk();  // Mengisi tabel request (kanan)
            UpdateTotalStok();     // Memperbarui angka total stok
        }


        private void btnSimpan_Click(object sender, EventArgs e)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                string query = "INSERT INTO Tabel_Kantong_Darah (Gol_Darah, Rhesus, Tgl_Kadaluwarsa, Status, ID_Unit) VALUES (@gol, @rhesus, GETDATE(), 'Tersedia', 1)";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@gol", cmbGol.Text);
                cmd.Parameters.AddWithValue("@rhesus", txtRhesus.Text);

                cmd.ExecuteNonQuery();

                MessageBox.Show("Data berhasil disimpan!");

                btnTampil_Click(null, null); // refresh data
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal simpan: " + ex.Message);
            }
            // Tambahkan validasi ini di paling atas
            if (string.IsNullOrEmpty(txtRhesus.Text))
            {
                MessageBox.Show("Field Rhesus tidak boleh kosong!");
                return;
            }
            TampilRequestMasuk();
            // ... sisa kode kamu ...
        }


        private void btnHapus_Click(object sender, EventArgs e)
{
    try
    {
        if (txtID.Text == "")
        {
            MessageBox.Show("Pilih data terlebih dahulu!");
            return;
        }

        DialogResult result = MessageBox.Show(
            "Yakin ingin menghapus data ini?",
            "Konfirmasi Hapus",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Warning
        );

        if (result == DialogResult.No)
        {
            return;
        }

        if (conn.State == ConnectionState.Closed)
            conn.Open();

        string query = "DELETE FROM Tabel_Kantong_Darah WHERE ID_Kantong = @id";

        SqlCommand cmd = new SqlCommand(query, conn);
        cmd.Parameters.AddWithValue("@id", txtID.Text);

        cmd.ExecuteNonQuery();

        MessageBox.Show("Data berhasil dihapus!");

        // refresh data
        btnTampil_Click(null, null);

        // bersihkan form
        txtID.Clear();
        txtRhesus.Clear();
        cmbGol.SelectedIndex = 0;
    }
    catch (Exception ex)
    {
        MessageBox.Show("Gagal hapus: " + ex.Message);
    }
}

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                string query = "UPDATE Tabel_Kantong_Darah SET Gol_Darah=@gol, Rhesus=@rhesus WHERE ID_Kantong=@id";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@gol", cmbGol.Text);
                cmd.Parameters.AddWithValue("@rhesus", txtRhesus.Text);
                cmd.Parameters.AddWithValue("@id", txtID.Text);

                cmd.ExecuteNonQuery();

                MessageBox.Show("Data berhasil diupdate!");

                btnTampil_Click(null, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal update: " + ex.Message);
            }
        }

        private void btnCari_Click(object sender, EventArgs e)
        {
            try
            {
                if (conn.State == ConnectionState.Closed) conn.Open();
                string query = "SELECT * FROM Tabel_Kantong_Darah WHERE Gol_Darah LIKE @cari";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@cari", "%" + txtCari.Text + "%");

                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                dgvDarah.DataSource = dt;
                dr.Close();
            }
            catch (Exception ex) { MessageBox.Show("Gagal cari: " + ex.Message); }
            finally { conn.Close(); }
        }
        private void dgvDarah_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvDarah.Rows[e.RowIndex];

                txtID.Text = row.Cells["ID_Kantong"].Value.ToString();
                cmbGol.Text = row.Cells["Gol_Darah"].Value.ToString();
                txtRhesus.Text = row.Cells["Rhesus"].Value.ToString();
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult konfirmasi = MessageBox.Show(
                "Yakin ingin logout?", "Konfirmasi Logout",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (konfirmasi == DialogResult.Yes)
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
                this.Close(); // Ini akan trigger FormClosed → Login muncul kembali
            }
        }

        // Fungsi untuk menarik data dari Tabel_Request ke DataGridView Admin
        // Fungsi untuk menarik data dari Tabel_Request ke DataGridView Admin
        private void TampilRequestMasuk()
        {
            try
            {
                if (conn.State == ConnectionState.Closed) conn.Open();

                // Mengambil data yang statusnya 'Pending' dari database
                string query = "SELECT * FROM Tabel_Request WHERE Status_Permintaan = 'Pending'";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                // Menampilkan data ke GridView kanan
                dgvRequestAdmin.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat data request: " + ex.Message);
            }
            finally { conn.Close(); }
        }
        

        private void btnProses_Click(object sender, EventArgs e)
        {
            if (dgvRequestAdmin.SelectedRows.Count > 0)
            {
                // Ambil ID_Request dari baris yang dipilih di Grid
                string idRequest = dgvRequestAdmin.SelectedRows[0].Cells["ID_Request"].Value.ToString();

                try
                {
                    if (conn.State == ConnectionState.Closed) conn.Open();

                    // Update status di database
                    string query = "UPDATE Tabel_Request SET Status_Permintaan = 'Dikirim' WHERE ID_Request = @id";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", idRequest);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Status berhasil diperbarui! Darah siap dikirim ke Rumah Sakit.", "Sukses");

                    // Refresh tabel agar data yang sudah diproses hilang dari daftar 'Pending'
                    TampilRequestMasuk();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal memproses: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
            else
            {
                MessageBox.Show("Pilih permintaan yang ingin diproses terlebih dahulu!");
            }
        }


        private void FormAdminPMI_Load(object sender, EventArgs e)
        {
            try
            {
                // 1. Pastikan koneksi bersih
                if (conn.State == ConnectionState.Open) conn.Close();
                conn.Open();

                // 2. Setup ComboBox (Hanya jika belum ada isinya)
                if (cmbGol.Items.Count == 0)
                {
                    cmbGol.Items.AddRange(new string[] { "A", "B", "AB", "O" });
                    cmbGol.SelectedIndex = 0;
                }

                // 3. Panggil data (Urutan dibalik untuk memastikan Request prioritas)
                TampilRequestMasuk();

                // Memanggil fungsi stok (Pastikan fungsi ini juga menggunakan koneksi dengan benar)
                TampilDataStok();

                // Update Label total stok
                UpdateTotalStok();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Terjadi kesalahan saat memuat form: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Jangan lupa tutup koneksi agar tidak membengkak di memory
                if (conn.State == ConnectionState.Open) conn.Close();
            }
        }

        private void UpdateTotalStok()
        {
            try
            {
                if (conn.State == ConnectionState.Closed) conn.Open();
                string countQuery = "SELECT COUNT(*) FROM Tabel_Kantong_Darah";
                SqlCommand cmdCount = new SqlCommand(countQuery, conn);
                int total = Convert.ToInt32(cmdCount.ExecuteScalar());
                lblStatus.Text = "Total Stok Kantong: " + total;
            }
            catch { /* Biarkan kosong agar tidak mengganggu load */ }
            finally { conn.Close(); }
        }

        // Fungsi pembantu agar kode Load di atas tetap rapi
        private void TampilDataStok()
        {
            try
            {
                if (conn.State == ConnectionState.Closed) conn.Open();
                string query = "SELECT * FROM Tabel_Kantong_Darah";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvDarah.DataSource = dt;
            }
            catch { /* biarkan kosong jika tidak ingin popup terus */ }
        }


        // Panggil fungsi di bawah ini saat form loading



        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_2(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                MessageBox.Show("Koneksi Database HemoScan Berhasil!", "Status");
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Koneksi Gagal: " + ex.Message);
            }
            cmbGol.Items.AddRange(new string[] { "A", "B", "AB", "O" });
            cmbGol.SelectedIndex = 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Cek apakah yang diklik bukan header (baris judul)
            if (e.RowIndex >= 0)
            {
                // Ambil data dari baris yang diklik
                DataGridViewRow row = dgvRequestAdmin.Rows[e.RowIndex];

                // Contoh: Menampilkan ID_Request ke sebuah TextBox (jika ada txtIDRequest)
                // txtIDRequest.Text = row.Cells["ID_Request"].Value.ToString();

                // Atau kamu bisa langsung memberikan konfirmasi proses di sini
                DialogResult dialog = MessageBox.Show("Apakah Anda ingin memproses permintaan ini?",
                    "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dialog == DialogResult.Yes)
                {
                    // Ambil ID dari kolom "ID_Request"
                    string idReq = row.Cells["ID_Request"].Value.ToString();
                    ProsesDarah(idReq); // Memanggil fungsi proses (logika UPDATE status)
                }
            }
        }



        // Fungsi tambahan untuk memproses (biar kode di atas tidak kepanjangan)
        private void ProsesDarah(string id)
        {
            try
            {
                if (conn.State == ConnectionState.Closed) conn.Open();
                string query = "UPDATE Tabel_Request SET Status_Permintaan = 'Dikirim' WHERE ID_Request = @id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Permintaan Berhasil Diproses!");
                TampilRequestMasuk(); // Refresh tabel setelah update
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saat proses: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
    }
}

