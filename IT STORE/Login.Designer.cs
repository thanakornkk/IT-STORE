namespace IT_STORE
{
    partial class Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.label4 = new System.Windows.Forms.Label();
            this.linksignin = new System.Windows.Forms.LinkLabel();
            this.linkforgetpass = new System.Windows.Forms.LinkLabel();
            this.BTLOGIN = new System.Windows.Forms.Button();
            this.username = new System.Windows.Forms.TextBox();
            this.password = new System.Windows.Forms.TextBox();
            this.close = new System.Windows.Forms.Button();
            this.eyeshow = new System.Windows.Forms.Button();
            this.eyehide = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(841, 620);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(222, 25);
            this.label4.TabIndex = 9;
            this.label4.Text = "Don’t have an account ?";
            // 
            // linksignin
            // 
            this.linksignin.AutoSize = true;
            this.linksignin.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.linksignin.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linksignin.Location = new System.Drawing.Point(1079, 622);
            this.linksignin.Name = "linksignin";
            this.linksignin.Size = new System.Drawing.Size(77, 22);
            this.linksignin.TabIndex = 8;
            this.linksignin.TabStop = true;
            this.linksignin.Text = "Register";
            this.linksignin.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linksignin_LinkClicked);
            // 
            // linkforgetpass
            // 
            this.linkforgetpass.AutoSize = true;
            this.linkforgetpass.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.linkforgetpass.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkforgetpass.Location = new System.Drawing.Point(839, 484);
            this.linkforgetpass.Name = "linkforgetpass";
            this.linkforgetpass.Size = new System.Drawing.Size(146, 22);
            this.linkforgetpass.TabIndex = 7;
            this.linkforgetpass.TabStop = true;
            this.linkforgetpass.Text = "Forgot Password";
            this.linkforgetpass.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkforgetpass_LinkClicked);
            // 
            // BTLOGIN
            // 
            this.BTLOGIN.BackColor = System.Drawing.Color.SaddleBrown;
            this.BTLOGIN.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BTLOGIN.Font = new System.Drawing.Font("Microsoft YaHei", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTLOGIN.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.BTLOGIN.Location = new System.Drawing.Point(843, 553);
            this.BTLOGIN.Name = "BTLOGIN";
            this.BTLOGIN.Size = new System.Drawing.Size(559, 66);
            this.BTLOGIN.TabIndex = 3;
            this.BTLOGIN.Text = "LOG IN";
            this.BTLOGIN.UseVisualStyleBackColor = false;
            this.BTLOGIN.Click += new System.EventHandler(this.BTLOGIN_Click);
            // 
            // username
            // 
            this.username.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.username.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.username.Location = new System.Drawing.Point(843, 308);
            this.username.Multiline = true;
            this.username.Name = "username";
            this.username.Size = new System.Drawing.Size(559, 42);
            this.username.TabIndex = 1;
            // 
            // password
            // 
            this.password.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.password.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.password.Location = new System.Drawing.Point(843, 429);
            this.password.Multiline = true;
            this.password.Name = "password";
            this.password.Size = new System.Drawing.Size(559, 42);
            this.password.TabIndex = 5;
            // 
            // close
            // 
            this.close.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.close.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.close.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.close.ForeColor = System.Drawing.Color.Red;
            this.close.Location = new System.Drawing.Point(1362, -2);
            this.close.Name = "close";
            this.close.Size = new System.Drawing.Size(63, 43);
            this.close.TabIndex = 15;
            this.close.Text = "X";
            this.close.UseVisualStyleBackColor = false;
            this.close.Click += new System.EventHandler(this.close_Click);
            // 
            // eyeshow
            // 
            this.eyeshow.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.eyeshow.BackgroundImage = global::IT_STORE.Properties.Resources.eyeshow;
            this.eyeshow.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.eyeshow.Location = new System.Drawing.Point(1362, 427);
            this.eyeshow.Name = "eyeshow";
            this.eyeshow.Size = new System.Drawing.Size(40, 40);
            this.eyeshow.TabIndex = 13;
            this.eyeshow.UseVisualStyleBackColor = false;
            this.eyeshow.Click += new System.EventHandler(this.eyeshow_Click);
            // 
            // eyehide
            // 
            this.eyehide.BackgroundImage = global::IT_STORE.Properties.Resources.eyehide;
            this.eyehide.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.eyehide.Location = new System.Drawing.Point(1362, 427);
            this.eyehide.Name = "eyehide";
            this.eyehide.Size = new System.Drawing.Size(40, 40);
            this.eyehide.TabIndex = 14;
            this.eyehide.UseVisualStyleBackColor = true;
            this.eyehide.Click += new System.EventHandler(this.eyehide_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = global::IT_STORE.Properties.Resources.BACKLOGIN;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox2.Location = new System.Drawing.Point(-4, -2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(1429, 713);
            this.pictureBox2.TabIndex = 6;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1424, 746);
            this.Controls.Add(this.close);
            this.Controls.Add(this.linkforgetpass);
            this.Controls.Add(this.linksignin);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.eyeshow);
            this.Controls.Add(this.username);
            this.Controls.Add(this.BTLOGIN);
            this.Controls.Add(this.eyehide);
            this.Controls.Add(this.password);
            this.Controls.Add(this.pictureBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.Load += new System.EventHandler(this.Login_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button eyeshow;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.LinkLabel linksignin;
        private System.Windows.Forms.LinkLabel linkforgetpass;
        private System.Windows.Forms.Button BTLOGIN;
        private System.Windows.Forms.TextBox username;
        private System.Windows.Forms.Button eyehide;
        private System.Windows.Forms.TextBox password;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button close;
    }
}