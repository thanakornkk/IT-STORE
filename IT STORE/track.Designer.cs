namespace IT_STORE
{
    partial class track
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(track));
            this.back = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.del = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.trackde = new System.Windows.Forms.TextBox();
            this.dataEquiment = new System.Windows.Forms.DataGridView();
            this.deletebtn = new System.Windows.Forms.Button();
            this.usernamee = new System.Windows.Forms.Label();
            this.order = new System.Windows.Forms.Label();
            this.editbtn = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.trackbt = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataEquiment)).BeginInit();
            this.SuspendLayout();
            // 
            // back
            // 
            this.back.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.back.ForeColor = System.Drawing.Color.Red;
            this.back.Location = new System.Drawing.Point(1, -3);
            this.back.Name = "back";
            this.back.Size = new System.Drawing.Size(49, 35);
            this.back.TabIndex = 43;
            this.back.Text = "X";
            this.back.UseVisualStyleBackColor = true;
            this.back.Click += new System.EventHandler(this.back_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::IT_STORE.Properties.Resources.Trackings__1_;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.del);
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.trackde);
            this.panel1.Controls.Add(this.dataEquiment);
            this.panel1.Controls.Add(this.deletebtn);
            this.panel1.Controls.Add(this.usernamee);
            this.panel1.Controls.Add(this.order);
            this.panel1.Controls.Add(this.editbtn);
            this.panel1.Controls.Add(this.textBox2);
            this.panel1.Controls.Add(this.trackbt);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Location = new System.Drawing.Point(1, -3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1283, 865);
            this.panel1.TabIndex = 51;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(58, 556);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(291, 34);
            this.textBox1.TabIndex = 45;
            // 
            // del
            // 
            this.del.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.del.Location = new System.Drawing.Point(485, 598);
            this.del.Margin = new System.Windows.Forms.Padding(4);
            this.del.Name = "del";
            this.del.Size = new System.Drawing.Size(155, 28);
            this.del.TabIndex = 50;
            this.del.Text = "DELETE ORDER";
            this.del.UseVisualStyleBackColor = true;
            this.del.Click += new System.EventHandler(this.del_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.White;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox2.Location = new System.Drawing.Point(736, 114);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(274, 363);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 42;
            this.pictureBox2.TabStop = false;
            // 
            // trackde
            // 
            this.trackde.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.trackde.Location = new System.Drawing.Point(58, 657);
            this.trackde.Multiline = true;
            this.trackde.Name = "trackde";
            this.trackde.Size = new System.Drawing.Size(394, 165);
            this.trackde.TabIndex = 48;
            // 
            // dataEquiment
            // 
            this.dataEquiment.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataEquiment.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataEquiment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataEquiment.Location = new System.Drawing.Point(58, 114);
            this.dataEquiment.Margin = new System.Windows.Forms.Padding(4);
            this.dataEquiment.Name = "dataEquiment";
            this.dataEquiment.RowHeadersWidth = 51;
            this.dataEquiment.Size = new System.Drawing.Size(658, 363);
            this.dataEquiment.TabIndex = 8;
            this.dataEquiment.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataEquiment_CellContentClick);
            // 
            // deletebtn
            // 
            this.deletebtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deletebtn.Location = new System.Drawing.Point(459, 781);
            this.deletebtn.Margin = new System.Windows.Forms.Padding(4);
            this.deletebtn.Name = "deletebtn";
            this.deletebtn.Size = new System.Drawing.Size(175, 41);
            this.deletebtn.TabIndex = 13;
            this.deletebtn.Text = "DELETE ORDER";
            this.deletebtn.UseVisualStyleBackColor = true;
            this.deletebtn.Click += new System.EventHandler(this.deletebtn_Click);
            // 
            // usernamee
            // 
            this.usernamee.AutoSize = true;
            this.usernamee.BackColor = System.Drawing.SystemColors.Window;
            this.usernamee.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usernamee.Location = new System.Drawing.Point(64, 603);
            this.usernamee.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.usernamee.Name = "usernamee";
            this.usernamee.Size = new System.Drawing.Size(15, 22);
            this.usernamee.TabIndex = 47;
            this.usernamee.Text = ".";
            // 
            // order
            // 
            this.order.AutoSize = true;
            this.order.BackColor = System.Drawing.SystemColors.Window;
            this.order.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.order.Location = new System.Drawing.Point(64, 552);
            this.order.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.order.Name = "order";
            this.order.Size = new System.Drawing.Size(15, 22);
            this.order.TabIndex = 44;
            this.order.Text = ".";
            // 
            // editbtn
            // 
            this.editbtn.BackColor = System.Drawing.SystemColors.HotTrack;
            this.editbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editbtn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.editbtn.Location = new System.Drawing.Point(367, 598);
            this.editbtn.Margin = new System.Windows.Forms.Padding(4);
            this.editbtn.Name = "editbtn";
            this.editbtn.Size = new System.Drawing.Size(110, 31);
            this.editbtn.TabIndex = 14;
            this.editbtn.Text = "Add track";
            this.editbtn.UseVisualStyleBackColor = false;
            this.editbtn.Click += new System.EventHandler(this.editbtn_Click);
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(58, 595);
            this.textBox2.Margin = new System.Windows.Forms.Padding(4);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(291, 34);
            this.textBox2.TabIndex = 46;
            // 
            // trackbt
            // 
            this.trackbt.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.trackbt.Location = new System.Drawing.Point(367, 556);
            this.trackbt.Margin = new System.Windows.Forms.Padding(4);
            this.trackbt.Name = "trackbt";
            this.trackbt.Size = new System.Drawing.Size(291, 34);
            this.trackbt.TabIndex = 10;
            // 
            // track
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1275, 858);
            this.Controls.Add(this.back);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "track";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "track";
            this.Load += new System.EventHandler(this.track_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataEquiment)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button editbtn;
        private System.Windows.Forms.Button deletebtn;
        private System.Windows.Forms.TextBox trackbt;
        private System.Windows.Forms.DataGridView dataEquiment;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button back;
        private System.Windows.Forms.Label order;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label usernamee;
        private System.Windows.Forms.TextBox trackde;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Button del;
        private System.Windows.Forms.Panel panel1;
    }
}