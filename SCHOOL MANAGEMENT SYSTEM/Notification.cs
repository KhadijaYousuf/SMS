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
    public partial class Notification : Form
    {
        public Notification()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ACER\Documents\SMS.mdf;Integrated Security=True;Connect Timeout=30");
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into Notifications(NId, Date, Notification) values('" + textBox1.Text + "', '" + dateTimePicker1.Text + "', '" + richTextBox1.Text + "')", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            MessageBox.Show("NOTIFICATION UPDATED SUCCESSFULLY");
            textBox1.Text = ""; richTextBox1.Text = "";
        }

        string NId = "NId#";
        private void GC()
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ACER\Documents\SMS.mdf;Integrated Security=True;Connect Timeout=30");
            con.Open();
            SqlCommand cmd = new SqlCommand("select count(HomeWorkID) from Homework", con);
            int i = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();
            i++;
            textBox1.Text = NId + i.ToString();
        }

        private void Notification_Load(object sender, EventArgs e)
        {
            GC();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ACER\Documents\SMS.mdf;Integrated Security=True;Connect Timeout=30");
            con.Open();
            SqlCommand cmd = new SqlCommand("delete from Notifications where NId='" + textBox1.Text + "'", con);
            int i = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Enter NOTIFICATION ID To UPDATE Required Notification");
            }
            else
            {
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ACER\Documents\SMS.mdf;Integrated Security=True;Connect Timeout=30");
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter("Update Notifications set Notification='" + richTextBox1.Text + "', Date='" + dateTimePicker1.Text + "'", con);
                sda.SelectCommand.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("DATA UPDATED SUCCESSFULLY");
                richTextBox1.Text = ""; textBox1.Text = "";
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ACER\Documents\SMS.mdf;Integrated Security=True;Connect Timeout=30");
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from  Notifications where NId ='" + textBox1.Text + "'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                richTextBox1.Text = (dr["Notification"].ToString());
            }
        }
    }
}
