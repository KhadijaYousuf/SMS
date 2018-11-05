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
    public partial class StaffRegistration : Form
    {
        public StaffRegistration()
        {
            InitializeComponent();
        }

        private void enter_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && staffname.Text != "" && comboBox1.Text != "" && comboBox2.Text != "" && comboBox3.Text != "" && comboBox4.Text != "" && comboBox5.Text != "" && username.Text != "" && passw.Text != "")
            {
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ACER\Documents\SMS.mdf;Integrated Security=True;Connect Timeout=30");
                con.Open();
                SqlCommand cmd = new SqlCommand("insert into StaffRegistration(StaffID, Name, Gender, Subjects, Role, Username, Password, Status, Class) values('" + textBox1.Text + "', '" + staffname.Text + "', '" + comboBox1.Text + "', '" + comboBox2.Text + "', '" + comboBox3.Text + "', '" + comboBox5.Text + "', '" + comboBox4.Text + "', '" + username.Text + "', '" + passw.Text + "')", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                MessageBox.Show("DATA INSERTED SUCESSFULY");
                textBox1.Text = ""; staffname.Text = ""; comboBox1.Text = ""; comboBox2.Text = ""; comboBox3.Text = ""; comboBox4.Text = ""; comboBox5.Text = ""; username.Text = ""; passw.Text = "";
            }
            else
            {
                MessageBox.Show("DATA INSERTION FAILED");
            }
        }

        string NId = "SFId#";
        private void GC()
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ACER\Documents\SMS.mdf;Integrated Security=True;Connect Timeout=30");
            con.Open();
            SqlCommand cmd = new SqlCommand("select count(StaffId) from StaffRegistration", con);
            int i = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();
            i++;
            textBox1.Text = NId + i.ToString();
            username.Text = NId + i.ToString();
        }
    
        private void GC1()
        {
            Random r = new Random();
            int random = r.Next(10000000, 990000000);
            passw.Text = random.ToString();
        }

        private void StaffRegistration_Load(object sender, EventArgs e)
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
