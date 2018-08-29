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
            if (studentIDTextBox.Text != "" && fisrtnameTextBox.Text != "" && lastnameTextBox.Text != "" && genderTextBox.Text != "" && dateofbithDateTimePicker.Text != "" && classTextBox.Text != "" && addressTextBox.Text != "" && mobileTextBox.Text != "" && fathernameTextBox.Text != "" && dateDateTimePicker.Text != "")
            {
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ACER\Documents\SMS.mdf;Integrated Security=True;Connect Timeout=30");
                con.Open();
                SqlCommand cmd = new SqlCommand("insert into StudentRegistration(StudentID, FN, LN, Gender, DOB, Class, Address, Mobile, FatherName, Date) values('" + studentIDTextBox.Text + "', '" + fisrtnameTextBox.Text + "', '" + lastnameTextBox.Text + "', '" + genderTextBox.Text + "', '" + dateofbithDateTimePicker.Text + "', '" + classTextBox.Text + "', '" + addressTextBox.Text + "', '" + mobileTextBox.Text + "', '" + fathernameTextBox.Text + "', '" + dateDateTimePicker.Text + "')", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                MessageBox.Show("DATA INSERTED SUCESSFULY");
                this.Hide();
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
            SqlCommand cmd = new SqlCommand("select count(StaffId) from StaffRegistration", con);
            int i = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();
            i++;
            studentIDTextBox.Text = NId + i.ToString();
        }

        private void StudentRegistration_Load(object sender, EventArgs e)
        {
            GC();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
