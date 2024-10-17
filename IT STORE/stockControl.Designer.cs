namespace IT_STORE
{
    partial class stockControl
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
            this.names = new System.Windows.Forms.Label();
            this.pricepro = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.amountpro = new System.Windows.Forms.Label();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.delete = new System.Windows.Forms.Button();
            this.stid = new System.Windows.Forms.Label();
            this.spec = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // names
            // 
            this.names.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.names.Location = new System.Drawing.Point(3, 185);
            this.names.Name = "names";
            this.names.Size = new System.Drawing.Size(264, 46);
            this.names.TabIndex = 1;
            this.names.Text = "label1";
            // 
            // pricepro
            // 
            this.pricepro.AutoSize = true;
            this.pricepro.Font = new System.Drawing.Font("Roboto", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pricepro.Location = new System.Drawing.Point(4, 240);
            this.pricepro.Name = "pricepro";
            this.pricepro.Size = new System.Drawing.Size(87, 37);
            this.pricepro.TabIndex = 3;
            this.pricepro.Text = "Price";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.Location = new System.Drawing.Point(7, 277);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 20);
            this.label3.TabIndex = 15;
            this.label3.Text = "จำนวนสินค้า";
            // 
            // amountpro
            // 
            this.amountpro.AutoSize = true;
            this.amountpro.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.amountpro.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.amountpro.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.amountpro.Location = new System.Drawing.Point(104, 277);
            this.amountpro.Name = "amountpro";
            this.amountpro.Size = new System.Drawing.Size(53, 20);
            this.amountpro.TabIndex = 14;
            this.amountpro.Text = "label3";
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(3, 3);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(262, 179);
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            this.pictureBox.Click += new System.EventHandler(this.pictureBox_Click);
            // 
            // delete
            // 
            this.delete.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.delete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.delete.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.delete.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.delete.Location = new System.Drawing.Point(191, 234);
            this.delete.Name = "delete";
            this.delete.Size = new System.Drawing.Size(64, 63);
            this.delete.TabIndex = 16;
            this.delete.Text = "🗑️";
            this.delete.UseVisualStyleBackColor = false;
            this.delete.Click += new System.EventHandler(this.delete_Click);
            // 
            // stid
            // 
            this.stid.AutoSize = true;
            this.stid.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stid.Location = new System.Drawing.Point(195, 300);
            this.stid.Name = "stid";
            this.stid.Size = new System.Drawing.Size(36, 25);
            this.stid.TabIndex = 17;
            this.stid.Text = "10";
            // 
            // spec
            // 
            this.spec.AutoSize = true;
            this.spec.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.spec.Location = new System.Drawing.Point(8, 330);
            this.spec.Name = "spec";
            this.spec.Size = new System.Drawing.Size(44, 16);
            this.spec.TabIndex = 18;
            this.spec.Text = "label1";
            // 
            // stockControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.spec);
            this.Controls.Add(this.stid);
            this.Controls.Add(this.delete);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.amountpro);
            this.Controls.Add(this.pricepro);
            this.Controls.Add(this.names);
            this.Controls.Add(this.pictureBox);
            this.Name = "stockControl";
            this.Size = new System.Drawing.Size(268, 346);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Label names;
        private System.Windows.Forms.Label pricepro;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label amountpro;
        private System.Windows.Forms.Button delete;
        private System.Windows.Forms.Label stid;
        private System.Windows.Forms.Label spec;
    }
}
