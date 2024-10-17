using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace IT_STORE
{
    public partial class statusControl1 : UserControl
    {
        public event EventHandler Reflow;
        protected virtual void OnReflow()
        {
            Reflow?.Invoke(this, EventArgs.Empty);
        }

        private MySqlConnection databaseConnection()
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=stock;";
            MySqlConnection conn = new MySqlConnection(connectionString);
            return conn;
        }

        private string usernamee;
        private string ord;
        private string f;
        private string l;
        private string a;
        private string s;
        private string d;
        private string p;
        private string dta;
        private string c;
        private string t;
        private string totalMoneyStr;
        private int pointcheck;

        public statusControl1(string username)
        {
            InitializeComponent();

            MySqlConnection check = databaseConnection();
            check.Open();
            MySqlCommand cmdcheck = check.CreateCommand();
            cmdcheck.CommandText = "SELECT point FROM point WHERE username = @username";
            cmdcheck.Parameters.AddWithValue("@username", username);
            MySqlDataReader readercheck = cmdcheck.ExecuteReader();
            if (readercheck.Read())
            {
                if (readercheck["point"] != DBNull.Value)
                {
                    pointcheck = readercheck["point"] != DBNull.Value ? Convert.ToInt32(readercheck["point"]) : 0;
   
                }
            }
            readercheck.Close();

            MySqlConnection us = databaseConnection();
            us.Open();
            MySqlCommand cmdus = us.CreateCommand();
            cmdus.CommandText = "SELECT * FROM `order` WHERE username = @username";
            cmdus.Parameters.AddWithValue("@username", username);
            MySqlDataReader dr = cmdus.ExecuteReader();
            if (dr.Read())
            {
                usernamee = username.ToString();
                ord = dr["order"].ToString();
                f = dr["fname"].ToString();
                l = dr["lname"].ToString();
                a = dr["address"].ToString();
                s = dr["subdistrict"].ToString();
                d = dr["district"].ToString();
                p = dr["province"].ToString();
                dta = dr["detailsaddress"].ToString();
                c = dr["code"].ToString();
                t = dr["tel"].ToString();
                totalMoneyStr = dr["totalmoney"].ToString();
            }
            dr.Close();
        


        }

        private void Submit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("ยินยันการรับสินค้า", "ยืนยันการดำเนินการ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                using (MySqlConnection record = databaseConnection())
                {
                    record.Open();
                    using (MySqlCommand cmdrecord = record.CreateCommand())
                    {
                        cmdrecord.CommandText = "INSERT INTO record (username, `order`, fname, lname, address, subdistrict, district, province, detailsaddress, code, tel, totalmoney, time) " +
                            "VALUES (@user, @order, @fname, @lname, @address, @subdistrict, @district, @province, @details, @code, @tel, @totalmoney, @time)";
                        cmdrecord.Parameters.AddWithValue("@user", usernamee);
                        cmdrecord.Parameters.AddWithValue("@order", ord);
                        cmdrecord.Parameters.AddWithValue("@fname", f);
                        cmdrecord.Parameters.AddWithValue("@lname", l);
                        cmdrecord.Parameters.AddWithValue("@address", a);
                        cmdrecord.Parameters.AddWithValue("@subdistrict", s);
                        cmdrecord.Parameters.AddWithValue("@district", d);
                        cmdrecord.Parameters.AddWithValue("@province", p);
                        cmdrecord.Parameters.AddWithValue("@details", dta);
                        cmdrecord.Parameters.AddWithValue("@code", c);
                        cmdrecord.Parameters.AddWithValue("@tel", t);
                        cmdrecord.Parameters.AddWithValue("@totalmoney", totalMoneyStr);
                        cmdrecord.Parameters.AddWithValue("@time", DateTime.Today.ToString("yyyy-MM-dd"));

                        cmdrecord.ExecuteNonQuery();
                    }
                    record.Close();
                }

                using (MySqlConnection point = databaseConnection())
                {
                    if (double.TryParse(totalMoneyStr, out double totalMoney))
                    {
                        double sumpointNumeric = pointcheck + totalMoney * 5 / 1000;
                        int sumpoint = (int)sumpointNumeric;
                        point.Open();
                        using (MySqlCommand cmdpoint = point.CreateCommand())
                        {
                            cmdpoint.CommandText = "UPDATE point SET point = @point WHERE username = @user";
                            cmdpoint.Parameters.AddWithValue("@user", usernamee);
                            cmdpoint.Parameters.AddWithValue("@point", sumpoint);
                            cmdpoint.ExecuteNonQuery();
                        }
                        point.Close();
                    }
                }

                using (MySqlConnection deor = databaseConnection())
                {
                    deor.Open();
                    using (MySqlCommand cmddeor = deor.CreateCommand())
                    {
                        cmddeor.CommandText = "DELETE FROM `order` WHERE id = @id";
                        int orderId = Convert.ToInt32(idl.Text);
                        cmddeor.Parameters.AddWithValue("@id", orderId);
                        cmddeor.ExecuteNonQuery();
                    }
                    deor.Close();
                }

                OnReflow();
                MessageBox.Show("การดำเนินการเสร็จสมบูรณ์", "สำเร็จ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("การดำเนินการถูกยกเลิก", "ยกเลิก", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void pictureBox_Click(object sender, EventArgs e)
        {
            MySqlConnection connna = databaseConnection();
            connna.Open();
            MySqlCommand cmdna = connna.CreateCommand();
            cmdna.CommandText = "SELECT stopic FROM picsto ";
            MySqlDataReader drna = cmdna.ExecuteReader();

            List<byte[]> imagesList = new List<byte[]>();

            while (drna.Read())
            {
                byte[] imageBytes = (byte[])drna["stopic"];
                imagesList.Add(imageBytes);
            }

            drna.Close();
            connna.Close();
            MySqlConnection connor = databaseConnection();
            connor.Open();
            MySqlCommand cmdor = connor.CreateCommand();
            cmdor.CommandText = "SELECT * FROM `order` WHERE id = @id";
            cmdor.Parameters.AddWithValue("@id", idl.Text);
            MySqlDataReader drrr = cmdor.ExecuteReader();

            while (drrr.Read())
            {

                Form detailsForm = new Form();
                detailsForm.Text = "รายละเอียด";
                detailsForm.StartPosition = FormStartPosition.CenterScreen;
                detailsForm.Size = new Size(1000, 670);
                detailsForm.BackColor = ColorTranslator.FromHtml("#F0F4BF");

                Label detailsorder = new Label();
                detailsorder.Font = new Font("Arial", 15);
                if (imagesList.Count > 0)
                {
                    using (MemoryStream ms = new MemoryStream(imagesList[0]))
                    {
                        detailsorder.Image = Image.FromStream(ms);
                    }
                }
                detailsorder.BackgroundImageLayout = ImageLayout.Zoom;
                detailsorder.Text = "\n\n" + drrr["order"].ToString() + "\n\n\n\n\n\n\n" +
                                    " " + "ชื่อจริง : " + drrr["fname"].ToString() + "\n" +
                                    " " + "นามสกุล : " + drrr["lname"].ToString() + "\n" +
                                    " " + "ที่อยู่ : " + drrr["address"].ToString() + "\n" +
                                    " " + "ตำบล :" + drrr["subdistrict"].ToString() + "\n" +
                                    " " + "อำเภอ :" + drrr["district"].ToString() + "\n" +
                                    " " + "จังหวัด :" + drrr["province"].ToString() + "\n" +
                                    " " + "รายละเอียด :" + drrr["detailsaddress"].ToString() + "\n" +
                                    " " + "รหัสไปรษณีย์ :" + drrr["code"].ToString() + "\n" +
                                    " " + "เบอร์โทรศัพท์ :" + drrr["tel"].ToString() + "\n";
                detailsorder.Dock = DockStyle.Fill;
                detailsorder.TextAlign = ContentAlignment.TopLeft;
                detailsForm.Controls.Add(detailsorder);
                detailsForm.ShowDialog();




            }
            connor.Close();
        }








        public void SetProductData(int ids, string statust, decimal price, string trackk)
        {
            idl.Text = ids.ToString();
            tracking.Text = trackk;
            statuss.Text = statust;
            prices.Text = price.ToString();
        }


    }
}
