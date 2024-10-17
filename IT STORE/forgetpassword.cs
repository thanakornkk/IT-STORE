using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

using System.Net.Mail;
using System.Net;

using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

using System.Data.SqlClient;
using System.IO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ScrollBar;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Reflection.Emit;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;
namespace IT_STORE
{
    public partial class forgetpassword : Form
    {
        public forgetpassword()
        {
            InitializeComponent();
        }
        private MySqlConnection databaseConnection()
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=stock;";
            MySqlConnection conn = new MySqlConnection(connectionString);
            return conn;
        }

        String randomCode;
        public static String to;
        private void btnext_Click(object sender, EventArgs e)
        {
            MySqlConnection connn = databaseConnection();
            connn.Open();
            string username = Pass.Text;
            string email = Mail.Text;
            string query = "SELECT email FROM signin WHERE username = @username";
            MySqlCommand cmd = new MySqlCommand(query, connn);
            cmd.Parameters.AddWithValue("@username", username);
            try
            {
                using (MySqlDataReader reader1 = cmd.ExecuteReader())
                {
                    if (reader1.HasRows)
                    {
                        reader1.Read(); // Move to the first row
                        string dbemail = reader1["email"].ToString();
                        if (dbemail == email)
                        {
                            MessageBox.Show("อีเมลถูกต้อง");
                            btnext.Visible = false;
                            btsubmit.Visible = true;
                            textBox2.Visible = true;
                            label2.Visible = true;

                            {
                                String from, pass, messageBody;
                                Random rand = new Random();
                                randomCode = (rand.Next(999999)).ToString();
                                MailMessage message = new MailMessage();
                               
                                to = (Mail.Text).ToString();
                                from = "thanapim56@gmail.com";
                                pass = "haav lohj prno aqrs";
                                messageBody = "Your reset code is " + randomCode;
                                message.To.Add(to);
                                message.From = new MailAddress(from);
                                message.Body = messageBody;
                                message.Subject = "Password Reseting Code";
                                SmtpClient smtp = new SmtpClient("smtp.gmail.com");
                                smtp.EnableSsl = true;
                                smtp.Port = 587;
                                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                                smtp.Credentials = new NetworkCredential(from, pass);

                                DateTime createdTime = DateTime.Now;

                                try
                                {
                                    smtp.Send(message);
                                    MessageBox.Show("Code Send to Email");


                                    DateTime currentTime = DateTime.Now;

                                    if ((currentTime - createdTime).TotalMinutes > 1)
                                    {
                                        randomCode = (rand.Next(999999)).ToString();
                                        messageBody = "Your reset code is " + randomCode;
                                        message.Body = messageBody;
                                        smtp.Send(message); // ส่งรหัส OTP ใหม่
                                        MessageBox.Show("New Code Send to Email");
                                        createdTime = DateTime.Now;
                                    }
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message);
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("อีเมลไม่ถูกต้อง");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                connn.Close();
            }
        }

        private void btreset_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == textBox3.Text)
            {

                MySqlConnection conn = databaseConnection();
                conn.Open();
                string up = "UPDATE signin SET pass = '" + textBox1.Text + "' WHERE username = '" + Pass.Text + "'";
                MySqlCommand passs = new MySqlCommand(up, conn);
                int rowsAffected = passs.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    MessageBox.Show("เปลี่ยนรหัสผ่านสำเร็จ");
                    Login lo = new Login();
                    lo.Show();
                    this.Hide();
                }
            }
            else
            {
                MessageBox.Show("รหัสผ่านไม่ตรงกัน");
            }
        }


        private void close_Click(object sender, EventArgs e)
        {
            Login lo = new Login();
            lo.Show();
            this.Hide();
        }







        private void btsubmit_Click(object sender, EventArgs e)
        {
            if (randomCode == textBox2.Text)
            {
                to = textBox2.Text;
                MessageBox.Show("ยืนยันสำเร็จ");
                label2.Visible = false;
                textBox2.Visible = false;
                btsubmit.Visible = false;
                label5.Visible = true;
                textBox1.Visible = true;
                label6.Visible = true;
                textBox3.Visible = true;
                btreset.Visible = true;
                eyehide.Visible = true;
                eyeshow.Visible = true;
                button4.Visible = true;
                button5.Visible = true;
            }
            else
            {
                MessageBox.Show("OTP ไม่ถูกต้อง");
            }
        }
        private void eyehide_Click(object sender, EventArgs e)
        {

            if (textBox1.PasswordChar == '\0')
            {
                eyeshow.BringToFront();
                textBox1.PasswordChar = '*';
            }
        }

        private void eyeshow_Click(object sender, EventArgs e)
        {
            if (textBox1.PasswordChar == '*')
            {
                eyehide.BringToFront();
                textBox1.PasswordChar = '\0';
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox3.PasswordChar == '\0')
            {
                button5.BringToFront();
                textBox3.PasswordChar = '*';
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
          
            if (textBox3.PasswordChar == '*')
            {
                button4.BringToFront();
                textBox3.PasswordChar = '\0';
            }
        }

        private void forgetpassword_Load(object sender, EventArgs e)
        {
            label2.Visible = false;
            textBox2.Visible = false;
            btsubmit.Visible = false;

            textBox2.Visible = false;
            label2.Visible = false;

            label5.Visible = false;
            textBox1.Visible = false;
            label6.Visible = false;
            textBox3.Visible = false;
            btreset.Visible = false;

            eyehide.Visible = false;
            eyeshow.Visible = false;
            button4.Visible = false;
            button5.Visible = false;

            textBox1.PasswordChar = '*';
            textBox3.PasswordChar = '*';

            close.FlatStyle = FlatStyle.Flat;
            close.FlatAppearance.BorderSize = 0;
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
