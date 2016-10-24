using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
namespace payroll_management_system
{
    public partial class EMPOLYEEINFO : Form
    {
       
        int num;
        public EMPOLYEEINFO()
        {
            InitializeComponent();
        }
        public static void GET()
        {
            SqlConnection obj = new SqlConnection();
            obj.ConnectionString = @"Data source=LENOVO-PC\SQLEXPRESS ; initial catalog=payroll; integrated security=True";
            obj.Open(); 
            //string data = "select BASICSALARY from DESIGNATION WHERE DESIGNATION LIKE '" +  + "'";
            

        }
        
        private void eMPOLYEEINFOToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void aTTENDANCESYSTEMToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SqlConnection obj = new SqlConnection();
            obj.ConnectionString = @"Data source=LENOVO-PC\SQLEXPRESS ; initial catalog=payroll; integrated security=True";
            obj.Open();
            string query = "select ID from INFO";
            //string data = "select BASICSALARY from DESIGNATION WHERE DESIGNATION LIKE '" + EMPDESIGNATION.Text + "'";
            SqlCommand cmd = new SqlCommand(query, obj);
            //SqlCommand cm = new SqlCommand(data,obj);
            using (SqlDataReader read = cmd.ExecuteReader())
            {
                while (read.Read())
                {
                    textBox1.Text = (read["ID"].ToString());

                }
            }
            

            if (textBox1.Text != "")
            {
                num = int.Parse(textBox1.Text);
                num++;
                ID.Text = Convert.ToString(num);
            }
            else
            {
                ID.Text = "0";
            }
           obj.Close();
            /*obj.Open();
            string data = "select BASICSALARY from DEPARTMENT WHERE DESIGNATION LIKE '%" + EMPDESIGNATION.Text + "'";
            SqlCommand cm = new SqlCommand(data,obj);
            using (SqlDataReader o = cm.ExecuteReader())
            {
                while (o.Read())
                {
                    EMPBASICSALARY.Text=(o["BASICSALARY"].ToString());
                }
            }
           obj.Close();*/
           /*SqlConnection OBJ = new SqlConnection();
           OBJ.ConnectionString = @"Data source=LENOVO-PC\SQLEXPRESS ; initial catalog=payroll; integrated security=True";
           OBJ.Open();
           //SqlCommand cM = new SqlCommand(OBJ);
           //SqlDataAdapter R = new SqlDataAdapter();
           string DATA = "select BASICSALARY from DEPARTMENT where DESIGNATION LIKE '%" + EMPDESIGNATION.Text + "'";
          SqlCommand  cM= new SqlCommand(DATA, obj);
           SqlDataAdapter R = new SqlDataAdapter(cM);
           DataTable A = new DataTable();
           R.Fill(A);
           EMPBASICSALARY.Text = A.Rows[0][0].ToString();
           OBJ.Close();*/
            
        }
        


