using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Collections;

namespace IT_STORE
{
    public partial class order : Form
    {
        private MySqlConnection databaseConnection()
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=stock;";
            MySqlConnection conn = new MySqlConnection(connectionString);
            return conn;
        }
        public order()
        {
            InitializeComponent();
            statusorder();
        }

        private void statusorder()
        {
            MySqlConnection conn = databaseConnection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM `order` ";
            MySqlDataReader dr = cmd.ExecuteReader();


            while (dr.Read())
            {
                string orderr = dr["order"].ToString(); 

                int ord = Convert.ToInt32(dr["id"]);
                string user1= dr["username"].ToString();
     
                PictureBox pic = new PictureBox();
                pic.Width = 1300;
                pic.Height = 70;
                pic.BackgroundImageLayout = ImageLayout.Stretch;
                pic.BorderStyle = BorderStyle.FixedSingle;
                pic.BackColor = Color.White;
                pic.Tag = dr["id"].ToString();

                Label or = new Label();
                or.Text = orderr;
                or.Width = 150;
                or.Height = 70;
                or.BackColor = Color.White;
                or.Font = new Font("Arial", 14);
          
                or.Dock = DockStyle.Left;

                Label fname = new Label();
                fname.Text = dr["fname"].ToString();
                fname.Width = 100;
                fname.Height = 20;
                fname.BackColor = Color.White;
                fname.Font = new Font("Arial", 14);
                fname.TextAlign = ContentAlignment.MiddleLeft;
                fname.Dock = DockStyle.Left;

                Label lname = new Label();
                lname.Text = dr["lname"].ToString();
                lname.Width = 100;
                lname.Height = 20;
                lname.BackColor = Color.White;
                lname.Font = new Font("Arial", 14);
                lname.TextAlign = ContentAlignment.MiddleLeft;
                lname.Dock = DockStyle.Left;

                Label add = new Label();
                add.Text = dr["address"].ToString();
                add.Width = 100;
                add.Height = 20;
                add.BackColor = Color.White;
                add.Font = new Font("Arial", 14);
                add.TextAlign = ContentAlignment.MiddleLeft;
                add.Dock = DockStyle.Left;

                Label sub = new Label();
                sub.Text = dr["subdistrict"].ToString();
                sub.Width = 100;
                sub.Height = 20;
                sub.BackColor = Color.White;
                sub.Font = new Font("Arial", 14);
                sub.TextAlign = ContentAlignment.MiddleLeft;
                sub.Dock = DockStyle.Left;

                Label dis = new Label();
                dis.Text = dr["district"].ToString();
                dis.Width = 100;
                dis.Height = 20;
                dis.BackColor = Color.White;
                dis.Font = new Font("Arial", 14);
                dis.TextAlign = ContentAlignment.MiddleLeft;
                dis.Dock = DockStyle.Left;

                Label pro = new Label();
                pro.Text = dr["province"].ToString();
                pro.Width = 100;
                pro.Height = 20;
                pro.BackColor = Color.White;
                pro.Font = new Font("Arial", 14);
                pro.TextAlign = ContentAlignment.MiddleLeft;
                pro.Dock = DockStyle.Left;

                Label code = new Label();
                code.Text = dr["code"].ToString();
                code.Width = 100;
                code.Height = 20;
                code.BackColor = Color.White;
                code.Font = new Font("Arial", 14);
                code.TextAlign = ContentAlignment.MiddleLeft;
                code.Dock = DockStyle.Left;

                Label tel = new Label();
                tel.Text = dr["tel"].ToString();
                tel.Width = 140;
                tel.Height = 20;
                tel.BackColor = Color.White;
                tel.Font = new Font("Arial", 14);
                tel.TextAlign = ContentAlignment.MiddleLeft;
                tel.Dock = DockStyle.Left;

                Label status = new Label();
                status.Text = dr["status"].ToString();
                status.Width = 100;
                status.Height = 15;
                status.BackColor = Color.White;
                status.ForeColor = Color.Blue;
                status.Font = new Font("Arial", 10);
                status.TextAlign = ContentAlignment.MiddleLeft;
                status.Dock = DockStyle.Left;


                Button addButtons = new Button();
                addButtons.Text = "จัด"+"\n"+"ส่ง";
                addButtons.Width = 70;
                addButtons.Height = 40;
                addButtons.ForeColor = Color.White;
                addButtons.BackColor = ColorTranslator.FromHtml("#6a1b9a");
                addButtons.Font = new Font("Arial", 13);
                addButtons.TextAlign = ContentAlignment.MiddleCenter;
                addButtons.Dock = DockStyle.Left;

                
                pic.Controls.Add(addButtons);
                pic.Controls.Add(status);
                pic.Controls.Add(code);
                pic.Controls.Add(tel);
                pic.Controls.Add(pro);
                pic.Controls.Add(dis);
                pic.Controls.Add(sub);
                pic.Controls.Add(add);
                pic.Controls.Add(lname);
                pic.Controls.Add(fname);
                pic.Controls.Add(or);
                flowshoworder.Controls.Add(pic);


                addButtons.Click += (sender, e) =>
                {
                    
                    using (MySqlConnection mail = databaseConnection())
                    {
                        mail.Open();
                        using (MySqlCommand cmde = mail.CreateCommand())
                        {
                            cmde.CommandText = "SELECT username FROM signin WHERE username = @username";
                            cmde.Parameters.AddWithValue("@username", user1 );
                            using (MySqlDataReader readere = cmde.ExecuteReader())
                            {
                                if (readere.Read())
                                {
                                    userz.Text = readere["username"].ToString();
                                }
                            }
                        }
                    }
                    string stat = "✔️จัดส่งสำเร็จ";
                    using (MySqlConnection record = databaseConnection())
                    {
                        record.Open();
                        using (MySqlCommand cmdrecord = record.CreateCommand())
                        {
                            cmdrecord.CommandText = "UPDATE `order` SET status = @status WHERE id = @id";
                            cmdrecord.Parameters.AddWithValue("@status", stat);
                            cmdrecord.Parameters.AddWithValue("@id", ord);
                            cmdrecord.ExecuteNonQuery();
                            flowshoworder.Controls.Clear();
                            statusorder();

                        }
                        record.Close();

                        MessageBox.Show("ทำการจัดส่ง");
                    }


                    string from = "thanapim56@gmail.com";
                    string subject = "แจ้งเตือน";
                    string body = "สินค้าจัดส่งสำเร็จแล้ว :)";
                    string ccList = null;
                  
                    using (MySqlConnection connn = databaseConnection())
                    {
                        connn.Open();
                        string sqll = "SELECT email FROM signin WHERE username = @username";
                        using (MySqlCommand cmdd = new MySqlCommand(sqll, connn))
                        {
                            cmdd.Parameters.AddWithValue("@username", userz.Text);

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
                                        message.Body = body+ " <br><br> " + orderr;

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
                    }
                    
  

                };

                pic.Cursor = Cursors.Hand;
                pic.Margin = new Padding(10, 10, 5, 5);
            }


            conn.Close(); 
        }
        private void order_Load(object sender, EventArgs e)
        {

        }

        private void back_Click(object sender, EventArgs e)
        {
            stock t = new stock();
            t.Show();
            this.Hide();
        }

        private void flowshoworder_Paint(object sender, PaintEventArgs e)
        {

        }

        private void userz_TextChanged(object sender, EventArgs e)
        {

        }

        private void track_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            track tra = new track();
            tra.Show();
            this.Hide();
        }
    }
}
