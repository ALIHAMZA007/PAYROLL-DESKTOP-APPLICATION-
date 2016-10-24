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
    public partial class HOLIDAYS : Form
    {
        SqlConnection obh;
        SqlDataAdapter r;
        DataSet dt;
        SqlCommandBuilder H;
        public HOLIDAYS()
        {
            InitializeComponent();
        }

        private void save_Click(object sender, EventArgs e)
        {
            try
            {

                H = new SqlCommandBuilder(r);
                r.Update(dt, "HOLIDAYS");
                MessageBox.Show("Records Has Been Modified");
            }
            catch 
            {
                MessageBox.Show("Date In Wromg Fromat");
            }
        }

        private void search_Click(object sender, EventArgs e)
        {
             obh = new SqlConnection(@"Data source=LENOVO-PC\SQLEXPRESS ; initial catalog=payroll; integrated security=True");
            obh.Open();
            SqlDataAdapter r = new SqlDataAdapter("select * from HOLIDAYS ", obh);
            DataTable dt = new DataTable();
            r.Fill(dt);
            dataGridView1.DataSource = dt;
            MessageBox.Show("search successfully");
        }

        private void HOLIDAYS_Load(object sender, EventArgs e)
        {
            try
            {
                obh = new SqlConnection(@"Data source=LENOVO-PC\SQLEXPRESS ; initial catalog=payroll; integrated security=True");
                obh.Open();
                r = new SqlDataAdapter("select * from HOLIDAYS ", obh);
                dt = new DataSet();
                r.Fill(dt, "HOLIDAYS");
                dataGridView1.DataSource = dt.Tables[0];
                //MessageBox.Show("search successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void UPDATE_Click(object sender, EventArgs e)
        {

        }
        
    }
}
