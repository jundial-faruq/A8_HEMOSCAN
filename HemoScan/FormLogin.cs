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
    public partial class FormLogin : Form
    {
        SqlConnection conn = new SqlConnection(
            @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=HEMOSCAN;Integrated Security=True");

        public FormLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Username dan password tidak boleh kosong!", "Peringatan",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                // Query sudah benar
                string query = "SELECT Role FROM Tabel_User WHERE Username=@user AND Password=@pass";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@user", username);
                cmd.Parameters.AddWithValue("@pass", password);

                object result = cmd.ExecuteScalar();

                if (result == null)
                {
                    MessageBox.Show("Username atau password salah!", "Login Gagal",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Gunakan .ToLower() agar switch case tidak error karena beda huruf besar/kecil
                string role = result.ToString().ToLower();
                this.Hide();

                switch (role)
                {
                    case "adminpmi": // Huruf kecil semua agar konsisten dengan .ToLower()
                        FormAdminPMI adminForm = new FormAdminPMI();
                        adminForm.FormClosed += (s, args) => this.Show();
                        adminForm.Show();
                        break;

                    case "stafrs":
                        FormStafRS stafForm = new FormStafRS();
                        stafForm.FormClosed += (s, args) => this.Show();
                        stafForm.Show();
                        break;

                    case "manajer":
                        FormManajer manajerForm = new FormManajer();
                        manajerForm.FormClosed += (s, args) => this.Show();
                        manajerForm.Show();
                        break;

                    default:
                        MessageBox.Show("Role tidak dikenali: " + result.ToString(), "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.Show();
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error koneksi: " + ex.Message, "Error Database",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            // Fitur enter untuk login sudah benar
            if (e.KeyCode == Keys.Enter)
                btnLogin_Click(sender, new EventArgs());
        }

        // Tambahan: Agar user tidak perlu klik textbox saat form muncul
        private void FormLogin_Load(object sender, EventArgs e)
        {
            txtUsername.Focus();
        }
    }
}