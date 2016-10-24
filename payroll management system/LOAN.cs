using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace payroll_management_system
{
    public partial class LOAN : Form
    {
        public LOAN()
        {
            InitializeComponent();
        }

        private void MONTHLYINSTALLMENT_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            image obj = new image();
            obj.Show();
            this.Hide();
        }
    }
}
