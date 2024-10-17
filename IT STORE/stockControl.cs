using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.Ocsp;
using Org.BouncyCastle.Math;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace IT_STORE
{
    public partial class stockControl : UserControl
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
  
        public stockControl()
        {
            InitializeComponent();

        }
        //ลบ
        private void delete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("คุณต้องการลบสินค้าใช่หรือไม่", "close", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                using (MySqlConnection deor = databaseConnection())
                {
                    deor.Open();
                    using (MySqlCommand cmddeor = deor.CreateCommand())
                    {
                        cmddeor.CommandText = "DELETE FROM stockorder WHERE id = @id";
                        int orderId = Convert.ToInt32(stid.Text);
                        cmddeor.Parameters.AddWithValue("@id", orderId);
                        cmddeor.ExecuteNonQuery();
                    }
                    deor.Close();
                }

                MessageBox.Show("ลบสินค้าเรียบร้อย");
                OnReflow();
            }
        }






        public void addl()
        {

            PC formShop = Application.OpenForms.OfType<PC>().FirstOrDefault();
            if (formShop != null)
            {
                formShop.addla(stid.Text, names.Text, pricepro.Text, amountpro.Text, spec.Text);
            }
        }


        private void pictureBox_Click(object sender, EventArgs e)
        {
            addl();
        }



        public void SetProductData(int ids, string specc, string details, decimal price, byte[] pic, int amountt)
        {
            names.Text = specc;
            pricepro.Text = price.ToString();
            stid.Text = ids.ToString();
            if (pic != null && pic.Length > 0)
            {
                try
                {
                    using (MemoryStream ms = new MemoryStream(pic))
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
            amountpro.Text = amountt.ToString();
            spec.Text = details;
        }

      
    }
}
