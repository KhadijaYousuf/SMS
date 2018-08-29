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
    public partial class STUDENT : Form
    {
        public STUDENT()
        {
            InitializeComponent();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ACER\Documents\SMS.mdf;Integrated Security=True;Connect Timeout=30");
                con.Open();
                SqlCommand cmd = new SqlCommand("select *from Homework where Class='" + textBox1.Text + "'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable DT = new DataTable();
                da.Fill(DT);
                dataGridView1.DataSource = DT;
                con.Close();
            }
            else
            {
                MessageBox.Show("FAILED");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form User = new User();
            User.ShowDialog();
        }

        private void notificationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ACER\Documents\SMS.mdf;Integrated Security=True;Connect Timeout=30");
            con.Open();
            SqlCommand cmd = new SqlCommand("select *from Notifications", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable DT = new DataTable();
            da.Fill(DT);
            dataGridView1.DataSource = DT;
            con.Close();
            textBox1.Text = "";
            textBox1.Enabled = false;
        }

        private void homeWorkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ACER\Documents\SMS.mdf;Integrated Security=True;Connect Timeout=30");
            con.Open();
            SqlCommand cmd = new SqlCommand("select *from Homework", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable DT = new DataTable();
            da.Fill(DT);
            dataGridView1.DataSource = DT;
            textBox1.Enabled = true;
            con.Close();
        }
    }
}
