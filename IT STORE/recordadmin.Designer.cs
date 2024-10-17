namespace IT_STORE
{
    partial class recordadmin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(recordadmin));
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.panel1 = new System.Windows.Forms.Panel();
            this.selectproduct = new System.Windows.Forms.ComboBox();
            this.labeldate = new System.Windows.Forms.Label();
            this.dateTimePickersearch = new System.Windows.Forms.DateTimePicker();
            this.textsearch = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.back = new System.Windows.Forms.Button();
            this.print = new System.Windows.Forms.Button();
            this.alltotal = new System.Windows.Forms.Label();
            this.daymoney = new System.Windows.Forms.Label();
            this.montyear = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::IT_STORE.Properties.Resources.RECORDa;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.selectproduct);
            this.panel1.Controls.Add(this.labeldate);
            this.panel1.Controls.Add(this.dateTimePickersearch);
            this.panel1.Controls.Add(this.textsearch);
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Controls.Add(this.back);
            this.panel1.Controls.Add(this.print);
            this.panel1.Controls.Add(this.alltotal);
            this.panel1.Controls.Add(this.daymoney);
            this.panel1.Controls.Add(this.montyear);
            this.panel1.Controls.Add(this.dateTimePicker1);
            this.panel1.Controls.Add(this.dateTimePicker2);
            this.panel1.Location = new System.Drawing.Point(0, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1387, 691);
            this.panel1.TabIndex = 28;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // selectproduct
            // 
            this.selectproduct.BackColor = System.Drawing.Color.White;
            this.selectproduct.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.selectproduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectproduct.FormattingEnabled = true;
            this.selectproduct.Location = new System.Drawing.Point(57, 62);
            this.selectproduct.Name = "selectproduct";
            this.selectproduct.Size = new System.Drawing.Size(229, 33);
            this.selectproduct.TabIndex = 33;
            this.selectproduct.Text = "SELECT";
            this.selectproduct.SelectedIndexChanged += new System.EventHandler(this.selectproduct_SelectedIndexChanged);
            // 
            // labeldate
            // 
            this.labeldate.AutoSize = true;
            this.labeldate.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labeldate.Location = new System.Drawing.Point(1084, 38);
            this.labeldate.Name = "labeldate";
            this.labeldate.Size = new System.Drawing.Size(138, 15);
            this.labeldate.TabIndex = 32;
            this.labeldate.Text = "Month - Day - Year          ";
            // 
            // dateTimePickersearch
            // 
            this.dateTimePickersearch.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickersearch.CustomFormat = "MM-dd-yyyy";
            this.dateTimePickersearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickersearch.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickersearch.Location = new System.Drawing.Point(1084, 57);
            this.dateTimePickersearch.Name = "dateTimePickersearch";
            this.dateTimePickersearch.ShowUpDown = true;
            this.dateTimePickersearch.Size = new System.Drawing.Size(188, 38);
            this.dateTimePickersearch.TabIndex = 30;
            this.dateTimePickersearch.Value = new System.DateTime(2024, 4, 4, 17, 57, 17, 0);
            this.dateTimePickersearch.ValueChanged += new System.EventHandler(this.dateTimePickersearch_ValueChanged);
            // 
            // textsearch
            // 
            this.textsearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textsearch.Location = new System.Drawing.Point(1073, 57);
            this.textsearch.Name = "textsearch";
            this.textsearch.Size = new System.Drawing.Size(205, 38);
            this.textsearch.TabIndex = 28;
            this.textsearch.TextChanged += new System.EventHandler(this.textsearch_TextChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(57, 104);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1275, 487);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // back
            // 
            this.back.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.back.ForeColor = System.Drawing.Color.Red;
            this.back.Location = new System.Drawing.Point(0, 0);
            this.back.Name = "back";
            this.back.Size = new System.Drawing.Size(49, 35);
            this.back.TabIndex = 18;
            this.back.Text = "X";
            this.back.UseVisualStyleBackColor = true;
            this.back.Click += new System.EventHandler(this.back_Click);
            // 
            // print
            // 
            this.print.BackgroundImage = global::IT_STORE.Properties.Resources.printer;
            this.print.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.print.Location = new System.Drawing.Point(1284, 52);
            this.print.Name = "print";
            this.print.Size = new System.Drawing.Size(48, 46);
            this.print.TabIndex = 20;
            this.print.UseVisualStyleBackColor = true;
            this.print.Click += new System.EventHandler(this.print_Click);
            // 
            // alltotal
            // 
            this.alltotal.AutoSize = true;
            this.alltotal.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.alltotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.alltotal.Location = new System.Drawing.Point(1133, 646);
            this.alltotal.Name = "alltotal";
            this.alltotal.Size = new System.Drawing.Size(70, 25);
            this.alltotal.TabIndex = 21;
            this.alltotal.Text = "label2";
            // 
            // daymoney
            // 
            this.daymoney.AutoSize = true;
            this.daymoney.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.daymoney.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.daymoney.Location = new System.Drawing.Point(369, 646);
            this.daymoney.Name = "daymoney";
            this.daymoney.Size = new System.Drawing.Size(64, 25);
            this.daymoney.TabIndex = 25;
            this.daymoney.Text = "label3";
            // 
            // montyear
            // 
            this.montyear.AutoSize = true;
            this.montyear.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.montyear.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.montyear.Location = new System.Drawing.Point(607, 646);
            this.montyear.Name = "montyear";
            this.montyear.Size = new System.Drawing.Size(64, 25);
            this.montyear.TabIndex = 27;
            this.montyear.Text = "label3";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.CustomFormat = "dd-MM-yyyy";
            this.dateTimePicker1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(448, 597);
            this.dateTimePicker1.MaxDate = new System.DateTime(2025, 12, 31, 0, 0, 0, 0);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(51, 34);
            this.dateTimePicker1.TabIndex = 24;
            this.dateTimePicker1.Value = new System.DateTime(2024, 4, 4, 0, 0, 0, 0);
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged_1);
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.CustomFormat = "MM-yyyy";
            this.dateTimePicker2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker2.Location = new System.Drawing.Point(718, 597);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.ShowUpDown = true;
            this.dateTimePicker2.Size = new System.Drawing.Size(128, 34);
            this.dateTimePicker2.TabIndex = 26;
            this.dateTimePicker2.Value = new System.DateTime(2024, 4, 4, 17, 57, 17, 0);
            this.dateTimePicker2.ValueChanged += new System.EventHandler(this.dateTimePicker2_ValueChanged);
            // 
            // recordadmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1386, 691);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "recordadmin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "recordadmin";
            this.Load += new System.EventHandler(this.recordadmin_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button back;
        private System.Windows.Forms.Button print;
        private System.Windows.Forms.Label alltotal;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label daymoney;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.Label montyear;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textsearch;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.DateTimePicker dateTimePickersearch;
        private System.Windows.Forms.Label labeldate;
        private System.Windows.Forms.ComboBox selectproduct;
    }
}