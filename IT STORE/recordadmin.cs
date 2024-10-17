using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

using iTextSharp.text;
using iTextSharp.text.pdf;
using Rectangle = iTextSharp.text.Rectangle;
using System.Diagnostics;

namespace IT_STORE
{
    public partial class recordadmin : Form
    {
        private MySqlConnection databaseConnection()
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=stock;";
            MySqlConnection conn = new MySqlConnection(connectionString);
            return conn;
        }
        public recordadmin()
        {
            InitializeComponent();
            search();
            textsearch.TextChanged += new EventHandler(textsearch_TextChanged);

        }


        private void search()
        {

            try
            {
                dataGridView1.Controls.Clear();
                MySqlConnection conn = databaseConnection();
                conn.Open();
                DataSet ds = new DataSet();
                MySqlCommand data = conn.CreateCommand();

                data.CommandText = "SELECT username, `order`, fname, lname, address, subdistrict, district, province," +
                    " detailsaddress, code, tel, totalmoney,time FROM record WHERE `order` LIKE @order or username LIKE @order";
                data.Parameters.AddWithValue("@order", "%" + textsearch.Text + "%");
                
                MySqlDataAdapter rec = new MySqlDataAdapter(data);
                rec.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0].DefaultView;

                int totalPrice = 0;
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    int price = Convert.ToInt32(row["totalmoney"]);
                    totalPrice += price;
                }

