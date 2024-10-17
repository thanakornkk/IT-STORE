using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;
using static QRCoder.PayloadGenerator;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using Image = System.Drawing.Image;
namespace IT_STORE
{
    public partial class ac : Form
    {
        private MySqlConnection databaseConnection()
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=stock;";
            MySqlConnection conn = new MySqlConnection(connectionString);
            return conn;
        }
        public ac(string username)
        {
            InitializeComponent();
            MySqlConnection conn = databaseConnection();
            conn.Open();
            string sql = "SELECT * FROM signin WHERE username = @username";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@username", username);

            MySqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                label_fname.Text = reader["fname"].ToString();
                label_lname.Text = reader["lname"].ToString();
                label_uname.Text = reader["username"].ToString();
                label_mail.Text = reader["email"].ToString();
                label_tel.Text = reader["tel"].ToString();
                labeladdress.Text = reader["address"].ToString();
                labelsubdistrict.Text = reader["subdistrict"].ToString();
                labeldistrict.Text = reader["district"].ToString();
                labelprovince.Text = reader["province"].ToString();
                labelcode.Text = reader["code"].ToString();
                griddetails.Text = reader["detailsaddress"].ToString();


                textBoxfname.Text = reader["fname"].ToString();
                textBoxlname.Text = reader["lname"].ToString();
                textBoxemail.Text = reader["email"].ToString();
                textBoxtel.Text = reader["tel"].ToString();
                textBoxaddress.Text = reader["address"].ToString();
                textBoxsubdistrict.Text = reader["subdistrict"].ToString();
                textBoxdistrict.Text = reader["district"].ToString();
                textBoxprovince.Text = reader["province"].ToString();
                textBoxcode.Text = reader["code"].ToString();
                textBoxdetails.Text = reader["detailsaddress"].ToString();
                pointt();
            }
            else
            {
                MessageBox.Show("User not found.");
                reader.Close();
                conn.Close();
                return;
            }
            reader.Close();
            conn.Close();

