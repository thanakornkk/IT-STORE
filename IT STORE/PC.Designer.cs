namespace IT_STORE
{
    partial class PC
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PC));
            this.name = new System.Windows.Forms.TextBox();
            this.pricec = new System.Windows.Forms.TextBox();
            this.amount = new System.Windows.Forms.TextBox();
            this.spec = new System.Windows.Forms.TextBox();
            this.picture = new System.Windows.Forms.PictureBox();
            this.Addpicture = new System.Windows.Forms.Button();
            this.updatebt = new System.Windows.Forms.Button();
            this.add = new System.Windows.Forms.Button();
            this.textpic = new System.Windows.Forms.TextBox();
            this.back = new System.Windows.Forms.Button();
            this.id = new System.Windows.Forms.Label();
            this.selectstock = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.flowLayoutPanelpc = new System.Windows.Forms.FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.picture)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // name
            // 
            this.name.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.name.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.name.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.name.Location = new System.Drawing.Point(199, 223);
            this.name.Multiline = true;
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(409, 40);
            this.name.TabIndex = 2;
            // 
            // pricec
            // 
            this.pricec.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.pricec.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.pricec.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pricec.Location = new System.Drawing.Point(199, 301);
            this.pricec.Multiline = true;
            this.pricec.Name = "pricec";
            this.pricec.Size = new System.Drawing.Size(425, 40);
            this.pricec.TabIndex = 3;
            // 
            // amount
            // 
            this.amount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.amount.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.amount.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.amount.Location = new System.Drawing.Point(249, 375);
            this.amount.Multiline = true;
            this.amount.Name = "amount";
            this.amount.Size = new System.Drawing.Size(386, 36);
            this.amount.TabIndex = 4;
            // 
            // spec
            // 
            this.spec.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.spec.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.spec.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spec.Location = new System.Drawing.Point(168, 447);
            this.spec.Multiline = true;
            this.spec.Name = "spec";
            this.spec.Size = new System.Drawing.Size(479, 183);
            this.spec.TabIndex = 5;
            // 
            // picture
            // 
            this.picture.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.picture.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picture.Location = new System.Drawing.Point(490, 12);
            this.picture.Name = "picture";
            this.picture.Size = new System.Drawing.Size(175, 191);
            this.picture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picture.TabIndex = 6;
            this.picture.TabStop = false;
            // 
            // Addpicture
            // 
            this.Addpicture.Location = new System.Drawing.Point(395, 15);
            this.Addpicture.Name = "Addpicture";
            this.Addpicture.Size = new System.Drawing.Size(90, 41);
            this.Addpicture.TabIndex = 7;
            this.Addpicture.Text = "เพิ่มรูป";
            this.Addpicture.UseVisualStyleBackColor = true;
            this.Addpicture.Click += new System.EventHandler(this.Addpicture_Click);
            // 
            // updatebt
            // 
            this.updatebt.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.updatebt.Location = new System.Drawing.Point(13, 527);
            this.updatebt.Name = "updatebt";
            this.updatebt.Size = new System.Drawing.Size(132, 49);
            this.updatebt.TabIndex = 8;
            this.updatebt.Text = "อัพเดท Stock";
            this.updatebt.UseVisualStyleBackColor = true;
            this.updatebt.Click += new System.EventHandler(this.updatebt_Click);
            // 
            // add
            // 
            this.add.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.add.Location = new System.Drawing.Point(13, 582);
            this.add.Name = "add";
            this.add.Size = new System.Drawing.Size(132, 48);
            this.add.TabIndex = 9;
            this.add.Text = "เพิ่มสินค้า";
            this.add.UseVisualStyleBackColor = true;
            this.add.Click += new System.EventHandler(this.add_Click);
            // 
            // textpic
            // 
            this.textpic.BackColor = System.Drawing.SystemColors.Control;
            this.textpic.ForeColor = System.Drawing.SystemColors.Control;
            this.textpic.Location = new System.Drawing.Point(540, -16);
            this.textpic.Name = "textpic";
            this.textpic.Size = new System.Drawing.Size(100, 22);
            this.textpic.TabIndex = 10;
            // 
            // back
            // 
            this.back.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.back.ForeColor = System.Drawing.Color.Red;
            this.back.Location = new System.Drawing.Point(13, 0);
            this.back.Name = "back";
            this.back.Size = new System.Drawing.Size(49, 35);
            this.back.TabIndex = 11;
            this.back.Text = "X";
            this.back.UseVisualStyleBackColor = true;
            this.back.Click += new System.EventHandler(this.back_Click);
            // 
            // id
            // 
            this.id.AutoSize = true;
            this.id.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.id.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.id.Location = new System.Drawing.Point(12, -26);
            this.id.Name = "id";
            this.id.Size = new System.Drawing.Size(0, 32);
            this.id.TabIndex = 12;
            // 
            // selectstock
            // 
            this.selectstock.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.selectstock.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.selectstock.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectstock.FormattingEnabled = true;
            this.selectstock.Location = new System.Drawing.Point(249, 155);
            this.selectstock.Name = "selectstock";
            this.selectstock.Size = new System.Drawing.Size(164, 33);
            this.selectstock.TabIndex = 15;
            this.selectstock.Text = "SELECT";
            this.selectstock.SelectedIndexChanged += new System.EventHandler(this.selectstock_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::IT_STORE.Properties.Resources.stom;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.selectstock);
            this.panel1.Controls.Add(this.back);
            this.panel1.Controls.Add(this.name);
            this.panel1.Controls.Add(this.pricec);
            this.panel1.Controls.Add(this.Addpicture);
            this.panel1.Controls.Add(this.updatebt);
            this.panel1.Controls.Add(this.add);
            this.panel1.Controls.Add(this.amount);
            this.panel1.Controls.Add(this.spec);
            this.panel1.Location = new System.Drawing.Point(3, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1426, 659);
            this.panel1.TabIndex = 16;
            // 
            // flowLayoutPanelpc
            // 
            this.flowLayoutPanelpc.AutoScroll = true;
            this.flowLayoutPanelpc.BackColor = System.Drawing.SystemColors.ControlLight;
            this.flowLayoutPanelpc.Location = new System.Drawing.Point(727, 12);
            this.flowLayoutPanelpc.Name = "flowLayoutPanelpc";
            this.flowLayoutPanelpc.Size = new System.Drawing.Size(685, 629);
            this.flowLayoutPanelpc.TabIndex = 0;
            this.flowLayoutPanelpc.Paint += new System.Windows.Forms.PaintEventHandler(this.flowLayoutPanelpc_Paint);
            // 
            // PC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::IT_STORE.Properties.Resources.stom;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(1424, 653);
            this.Controls.Add(this.id);
            this.Controls.Add(this.textpic);
            this.Controls.Add(this.picture);
            this.Controls.Add(this.flowLayoutPanelpc);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PC";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PC";
            this.Load += new System.EventHandler(this.PC_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picture)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox name;
        private System.Windows.Forms.TextBox pricec;
        private System.Windows.Forms.TextBox amount;
        private System.Windows.Forms.TextBox spec;
        private System.Windows.Forms.PictureBox picture;
        private System.Windows.Forms.Button Addpicture;
        private System.Windows.Forms.Button updatebt;
        private System.Windows.Forms.Button add;
        private System.Windows.Forms.TextBox textpic;
        private System.Windows.Forms.Button back;
        private System.Windows.Forms.Label id;
        private System.Windows.Forms.ComboBox selectstock;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelpc;
    }
}