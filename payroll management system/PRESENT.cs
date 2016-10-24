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
    public partial class PRESENT : Form
    {
        public PRESENT()
        {
            InitializeComponent();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void SAVE_Click(object sender, EventArgs e)
        {
            try
            {
                //if (ID.Text != "" && EMPNAME.Text != "" && EMPNICNUMBER.Text != "" && EMPGENDER.Text != "" && EMPEMAIL.Text != "" && EMPDESIGNATION.Text != "" && EMPBASICSALARY.Text != "" && EMPAGE.Text != "" && EMPCONTACTNUMBER.Text != "" && EMPADDRESS.Text != "" ))
                //{
                int i = 0;
                SqlConnection obj = new SqlConnection();
                obj.ConnectionString = @"Data source=LENOVO-PC\SQLEXPRESS ; initial catalog=payroll; integrated security=True";
                obj.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO ATTENDANCE(EMPOLYEEID,EMPOLYEENAME,MONTH,YEAR,WORKINGDAYS,PRESENT,ABSENT,DATEOFATTENDANCE) VALUES (" + EMPOLYEEID.Text + ",'" + EMPOLYEENAME.Text + "','" +MONTH.Text+ "','" + YEAR.Text + "'," + WORKINGDAYS.Text + "," + PRESEN.Text + "," + ABSENT.Text + ",'" + dateTimePicker1.Value.ToString("M/d/yyyy") + "')", obj);
                i = cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    MessageBox.Show("Successfully Saved");
                }
                obj.Close();
                // }
                // else
                //{
                // MessageBox.Show("Fill the form completely");
                //}
            }
            catch
            {
                MessageBox.Show("Fill The Form Completely");
            }
            
        }

        private void SEARCH_Click(object sender, EventArgs e)
        {
            try
            {
                if (EMPOLYEEID.Text != "" && MONTH.Text != "" && YEAR.Text != "")
                {
                    SqlConnection obj = new SqlConnection();
                    obj.ConnectionString = @"Data source=LENOVO-PC\SQLEXPRESS ; initial catalog=payroll; integrated security=True";
                    obj.Open();
                    SqlCommand cmd;
                    SqlDataAdapter r;
                    string query = "select * from ATTENDANCE where EMPOLYEEID= " + EMPOLYEEID.Text + " AND MONTH= '" + MONTH.Text + "' AND YEAR= '" + YEAR.Text + "' ";
                    cmd = new SqlCommand(query, obj);
                    r = new SqlDataAdapter(cmd);
                    DataTable tb = new DataTable();
                    r.Fill(tb);
                    EMPOLYEENAME.Text = tb.Rows[0][1].ToString();
                    WORKINGDAYS.Text = tb.Rows[0][4].ToString();
                    PRESEN.Text = tb.Rows[0][5].ToString();
                    ABSENT.Text = tb.Rows[0][6].ToString();
                    dateTimePicker1.Text = tb.Rows[0][7].ToString();
                    obj.Close();
                }
                else
                {
                    MessageBox.Show("ENTER THE VALID MONTH  ID AND YEAR");
                }
            }
            catch
            {
                MessageBox.Show("No Data Found");
            }
        }

        private void UPDATE_Click(object sender, EventArgs e)
        {
            try
            {
                //if (ID.Text != "" && EMPNAME.Text != "" && EMPNICNUMBER.Text != "" && EMPGENDER.Text != "" && EMPEMAIL.Text != "" && EMPDESIGNATION.Text != "" && EMPBASICSALARY.Text != "" && EMPAGE.Text != "" && EMPCONTACTNUMBER.Text != "" && EMPADDRESS.Text != "" ))
                //{
                if (EMPOLYEEID.Text != "")
                {
                    int i = 0;
                    SqlConnection obj = new SqlConnection();
                    obj.ConnectionString = @"Data source=LENOVO-PC\SQLEXPRESS ; initial catalog=payroll; integrated security=True";
                    obj.Open();
                    SqlCommand cmd = new SqlCommand("Update ATTENDANCE SET MONTH = '" + MONTH.Text + "',YEAR = '" + YEAR.Text + "',WORKINGDAYS=" + WORKINGDAYS.Text + ",PRESENT=" + PRESEN.Text + ",ABSENT='" + ABSENT.Text + "',DATEOFATTENDANCE='" + dateTimePicker1.Value.ToString("M/d/yyyy") + "'  WHERE ID = " + EMPOLYEEID.Text
    , obj);


                    if (i > 0)
                    {
                        MessageBox.Show("Successfully Updated");
                    }
                    obj.Close();
                    // }
                    // else
                    //{
                    // MessageBox.Show("Fill the form completely");
                    //}
                }
                else
                {
                    MessageBox.Show("NO DATA FOUND");
                }
            }
            catch
            {
                MessageBox.Show("Cannot Be Updated ");
            }
            
            
        }

        private void DELETE_Click(object sender, EventArgs e)
        {
            try
            {
                //if (ID.Text != "" && EMPNAME.Text != "" && EMPNICNUMBER.Text != "" && EMPGENDER.Text != "" && EMPEMAIL.Text != "" && EMPDESIGNATION.Text != "" && EMPBASICSALARY.Text != "" && EMPAGE.Text != "" && EMPCONTACTNUMBER.Text != "" && EMPADDRESS.Text != "" ))
                //{
                int i = 0;
                SqlConnection obj = new SqlConnection();
                obj.ConnectionString = @"Data source=LENOVO-PC\SQLEXPRESS ; initial catalog=payroll; integrated security=True";
                obj.Open();
                SqlCommand cmd = new SqlCommand("delete  from ATTENDANCE where EMPOLYEEID=" + EMPOLYEEID + " AND MONTH='"+MONTH.Text+"' AND YEAR='"+YEAR.Text+"'", obj);
                //MemoryStream sd = new MemoryStream();
                //EMPPICTURE.Image.Save(sd, System.Drawing.Imaging.ImageFormat.Jpeg);
                //byte[] r = sd.ToArray();
                //cmd.Parameters.AddWithValue("@PHOTO", r);
                i = cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    MessageBox.Show("Successfully Deleted");
                }
                obj.Close();
                //}
                // else
                //{
                // MessageBox.Show("Fill the form completely");
                //}
            }
            catch
            {
                MessageBox.Show("No data Found");
            }
        }
    }
}
