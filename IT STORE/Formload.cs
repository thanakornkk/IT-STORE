using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IT_STORE
{
    public partial class Formload : Form
    {
        public Formload()
        {
            InitializeComponent();
        }

        private int labelCounter = 1;
        private void timer1_Tick(object sender, EventArgs e)
        {
            panel1.Width += 30;
            if (panel1.Width >= 1400)
            {
                timer1.Stop();
                Login log = new Login();
                log.Show();
                this.Hide();
            }
            else
            {
                switch (labelCounter)
                {
                    case 1:
                        LOADING1.Visible = true;
                        LOADING1.Visible = false;
                        LOADING3.Visible = false;
                        break;
                    case 2:
                        LOADING1.Visible = false;
                        LOADING2.Visible = true;
                        LOADING3.Visible = false;
                        break;
                    case 3:
                        LOADING1.Visible = false;
                        LOADING2.Visible = false;
                        LOADING3.Visible = true;
                        break;
                }

                labelCounter = (labelCounter % 10) + 1;
            }
        }

        private void Formload_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }
    }
}
