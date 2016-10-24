using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace payroll_management_system
{
    public partial class SALARY : Form
    {
        public SALARY()
        {
            InitializeComponent();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            salaryperday.Text = Convert.ToString(Convert.ToInt32(basicsalary.Text) /Convert.ToInt32( workingdays.Text));
            hra.Text = Convert.ToString(Convert.ToInt32(basicsalary.Text) * 0.5);
            pf.Text = Convert.ToString(Convert.ToInt32(basicsalary.Text) * 0.12);
            amount.Text = Convert.ToString(Convert.ToInt32(fordays) * Convert.ToInt32(salaryperday));


        }

        private void pf_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void name_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
