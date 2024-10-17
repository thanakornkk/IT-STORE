using MySql.Data.MySqlClient;
using Org.BouncyCastle.Math;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;



namespace IT_STORE
{
    public partial class shop : Form
    {

        public shop(string username)
        {
            InitializeComponent();
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=stock;";

            MySqlConnection conn = new MySqlConnection(connectionString);
            DataSet ds = new DataSet();
            conn.Open();
            MySqlCommand cmdu = conn.CreateCommand();
            cmdu.CommandText = "SELECT username FROM signin WHERE username = '" + username + "'";
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmdu);
            adapter.Fill(ds);
            MySqlDataReader reader = cmdu.ExecuteReader();
            if (reader.Read())
            {
                user.Text = reader["username"].ToString();
            }
            reader.Close();

            MySqlConnection check = new MySqlConnection(connectionString);
            check.Open();
            MySqlCommand cmdcheck = check.CreateCommand();
            cmdcheck.CommandText = "SELECT point FROM point WHERE username = @username";
            cmdcheck.Parameters.AddWithValue("@username", username);
            MySqlDataReader readercheck = cmdcheck.ExecuteReader();
            if (readercheck.Read())
            {
                checkpoint.Text = readercheck["point"].ToString();
            }
            readercheck.Close();
            conn.Close();
            sshop();

        }

        private void sshop()
        {
            flowLayoutPanel1.Controls.Clear();
            labeltotal.Text = "0";
            labelv.Text = "0";
            labelp.Text = "0";
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=stock;";
            int totalPrice = 0;
            int vat = 0;

            string query = "SELECT number, specb, priceb, amountb, picb FROM baskett WHERE username=@username";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@username", user.Text);

                    using (MySqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            int ids = dr.GetInt32(dr.GetOrdinal("number"));
                            string specb = dr["specb"].ToString();
                            decimal priceb = dr.GetDecimal(dr.GetOrdinal("priceb"));
                            byte[] picb = dr["picb"] as byte[];
                            int amountb = dr.GetInt32(dr.GetOrdinal("amountb"));
                         
                            shopcontrol productControl = new shopcontrol();
                            productControl.SetProductData(ids, specb, priceb, picb, amountb);

                            productControl.Reflow += ProductControl_Reflow;
                            flowLayoutPanel1.Controls.Add(productControl);
                            totalPrice += (int)(priceb * amountb);
                            vat += (int)(priceb * amountb * 0.07m);
                            int total = 0;
                            total = totalPrice + vat;

                            labeltotal.Text = total.ToString();
                            labelp.Text = totalPrice.ToString();
                            labelv.Text = vat.ToString();
                        }
                    }
                }
            }

        }
        private void checkpoint_CheckedChanged(object sender, EventArgs e)
        {
           
            
                CalculateTotal();
           
        }

        private void CalculateTotal()
        {
            if (int.TryParse(labeltotal.Text, out int too) && int.TryParse(checkpoint.Text, out int checko))
            {
             
                int moneyy = 0;
                
                if (checkpoint.Checked)
                {

                    int to = Convert.ToInt32(labeltotal.Text);
                    int check = Convert.ToInt32(checkpoint.Text);
                    int summoney = to - check;

                    labeltotal.Text = summoney.ToString();

                }

                else
                {
                    int to = Convert.ToInt32(labeltotal.Text);
                    int check = Convert.ToInt32(checkpoint.Text);
                    moneyy = to + check;
                    labeltotal.Text = moneyy.ToString();
                }
                
              
            }
        }

        private void bpay_Click(object sender, EventArgs e)
        {
            try
            {
                string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=stock;";
                string query = "SELECT number, specb, priceb, amountb, picb FROM baskett WHERE username=@username";

                string resultString = "";
                string resultspec = "";
                string resultsprr = "";
                string resultsam = "";

                int num = 0;
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    try
                    {
                        connection.Open();
                        MySqlCommand command = new MySqlCommand(query, connection);
                        command.Parameters.AddWithValue("@username", user.Text);

                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            StringBuilder result = new StringBuilder();
                            StringBuilder spec = new StringBuilder();
                            StringBuilder prr = new StringBuilder();
                            StringBuilder am = new StringBuilder();
                            result.AppendLine("------------------------------------------------"+"\n");

                            while (reader.Read())
                            {
                                num++;
                                result.AppendFormat("{0, -10} {1, -12} {2, -8} {3, -10} \n",
                                    "Number "+reader["number"],
                                    "Spec "+reader["specb"],
                                    "Price "+reader["priceb"],
                                    "Amount "+reader["amountb"]);

                                spec.Append(num+"."+reader["specb"].ToString() +"\n");
                                prr.Append(reader["priceb"].ToString() + "\n");
                                am.Append(reader["amountb"].ToString() + "\n");
                            }

                            resultString = result.ToString();
                            resultspec = spec.ToString();
                            resultsprr = prr.ToString();
                            resultsam = am.ToString();

                        }
                        if (num > 0)
                        {
                            MessageBox.Show("กำลังไปที่หน้าจ่ายเงิน");

                            string pr = labelp.Text;
                            string vat = labelv.Text;
                            string totalpr = labeltotal.Text;
                            string status = "⏰กำลังดำเนินการจัดส่ง";

                            using (MySqlCommand cmd = new MySqlCommand("INSERT INTO `order` (username, `order`, totalmoney, status, vat, money , spec ,pr ,am) VALUES (@user, @orderDetails, @totalmoney, @status, @vat, @money ,@spec ,@pr ,@am)", connection))
                            {
                                cmd.Parameters.AddWithValue("@user", user.Text);
                                cmd.Parameters.AddWithValue("@orderDetails", resultString);
                                cmd.Parameters.AddWithValue("@totalmoney", totalpr);
                                cmd.Parameters.AddWithValue("@status", status);
                                cmd.Parameters.AddWithValue("@vat", vat);
                                cmd.Parameters.AddWithValue("@money", pr);
                                cmd.Parameters.AddWithValue("@spec", resultspec);
                                cmd.Parameters.AddWithValue("@pr", resultsprr);
                                cmd.Parameters.AddWithValue("@am", resultsam);
                                cmd.ExecuteNonQuery();
                            }

                            payment pay = new payment(Program.showusername);
                            pay.Show();
                            this.Hide();
                        }

                        else
                        {
                            MessageBox.Show("กรุณาเลือกสินค้า", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }



                        connection.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"An error occurred: {ex.Message}");
                    }

                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("เกิดข้อผิดพลาด: " + ex.Message);
            }


        }
   

        private void back_Click(object sender, EventArgs e)
        {
            store s = new store(Program.showusername);
            s.Show();
            this.Hide();
        }

      
        private void label4_Click(object sender, EventArgs e)
        {
            this.BackColor = ColorTranslator.FromHtml("#D9D9D9");
        }

      
        public void ClearFlowLayoutPanel()
        {
            flowLayoutPanel1.Controls.Clear();
        }
        private void ProductControl_Reflow(object sender, EventArgs e)
        {

            sshop();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
