using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

using System.Net.Mail;
using System.Net;

using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

using System.Data.SqlClient;
using System.IO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ScrollBar;

using iTextSharp.text;
using iTextSharp.text.pdf;
using Image = System.Drawing.Image;
using Font = System.Drawing.Font;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Rectangle = iTextSharp.text.Rectangle;
using iTextSharp.text.pdf.qrcode;

using QRCoder;
using QRCode = QRCoder.QRCode;

using Saladpuk.EMVCo.Contracts;
using Saladpuk.PromptPay.Facades;
using System.Diagnostics;




namespace IT_STORE
{
    public partial class payment : Form
    {
        private MySqlConnection databaseConnection()
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=stock;";
            MySqlConnection conn = new MySqlConnection(connectionString);
            return conn;
        }

        public payment(string username)
        {
            InitializeComponent();

            CountdownTimer_Tick();
            MySqlConnection conn = databaseConnection();
            conn.Open();
            string sqlOrders = "SELECT `order`,vat ,money,totalmoney,spec,am,pr,totalmoney,vat,money FROM `order` WHERE username = @username ORDER BY id DESC LIMIT 1";
            MySqlCommand cmdOrders = new MySqlCommand(sqlOrders, conn);
            cmdOrders.Parameters.AddWithValue("@username", username);
            MySqlDataReader readerOrders = cmdOrders.ExecuteReader();
            if (readerOrders.Read())
            {
                labelshowor.Text = readerOrders["order"].ToString();
                vat.Text = readerOrders["vat"].ToString();
                money.Text = readerOrders["money"].ToString();
                totalmoney.Text = readerOrders["totalmoney"].ToString();
                nameor.Text = readerOrders["spec"].ToString();
                amountor.Text = readerOrders["am"].ToString();
                pr.Text = readerOrders["pr"].ToString();

                to.Text = readerOrders["totalmoney"].ToString();
                mon.Text = readerOrders["money"].ToString();
                vatt.Text = readerOrders["vat"].ToString();

            }

            readerOrders.Close();

            string sql = "SELECT * FROM signin WHERE username = @username";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@username", username);

            MySqlDataReader readerUser = cmd.ExecuteReader();

            if (readerUser.Read())
            {
                textuser.Text = readerUser["username"].ToString(); 
                firstname.Text = readerUser["fname"].ToString();
                lastname.Text = readerUser["lname"].ToString();
                tel.Text = readerUser["tel"].ToString();
                Address.Text = readerUser["address"].ToString();
                Subdistrict.Text = readerUser["subdistrict"].ToString();
                District.Text = readerUser["district"].ToString();
                Province.Text = readerUser["province"].ToString();
                detailsaddress.Text = readerUser["detailsaddress"].ToString(); 
                Code.Text = readerUser["code"].ToString();
            }
            else
            {
                MessageBox.Show("User not found.");
                readerUser.Close();
                conn.Close();
                return;
            }
            readerUser.Close();

            conn.Close();
            GenerateQrCode(to.Text);


        }

        private void GenerateQrCode(string totalAmount)
        {
            try
            {
                string Amountringking = to.Text;
                string phoneNumber = "0630281197";
                double amount;

                if (!double.TryParse(Amountringking.Replace("Total Price: ", ""), out amount))
                {
                    return;
                }
                string qrData = PPay.StaticQR.MobileNumber(phoneNumber).Amount(amount).CreateCreditTransferQrCode();

                QRCoder.QRCodeGenerator qrGenerator = new QRCoder.QRCodeGenerator();
                QRCodeData qrCodeData = qrGenerator.CreateQrCode(qrData, QRCoder.QRCodeGenerator.ECCLevel.H);
                QRCode qrCode = new QRCode(qrCodeData);
                Bitmap qrCodeImage = qrCode.GetGraphic(5);

                qrCodePictureBox.Image = qrCodeImage;

                IPromptPayQrInfo promptPayInfo = PPay.Reader.ReadQrPromptPay(qrData);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while generating QR code: " + ex.Message);
            }
        }

