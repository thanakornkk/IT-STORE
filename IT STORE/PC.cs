using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.IO;
using System.Drawing.Drawing2D;
using System.Security.Cryptography;
using System.Diagnostics;
using System.Xml.Linq;
using System.Net;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Button = System.Windows.Forms.Button;
using System.Diagnostics.Eventing.Reader;
using System.Threading;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;


namespace IT_STORE
{
    public partial class PC : Form
    {
        private MySqlConnection databaseConnection()
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=stock;";
            MySqlConnection conn = new MySqlConnection(connectionString);
            return conn;
        }
        public PC()
        {
            InitializeComponent();
        }
        //combo
        private void PC_Load(object sender, EventArgs e)
        {
            selectstock.Items.Add("pc");
            selectstock.Items.Add("monitor");
            selectstock.Items.Add("laptop");
            selectstock.Items.Add("gaming");
        }

        private void selectstock_SelectedIndexChanged(object sender, EventArgs e)
        {
            flowLayoutPanelpc.Controls.Clear();
            showdata();
        }

        private int ids;
        private string specc;
        private decimal price;
        private int amountt;
        private string details;
        private void showdata()
        {
            MySqlConnection conn = databaseConnection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT id, spec, details, price, pic, amount FROM stockorder WHERE category=@category";
            cmd.Parameters.AddWithValue("@category", selectstock.Text);
            MySqlDataReader drr = cmd.ExecuteReader();

            while (drr.Read())
            {
                ids = drr.GetInt32(drr.GetOrdinal("id"));
                specc = drr["spec"].ToString();
                details = drr["details"].ToString();
                price = drr.GetDecimal(drr.GetOrdinal("price"));
                byte[] pic = drr["pic"] as byte[];
                amountt = drr.GetInt32(drr.GetOrdinal("amount"));

                //UserControl
                stockControl productControl = new stockControl();
                productControl.SetProductData(ids, specc, details, price, pic, amountt);

                productControl.Reflow += ProductControl_Reflow;
                flowLayoutPanelpc.Controls.Add(productControl);

            }
        
            
            drr.Close();
            conn.Close();
        }

        public void addla(string idText, string nameText, string priceText, string amountText, string specText)
        {
            id.Controls.Clear();
            name.Controls.Clear();
            pricec.Controls.Clear();
            amount.Controls.Clear();
            spec.Controls.Clear();

            id.Text = idText;
            name.Text = nameText;
            pricec.Text = priceText;
            amount.Text = amountText;
            spec.Text = specText;
        }

        //up
      

        private byte[] imageData;
        private void fileimage(byte[] data)
        {

            imageData = data;
        }
       
        private void add_Click(object sender, EventArgs e)
        {
            if (decimal.TryParse(pricec.Text, out decimal price) && decimal.TryParse(amount.Text, out decimal amountValue) && price >= 0 && amountValue >= 0)
            {
                if (name.Text.Length > 0 && pricec.Text.Length > 0 && spec.Text.Length > 0 && amount.Text.Length > 0 && textpic.Text.Length > 0)
                {
                    using (MySqlConnection conn = databaseConnection())
                    {
                        conn.Open();
                        
                        string sql = "INSERT INTO stockorder (category,spec , price , details , amount , pic)  VALUES( @pc ,@spec , @pricepc ,@details , @amount , @picpc )";
                        MySqlCommand picCmd = new MySqlCommand(sql, conn);
                        picCmd.Parameters.AddWithValue("@pc", selectstock.Text);
                        picCmd.Parameters.AddWithValue("@spec", name.Text);
                        picCmd.Parameters.AddWithValue("@pricepc", pricec.Text);
                        picCmd.Parameters.AddWithValue("@details", spec.Text);
                        picCmd.Parameters.AddWithValue("@amount", amount.Text);
                        picCmd.Parameters.AddWithValue("@picpc", imageData);
                        picCmd.ExecuteNonQuery();
                        conn.Close();
                    }

                    name.Text = "";
                    pricec.Text = "";
                    spec.Text = "";
                    amount.Text = "";
                    textpic.Text = "";
                    picture.Image = null;
                    imageData = null;
                    flowLayoutPanelpc.Controls.Clear();
                    showdata();
                    MessageBox.Show("เพิ่มสินค้นเรียบร้อย");

                }
                else
                {
                    MessageBox.Show("กรุณากรอกสินค้า");
                }
            }
            else
            {
                MessageBox.Show("ค่าห้ามติดลบ");
            }
            
        }

