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
    public partial class StudentRegistration : Form
    {
        public StudentRegistration()
        {
            InitializeComponent();
        }

        private void sev_Click(object sender, EventArgs e)
        {
            if (studentIDTextBox.Text != "" && fisrtnameTextBox.Text != "" && lastnameTextBox.Text != "" && comboBox1.Text != "" && dateofbithDateTimePicker.Text != "" && comboBox4.Text != "" && addressTextBox.Text != "" && mobileTextBox.Text != "" && fathernameTextBox.Text != "" && dateDateTimePicker.Text != "" && textBox1.Text!="" && textBox2.Text != "")
            {
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ACER\Documents\SMS.mdf;Integrated Security=True;Connect Timeout=30");
                con.Open();
                SqlCommand cmd = new SqlCommand("insert into StudentRegistration(StudentID, FN, LN, Gender, DOB, Class, Address, Mobile, FatherName, Date, Username, Password) values('" + studentIDTextBox.Text + "', '" + fisrtnameTextBox.Text + "', '" + lastnameTextBox.Text + "', '" + comboBox1.Text + "', '" + dateofbithDateTimePicker.Text + "', '" + comboBox4.Text + "', '" + addressTextBox.Text + "', '" + mobileTextBox.Text + "', '" + fathernameTextBox.Text + "', '" + dateDateTimePicker.Text + "' , '" + textBox1.Text + "' , '" + textBox2.Text + "')", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                MessageBox.Show("DATA INSERTED SUCESSFULY");
                studentIDTextBox.Text = ""; fisrtnameTextBox.Text = ""; lastnameTextBox.Text = ""; comboBox1.Text = ""; dateofbithDateTimePicker.Text = ""; comboBox4.Text = ""; addressTextBox.Text = ""; mobileTextBox.Text = ""; fathernameTextBox.Text = ""; dateDateTimePicker.Text = ""; textBox1.Text = ""; textBox2.Text = "";
            }
            else
            {
                MessageBox.Show("DATA INSERTION FAILED");
            }
        }

        private void clr_Click(object sender, EventArgs e)
        {

        }

        string NId = "STId#";
        private void GC()
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ACER\Documents\SMS.mdf;Integrated Security=True;Connect Timeout=30");
            con.Open();
            SqlCommand cmd = new SqlCommand("select count(StudentId) from StudentRegistration", con);
            int i = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();
            i++;
            studentIDTextBox.Text = NId + i.ToString();
            textBox1.Text = NId + i.ToString();
        }

        private void GC1()
        {
            Random r = new Random();
            int random = r.Next(100000, 9900000);
            textBox2.Text = random.ToString();
        }

        private void StudentRegistration_Load(object sender, EventArgs e)
        {
            GC();
            GC1();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
