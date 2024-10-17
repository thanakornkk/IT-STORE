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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using Org.BouncyCastle.Math;


namespace IT_STORE
{
    public partial class store : Form
    { 
        private MySqlConnection databaseConnection()
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=stock;";
            MySqlConnection conn = new MySqlConnection(connectionString);
            return conn;
        }

        public store(string username)
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

            basnum();

        }
         //จำนวนสินค้า
       private void basnum()
        {
            nump.Text = "0";
            int totalAmount = 0;  

            string query = "SELECT amountb FROM baskett WHERE username=@username";
            MySqlConnection connection = databaseConnection();
            {
                connection.Open();
                using (MySqlCommand cmdb = new MySqlCommand(query, connection))
                {
                    cmdb.Parameters.AddWithValue("@username", user.Text);
                    using (MySqlDataReader dr = cmdb.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            int amountb = Convert.ToInt32(dr["amountb"]);
                            totalAmount += amountb;
                        }
                        nump.Text = totalAmount.ToString();
                    }
                }
            }
        }

        

        private string textsearch;
        private void BTPC_Click(object sender, EventArgs e){ShowPanelAndSearch(flowLayoutPanel2, "pc");}
        private void BTMO_Click(object sender, EventArgs e){ShowPanelAndSearch(flowLayoutPanel2, "monitor");}
        private void BTLAP_Click(object sender, EventArgs e){ShowPanelAndSearch(flowLayoutPanel2, "laptop");}

        private void BTG_Click(object sender, EventArgs e){  ShowPanelAndSearch(flowLayoutPanel2, "gaming");}

        private void ShowPanelAndSearch(FlowLayoutPanel panelToShow, string searchText)
        {

          
            flowLayoutPanel2.Visible = false;
            panelToShow.Controls.Clear();
            panelToShow.Visible = true;
            textsearch = searchText;
            Getsearchdatapc();
        }


        private Label dessc;
        private void Getsearchdatapc()
        {
            flowLayoutPanel2.Controls.Clear();

            using (MySqlConnection connn = databaseConnection())
            {
                connn.Open();
                using (MySqlCommand cmd = connn.CreateCommand())
                {
                   
                    cmd.CommandText = "SELECT id, spec, details, price, pic , amount FROM stockorder WHERE category=@category AND spec LIKE '%" + textBox1.Text + "%'";
                    cmd.Parameters.AddWithValue("@category", textsearch);
                    using (MySqlDataReader drr = cmd.ExecuteReader())
                    {
                        while (drr.Read())
                        {
                            int ids = drr.GetInt32(drr.GetOrdinal("id"));
                            string spec = drr["spec"].ToString();
                            string details = drr["details"].ToString();
                            decimal price = drr.GetDecimal(drr.GetOrdinal("price"));
                            byte[] pic = drr["pic"] as byte[];
                            int amount = drr.GetInt32(drr.GetOrdinal("amount"));

                            //UserControl
                            producttype productControl = new producttype(Program.showusername);
                            productControl.SetProductData(ids, spec, details, price, pic, amount);
                            productControl.Reflow += ProductControl_Reflow;
                            flowLayoutPanel2.Controls.Add(productControl);
                            
                        }
                    }
                }
                
            }
 
        }

        //---------------------------------------------------------------------------------------------

       
        private void logout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("ออกจากระบบ", "close", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Login log = new Login();
                log.Show();
                this.Hide();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Getsearchdatapc();
        }


        private void BTAC_Click(object sender, EventArgs e)
        {
            ac a = new ac(Program.showusername);
            a.Show();
            this.Hide();
        }

        private void BTSTATUS_Click(object sender, EventArgs e)
        {
            status st = new status(Program.showusername);
            st.Show();
            this.Hide();
        }

        private void BTREC_Click(object sender, EventArgs e)
        {
            record rec = new record(Program.showusername);
            rec.Show();
            this.Hide();
        }


        private void basket_Click(object sender, EventArgs e)
        {
       
            shop s = new shop(Program.showusername);
            s.Show();
            this.Hide();
        }


        private void store_Load(object sender, EventArgs e)
        {

            BTPC.FlatStyle = FlatStyle.Flat;
            BTPC.FlatAppearance.BorderSize = 0;

            BTLAP.FlatStyle = FlatStyle.Flat;
            BTLAP.FlatAppearance.BorderSize = 0;

            BTMO.FlatStyle = FlatStyle.Flat;
            BTMO.FlatAppearance.BorderSize = 0;

            BTG.FlatStyle = FlatStyle.Flat;
            BTG.FlatAppearance.BorderSize = 0;

            BTSTATUS.FlatStyle = FlatStyle.Flat;
            BTSTATUS.FlatAppearance.BorderSize = 0;

            BTREC.FlatStyle = FlatStyle.Flat;
            BTREC.FlatAppearance.BorderSize = 0;

            logout.FlatStyle = FlatStyle.Flat;
            logout.FlatAppearance.BorderSize = 0;
            

        }
     
        private void ProductControl_Reflow(object sender, EventArgs e)
        {
            MessageBox.Show("เพิ่มสินค้าเเล้ว");
            basnum();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
