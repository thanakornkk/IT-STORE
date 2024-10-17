using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace IT_STORE
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        private MySqlConnection databaseConnection()
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=stock;";
            MySqlConnection conn = new MySqlConnection(connectionString);
            return conn;
        }
     
        private void BTLOGIN_Click(object sender, EventArgs e)
        {
            if (username.Text == "Admin" && password.Text == "Admin123")
            {
                MessageBox.Show("กำลังไปหน้า stock");
                stock st = new stock();
                st.Show();
                this.Hide();
            }
            else
            {
                using (MySqlConnection conn = databaseConnection())
                {
                    string sql = "SELECT * FROM signin WHERE username = @username AND pass = @password";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@username", username.Text);
                    cmd.Parameters.AddWithValue("@password", password.Text);

                    try
                    {
                        conn.Open();
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                Program.showusername = username.Text;
                                MessageBox.Show("เข้าสู่ระบบสำเร็จ");

                                store form = new store(username.Text);
                                form.Show();
                                this.Hide();
                                ac a = new ac(username.Text);
                                payment pay = new payment(username.Text);
                                status m = new status(username.Text);
                                record show = new record(username.Text);

                                producttype user = new producttype(username.Text);
                                statusControl1 st = new statusControl1(username.Text);
                             
                            }
                            else
                            {
                                MessageBox.Show("บัญชีหรือรหัสไม่ถูกต้อง");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred: " + ex.Message);
                    }
                }
            }
        }

        private void linkforgetpass_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            forgetpassword from = new forgetpassword();
            from.Show();
            this.Hide();
        }

        private void linksignin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            signin form = new signin();
            form.Show();
            this.Hide(); 
        }

        private void eyeshow_Click(object sender, EventArgs e)
        {
            if (password.PasswordChar == '*')
            {
                eyehide.BringToFront();
                password.PasswordChar = '\0';
            }
        }

        private void eyehide_Click(object sender, EventArgs e)
        {
            if (password.PasswordChar == '\0')
            {
                eyeshow.BringToFront();
                password.PasswordChar = '*';
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {
            password.PasswordChar = '*';
            close.FlatStyle = FlatStyle.Flat;
            close.FlatAppearance.BorderSize = 0;
        }

        private void close_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("ออกจากโปรเเกรม", "close", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close(); // ปิด
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}
