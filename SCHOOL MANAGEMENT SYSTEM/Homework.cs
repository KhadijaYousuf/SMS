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
    public partial class Homework : Form
    {
        public Homework()
        {
            InitializeComponent();
        }


        private void GC()
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ACER\Documents\SMS.mdf;Integrated Security=True;Connect Timeout=30");
            con.Open();
            SqlCommand cmd = new SqlCommand("select count(HomeWorkID) from Homework", con);
            int i = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();
            i++;
            textBox1.Text = HId + i.ToString();
        }

        string HId = "HW#";
        private void Homework_Load(object sender, EventArgs e)
        {
            GC();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ACER\Documents\SMS.mdf;Integrated Security=True;Connect Timeout=30");
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into Homework(HomeWorkID, Class, Subject, Date, Homework) values('" + textBox1.Text + "', '" + comboBox4.Text + "', '" + comboBox2.Text + "','" + dateTimePicker1.Text + "', '" + richTextBox1.Text + "')", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            MessageBox.Show("HOMEWORK UPDATED SUCCESSFULLY");
            GC();
            comboBox2.Text = ""; comboBox4.Text = ""; richTextBox1.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form TEACHER = new TEACHER();
            TEACHER.ShowDialog();
        }
    }
}
