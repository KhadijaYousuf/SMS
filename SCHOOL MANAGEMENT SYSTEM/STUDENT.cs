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

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox2.Text == "" || comboBox4.Text != "")
            {
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ACER\Documents\SMS.mdf;Integrated Security=True;Connect Timeout=30");
                con.Open();
                SqlCommand cmd = new SqlCommand("select *from Homework where Class='" + comboBox4.Text + "'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable DT = new DataTable();
                da.Fill(DT);
                dataGridView1.DataSource = DT;
                con.Close();
            }
            else if(comboBox2.Text != "" || comboBox4.Text != "")
            {
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ACER\Documents\SMS.mdf;Integrated Security=True;Connect Timeout=30");
                con.Open();
                SqlCommand cmd = new SqlCommand("select *from Homework where Class='" + comboBox4.Text + "' && Subject ='" + comboBox2.Text + "'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable DT = new DataTable();
                da.Fill(DT);
                dataGridView1.DataSource = DT;
                con.Close();
            }
            else
            {
                MessageBox.Show("Class and Subject Missing");
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
            comboBox4.Enabled = false;
            comboBox2.Enabled = false;

            this.Hide();
            NotificationDetails HD = new NotificationDetails();
            HD.label1.Text = this.dataGridView1.CurrentRow.Cells[2].Value.ToString();
            HD.ShowDialog();
        }

        private void homeWorkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            comboBox4.Enabled = true;
            comboBox2.Enabled = true;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            this.Hide();
            HomeworkDetails HD = new HomeworkDetails();
            HD.label5.Text = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
            HD.label6.Text = this.dataGridView1.CurrentRow.Cells[2].Value.ToString();
            HD.label7.Text = this.dataGridView1.CurrentRow.Cells[4].Value.ToString();
            HD.label8.Text = this.dataGridView1.CurrentRow.Cells[3].Value.ToString();
            HD.ShowDialog();
        }
    }
}
