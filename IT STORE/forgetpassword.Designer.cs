namespace IT_STORE
{
    partial class forgetpassword
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(forgetpassword));
            this.panel2 = new System.Windows.Forms.Panel();
            this.close = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btreset = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.eyeshow = new System.Windows.Forms.Button();
            this.eyehide = new System.Windows.Forms.Button();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btsubmit = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.btnext = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.Mail = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Pass = new System.Windows.Forms.TextBox();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackgroundImage = global::IT_STORE.Properties.Resources.BGforget;
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel2.Controls.Add(this.close);
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Location = new System.Drawing.Point(-1, -3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1426, 753);
            this.panel2.TabIndex = 4;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // close
            // 
            this.close.BackColor = System.Drawing.SystemColors.ControlLight;
            this.close.BackgroundImage = global::IT_STORE.Properties.Resources.btback;
            this.close.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.close.Location = new System.Drawing.Point(1340, 3);
            this.close.Name = "close";
            this.close.Size = new System.Drawing.Size(86, 53);
            this.close.TabIndex = 16;
            this.close.UseVisualStyleBackColor = false;
            this.close.Click += new System.EventHandler(this.close_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel1.Controls.Add(this.btreset);
            this.panel1.Controls.Add(this.button5);
            this.panel1.Controls.Add(this.button4);
            this.panel1.Controls.Add(this.eyeshow);
            this.panel1.Controls.Add(this.eyehide);
            this.panel1.Controls.Add(this.textBox3);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.btsubmit);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.textBox2);
            this.panel1.Controls.Add(this.btnext);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.Mail);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.Pass);
            this.panel1.Location = new System.Drawing.Point(693, 194);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(720, 484);
            this.panel1.TabIndex = 3;
            // 
            // btreset
            // 
            this.btreset.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btreset.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btreset.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btreset.Location = new System.Drawing.Point(21, 397);
            this.btreset.Name = "btreset";
            this.btreset.Size = new System.Drawing.Size(675, 59);
            this.btreset.TabIndex = 34;
            this.btreset.Text = "RESET PASSWORD";
            this.btreset.UseVisualStyleBackColor = false;
            this.btreset.Click += new System.EventHandler(this.btreset_Click);
            // 
            // button5
            // 
            this.button5.BackgroundImage = global::IT_STORE.Properties.Resources.eyeshow;
            this.button5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button5.Location = new System.Drawing.Point(656, 325);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(40, 40);
            this.button5.TabIndex = 33;
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button4
            // 
            this.button4.BackgroundImage = global::IT_STORE.Properties.Resources.eyehide;
            this.button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button4.Location = new System.Drawing.Point(656, 325);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(40, 40);
            this.button4.TabIndex = 32;
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // eyeshow
            // 
            this.eyeshow.BackgroundImage = global::IT_STORE.Properties.Resources.eyeshow;
            this.eyeshow.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.eyeshow.Location = new System.Drawing.Point(656, 208);
            this.eyeshow.Name = "eyeshow";
            this.eyeshow.Size = new System.Drawing.Size(40, 40);
            this.eyeshow.TabIndex = 31;
            this.eyeshow.UseVisualStyleBackColor = true;
            this.eyeshow.Click += new System.EventHandler(this.eyeshow_Click);
            // 
            // eyehide
            // 
            this.eyehide.BackgroundImage = global::IT_STORE.Properties.Resources.eyehide;
            this.eyehide.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.eyehide.Location = new System.Drawing.Point(656, 208);
            this.eyehide.Name = "eyehide";
            this.eyehide.Size = new System.Drawing.Size(40, 40);
            this.eyehide.TabIndex = 30;
            this.eyehide.UseVisualStyleBackColor = true;
            this.eyehide.Click += new System.EventHandler(this.eyehide_Click);
            // 
            // textBox3
            // 
            this.textBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox3.Location = new System.Drawing.Point(21, 313);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(675, 59);
            this.textBox3.TabIndex = 28;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(16, 285);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(287, 25);
            this.label6.TabIndex = 27;
            this.label6.Text = "CONFIRM NEW PASSWORD*";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(21, 201);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(675, 59);
            this.textBox1.TabIndex = 26;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(16, 170);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(261, 25);
            this.label5.TabIndex = 25;
            this.label5.Text = "ENTER NEW PASSWORD*";
            // 
            // btsubmit
            // 
            this.btsubmit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btsubmit.Location = new System.Drawing.Point(280, 313);
            this.btsubmit.Name = "btsubmit";
            this.btsubmit.Size = new System.Drawing.Size(85, 36);
            this.btsubmit.TabIndex = 24;
            this.btsubmit.Text = "ยืนยัน";
            this.btsubmit.UseVisualStyleBackColor = true;
            this.btsubmit.Click += new System.EventHandler(this.btsubmit_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(24, 313);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 36);
            this.label2.TabIndex = 23;
            this.label2.Text = "OTP :";
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(139, 313);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(135, 36);
            this.textBox2.TabIndex = 22;
            // 
            // btnext
            // 
            this.btnext.BackColor = System.Drawing.Color.ForestGreen;
            this.btnext.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnext.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnext.Location = new System.Drawing.Point(21, 313);
            this.btnext.Name = "btnext";
            this.btnext.Size = new System.Drawing.Size(675, 57);
            this.btnext.TabIndex = 21;
            this.btnext.Text = "NEXT";
            this.btnext.UseVisualStyleBackColor = false;
            this.btnext.Click += new System.EventHandler(this.btnext_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(16, 170);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(181, 25);
            this.label4.TabIndex = 20;
            this.label4.Text = "EMAIL ADDRESS*";
            // 
            // Mail
            // 
            this.Mail.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Mail.Location = new System.Drawing.Point(21, 198);
            this.Mail.Multiline = true;
            this.Mail.Name = "Mail";
            this.Mail.Size = new System.Drawing.Size(675, 59);
            this.Mail.TabIndex = 19;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(16, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(132, 25);
            this.label3.TabIndex = 18;
            this.label3.Text = "USERNAME*";
            // 
            // Pass
            // 
            this.Pass.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Pass.Location = new System.Drawing.Point(21, 74);
            this.Pass.Multiline = true;
            this.Pass.Name = "Pass";
            this.Pass.Size = new System.Drawing.Size(675, 62);
            this.Pass.TabIndex = 17;
            // 
            // forgetpassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1424, 746);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "forgetpassword";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "forgetpassword";
            this.Load += new System.EventHandler(this.forgetpassword_Load);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btreset;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button eyeshow;
        private System.Windows.Forms.Button eyehide;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btsubmit;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button btnext;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox Mail;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox Pass;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button close;
    }
}