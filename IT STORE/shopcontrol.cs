using MySql.Data.MySqlClient;
using Org.BouncyCastle.Math;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IT_STORE
{


    public partial class shopcontrol : UserControl
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
        public shopcontrol()
        {
            InitializeComponent();
        }

        private void inc_Click(object sender, EventArgs e)
        {
            string id = number.Text; 
            int requestedQuantity = int.Parse(quan.Text);
            string sqlCheck = "SELECT amount FROM stockorder WHERE id = @id";
            using (MySqlConnection con = databaseConnection())
            {
                con.Open();
                using (MySqlCommand checkCmd = new MySqlCommand(sqlCheck, con))
                {
                    checkCmd.Parameters.AddWithValue("@id", id);

                    using (MySqlDataReader drb = checkCmd.ExecuteReader())
                    {
                        if (drb.Read())
                        {
                            int availableAmount = drb.GetInt32("amount");
                            if (requestedQuantity >= availableAmount)
                            {
                                MessageBox.Show("จำนวนสินค้าที่ต้องการเกินกว่าจำนวนที่มีอยู่ในสต็อก");
                            }
                            else
                            {
                                requestedQuantity += 1;
                                quan.Text = requestedQuantity.ToString();
                                UpdateAmount(id, 1); 
                                
                            }
                        }
                        
                    }
                }
                OnReflow();
                con.Close();
    
            }
        }
        private void dec_Click(object sender, EventArgs e)
        {
            string id = number.Text;
            int requestedQuantity = int.Parse(quan.Text);
            int amount = 1;

            if (requestedQuantity > 1)
            {
                UpdateAmount(id, -1);
                this.Invoke((MethodInvoker)delegate
                {

                    requestedQuantity -= amount;
                    quan.Text = requestedQuantity.ToString();

                });

            }
            OnReflow();

        }
        private void UpdateAmount(string number, int delta)
        {
            try
            {
                string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=stock;";
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    using (MySqlCommand cmd = new MySqlCommand("UPDATE baskett SET amountb = amountb + @delta WHERE number = @number", connection))
                    {
                        cmd.Parameters.AddWithValue("@delta", delta);
                        cmd.Parameters.AddWithValue("@number", number);
                        cmd.ExecuteNonQuery();
                    }
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating amount: " + ex.Message);
            }
        }

        private void de_Click(object sender, EventArgs e)
        {
            using (MySqlConnection deor = databaseConnection())
            {
                deor.Open();
                using (MySqlCommand cmddeor = deor.CreateCommand())
                {
                    DialogResult result = MessageBox.Show("นำสินค้าออก", "close", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        cmddeor.CommandText = "DELETE FROM baskett WHERE number = @id";
                        cmddeor.Parameters.AddWithValue("@id", number.Text);
                        cmddeor.ExecuteNonQuery();
                        OnReflow();
                    }
                }
                deor.Close();
            }

        }





        private void shopcontrol_Load(object sender, EventArgs e)
        {

        }

        public void SetProductData(int ids, string specb, decimal priceb, byte[] picb, int amountb)
        {
            namepro.Text = specb;
            pricepro.Text = priceb.ToString();
            number.Text = ids.ToString();
            if (picb != null && picb.Length > 0)
            {
                try
                {
                    using (MemoryStream ms = new MemoryStream(picb))
                    {
                        pictureBox.Image = Image.FromStream(ms);
                        pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("เกิดข้อผิดพลาดในการแสดงภาพ: " + ex.Message);
                }
            }
            else
            {
                pictureBox.Image = null;
                MessageBox.Show("ไม่พบภาพสำหรับสินค้านี้");
            }
            quan.Text = amountb.ToString();
        }
    }
}