            using (MySqlConnection s = databaseConnection())
            {
                sql = "SELECT picture FROM pic WHERE username = @username";
                MySqlCommand picCmd = new MySqlCommand(sql, s);
                picCmd.Parameters.AddWithValue("@username", username);

                try
                {
                    s.Open();
                    byte[] imageData = (byte[])picCmd.ExecuteScalar();

                    if (imageData != null && imageData.Length > 0)
                    {
                        using (MemoryStream ms = new MemoryStream(imageData))
                        {
                            pictureBox2.Image = Image.FromStream(ms);
                        }
                    }
                    else
                    {
                        MessageBox.Show("ไม่มีรูปภาพ");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }
      
        private void edituser_Click(object sender, EventArgs e)
        {
            string email = textBoxemail.Text;
            if (!email.EndsWith("@gmail.com") && !email.EndsWith("@kkumail.com"))
            {
                MessageBox.Show("รูปแบบอีเมลไม่ถูกต้อง กรุณาใส่อีเมลที่มีรูปแบบ @gmail.com");
                return; // หยุดการทำงานทันทีหากอีเมลไม่ถูกต้อง
            }

            if (textBoxtel.Text.Length == 10 && int.TryParse(textBoxtel.Text, out int telNumber))
            {
                if (textBoxfname.Text.Length > 0 && textBoxlname.Text.Length > 0 && textBoxemail.Text.Length > 0)
                {

                    try
                    {
                        using (MySqlConnection connor = databaseConnection())
                        {
                            connor.Open();
                            string sql = "UPDATE signin SET fname = @fname, lname = @lname, tel = @tel , email = @emaill ,address = @address, subdistrict = @subdistrict, district = @district , province = @province , detailsaddress = @etailsaddress WHERE username = @username";
                            MySqlCommand cmd = new MySqlCommand(sql, connor);
                            cmd.Parameters.AddWithValue("@fname", textBoxfname.Text);
                            cmd.Parameters.AddWithValue("@lname", textBoxlname.Text);
                            cmd.Parameters.AddWithValue("@tel", textBoxtel.Text);
                            cmd.Parameters.AddWithValue("@emaill", textBoxemail.Text);
                  
                            cmd.Parameters.AddWithValue("@address", textBoxaddress.Text);
                            cmd.Parameters.AddWithValue("@subdistrict", textBoxsubdistrict.Text);
                            cmd.Parameters.AddWithValue("@district", textBoxdistrict.Text);
                            cmd.Parameters.AddWithValue("@province", textBoxprovince.Text);
                            cmd.Parameters.AddWithValue("@etailsaddress", textBoxdetails.Text);
                            cmd.Parameters.AddWithValue("@username", label_uname.Text);

                            cmd.ExecuteNonQuery();
                        }

                        MessageBox.Show("เเก้ไขข้อมูลเรียบร้อย");
                        ac m = new ac(Program.showusername);
                        m.Show();
                        this.Hide();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                }
                else
                {
                    MessageBox.Show("กรอกข้อมูลให้ครบ");
                    textBoxfname.Text = "";
                    textBoxlname.Text = "";
                    textBoxemail.Text = "";
                    textBoxtel.Text = "";
                }
            }
            else
            {
                MessageBox.Show("กรอกหมายเลขโทรศัพท์ 10 หลัก หรือ เป็นกรอกเป็นตัวเลข");
            }
        }


        private byte[] imageData;
        private void fileimage(byte[] data)
        {

            imageData = data;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            btpic.Visible = true;
            picbox.Visible = true;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp|All Files (.)|*.*";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.Multiselect = false;

            DialogResult result = openFileDialog1.ShowDialog();

            if (result == DialogResult.OK)
            {
                string filename = openFileDialog1.FileName;
                textpic.Text = filename;
                picbox.Image = Image.FromFile(filename);
                byte[] imageBytes = File.ReadAllBytes(filename);
                fileimage(imageBytes);
            }
        }

        private void btpic_Click(object sender, EventArgs e)
        {

            using (MySqlConnection connor = databaseConnection())
            {
                connor.Open();

                if (textpic.Text.Length > 5)
                {
                    using (MySqlConnection connpic = databaseConnection())
                    {
                        connpic.Open();
                        string pic = "UPDATE pic SET picture = @picture WHERE username = @username";
                        MySqlCommand picCmd = new MySqlCommand(pic, connpic);
                        picCmd.Parameters.AddWithValue("@username", label_uname.Text);
                        picCmd.Parameters.AddWithValue("@picture", imageData);
                        picCmd.ExecuteNonQuery();

                        MessageBox.Show("เปลี่ยนรูป");
                        ac m = new ac(Program.showusername);
                        m.Show();
                        this.Hide();
                    }
                }
                else
                {

                    MessageBox.Show("กรุณาใส่รูปภาพ");
                }
            }
        }

        private void btdelete_Click(object sender, EventArgs e)
        {
            string username = label_uname.Text;

            if (string.IsNullOrEmpty(username))
            {
                MessageBox.Show("Please enter a username to delete.");
                return;
            }
            DialogResult result = MessageBox.Show("ลบ", "delete account", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                using (MySqlConnection s = databaseConnection())
                {
                    s.Open(); 

                    MySqlCommand deleteCmd = new MySqlCommand(); 
                    deleteCmd.Connection = s;

              
                    deleteCmd.CommandText = "DELETE FROM signin WHERE username = @username";
                    deleteCmd.Parameters.AddWithValue("@username", username);
                    deleteCmd.ExecuteNonQuery();

                    deleteCmd.CommandText = "DELETE FROM point WHERE username = @username";
                    deleteCmd.ExecuteNonQuery();

                    deleteCmd.CommandText = "DELETE FROM pic WHERE username = @username";
                    deleteCmd.ExecuteNonQuery();

        
                    int rowsAffected = deleteCmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Account deleted successfully.");
                    }
                    else
                    {
                        MessageBox.Show("No account ");
                    }

                    s.Close();
                    Login log = new Login();
                    log.Show();
                    this.Hide();
                }
            }
        }

        private void pointt()
        {
            MySqlConnection conn = databaseConnection();
            conn.Open();
            string sql = "SELECT point FROM point WHERE username = @username";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@username", label_uname.Text);

            MySqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                labelpoint.Text = reader["point"].ToString();
            }

        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void POINT_Click(object sender, EventArgs e)
        {

        }

        private void close_Click(object sender, EventArgs e)
        {
            store st = new store(Program.showusername);
            st.Show();
            this.Hide();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            textBoxfname.Visible = true;
            textBoxlname.Visible = true;
            textBoxemail.Visible = true;
            textBoxtel.Visible = true;
            textBoxaddress.Visible = true;
            textBoxsubdistrict.Visible = true;
            textBoxdistrict.Visible = true;
            textBoxprovince.Visible = true;
            textBoxcode.Visible = true;
            textBoxdetails.Visible = true;
            edituser.Visible = true;
            canceluser.Visible = true;
            button2.Visible = false;

        }


        private void ac_Load(object sender, EventArgs e)
        {
            textBoxfname.Visible = false;
            textBoxlname.Visible = false;
            textBoxemail.Visible = false;
            textBoxtel.Visible = false;
            textBoxaddress.Visible = false;
            textBoxsubdistrict.Visible = false;
            textBoxdistrict.Visible = false;
            textBoxprovince.Visible = false;
            textBoxcode.Visible = false;
            textBoxdetails.Visible = false;
            edituser.Visible = false;
            canceluser.Visible = false;
            btpic.Visible = false;
            picbox.Visible = false;

            close.FlatStyle = FlatStyle.Flat;
            close.FlatAppearance.BorderSize = 0;
        }

        private void canceluser_Click(object sender, EventArgs e)
        {
            textBoxfname.Visible = false;
            textBoxlname.Visible = false;
            textBoxemail.Visible = false;
            textBoxtel.Visible = false;
            textBoxaddress.Visible = false;
            textBoxsubdistrict.Visible = false;
            textBoxdistrict.Visible = false;
            textBoxprovince.Visible = false;
            textBoxcode.Visible = false;
            textBoxdetails.Visible = false;
            edituser.Visible = false;
            canceluser.Visible = false;
            btpic.Visible = false;
            picbox.Visible = false;

            button2.Visible = true;
        }



    }

}
