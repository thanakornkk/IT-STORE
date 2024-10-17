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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace IT_STORE
{
    public partial class record : Form
    {
        private MySqlConnection databaseConnection()
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=stock;";
            MySqlConnection conn = new MySqlConnection(connectionString);
            return conn;
        }
        public record(string username)
        {
            InitializeComponent();
            MySqlConnection conn = databaseConnection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM record WHERE username = @username";
            cmd.Parameters.AddWithValue("@username", username);
            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {

                int ids = dr.GetInt32(dr.GetOrdinal("id"));
                decimal price = dr.GetDecimal(dr.GetOrdinal("totalmoney"));

                recordControl1 productControl = new recordControl1();
                productControl.SetProductData(ids,price);

                flowshoworder.Controls.Add(productControl);
            }
           

        }

        private void PictureBoxorder(object sender, EventArgs e)
        {
            
        }
        private void record_Load(object sender, EventArgs e)
        {
            close.FlatStyle = FlatStyle.Flat;
            close.FlatAppearance.BorderSize = 0;
        }

        private void close_Click(object sender, EventArgs e)
        {
            store st = new store(Program.showusername);
            st.Show();
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void flowshoworder_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