                alltotal.Text = totalPrice.ToString();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }
        private void date()
        {
            try
            {
                dataGridView1.Controls.Clear();
                string selectedDate = dateTimePickersearch.Value.ToString("yyyy-MM-dd");
                using (MySqlConnection conn = databaseConnection())
                {
                    conn.Open();
                    DataSet ds = new DataSet();
                    MySqlCommand data = conn.CreateCommand();
                    data.CommandText = "SELECT username, `order`, fname, lname, address, subdistrict, district, " +
                        "province, detailsaddress, code, tel, totalmoney, time FROM record WHERE time LIKE @order";
                    data.Parameters.AddWithValue("@order", "%" + selectedDate + "%");

                    MySqlDataAdapter rec = new MySqlDataAdapter(data);
                    rec.Fill(ds);
                    dataGridView1.DataSource = ds.Tables[0].DefaultView;

                    int totalPrice = 0;
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        int price;
                        if (int.TryParse(row["totalmoney"].ToString(), out price))
                        {
                            totalPrice += price;
                        }
                    }
                    alltotal.Text = totalPrice.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void searchbestdelling()
        {

            try
            {
                dataGridView1.Controls.Clear();
                MySqlConnection conn = databaseConnection();
                conn.Open();
                DataSet ds = new DataSet();
                MySqlCommand data = conn.CreateCommand();

                data.CommandText = "SELECT product, amountproduct FROM bsproduct ORDER BY amountproduct DESC";

                MySqlDataAdapter rec = new MySqlDataAdapter(data);
                rec.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0].DefaultView;

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void print_Click(object sender, EventArgs e)
        {

            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "PDF Files|*.pdf",
                Title = "Save PDF",
                FileName = "Record.pdf"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                  
                    using (FileStream stream = new FileStream(saveFileDialog.FileName, FileMode.Create))
                    {
                        
                        Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
                        PdfWriter.GetInstance(pdfDoc, stream);
                        pdfDoc.Open();
                        PdfPTable pdfTable = new PdfPTable(dataGridView1.ColumnCount);
                        foreach (DataGridViewColumn column in dataGridView1.Columns)
                        {
                            PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));
                            pdfTable.AddCell(cell);
                        }
                        foreach (DataGridViewRow row in dataGridView1.Rows)
                        {
                            foreach (DataGridViewCell cell in row.Cells)
                            {
                                pdfTable.AddCell(cell.Value?.ToString() ?? string.Empty);
                            }
                        }
                        pdfDoc.Add(pdfTable);
                        pdfDoc.Close();
                        stream.Close();
                    }
                    MessageBox.Show("PDF saved successfully.", "Info");
                    Process.Start(new ProcessStartInfo(saveFileDialog.FileName) { UseShellExecute = true });
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error");
                }
            }


        }













        private void selectproduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedProduct = selectproduct.SelectedItem.ToString();

            dataGridView1.Controls.Clear();

            if (selectedProduct == "BEST SELLING")
            {
                labeldate.Visible = false;
                dateTimePickersearch.Visible = false;
                searchbestdelling();
            }
            if (selectedProduct == "ALL")
            {
                labeldate.Visible = false;
                dateTimePickersearch.Visible = false;
                search();
            }
            if (selectedProduct == "DATE")
            {
                labeldate.Visible = true;
                dateTimePickersearch.Visible = true;
            }
            if (selectedProduct == "SEARCH")
            {
                search();
                textsearch.Visible = true;
                labeldate.Visible = false;
                dateTimePickersearch.Visible = false;
             
            }

        }

      
        private void day()
        {
            MySqlConnection connn = databaseConnection();
            connn.Open();
            MySqlCommand dataday = connn.CreateCommand();

            int selectedDay = dateTimePicker1.Value.Day;
            int selectedMonth = dateTimePicker1.Value.Month;
            int selectedYear = dateTimePicker1.Value.Year;

            dataday.CommandText = "SELECT totalmoney FROM record WHERE DAY(time) = @selectedDay AND MONTH(time) = @selectedMonth AND YEAR(time) = @selectedYear";
            dataday.Parameters.AddWithValue("@selectedDay", selectedDay);
            dataday.Parameters.AddWithValue("@selectedMonth", selectedMonth);
            dataday.Parameters.AddWithValue("@selectedYear", selectedYear);

            using (MySqlDataReader reader = dataday.ExecuteReader())
            {
                int money = 0;
                while (reader.Read())
                {
                    int price = Convert.ToInt32(reader["totalmoney"]);
                    money += price;
                }

                daymoney.Text = money.ToString();
            }
        }
        private void montyearr()
        {
            MySqlConnection con = databaseConnection();
            con.Open();

            DateTime selectedDate = dateTimePicker2.Value;
            int selectedMonth = selectedDate.Month;
            int selectedYear = selectedDate.Year;
            MySqlCommand datamy = con.CreateCommand();
            datamy.CommandText = "SELECT totalmoney FROM record WHERE MONTH(time) = @seMonth AND YEAR(time) = @seYear";
            datamy.Parameters.AddWithValue("@seMonth", selectedMonth);
            datamy.Parameters.AddWithValue("@seYear", selectedYear);

            using (MySqlDataReader readermy = datamy.ExecuteReader())
            {
                int money = 0;
                while (readermy.Read())
                {
                    int price = Convert.ToInt32(readermy["totalmoney"]);
                    money += price;
                }

                montyear.Text = money.ToString();
            }
            con.Close();
        }




        private void textsearch_TextChanged(object sender, EventArgs e)
        {
            search();
        }
        private void dateTimePickersearch_ValueChanged(object sender, EventArgs e)
        {
            date();
        }
        private void refresh_Click(object sender, EventArgs e)
        {
            search();
        }
        private void dateTimePicker1_ValueChanged_1(object sender, EventArgs e)
        {
            day();
        }



      
        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            montyearr();
        }




        private void back_Click(object sender, EventArgs e)
        {
            stock st = new stock();
            st.Show();
            this.Hide();
        }




        private void recordadmin_Load(object sender, EventArgs e)
        {
            day();
            montyearr();

            textsearch.Visible = false;
            labeldate.Visible = false;
            dateTimePickersearch.Visible = false;

            selectproduct.Items.Add("DATE");
            selectproduct.Items.Add("SEARCH");
            selectproduct.Items.Add("BEST SELLING");
            selectproduct.Items.Add("ALL");
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

    
    }
}
