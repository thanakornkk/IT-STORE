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
using System.Globalization;

namespace IT_STORE
{
    public partial class signin : Form
    {
        String randomCode;
        public static String to;

        public signin()
        {
            InitializeComponent();
        }

        private MySqlConnection databaseConnection()
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=stock;";
            MySqlConnection conn = new MySqlConnection(connectionString);
            return conn;
        }

        private bool isButtonClickable = true;
        private void otp_Click(object sender, EventArgs e)
        {

            string email = Mail.Text;
            if (!email.EndsWith("@gmail.com") && !email.EndsWith("@kkumail.com") && !email.EndsWith("@hotmail") && !email.EndsWith(".ac") && !email.EndsWith(".th") && !email.EndsWith(".com"))
            {
                MessageBox.Show("รูปแบบอีเมลไม่ถูกต้อง");
                return;
            }
            if (Tel.Text.Length == 10 && Tel.Text.All(char.IsDigit))
            {

            }
            else
            {
                MessageBox.Show("ใส่หมายเลขโทรศัพท์ 10 ตัว เป็นตัวเลข");
                return;
            }
            if (textpic.Text.Length < 2)
            {
                MessageBox.Show("กรุณาใส่รูปภาพ");
                return;
            }
            if (Fname.Text.Length > 0 && Lname.Text.Length > 0 && Mail.Text.Length > 0 && Username.Text.Length > 0 && Pass.Text.Length > 0
                && Address.Text.Length > 0 && Subdistrict.Text.Length > 0 && District.Text.Length > 0 && Province.Text.Length > 0 && Code.Text.Length > 0 && Detailsaddress.Text.Length > 0)
            {
                CountdownTimer_Tick();

                if (isButtonClickable)
                {

                    isButtonClickable = false;
                    otp.Enabled = false;

                    Timer timer = new Timer();
                    timer.Interval = 60000; // 1 minute 
                    timer.Tick += (s, eventArgs) =>
                    {
                        timer.Stop();

                        isButtonClickable = true;
                        otp.Enabled = true;
                    };
                    timer.Start();

                }

                string capitalizedFname = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(Fname.Text.ToLower());
                string capitalizedLname = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(Lname.Text.ToLower());

                if (capitalizedFname != Fname.Text || capitalizedLname != Lname.Text)
                {
                    MessageBox.Show("กรุณากรอกด้านหน้าชื่อสกุลเป็นตัวพิมพ์ใหญ่");
                    return;
                }

                using (MySqlConnection conn = databaseConnection())
                {
                    conn.Open();

                    string checkEmailQuery = "SELECT COUNT(*) FROM signin WHERE email = @mail ";
                    string checkUserQuery = "SELECT COUNT(*) FROM signin WHERE username = @user";

                    MySqlCommand checkEmailCmd = new MySqlCommand(checkEmailQuery, conn);
                    checkEmailCmd.Parameters.AddWithValue("@mail", Mail.Text);
                    checkEmailCmd.Parameters.AddWithValue("@user", Username.Text);
                    int emailCount = Convert.ToInt32(checkEmailCmd.ExecuteScalar());

                    MySqlCommand checkUserCmd = new MySqlCommand(checkUserQuery, conn);
                    checkUserCmd.Parameters.AddWithValue("@user", Username.Text);
                    int userCount = Convert.ToInt32(checkUserCmd.ExecuteScalar());

                    if (emailCount > 0)
                    {
                        MessageBox.Show("มีอีเมลนี้อยู่เเล้ว");
                    }
                    else if (userCount > 0)
                    {
                        MessageBox.Show("มีชื่อผู้ใช้นี้อยู่เเล้ว");
                    }
                    else
                    {
                        regis.Visible = true;
                        textBox2.Visible = true;
                        label14.Visible = true;
                        Random rand = new Random();
                        randomCode = rand.Next(999999).ToString();
                        MessageBox.Show(randomCode);

                        string to = Mail.Text;
                        string from = "thanapim56@gmail.com";
                        string pass = "haav lohj prno aqrs";
                        string messageBody = "Your reset code is " + randomCode;
                        MailMessage message = new MailMessage();
                        message.To.Add(to);
                        message.From = new MailAddress(from);
                        message.Body = messageBody;
                        message.Subject = "Password Reseting Code";

                        SmtpClient smtp = new SmtpClient("smtp.gmail.com")
                        {
                            EnableSsl = true,
                            Port = 587,
                            DeliveryMethod = SmtpDeliveryMethod.Network,
                            Credentials = new NetworkCredential(from, pass)
                        };

                        DateTime createdTime = DateTime.Now;

                        try
                        {
                            smtp.Send(message);
                            MessageBox.Show("Code Send to Email");


                            Timer timer = new Timer();
                            timer.Interval = 60000; // 1 minute in milliseconds
                            timer.Tick += (s, Event) =>
                            {
                                timer.Stop();
                                return;

                            };
                            timer.Start();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }

                    conn.Close();
                }
            }
            else
            {
                MessageBox.Show("กรุณากรอกข้อมูลให้ครบ");
            }

        }

        private int secondsRemaining = 60;
        private void CountdownTimer_Tick()
        {
            timer1 = new System.Windows.Forms.Timer();
            timer1.Interval = 1000; //กำหนดช่วงเวลาเป็น 1 วินาที
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            secondsRemaining--;
            if (secondsRemaining >= 0)
            {
                otp.Text = (secondsRemaining / 60).ToString(" ") + (secondsRemaining % 60).ToString("00");
            }
            else
            {

                timer1.Stop();
                otp.Text = "OTP";
            }
        }

        private byte[] imageData;
        private void fileimage(byte[] data)
        {

            imageData = data;
        }
        private void regis_Click(object sender, EventArgs e)
        {
            string email = Mail.Text;
            if (!email.EndsWith("@gmail.com") && !email.EndsWith("@kkumail.com"))
            {
                MessageBox.Show("รูปแบบอีเมลไม่ถูกต้อง กรุณาใส่อีเมลที่มีรูปแบบ @gmail.com");
                return;
            }

            if (Tel.Text.Length == 10 && Tel.Text.All(char.IsDigit))
            {
            }
            else
            {
                MessageBox.Show("กรุณากรอกหมายเลขโทรศัพท์ 10 หลัก เเละ เป็นตัวเลขเท่านั้น");
                return;
            }

            if (textpic.Text.Length > 2)
            {
            }
            else
            {
                MessageBox.Show("กรุณาเพิ่มรูปภาพของคุณ");
            }

            if (Fname.Text.Length > 0 && Lname.Text.Length > 0 && Mail.Text.Length > 0 && Username.Text.Length > 0 && Pass.Text.Length > 0
                && Address.Text.Length > 0 && Subdistrict.Text.Length > 0 && District.Text.Length > 0 && Province.Text.Length > 0 && Code.Text.Length > 0 && Detailsaddress.Text.Length > 0)
            {
                if (randomCode == textBox2.Text)
                {
                    try
                    {
                        string capitalizedFname = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(Fname.Text.ToLower());
                        string capitalizedLname = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(Lname.Text.ToLower());

                        if (capitalizedFname != Fname.Text || capitalizedLname != Lname.Text)
                        {
                            MessageBox.Show("กรุณากรอกด้านหน้าชื่อสกุลเป็นตัวพิมพ์ใหญ่");
                            return;
                        }

                        to = textBox2.Text;
                        using (MySqlConnection conn = databaseConnection())
                        {
                            conn.Open();
                            string sql = "INSERT INTO signin (fname , lname , username , pass , email , tel , address , subdistrict , district , province ,code , detailsaddress ) " +
                                "VALUES('" + Fname.Text + "','" + Lname.Text + "','" + Username.Text + "','" + Pass.Text + "','" + Mail.Text + "','" + Tel.Text + "' , '" + Address.Text + "'" +
                                ", '" + Subdistrict.Text + "', '" + District.Text + "' , '" + Province.Text + "' , '" + Code.Text + "', '" + Detailsaddress.Text + "' )";
                            MySqlCommand cmd = new MySqlCommand(sql, conn);
                            cmd.ExecuteNonQuery();

                            string pic = "INSERT INTO pic (username, picture) VALUES (@username, @picture)";
                            MySqlCommand picCmd = new MySqlCommand(pic, conn);
                            picCmd.Parameters.AddWithValue("@username", Username.Text);
                            picCmd.Parameters.AddWithValue("@picture", imageData);
                            picCmd.ExecuteNonQuery();

                            int sumpoint = 0;
                            string point = "INSERT INTO point (username, point) VALUES (@username, @point)";
                            MySqlCommand recpoint = new MySqlCommand(point, conn);
                            recpoint.Parameters.AddWithValue("@username", Username.Text);
                            recpoint.Parameters.AddWithValue("@point", sumpoint);
                            recpoint.ExecuteNonQuery();

                            conn.Close();

                        }

                        MessageBox.Show("สมัครสมาชิกเเล้ว");
                        Login m = new Login();
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
                    MessageBox.Show("รหัส OTP ไม่ถูกต้อง");
                }

            }
            else
            {
                MessageBox.Show("กรอกข้อมูลให้ครบ");
                Fname.Text = "";
                Lname.Text = "";
                Mail.Text = "";
                Pass.Text = "";
                Tel.Text = "";
                Username.Text = "";
            }

        }




        private void Browse_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp|All Files (.)|*.*";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.Multiselect = false;

            DialogResult result = openFileDialog1.ShowDialog();

            if (result == DialogResult.OK)
            {
                string filename = openFileDialog1.FileName;
                textpic.Text = filename;
                pictureBox2.Image = Image.FromFile(filename);
                MessageBox.Show(textpic.Text);
                byte[] imageBytes = File.ReadAllBytes(filename);
                fileimage(imageBytes);
            }
        }




        private void close_Click(object sender, EventArgs e)
        {
            Login form = new Login();
            form.Show();
            this.Hide();
        }






        private void signin_Load(object sender, EventArgs e)
        {
            regis.Visible = false;
            textBox2.Visible = false;
            label14.Visible = false;
            close.FlatStyle = FlatStyle.Flat;
            close.FlatAppearance.BorderSize = 0;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        
    }
}
