using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace IT_STORE
{
    public partial class producttype : UserControl
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

        public producttype(string username)
        {
            InitializeComponent();

            MySqlConnection conn = databaseConnection();
            DataSet ds = new DataSet();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT username FROM signin WHERE username = '" + username + "'";
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            adapter.Fill(ds);
            MySqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                user.Text = reader["username"].ToString();
            }
            reader.Close();

         
        }

        private void add_Click(object sender, EventArgs e)
        {
            byte[] imageBytes = null;
            using (MySqlConnection connn = databaseConnection())
            {
                connn.Open();
                using (MySqlCommand cmd = connn.CreateCommand())
                {
                    cmd.CommandText = "SELECT pic FROM stockorder WHERE id = @id";
                    cmd.Parameters.AddWithValue("@id", stid.Text);
                    using (MySqlDataReader drr = cmd.ExecuteReader())
                    {
                        if (drr.Read())
                        {
                            imageBytes = drr["pic"] as byte[];
                        }
                    }
                }

            }

            int currentAmountt = 1;
            string spec = namepro.Text;
            string pricee = pricepro.Text;
            string ids = stid.Text;

            string sqlCheck = "SELECT COUNT(*) FROM baskett WHERE number = @id AND username = @username";

            using (MySqlConnection con = databaseConnection())
            {
                con.Open();
                using (MySqlCommand checkCmd = new MySqlCommand(sqlCheck, con))
                {
                    checkCmd.Parameters.AddWithValue("@id", ids);

                    checkCmd.Parameters.AddWithValue("@username", user.Text);
                    int count = Convert.ToInt32(checkCmd.ExecuteScalar());

                    if (count > 0)
                    {
                        string updateSql = "UPDATE baskett SET amountb = amountb + 1 WHERE number = @id";
                        using (MySqlCommand updateCmd = new MySqlCommand(updateSql, con))
                        {
                            updateCmd.Parameters.AddWithValue("@id", ids);
                            updateCmd.ExecuteNonQuery();
                        }
                    }
                    else
                    {
                        string insertSql = "INSERT INTO baskett (number, specb, priceb, amountb, picb, username) VALUES (@id, @spec, @price, @amount, @pic, @username)";
                        using (MySqlCommand insertCmd = new MySqlCommand(insertSql, con))
                        {
                            insertCmd.Parameters.AddWithValue("@id", ids);
                            insertCmd.Parameters.AddWithValue("@spec", spec);
                            insertCmd.Parameters.AddWithValue("@price", pricee);
                            insertCmd.Parameters.AddWithValue("@amount", currentAmountt);
                            insertCmd.Parameters.AddWithValue("@pic", imageBytes ?? (object)DBNull.Value);
                            insertCmd.Parameters.AddWithValue("@username", user.Text);
                            insertCmd.ExecuteNonQuery();
                        }
                    }
                }
            }
            OnReflow();
        }

        private void de_Click(object sender, EventArgs e)
        {
            //details
            string id = stid.Text;
            MySqlConnection conn = databaseConnection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT pic,details,spec,price FROM stockorder WHERE id = @id";
            cmd.Parameters.AddWithValue("@id", id);

            MySqlDataReader drr = cmd.ExecuteReader();
            while (drr.Read())
            {
                Form detailsForm = new Form();
                detailsForm.Text = "รายละเอียด";
                detailsForm.StartPosition = FormStartPosition.CenterScreen;
                detailsForm.Size = new Size(900, 400);
                detailsForm.BackColor = Color.White;

                PictureBox picc = new PictureBox();
                picc.Width = 220;
                picc.Height = 170;
                picc.SizeMode = PictureBoxSizeMode.StretchImage;
                picc.Location = new Point(20, 20);

                byte[] array = (byte[])drr["pic"];
                using (MemoryStream ms = new MemoryStream(array))
                {
                    Bitmap bitmap = new Bitmap(ms);
                    picc.Image = bitmap;
                }

                Label detailsLabel = new Label();
                detailsLabel.Font = new Font("Arial", 15);
                detailsLabel.Text = "Spec :" + "\n" + drr["details"].ToString() + "\n\n" + "Model : " + drr["spec"].ToString() + "\n" + "Price :" + drr["price"].ToString();
                detailsLabel.AutoSize = true;
                detailsLabel.Font = new Font("Arial", 12);
                detailsLabel.Location = new Point(260, 20);

                detailsForm.Controls.Add(picc);
                detailsForm.Controls.Add(detailsLabel);

                detailsForm.ShowDialog();
            }
            conn.Close();
        }










        public void SetProductData(int ids ,string spec, string details, decimal price, byte[] pic, int amount)
        {
            namepro.Text = spec;
            pricepro.Text =price.ToString();
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
            de.Text = details;
            amountpro.Text =amount.ToString();
        }








        private void producttype_Load(object sender, EventArgs e)
        {
            int maxLength = 45;
            if (de.Text.Length > maxLength)
            {
                de.Text = de.Text.Substring(0, maxLength) + "\n" + "...More ";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button2.Visible = true;
            button1.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button1.Visible = true;
            button2.Visible = false;

        }

        private int _cornerRadius = 20;
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            GraphicsPath path = new GraphicsPath();
            path.StartFigure();

            path.AddArc(new Rectangle(0, 0, _cornerRadius, _cornerRadius), 180, 90);
            path.AddLine(_cornerRadius, 0, this.Width - _cornerRadius, 0);
            path.AddArc(new Rectangle(this.Width - _cornerRadius, 0, _cornerRadius, _cornerRadius), 270, 90);
            path.AddLine(this.Width, _cornerRadius, this.Width, this.Height - _cornerRadius);
            path.AddArc(new Rectangle(this.Width - _cornerRadius, this.Height - _cornerRadius, _cornerRadius, _cornerRadius), 0, 90);
            path.AddLine(this.Width - _cornerRadius, this.Height, _cornerRadius, this.Height);
            path.AddArc(new Rectangle(0, this.Height - _cornerRadius, _cornerRadius, _cornerRadius), 90, 90);
            path.AddLine(0, this.Height - _cornerRadius, 0, _cornerRadius);
            path.CloseFigure();
            this.Region = new Region(path);
            using (SolidBrush brush = new SolidBrush(this.BackColor))
            {
                e.Graphics.FillPath(brush, path);
            }
        }
    }
}
