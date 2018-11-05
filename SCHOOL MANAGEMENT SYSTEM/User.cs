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
            panel1.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Administrator")
            {
                if (textBox1.Text == "Admin" && textBox2.Text == "admin")
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

            else if (comboBox1.Text == "Staff")
            {
                if (textBox1.Text == "" || textBox2.Text == "")
                {
                    MessageBox.Show("Enter Username and Password");
                }
                else
                {
                    if (textBox1.Text == "" || textBox2.Text == "")
                    {
                        MessageBox.Show("Enter Username and Password");
                    }
                    else
                    {
                        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ACER\Documents\SMS.mdf;Integrated Security=True;Connect Timeout=30");
                        con.Open();
                        SqlCommand cmd = new SqlCommand("select count(*) from StaffRegistration where Username ='" + textBox1.Text + "' and Password ='" + textBox2.Text + "'", con);
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        this.Hide();
                        Form TEACHER = new TEACHER();
                        TEACHER.ShowDialog();
                    }
                }
            }

            else if (comboBox1.Text == "Staff")
            {
                if (textBox1.Text == "" || textBox2.Text == "")
                {
                    MessageBox.Show("Enter Username and Password");
                }
                else
                {
                    SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ACER\Documents\SMS.mdf;Integrated Security=True;Connect Timeout=30");
                    con.Open();
                    SqlCommand cmd = new SqlCommand("select count(*) from StudentRegistration where Username ='" + textBox1.Text + "' and Password ='" + textBox2.Text + "'", con);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    this.Hide();
                    Form STUDENT = new STUDENT();
                    STUDENT.ShowDialog();
                }
            }

            else
            {
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // for spreading form           
            int width = 364;
            while (width <= 390)
            {
                this.Size = new Size(width, 390);
                this.Refresh();
                this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
                this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
                this.SetStyle(ControlStyles.UserPaint, true);
                Thread.Sleep(10);
                width += 10;
            }

            if (comboBox1.Text == "Administrator")
            {
                panel1.Show();
                label2.Text = "*Please enter Username and Password";
            }
            else if (comboBox1.Text == "Staff")
            {
                panel1.Show();
                label2.Text = "*Please enter Username and Password";
            }
            else if (comboBox1.Text == "Student")
            {
                panel1.Show();
                label2.Text = "*Please enter Username and Password";
            }

            else 
            {
                panel1.Hide();
                this.Hide();
                Form PARENTS = new PARENTS();
                PARENTS.ShowDialog();
            }
        }

        private void User_Load(object sender, EventArgs e)
        {
            this.Size = new Size(272, 231); 
            panel1.Hide();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
