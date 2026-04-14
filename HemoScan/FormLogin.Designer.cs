namespace HemoScan
{
    partial class FormLogin
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // Form
            this.Text = "HemoScan - Login";
            this.ClientSize = new System.Drawing.Size(380, 260);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;

            // lblTitle
            this.lblTitle.Text = "HEMOSCAN";
            this.lblTitle.Font = new System.Drawing.Font("Arial", 18, System.Drawing.FontStyle.Bold);
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTitle.SetBounds(0, 20, 380, 45);

            // lblUsername
            this.lblUsername.Text = "Username:";
            this.lblUsername.SetBounds(60, 90, 80, 24);

            // txtUsername
            this.txtUsername.SetBounds(150, 87, 170, 24);

            // lblPassword
            this.lblPassword.Text = "Password:";
            this.lblPassword.SetBounds(60, 130, 80, 24);

            // txtPassword
            this.txtPassword.SetBounds(150, 127, 170, 24);
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPassword_KeyDown);

            // btnLogin
            this.btnLogin.Text = "Login";
            this.btnLogin.SetBounds(145, 180, 90, 34);
            this.btnLogin.BackColor = System.Drawing.Color.SteelBlue;
            this.btnLogin.ForeColor = System.Drawing.Color.White;
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);

            this.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblTitle,
                this.lblUsername,
                this.txtUsername,
                this.lblPassword,
                this.txtPassword,
                this.btnLogin
            });

            this.ResumeLayout(false);
            this.PerformLayout();
        }

        // Deklarasi kontrol — HANYA di sini, jangan duplikat di .cs
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button btnLogin;
    }
}