        private void updatebt_Click(object sender, EventArgs e)
        {
            if (decimal.TryParse(pricec.Text, out decimal price) && decimal.TryParse(amount.Text, out decimal amountValue) && price >= 0 && amountValue >= 0)
            {

                if (name.Text.Length > 0)
                {
                    using (MySqlConnection conn = databaseConnection())
                    {

                        conn.Open();
                        string orderUpdateQuery = "UPDATE stockorder SET spec = @spec, details = @details, price = @pricepc, amount = @amount  WHERE id = @id";
                        using (MySqlCommand cmdorder = new MySqlCommand(orderUpdateQuery, conn))
                        {
                            cmdorder.Parameters.AddWithValue("@spec", name.Text);
                            cmdorder.Parameters.AddWithValue("@details", spec.Text);
                            cmdorder.Parameters.AddWithValue("@pricepc", pricec.Text);
                            cmdorder.Parameters.AddWithValue("@amount", amount.Text);
                            cmdorder.Parameters.AddWithValue("@id", id.Text);

                            int rowsAffected = cmdorder.ExecuteNonQuery();
                            if (rowsAffected > 0)
                            {
                                if (textpic.Text.Length > 5)
                                {
                                    using (MySqlConnection pic = databaseConnection())
                                    {

                                        pic.Open();
                                        string orderUpdateQuery1 = "UPDATE stockorder SET pic = @picpc WHERE id = @id";

                                        using (MySqlCommand cmdorder1 = new MySqlCommand(orderUpdateQuery1, pic))
                                        {
                                            cmdorder1.Parameters.AddWithValue("@picpc", imageData);
                                            cmdorder1.Parameters.AddWithValue("@id", id.Text);

                                            int rowsAffected1 = cmdorder1.ExecuteNonQuery();
                                            if (rowsAffected1 > 0)
                                            {
                                                MessageBox.Show("อัพเดท รูป สำเร็จ");
                                                name.Text = "";
                                                spec.Text = "";
                                                pricec.Text = "";
                                                amount.Text = "";
                                                id.Text = "";
                                                textpic.Text = "";
                                                picture.Image = null;
                                                imageData = null;
                                                flowLayoutPanelpc.Controls.Clear();
                                                showdata();
                                            }
                                            else
                                            {
                                                MessageBox.Show("No order updated.");
                                            }

                                        }
                                    }
                                }
                                MessageBox.Show("อัพเดท Stock สำเร็จ");
                                name.Text = "";
                                spec.Text = "";
                                pricec.Text = "";
                                amount.Text = "";
                                id.Text = "";
                                flowLayoutPanelpc.Controls.Clear();
                                showdata();
                            }
                            else
                            {
                                MessageBox.Show("No order updated.");
                            }
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("ค่าห้ามติดลบ");
            }

        }
        private void Addpicture_Click(object sender, EventArgs e)
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
                picture.Image = Image.FromFile(filename);
                MessageBox.Show(textpic.Text);
                byte[] imageBytes = File.ReadAllBytes(filename);
                fileimage(imageBytes);
            }
        }






        private void back_Click(object sender, EventArgs e)
        {
            stock t = new stock();
            t.Show();
            this.Hide();
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
           
        }

        internal void addla(string text1, string text2, string text3, string text4, object text5)
        {
            throw new NotImplementedException();
        }

        private void flowLayoutPanelpc_Paint(object sender, PaintEventArgs e)
        {

        }
        private void ProductControl_Reflow(object sender, EventArgs e)
        {
            
            flowLayoutPanelpc.Controls.Clear();
            showdata();
        }

       
    }


}
