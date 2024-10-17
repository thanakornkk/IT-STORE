namespace IT_STORE
{
    partial class order
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(order));
            this.flowshoworder = new System.Windows.Forms.FlowLayoutPanel();
            this.back = new System.Windows.Forms.Button();
            this.userz = new System.Windows.Forms.TextBox();
            this.track = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // flowshoworder
            // 
            this.flowshoworder.AutoScroll = true;
            this.flowshoworder.BackColor = System.Drawing.SystemColors.ControlLight;
            this.flowshoworder.Location = new System.Drawing.Point(-3, 29);
            this.flowshoworder.Name = "flowshoworder";
            this.flowshoworder.Size = new System.Drawing.Size(1915, 678);
            this.flowshoworder.TabIndex = 0;
            this.flowshoworder.Paint += new System.Windows.Forms.PaintEventHandler(this.flowshoworder_Paint);
            // 
            // back
            // 
            this.back.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.back.ForeColor = System.Drawing.Color.Red;
            this.back.Location = new System.Drawing.Point(-3, -1);
            this.back.Name = "back";
            this.back.Size = new System.Drawing.Size(51, 31);
            this.back.TabIndex = 18;
            this.back.Text = "X";
            this.back.UseVisualStyleBackColor = true;
            this.back.Click += new System.EventHandler(this.back_Click);
            // 
            // userz
            // 
            this.userz.Location = new System.Drawing.Point(68, 6);
            this.userz.Name = "userz";
            this.userz.Size = new System.Drawing.Size(10, 22);
            this.userz.TabIndex = 19;
            this.userz.TextChanged += new System.EventHandler(this.userz_TextChanged);
            // 
            // track
            // 
            this.track.AutoSize = true;
            this.track.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.track.LinkColor = System.Drawing.Color.Red;
            this.track.Location = new System.Drawing.Point(1492, 6);
            this.track.Name = "track";
            this.track.Size = new System.Drawing.Size(51, 20);
            this.track.TabIndex = 20;
            this.track.TabStop = true;
            this.track.Text = "Track";
            this.track.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.track_LinkClicked);
            // 
            // order
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(1924, 746);
            this.Controls.Add(this.track);
            this.Controls.Add(this.userz);
            this.Controls.Add(this.back);
            this.Controls.Add(this.flowshoworder);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "order";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "order";
            this.Load += new System.EventHandler(this.order_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowshoworder;
        private System.Windows.Forms.Button back;
        private System.Windows.Forms.TextBox userz;
        private System.Windows.Forms.LinkLabel track;
    }
}