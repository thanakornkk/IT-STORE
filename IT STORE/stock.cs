using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IT_STORE
{
    public partial class stock : Form
    {
        public stock()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btpc_Click(object sender, EventArgs e)
        {
            PC pc = new PC();
            pc.Show();
            this.Hide();
        }

    

        private void button1_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Show();
            this.Hide();
        }

        private void btstatus_Click(object sender, EventArgs e)
        {
            order s = new order();
            s.Show();
            this.Hide();
        }

        private void btrec_Click(object sender, EventArgs e)
        {
            recordadmin re = new recordadmin();
            re.Show();
            this.Hide();
        }
    }
}
