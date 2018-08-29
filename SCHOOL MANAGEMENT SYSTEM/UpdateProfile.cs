using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SCHOOL_MANAGEMENT_SYSTEM
{
    public partial class UpdateProfile : Form
    {
        public UpdateProfile()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ACER\Documents\SMS.mdf;Integrated Security=True;Connect Timeout=30");
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from  StudentRegistration where StudentId ='" + comboBox1.Text + "'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                textBox2.Text = (dr["FN"].ToString());
                textBox3.Text = (dr["LN"].ToString());
                textBox4.Text = (dr["Gender"].ToString());
                dateofbirthDateTimePicker.Text = (dr["DOB"].ToString());
                textBox5.Text = (dr["Class"].ToString());
                textBox6.Text = (dr["Address"].ToString());
                textBox7.Text = (dr["Mobile"].ToString());
                textBox8.Text = (dr["FatherName"].ToString());
                dateDateTimePicker.Text = (dr["Date"].ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "")
            {
                MessageBox.Show("Enter Student ID To UPDATE Student's Data");
            }
            else
            {
                if (textBox2.Text==""||textBox3.Text==""|| textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "" || textBox7.Text == "" || textBox8.Text == "")
                {
                    MessageBox.Show("Some Data Missing");
                }
                else
                {
                    SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ACER\Documents\SMS.mdf;Integrated Security=True;Connect Timeout=30");
                    con.Open();
                    SqlCommand cmd = new SqlCommand("update StudentRegistration set FN ='" + textBox2.Text + "',LN ='" + textBox3.Text + "',Gender ='" + textBox4.Text + "',DOB ='" + dateofbirthDateTimePicker.Text + "',Class ='" + textBox5.Text + "',Address ='" + textBox6.Text + "',Mobile ='" + textBox7.Text + "',FatherName ='" + textBox8.Text + "', Date ='" + dateDateTimePicker.Text + "' where StudentId='" + comboBox1.Text + "'", con);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    MessageBox.Show("DATA UPDATED SUCCESSFULLY");
                    this.Close();
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UpdateProfile_Load(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ACER\Documents\SMS.mdf;Integrated Security=True;Connect Timeout=30");
                con.Open();
                string cmd = "select StudentId from StudentRegistration ";
                SqlDataReader sdr = new SqlCommand(cmd, con).ExecuteReader();
                while (sdr.Read())
                {
                    comboBox1.Items.Add(sdr.GetValue(0).ToString());
                }
                sdr.Close();
            }

            catch (SqlException x)
            {

            }
        }
    }
}
