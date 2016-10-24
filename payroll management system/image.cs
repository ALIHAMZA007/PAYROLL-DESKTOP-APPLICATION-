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
    public partial class image : Form
    {
        public image()
        {
            InitializeComponent();
        }

        private void UPLOAD_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "jpg|*.jpg";
            DialogResult res = openFileDialog1.ShowDialog();
            if (res == DialogResult.OK)
            {
                pictureBox6.Image = Image.FromFile(openFileDialog1.FileName);
            }
        }

        private void UPLOAD1_Click(object sender, EventArgs e)
        {
            openFileDialog2.Filter = "jpg|*.jpg";
            DialogResult res = openFileDialog1.ShowDialog();
            if (res == DialogResult.OK)
            {
                pictureBox8.Image = Image.FromFile(openFileDialog1.FileName);
            }
        }

        private void UPLOAD2_Click(object sender, EventArgs e)
        {
            openFileDialog3.Filter = "jpg|*.jpg";
            DialogResult res = openFileDialog1.ShowDialog();
            if (res == DialogResult.OK)
            {
                pictureBox3.Image = Image.FromFile(openFileDialog1.FileName);
            }
        }

        private void UPLOAD3_Click(object sender, EventArgs e)
        {
            openFileDialog4.Filter = "jpg|*.jpg";
            DialogResult res = openFileDialog1.ShowDialog();
            if (res == DialogResult.OK)
            {
                pictureBox5.Image = Image.FromFile(openFileDialog1.FileName);
            }
        }

        private void SAVE_Click(object sender, EventArgs e)
        {
            int i = 0;
            SqlConnection obj = new SqlConnection();
            obj.ConnectionString = @"Data source=LENOVO-PC\SQLEXPRESS ; initial catalog=payroll; integrated security=True";
            obj.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO IMAGE(PHOTO,PHOTO1,PHOTO2,PHOTO3) VALUES (@PHOTO,@PHOTO1,@PHOTO2,@PHOTO3)", obj);
            MemoryStream sd = new MemoryStream();
            pictureBox6.Image.Save(sd, System.Drawing.Imaging.ImageFormat.Jpeg);
            pictureBox8.Image.Save(sd, System.Drawing.Imaging.ImageFormat.Jpeg);
            pictureBox3.Image.Save(sd, System.Drawing.Imaging.ImageFormat.Jpeg);
            pictureBox5.Image.Save(sd, System.Drawing.Imaging.ImageFormat.Jpeg);
            byte[] r = sd.ToArray();
            cmd.Parameters.AddWithValue("@PHOTO", r);
            cmd.Parameters.AddWithValue("@PHOTO1", r);
            cmd.Parameters.AddWithValue("@PHOTO2", r);
            cmd.Parameters.AddWithValue("@PHOTO3", r);
            i = cmd.ExecuteNonQuery();
            if (i > 0)
            {
                MessageBox.Show("Successfully Saved" + i);
            }
            obj.Close();
        }
    }
}
