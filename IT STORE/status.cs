using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using Org.BouncyCastle.Math.EC;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace IT_STORE
{
    public partial class status : Form
    {

        private MySqlConnection databaseConnection()
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=stock;";
            MySqlConnection conn = new MySqlConnection(connectionString);
            return conn;
        }

        private string _username;
        public status(string username)
        {
            InitializeComponent();
            _username = username;
            showst();
            
        }
        private void showst()
        {
            flowshoworder.Controls.Clear();
            using (MySqlConnection conn = databaseConnection())
            {
                conn.Open();
                using (MySqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM `order` WHERE username = @username";
                    cmd.Parameters.AddWithValue("@username", _username);
                    using (MySqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            int ids = dr.GetInt32(dr.GetOrdinal("id"));
                            string statust = dr["status"].ToString();
                            decimal price = dr.GetDecimal(dr.GetOrdinal("totalmoney"));
                            string trackk = dr["track"].ToString();

                            statusControl1 productControl = new statusControl1(Program.showusername);
                            productControl.SetProductData(ids, statust, price, trackk);

                            productControl.Reflow += ProductControl_Reflow;
                            flowshoworder.Controls.Add(productControl);
                        }
                    }
                }
            }
        }
 

        private void close_Click(object sender, EventArgs e)
        {
            store st = new store(Program.showusername);
            st.Show();
            this.Hide();
        }

        private void status_Load(object sender, EventArgs e)
        {
            close.FlatStyle = FlatStyle.Flat;
            close.FlatAppearance.BorderSize = 0;
        }

        private void ProductControl_Reflow(object sender, EventArgs e)
        {

            showst();
        }

        private void flowshoworder_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}
