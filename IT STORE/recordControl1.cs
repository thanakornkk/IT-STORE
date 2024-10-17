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
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace IT_STORE
{
    public partial class recordControl1 : UserControl
    {
        private MySqlConnection databaseConnection()
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=stock;";
            MySqlConnection conn = new MySqlConnection(connectionString);
            return conn;
        }

        public recordControl1()
        {
            InitializeComponent();
        }

        private void pictureBox_Click(object sender, EventArgs e)
        {
            MySqlConnection connor = databaseConnection();
            connor.Open();
            MySqlCommand cmdor = connor.CreateCommand();
            cmdor.CommandText = "SELECT * FROM record WHERE id = @id";
            cmdor.Parameters.AddWithValue("@id", idl.Text);
            MySqlDataReader drrr = cmdor.ExecuteReader();

            while (drrr.Read())
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
                detailsorder.Text = "\n\n" + drrr["order"].ToString() + "\n\n\n\n\n\n\n\n\n\n\n" +
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







        public void SetProductData(int ids, decimal price)
        {
            idl.Text = ids.ToString();
            prices.Text = price.ToString();
        }

    }
}