        private void lEAVEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LEAVE obj = new LEAVE();
            obj.Show();
            this.Hide();
        }

        private void pRESENTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PRESENT obj = new PRESENT();
            obj.Show();
            this.Hide();
        }

        private void eXITToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void iNCENTIVESToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SALARY OBJ = new SALARY();
            OBJ.Show();
            this.Hide();
        }

        private void bONUSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LOAN obj = new LOAN();
            obj.Show();
            this.Hide();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void UPLOAD_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "jpg|*.jpg";
            DialogResult res = openFileDialog1.ShowDialog();
            if(res==DialogResult.OK)
                
            {
                EMPPICTURE.Image = Image.FromFile(openFileDialog1.FileName);
            }
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
                SqlCommand cmd = new SqlCommand("INSERT INTO INFO(ID,NAME,NICNUMBER,GENDER,AGE,ADDRESS,CONTACTNUMBER,EMAIL,DATEOFAPPOINTMENT,DESIGNATION,BASICSALARY,PHOTO) VALUES (" + ID.Text + ",'" + EMPNAME.Text + "'," + EMPNICNUMBER.Text + ",'" + EMPGENDER.Text + "'," + EMPAGE.Text + ",'" + EMPADDRESS.Text + "','" + EMPCONTACTNUMBER.Text + "','" + EMPEMAIL.Text + "','"+dateTimePicker1.Value.ToString("M/d/yyyy")+"','" + EMPDESIGNATION.Text + "'," + EMPBASICSALARY.Text + ",@PHOTO)", obj);
                MemoryStream sd = new MemoryStream();
                EMPPICTURE.Image.Save(sd, System.Drawing.Imaging.ImageFormat.Jpeg);
                byte[] r = sd.ToArray();
                cmd.Parameters.AddWithValue("@PHOTO", r);
                i = cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    MessageBox.Show("Successfully Saved" + i);
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
                SqlConnection obj = new SqlConnection();
                obj.ConnectionString = @"Data source=LENOVO-PC\SQLEXPRESS ; initial catalog=payroll; integrated security=True";
                obj.Open();
                SqlCommand cmd;
                SqlDataAdapter r;
                string query = "select * from INFO where ID= " + textBox1.Text + "";
                cmd = new SqlCommand(query, obj);
                r = new SqlDataAdapter(cmd);
                DataTable tb = new DataTable();
                r.Fill(tb);
                
                //ID.Text = tb.Rows[0][0].ToString();
                EMPNAME.Text = tb.Rows[0][1].ToString();
                EMPNICNUMBER.Text = tb.Rows[0][2].ToString();
                EMPGENDER.Text = tb.Rows[0][3].ToString();
                EMPAGE.Text = tb.Rows[0][4].ToString();
                EMPADDRESS.Text = tb.Rows[0][5].ToString();
                EMPCONTACTNUMBER.Text = tb.Rows[0][6].ToString();
                EMPEMAIL.Text = tb.Rows[0][7].ToString();
                dateTimePicker1.Text = tb.Rows[0][8].ToString();
                EMPDESIGNATION.Text = tb.Rows[0][9].ToString();
                EMPBASICSALARY.Text = tb.Rows[0][10].ToString();
                
                byte[] img = (byte[])tb.Rows[0][11];
                MemoryStream me = new MemoryStream(img);
                EMPPICTURE.Image = Image.FromStream(me);
                r.Dispose();
                obj.Close();
            }
            catch
            {
                MessageBox.Show("No Data Found");
            }
        }

        private void UPDATE_Click(object sender, EventArgs e)
        {
            
            
                /*SqlConnection obj = new SqlConnection();
                obj.ConnectionString = @"Data source=LENOVO-PC\SQLEXPRESS ; initial catalog=payroll; integrated security=True";
                obj.Open();
                string query = "Update INFO SET NAME = '" + EMPNAME.Text + "', NICNUMBER = '" + EMPNICNUMBER.Text + "',GENDER = '" + EMPGENDER.Text + "',AGE=" + EMPAGE.Text + ",ADDRESS='" + EMPADDRESS.Text + "',CONTACTNUMBER='" + EMPADDRESS.Text + "',EMAIL='" + EMPEMAIL.Text + "',DATEOFAPPOINTMENT='" + dateTimePicker1.Value.ToString("M/d/yyyy") + "',DESIGNATION='"+EMPDESIGNATION.Text+"',BASICSALARY="+EMPBASICSALARY.Text+",PHOTO=@PHOTO  WHERE ID = " + ID.Text;

                SqlCommand cmd = new SqlCommand(query, obj);
                cmd.ExecuteNonQuery();
                MessageBox.Show(" Succesfully Updated");
                obj.Close();*/
                //TxtBoxClear();
            try
            {
                //if (ID.Text != "" && EMPNAME.Text != "" && EMPNICNUMBER.Text != "" && EMPGENDER.Text != "" && EMPEMAIL.Text != "" && EMPDESIGNATION.Text != "" && EMPBASICSALARY.Text != "" && EMPAGE.Text != "" && EMPCONTACTNUMBER.Text != "" && EMPADDRESS.Text != "" ))
                //{
                int i = 0;
                SqlConnection obj = new SqlConnection();
                obj.ConnectionString = @"Data source=LENOVO-PC\SQLEXPRESS ; initial catalog=payroll; integrated security=True";
                obj.Open();
                SqlCommand cmd = new SqlCommand("Update INFO SET NAME = '" + EMPNAME.Text + "', NICNUMBER = '" + EMPNICNUMBER.Text + "',GENDER = '" + EMPGENDER.Text + "',AGE=" + EMPAGE.Text + ",ADDRESS='" + EMPADDRESS.Text + "',CONTACTNUMBER='" + EMPCONTACTNUMBER.Text + "',EMAIL='" + EMPEMAIL.Text + "',DATEOFAPPOINTMENT='" + dateTimePicker1.Value.ToString("M/d/yyyy") + "',DESIGNATION='"+EMPDESIGNATION.Text+"',BASICSALARY="+EMPBASICSALARY.Text+",PHOTO=@PHOTO  WHERE ID = " + textBox1.Text
, obj);
               
                MemoryStream sd = new MemoryStream();
                EMPPICTURE.Image.Save(sd, System.Drawing.Imaging.ImageFormat.Jpeg);
                byte[] r = sd.ToArray();
                cmd.Parameters.AddWithValue("@PHOTO", r);
                i = cmd.ExecuteNonQuery();
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
                SqlCommand cmd = new SqlCommand("delete  from INFO where ID="+ textBox1.Text+"", obj);
                //MemoryStream sd = new MemoryStream();
                //EMPPICTURE.Image.Save(sd, System.Drawing.Imaging.ImageFormat.Jpeg);
                //byte[] r = sd.ToArray();
                //cmd.Parameters.AddWithValue("@PHOTO", r);
                i = cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    MessageBox.Show("Successfully Deleted" );
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

        private void hOLIDAYSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HOLIDAYS OBJ=new HOLIDAYS();
            OBJ.Show();
            this.Hide();
        }

        private void dEPARTMENTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DESIGNATION obj = new DESIGNATION();
            obj.Show();
            this.Hide();
        }

        private void oTHERINFOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OTHERINFO obh = new OTHERINFO();
            obh.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection obj = new SqlConnection();
                obj.ConnectionString = @"Data source=LENOVO-PC\SQLEXPRESS ; initial catalog=payroll; integrated security=True";
                obj.Open();
                string data = "select BASICSALARY from DEPARTMENT WHERE DESIGNATION LIKE '%" + EMPDESIGNATION.Text + "'";
                SqlCommand cm = new SqlCommand(data, obj);
                using (SqlDataReader o = cm.ExecuteReader())
                {
                        while (o.Read())
                        {
                            EMPBASICSALARY.Text = (o["BASICSALARY"].ToString());
                        }
                }
                obj.Close();
                
               
            }
            catch (Exception EX)
            {
                MessageBox.Show(EX.Message);
            }
        }

        private void sALARYSLIPToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
 