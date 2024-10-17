using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;

namespace IT_STORE
{
    public partial class track : Form
    {
        private MySqlConnection databaseConnection()
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=stock;";
            MySqlConnection conn = new MySqlConnection(connectionString);
            return conn;
        }

        public track()
        {
            InitializeComponent();
        }

        private void showEquiment()
        {
            MySqlConnection conn = databaseConnection();
            DataSet ds = new DataSet();
            conn.Open();
            MySqlCommand cmd;
            cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT id,username,`order`,totalmoney,track FROM `order`";
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            adapter.Fill(ds);

            conn.Close();
            dataEquiment.DataSource = ds.Tables[0].DefaultView;
        }

        //add 
        private void dataEquiment_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            DataGridViewRow row = dataEquiment.Rows[e.RowIndex];

            order.Text = row.Cells["id"].Value.ToString();
            trackbt.Text = row.Cells["track"].Value.ToString();
            usernamee.Text = row.Cells["username"].Value.ToString();
            int id = Convert.ToInt32(row.Cells["id"].Value);
            byte[] imageData = GetImageDataFromDatabase(id);

            if (imageData != null && imageData.Length > 0)
            {
                using (MemoryStream ms = new MemoryStream(imageData))
                {
                    pictureBox2.Image = Image.FromStream(ms);
                }
            }
            else
            {
                pictureBox2.Image = null;
            }

        }

        private byte[] GetImageDataFromDatabase(int id)
        {
            byte[] imageData = null;
            string query = "SELECT picslip FROM `order` WHERE id = @id";

            using (MySqlConnection connection = databaseConnection())
            {
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    connection.Open();
                    imageData = (byte[])command.ExecuteScalar();
                }
            }
            return imageData;
        }

        private void editbtn_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("add track", "track", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                int selectedRow = dataEquiment.CurrentCell.RowIndex;
                int editId = Convert.ToInt32(dataEquiment.Rows[selectedRow].Cells["id"].Value);
                MySqlConnection conn = databaseConnection();
                string sql = "UPDATE `order` SET track = '" + trackbt.Text + "'WHERE id ='" + editId + "'";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                conn.Close();
                if (rows > 0)
                {
                    MessageBox.Show("เพิ่มtrack");
                    showEquiment();
                }

                string from = "thanapim56@gmail.com";
                string subject = "แจ้งเตือน";
                string body = trackbt.Text;
                string ccList = null;

                using (MySqlConnection connn = databaseConnection())
                {
                    connn.Open();
                    string sqll = "SELECT email FROM signin WHERE username = @username";
                    using (MySqlCommand cmdd = new MySqlCommand(sqll, connn))
                    {
                        cmdd.Parameters.AddWithValue("@username", usernamee.Text);

                        using (MySqlDataReader reader = cmdd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string toList = reader["email"].ToString();

                                MailMessage message = new MailMessage();
                                SmtpClient smtpClient = new SmtpClient();
                                try
                                {
                                    message.From = new MailAddress(from);
                                    message.To.Add(toList);
                                    if (!string.IsNullOrEmpty(ccList))
                                        message.CC.Add(ccList);
                                    message.Subject = subject;
                                    message.IsBodyHtml = true;
                                    message.Body ="หมายเลข Tracking ของคุณ  : " + body  ;

                                    smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                                    smtpClient.EnableSsl = true;
                                    smtpClient.Timeout = 30000;
                                    smtpClient.Host = "smtp.gmail.com";
                                    smtpClient.Port = 587;
                                    smtpClient.UseDefaultCredentials = false;
                                    smtpClient.Credentials = new NetworkCredential("thanapim56@gmail.com", "haav lohj prno aqrs");

                                    smtpClient.Send(message);

                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine("Error sending email: " + ex.Message);

                                }
                                finally
                                {
                                    message.Dispose();
                                    smtpClient.Dispose();
                                }
                            }
                        }
                    }
                    connn.Close();
                }
            }
        }

        private void deletebtn_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("delete order", "order", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                int selectedRow = dataEquiment.CurrentCell.RowIndex;
                int deleteid = Convert.ToInt32(dataEquiment.Rows[selectedRow].Cells["id"].Value);
                MySqlConnection conn = databaseConnection();
                string sql = "DELETE FROM `order` WHERE id ='" + deleteid + "'";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                conn.Close();
                if (rows > 0)
                {
                    MessageBox.Show("ลบ order สำเร็จ");
                    showEquiment();
                }

                string from = "thanapim56@gmail.com";
                string subject = "แจ้งเตือน";
                string body = trackde.Text;
                string ccList = null;

                using (MySqlConnection connn = databaseConnection())
                {
                    connn.Open();
                    string sqll = "SELECT email FROM signin WHERE username = @username";
                    using (MySqlCommand cmdd = new MySqlCommand(sqll, connn))
                    {
                        cmdd.Parameters.AddWithValue("@username", usernamee.Text);

                        using (MySqlDataReader reader = cmdd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string toList = reader["email"].ToString();

                                MailMessage message = new MailMessage();
                                SmtpClient smtpClient = new SmtpClient();
                                try
                                {
                                    message.From = new MailAddress(from);
                                    message.To.Add(toList);
                                    if (!string.IsNullOrEmpty(ccList))
                                        message.CC.Add(ccList);
                                    message.Subject = subject;
                                    message.IsBodyHtml = true;
                                    message.Body = "Order ของคุณถูกยกเลิกเนื่องจาก  : " + body;

                                    smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                                    smtpClient.EnableSsl = true;
                                    smtpClient.Timeout = 30000;
                                    smtpClient.Host = "smtp.gmail.com";
                                    smtpClient.Port = 587;
                                    smtpClient.UseDefaultCredentials = false;
                                    smtpClient.Credentials = new NetworkCredential("thanapim56@gmail.com", "haav lohj prno aqrs");

                                    smtpClient.Send(message);

                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine("Error sending email: " + ex.Message);

                                }
                                finally
                                {
                                    // Dispose resources
                                    message.Dispose();
                                    smtpClient.Dispose();
                                }
                            }
                        }
                    }
                    connn.Close();
                    trackde.Visible = false;
                    deletebtn.Visible = false;
                }

            }
        }




        private void back_Click(object sender, EventArgs e)
        {
            order or = new order();
            or.Show();
            this.Hide();
        }

        private void del_Click(object sender, EventArgs e)
        {
            trackde.Visible = true;
            deletebtn.Visible = true;
        }
        private void track_Load(object sender, EventArgs e)
        {
            showEquiment();
            trackde.Visible = false;
            deletebtn.Visible = false;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
