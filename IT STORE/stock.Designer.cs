namespace IT_STORE
{
    partial class stock
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(stock));
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.btpc = new System.Windows.Forms.Button();
            this.btrec = new System.Windows.Forms.Button();
            this.btstatus = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.btpc);
            this.panel1.Controls.Add(this.btrec);
            this.panel1.Controls.Add(this.btstatus);
            this.panel1.Location = new System.Drawing.Point(-1, -2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(818, 476);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.button1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button1.Location = new System.Drawing.Point(299, 371);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(226, 34);
            this.button1.TabIndex = 6;
            this.button1.Text = "Close";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btpc
            // 
            this.btpc.BackgroundImage = global::IT_STORE.Properties.Resources.STOCK;
            this.btpc.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btpc.Location = new System.Drawing.Point(0, 3);
            this.btpc.Name = "btpc";
            this.btpc.Size = new System.Drawing.Size(815, 123);
            this.btpc.TabIndex = 0;
            this.btpc.UseVisualStyleBackColor = true;
            this.btpc.Click += new System.EventHandler(this.btpc_Click);
            // 
            // btrec
            // 
            this.btrec.BackgroundImage = global::IT_STORE.Properties.Resources.HISTORsY;
            this.btrec.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btrec.Location = new System.Drawing.Point(3, 242);
            this.btrec.Name = "btrec";
            this.btrec.Size = new System.Drawing.Size(815, 123);
            this.btrec.TabIndex = 5;
            this.btrec.UseVisualStyleBackColor = true;
            this.btrec.Click += new System.EventHandler(this.btrec_Click);
            // 
            // btstatus
            // 
            this.btstatus.BackgroundImage = global::IT_STORE.Properties.Resources.STATUS__1_;
            this.btstatus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btstatus.Location = new System.Drawing.Point(0, 122);
            this.btstatus.Name = "btstatus";
            this.btstatus.Size = new System.Drawing.Size(815, 123);
            this.btstatus.TabIndex = 4;
            this.btstatus.UseVisualStyleBackColor = true;
            this.btstatus.Click += new System.EventHandler(this.btstatus_Click);
            // 
            // stock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(813, 415);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "stock";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "stock";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btpc;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button btstatus;
        private System.Windows.Forms.Button btrec;
        private System.Windows.Forms.Button button1;
    }
}