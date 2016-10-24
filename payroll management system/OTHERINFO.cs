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
    public partial class OTHERINFO : Form
    {
        SqlConnection obh;
        SqlDataAdapter r;
        DataSet dt;
        SqlCommandBuilder H;
        public OTHERINFO()
        {
            InitializeComponent();
        }

        private void OTHERINFO_Load(object sender, EventArgs e)
        {
            try
            {
                obh = new SqlConnection(@"Data source=LENOVO-PC\SQLEXPRESS ; initial catalog=payroll; integrated security=True");
                obh.Open();
                r = new SqlDataAdapter("select * from OTHER ", obh);
                dt = new DataSet();
                r.Fill(dt, "OTHER");
                dataGridView1.DataSource = dt.Tables[0];
                //MessageBox.Show("search successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SAVE_Click(object sender, EventArgs e)
        {
            try
            {

                H = new SqlCommandBuilder(r);
                r.Update(dt, "OTHER");
                MessageBox.Show("Records Has Been Modified");
            }
            catch (Exception EX)
            {
                MessageBox.Show(EX.Message);
            }
        }
    }
}
