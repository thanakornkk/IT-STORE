namespace IT_STORE
{
    partial class shopcontrol
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.namepro = new System.Windows.Forms.Label();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.pricepro = new System.Windows.Forms.Label();
            this.de = new System.Windows.Forms.Button();
            this.quan = new System.Windows.Forms.Label();
            this.dec = new System.Windows.Forms.Button();
            this.inc = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.number = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // namepro
            // 
            this.namepro.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.namepro.Location = new System.Drawing.Point(275, 42);
            this.namepro.Name = "namepro";
            this.namepro.Size = new System.Drawing.Size(389, 51);
            this.namepro.TabIndex = 1;
            this.namepro.Text = "label1";
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(29, 17);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(211, 187);
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            // 
            // pricepro
            // 
            this.pricepro.AutoSize = true;
            this.pricepro.Font = new System.Drawing.Font("Roboto", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pricepro.Location = new System.Drawing.Point(300, 105);
            this.pricepro.Name = "pricepro";
            this.pricepro.Size = new System.Drawing.Size(87, 37);
            this.pricepro.TabIndex = 3;
            this.pricepro.Text = "Price";
            // 
            // de
            // 
            this.de.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.de.ForeColor = System.Drawing.Color.IndianRed;
            this.de.Location = new System.Drawing.Point(584, 135);
            this.de.Name = "de";
            this.de.Size = new System.Drawing.Size(80, 69);
            this.de.TabIndex = 4;
            this.de.Text = "🗑️";
            this.de.UseVisualStyleBackColor = true;
            this.de.Click += new System.EventHandler(this.de_Click);
            // 
            // quan
            // 
            this.quan.AutoSize = true;
            this.quan.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.quan.Location = new System.Drawing.Point(363, 172);
            this.quan.Name = "quan";
            this.quan.Size = new System.Drawing.Size(24, 25);
            this.quan.TabIndex = 5;
            this.quan.Text = "0";
            // 
            // dec
            // 
            this.dec.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dec.Location = new System.Drawing.Point(280, 163);
            this.dec.Name = "dec";
            this.dec.Size = new System.Drawing.Size(35, 41);
            this.dec.TabIndex = 6;
            this.dec.Text = "-";
            this.dec.UseVisualStyleBackColor = true;
            this.dec.Click += new System.EventHandler(this.dec_Click);
            // 
            // inc
            // 
            this.inc.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inc.Location = new System.Drawing.Point(439, 163);
            this.inc.Name = "inc";
            this.inc.Size = new System.Drawing.Size(38, 41);
            this.inc.TabIndex = 7;
            this.inc.Text = "+";
            this.inc.UseVisualStyleBackColor = true;
            this.inc.Click += new System.EventHandler(this.inc_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Roboto", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(273, 105);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 37);
            this.label1.TabIndex = 8;
            this.label1.Text = "฿";
            // 
            // number
            // 
            this.number.AutoSize = true;
            this.number.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.number.Location = new System.Drawing.Point(628, 4);
            this.number.Name = "number";
            this.number.Size = new System.Drawing.Size(44, 16);
            this.number.TabIndex = 9;
            this.number.Text = "label2";
            // 
            // shopcontrol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.number);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.inc);
            this.Controls.Add(this.dec);
            this.Controls.Add(this.quan);
            this.Controls.Add(this.de);
            this.Controls.Add(this.pricepro);
            this.Controls.Add(this.namepro);
            this.Controls.Add(this.pictureBox);
            this.Name = "shopcontrol";
            this.Size = new System.Drawing.Size(672, 222);
            this.Load += new System.EventHandler(this.shopcontrol_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Label namepro;
        private System.Windows.Forms.Label pricepro;
        private System.Windows.Forms.Button de;
        private System.Windows.Forms.Label quan;
        private System.Windows.Forms.Button dec;
        private System.Windows.Forms.Button inc;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label number;
    }
}
