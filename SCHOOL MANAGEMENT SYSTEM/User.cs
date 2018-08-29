using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Data.SqlClient;

namespace SCHOOL_MANAGEMENT_SYSTEM
{
    public partial class User : Form
    {
        public User()
        {
            Thread t = new Thread(new ThreadStart(SplashStart));
            t.Start();
            Thread.Sleep(1000);

            InitializeComponent();

            t.Abort();
        }

        public void SplashStart()
        {
            Application.Run(new SplashScreen());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form STUDENT = new STUDENT();
            STUDENT.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            panel2.Visible = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if(textBox1.Text== "Admin"&&textBox2.Text=="admin")
            {
                this.Hide();
                Form ADMIN = new ADMIN();
                ADMIN.ShowDialog();
            }
            else
            {
                MessageBox.Show("Wrong username or password");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel2.Visible = true;
            panel1.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form PARENTS = new PARENTS();
            PARENTS.ShowDialog();
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            if (textBox4.Text == "" || textBox3.Text == "")
            {
                MessageBox.Show("Enter Username and Password");
            }
            else
            {
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ACER\Documents\SMS.mdf;Integrated Security=True;Connect Timeout=30");
                con.Open();
                SqlCommand cmd = new SqlCommand("select count(*) from StaffRegistration where Username ='" + textBox3.Text + "' and Password ='" + textBox4.Text + "'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                this.Hide();
                Form TEACHER = new TEACHER();
                TEACHER.ShowDialog();
            }
        }
    }
}
