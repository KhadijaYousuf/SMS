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
    public partial class FeesManagement : Form
    {
        public FeesManagement()
        {
            InitializeComponent();
        }

        private void reciep_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text != "" && txtname.Text != "" && txtclass.Text != "" && txttot.Text != "" && txtbal.Text != "" && txtamtpaid.Text != "")
            {
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ACER\Documents\SMS.mdf;Integrated Security=True;Connect Timeout=30");
                con.Open();
                SqlCommand cmd = new SqlCommand("insert into FeesAdmin(StudentId, Name, Class, TotalFees, Balance, AmountPaid) values('" + comboBox1.Text + "', '" + txtname.Text + "', '" + txtclass.Text + "', '" + txttot.Text + "', '" + txtbal.Text + "', '" + txtamtpaid.Text + "')", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                MessageBox.Show("DATA INSERTED SUCESSFULY");
                comboBox1.Text = ""; txtamtpaid.Text = ""; txtbal.Text = ""; txtclass.Text = ""; txtname.Text = ""; txttot.Text = "";
            }
            else
            {
                MessageBox.Show("DATA INSERTION FAILED");
            }
        }

        private void FeesManagement_Load(object sender, EventArgs e)
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
                txtname.Text = (dr["FN"].ToString() + dr["LN"].ToString());
                txtclass.Text = (dr["Class"].ToString());
                txttot.Text = (dr["TotalFees"].ToString());
                txtbal.Text = (dr["Balance"].ToString());
                txtamtpaid.Text = (dr["AmountPaid"].ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "")
            {
                MessageBox.Show("Enter STUDENT ID To UPDATE Required Student's Data");
            }
            else
            {
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ACER\Documents\SMS.mdf;Integrated Security=True;Connect Timeout=30");
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter("Update FeesAdmin set Name='" + txtname.Text + "', Class='" + txtclass.Text + "', TotalFees='" + txttot.Text + "', Balance='" + txtbal.Text + "', AmountPaid='" + txtamtpaid.Text + "' where SID='" + comboBox1.Text + "'", con);
                sda.SelectCommand.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("DATA UPDATED SUCCESSFULLY");

                comboBox1.Text = ""; txtamtpaid.Text = ""; txtbal.Text = ""; txtclass.Text = ""; txtname.Text = ""; txttot.Text = "";
            }
        }
    }
}