        private int secondsRemaining = 3600; // 1ชม
        private void CountdownTimer_Tick()
        {
            timer1 = new System.Windows.Forms.Timer();
            timer1.Interval = 1000; //กำหนดช่วงเวลาเป็น 1 วินาที
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Enabled = true;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            secondsRemaining--;
            //แสดงเวลาที่เหลือเป็นนาทีและวินาที
            labeltime.Text = (secondsRemaining / 60).ToString("00") + ":" + (secondsRemaining % 60).ToString("00");

            if (secondsRemaining <= 0)
            {
                timer1.Stop();
                MySqlConnection conn = databaseConnection();
                conn.Open();

                string sql = "DELETE FROM `order` WHERE username = @username ORDER BY id DESC LIMIT 1";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@username", textuser.Text);
                int rowsAffected = cmd.ExecuteNonQuery();
                conn.Close();
                if (rowsAffected > 0)
                {
                    MessageBox.Show("หมดเวลาชำระเงิน กรุณาทำรายการใหม่"); ;
                    store log = new store(Program.showusername);
                    log.Show();
                    this.Hide();
                }
                conn.Close();

            }

        }

        private void button4_Click(object sender, EventArgs e)
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
                pictureBox2.Image = Image.FromFile(filename);
                MessageBox.Show(textpic.Text);
                byte[] imageBytes = File.ReadAllBytes(filename);
                fileimage(imageBytes);
            }
        }

        private void BTSUBMIT_Click(object sender, EventArgs e)
        {
            if (textpic.Text.Length > 5)
            {
                try
                {
                    string username = textuser.Text;

                    List<BasketItem> basketItems = new List<BasketItem>();

                    using (MySqlConnection conns = databaseConnection())
                    {
                        conns.Open();

                        string b = "SELECT number, specb, amountb FROM baskett WHERE username = @username";
                        MySqlCommand cmdba = new MySqlCommand(b, conns);
                        cmdba.Parameters.AddWithValue("@username", username);

                        using (MySqlDataReader readerb = cmdba.ExecuteReader())
                        {
                            while (readerb.Read())
                            {
                                basketItems.Add(new BasketItem
                                {
                                    Number = readerb.GetInt32("number"),
                                    Specb = readerb.GetString("specb"),
                                    Amountb = readerb.GetInt32("amountb")
                                });
                            }
                        }

                        conns.Close();
                    }

                    using (MySqlConnection connss = databaseConnection())
                    {
                        connss.Open();

                        foreach (var item in basketItems)
                        {
                            int stockId = GetStockId(connss, item.Specb);
                            if (stockId != -1)
                            {
                                UpdateStock(connss, stockId, item.Amountb);
                            }
                        }

                        connss.Close();
                    }

                    using (MySqlConnection conn = databaseConnection())
                    {
                        conn.Open();

                        string orderUpdateQuery = "UPDATE `order` SET fname = @fname, lname = @lname, address = @address, subdistrict = @subdistrict, " +
                                "district = @district, province = @province, detailsaddress = @detailsaddress, code = @code, tel = @tel, picslip = @picslip WHERE username = @username AND `order` = @order_number";

                        using (MySqlCommand cmdorder = new MySqlCommand(orderUpdateQuery, conn))
                        {
                            cmdorder.Parameters.AddWithValue("@fname", firstname.Text);
                            cmdorder.Parameters.AddWithValue("@lname", lastname.Text);
                            cmdorder.Parameters.AddWithValue("@address", Address.Text);
                            cmdorder.Parameters.AddWithValue("@subdistrict", Subdistrict.Text);
                            cmdorder.Parameters.AddWithValue("@district", District.Text);
                            cmdorder.Parameters.AddWithValue("@province", Province.Text);
                            cmdorder.Parameters.AddWithValue("@detailsaddress", detailsaddress.Text);
                            cmdorder.Parameters.AddWithValue("@code", Code.Text);
                            cmdorder.Parameters.AddWithValue("@tel", tel.Text);
                            cmdorder.Parameters.AddWithValue("@picslip", imageData);
                            cmdorder.Parameters.AddWithValue("@username", textuser.Text);
                            cmdorder.Parameters.AddWithValue("@order_number", labelshowor.Text);

                            int rowsAffected = cmdorder.ExecuteNonQuery();
                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("สั่งซื้อสำเร็จ");
                            }
                            else
                            {
                                MessageBox.Show("ไม่สามารถอัปเดตคำสั่งซื้อได้");
                            }
                        }

                        conn.Close();
                    }

                    using (MySqlConnection connbpro = databaseConnection())
                    {
                        connbpro.Open();

                        List<(string ProductName, int Amount)> products = new List<(string ProductName, int Amount)>();
                        string productQuery = "SELECT specb, amountb FROM baskett WHERE username = @user";

                        using (MySqlCommand productCmd = new MySqlCommand(productQuery, connbpro))
                        {
                            productCmd.Parameters.AddWithValue("@user", textuser.Text);

                            using (MySqlDataReader readerproduct = productCmd.ExecuteReader())
                            {
                                while (readerproduct.Read())
                                {
                                    string productName = readerproduct["specb"].ToString();
                                    int amount = Convert.ToInt32(readerproduct["amountb"]);
                                    products.Add((productName, amount));
                                }
                            }
                        }

                        foreach (var (productName, amount) in products)
                        {
                           
                            string checkProductQuery = "SELECT amountproduct FROM bsproduct WHERE product = @name";
                            using (MySqlCommand checkProductCmd = new MySqlCommand(checkProductQuery, connbpro))
                            {
                                checkProductCmd.Parameters.AddWithValue("@name", productName);
                                object result = checkProductCmd.ExecuteScalar();

                               if (result != null)
                                {
                                  
                                    int currentAmount = Convert.ToInt32(result);
                                    string updateProductQuery = "UPDATE bsproduct SET amountproduct = amountproduct + @am WHERE product = @name";
                                    using (MySqlCommand updateProductCmd = new MySqlCommand(updateProductQuery, connbpro))
                                    {
                                        updateProductCmd.Parameters.AddWithValue("@name", productName);
                                        updateProductCmd.Parameters.AddWithValue("@am", amount);
                                        updateProductCmd.ExecuteNonQuery();
                                    }
                                }
                                else
                                {
                                   
                                    string insertProductQuery = "INSERT INTO bsproduct (product, amountproduct) VALUES (@name, @am)";
                                    using (MySqlCommand insertProductCmd = new MySqlCommand(insertProductQuery, connbpro))
                                    {
                                        insertProductCmd.Parameters.AddWithValue("@name", productName);
                                        insertProductCmd.Parameters.AddWithValue("@am", amount);
                                        insertProductCmd.ExecuteNonQuery();
                                    }
                                }
                            }
                        }

                        connbpro.Close();

                        
                    }


                    using (MySqlConnection connn = databaseConnection())
                    {
                        connn.Open();

                        string deleteBasketQuery = "DELETE FROM baskett WHERE username = @username";
                        using (MySqlCommand deleteBasketCmd = new MySqlCommand(deleteBasketQuery, connn))
                        {
                            deleteBasketCmd.Parameters.AddWithValue("@username", textuser.Text);
                            int rowsDeleted = deleteBasketCmd.ExecuteNonQuery();
                        }

                        connn.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }

                store st = new store(Program.showusername);
                st.Show();
                this.Hide();
            }

            if (textpic.Text.Length > 5) // รูป
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "PDF Files|*.pdf";
                saveFileDialog.Title = "Save PDF";
                saveFileDialog.FileName = "slip.pdf";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    int width = 420;
                    int height = 500;

                    Rectangle rectangle = new Rectangle(width, height);
                    Document document = new Document(rectangle, 10f, 10f, 10f, 10f);
                    PdfWriter.GetInstance(document, new FileStream(saveFileDialog.FileName, FileMode.Create));
                    document.Open();

                    string t1 = "Manisi IT";
                    Paragraph paragraph = new Paragraph(t1);
                    paragraph.Alignment = Element.ALIGN_CENTER;
                    paragraph.Font.Size = 20;

                    string t2 = "__________________________________________" + "\n\n\n";
                    Paragraph paragraph2 = new Paragraph(t2);
                    paragraph2.Alignment = Element.ALIGN_CENTER;

                    string fl = "Cusromer   " + firstname.Text + " " + lastname.Text;
                    Paragraph paragraphfl = new Paragraph(fl);
                    paragraphfl.Alignment = Element.ALIGN_LEFT;

                    string ad = "Address   " + Address.Text + " " + Subdistrict.Text + " " + District.Text + " " + Province.Text + " " + Code.Text;
                    Paragraph paragraphad = new Paragraph(ad);
                    paragraphad.Alignment = Element.ALIGN_LEFT;

                    Random rand = new Random();
                    StringBuilder stringBuilder = new StringBuilder();
                    for (int i = 0; i < 12; i++)
                    {
                        stringBuilder.Append(rand.Next(10));
                    }
                    string tax = "Tax id  " + stringBuilder.ToString() + "\n" + "___________________________________________________________" + "\n\n";
                    Paragraph paragraphtax = new Paragraph(tax);
                    paragraphtax.Alignment = Element.ALIGN_LEFT;

                    string ma = "Issuer  MANISY COMPANY LTD." + "\n\n";
                    Paragraph paragraphma = new Paragraph(ma);
                    paragraphma.Alignment = Element.ALIGN_LEFT;

                    PdfPTable pdfTable = new PdfPTable(3);
                    float[] columnWidths = { 70f, 10f, 30f };
                    pdfTable.SetWidths(columnWidths);
                    pdfTable.WidthPercentage = 100;

                    PdfPCell header1 = new PdfPCell(new Phrase("Name"));
                    header1.HorizontalAlignment = Element.ALIGN_CENTER;
                    header1.Phrase.Font.Size = 9;
                    header1.BackgroundColor = BaseColor.GRAY;
                    PdfPCell header2 = new PdfPCell(new Phrase("Amount"));
                    header2.HorizontalAlignment = Element.ALIGN_CENTER;
                    header2.Phrase.Font.Size = 9;
                    header2.BackgroundColor = BaseColor.GRAY;
                    PdfPCell header3 = new PdfPCell(new Phrase("Price"));
                    header3.HorizontalAlignment = Element.ALIGN_CENTER;
                    header3.Phrase.Font.Size = 9;
                    header3.BackgroundColor = BaseColor.GRAY;

                    pdfTable.AddCell(header1);
                    pdfTable.AddCell(header2);
                    pdfTable.AddCell(header3);

                    PdfPCell cell1 = new PdfPCell(new Phrase(nameor.Text));
                    cell1.HorizontalAlignment = Element.ALIGN_LEFT;
                    cell1.Phrase.Font.Size = 9;
                    PdfPCell cell2 = new PdfPCell(new Phrase(amountor.Text));
                    cell2.HorizontalAlignment = Element.ALIGN_CENTER;
                    cell2.Phrase.Font.Size = 9;
                    PdfPCell cell3 = new PdfPCell(new Phrase(pr.Text));
                    cell3.HorizontalAlignment = Element.ALIGN_CENTER;
                    cell3.Phrase.Font.Size = 9;

                    pdfTable.AddCell(cell1);
                    pdfTable.AddCell(cell2);
                    pdfTable.AddCell(cell3);

                    string t3 = "\n\n";
                    Paragraph paragraph3 = new Paragraph(t3);

                    string t4 = "Net product price (baht)  : " + money.Text;
                    Paragraph paragraph4 = new Paragraph(t4);
                    paragraph4.Alignment = Element.ALIGN_RIGHT;

                    string t5 = "Vat 7% (Bath)  : " + vat.Text;
                    Paragraph paragraph5 = new Paragraph(t5);
                    paragraph5.Alignment = Element.ALIGN_RIGHT;

                    string t6 = "Total amount (Baht)  : " + totalmoney.Text;
                    Paragraph paragraph6 = new Paragraph(t6);
                    paragraph6.Alignment = Element.ALIGN_RIGHT;

                    string note = "\n\n\n" + "Note : When the customer receives the product, please record a video clip as evidence if the product is damaged.";
                    Paragraph paragraphnote = new Paragraph(note);
                    paragraphnote.Alignment = Element.ALIGN_LEFT;
                    paragraphnote.Font.Size = 9;
                    paragraphnote.Font.Color = BaseColor.RED;

                    document.Add(paragraph);
                    document.Add(paragraph2);
                    document.Add(paragraphfl);
                    document.Add(paragraphad);
                    document.Add(paragraphtax);
                    document.Add(paragraphma);
                    document.Add(pdfTable);
                    document.Add(paragraph3);
                    document.Add(paragraph4);
                    document.Add(paragraph5);
                    document.Add(paragraph6);
                    document.Add(paragraphnote);
                    document.Close();

                    MessageBox.Show("PDF slip ได้ถูกสร้างขึ้นเรียบร้อยแล้ว", "PDF Export", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Process.Start(new ProcessStartInfo(saveFileDialog.FileName) { UseShellExecute = true });
                }
            }
            else
            {
                MessageBox.Show("กรุณาเเนบสลิป");
            }

        }
        private void cancelorder_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("คุณต้องการยกเลิกคำสั่งซื้อ", "คำสั่งซื้อ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                try
                {
                    MySqlConnection conn = databaseConnection();
                    conn.Open();

                    string sql = "DELETE FROM `order` WHERE username = @username ORDER BY id DESC LIMIT 1";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@username", textuser.Text);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    conn.Close();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("ยกเลิอกคำสั่งซื้อสำเร็จ"); ;
                        store log = new store(Program.showusername);
                        log.Show();
                        this.Hide();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("เกิดข้อผิดพลาด: " + ex.Message);
                }
            }
        }














        static int GetStockId(MySqlConnection conn, string spec)
        {
            string queryStockId = "SELECT id FROM stockorder WHERE spec = @spec";
            MySqlCommand cmdStockId = new MySqlCommand(queryStockId, conn);
            cmdStockId.Parameters.AddWithValue("@spec", spec);

            object result = cmdStockId.ExecuteScalar();
            if (result != null)
            {
                return Convert.ToInt32(result);
            }
            else
            {
                MessageBox.Show($"No stock ID found for spec: {spec}");
                return -1;
            }
        }

        static bool UpdateStock(MySqlConnection conn, int id, int amount)
        {
            string queryStock = "UPDATE stockorder SET amount = amount - @amount WHERE id = @id";
            MySqlCommand cmdStock = new MySqlCommand(queryStock, conn);
            cmdStock.Parameters.AddWithValue("@amount", amount);
            cmdStock.Parameters.AddWithValue("@id", id);

            int rowsAffected = cmdStock.ExecuteNonQuery();
            if (rowsAffected > 0)
            {
                return true;
            }
            else
            {
                MessageBox.Show($"Failed to update stock for ID: {id} by amount: {amount}");
                return false;
            }
        }

       






        private void payment_Load(object sender, EventArgs e)
        {
            CountdownTimer_Tick();
            BTSUBMIT.FlatStyle = FlatStyle.Flat;
            BTSUBMIT.FlatAppearance.BorderSize = 0;

        }
        private void payment_Load_1(object sender, EventArgs e)
        {

        }
        public class BasketItem
        {
            public int Number { get; set; }
            public string Specb { get; set; }
            public int Amountb { get; set; }
        }

        private byte[] imageData;
        private void fileimage(byte[] data)
        {

            imageData = data;
        }

    }
}
