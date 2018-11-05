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
    public partial class TestResult : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ACER\Documents\SMS.mdf;Integrated Security=True;Connect Timeout=30");
        public TestResult()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlDataAdapter sda = new SqlDataAdapter("select distinct StudentId from StudentRegistration where Class='"+comboBox1.Text+"'",con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                comboBox3.Items.Add(dr["StudentId"].ToString());
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlDataAdapter sda = new SqlDataAdapter("select distinct FN,LN from StudentRegistration where StudentId='" + comboBox3.Text + "'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                textBox1.Text = (dr["FN"].ToString() + " " + dr["LN"].ToString());
            }
        }


        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            try
            {
                textBox4.Text = (float.Parse(textBox2.Text) / float.Parse(textBox3.Text) * 100).ToString();
            }
            catch
            {

            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            float num = Convert.ToInt16(textBox4.Text);
            try  
            {
                if( num <= 100 && num >= 80)
                {
                    textBox5.Text = "A+";
                }

                else if (num <= 79 && num >= 70)
                {
                    textBox5.Text = "A";
                }

                else if (num <= 69 && num >= 60)
                {
                    textBox5.Text = "B";
                }

                else if (num <= 59 && num >= 50)
                {
                    textBox5.Text = "C";
                }

                else if (num <= 49 && num >= 40)
                {
                    textBox5.Text = "D";
                }

                else if (num <= 39 && num >= 0)
                {
                    textBox5.Text = "Failed";
                }

                else
                { }
            }
            catch
            {

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox6.Text !="" && comboBox1.Text != "" && comboBox2.Text != "" && comboBox3.Text != "" && textBox1.Text != "" && textBox2.Text != "" && textBox4.Text != "" && textBox5.Text != "")
            {
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ACER\Documents\SMS.mdf;Integrated Security=True;Connect Timeout=30");
                con.Open();
                SqlCommand cmd = new SqlCommand("insert into TestResults(TId, Class, Subject, StudentID, Name, ObtainedMarks, TotalMarks, Grade) values('" + textBox6.Text + "', '" + comboBox1.Text + "', '" + comboBox2.Text + "', '" + comboBox3.Text + "', '" + textBox1.Text + "', '" + textBox2.Text + "', '" + textBox3.Text + "', '" + textBox4.Text + "', '" + textBox5.Text + "')", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                MessageBox.Show("DATA INSERTED SUCESSFULY");
                comboBox1.Text = ""; comboBox2.Text = ""; comboBox3.Text = ""; textBox1.Text = ""; textBox2.Text = ""; textBox3.Text = ""; textBox4.Text = ""; textBox5.Text = "";
            }
            else
            {
                MessageBox.Show("DATA INSERTION FAILED");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            TEACHER t = new TEACHER();
            t.ShowDialog();
        }

        string NId = "TId#";
        private void GC()
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ACER\Documents\SMS.mdf;Integrated Security=True;Connect Timeout=30");
            con.Open();
            SqlCommand cmd = new SqlCommand("select count(TId) from TestResults", con);
            int i = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();
            i++;
            textBox6.Text = NId + i.ToString();
        }

        private void TestResult_Load(object sender, EventArgs e)
        {
            GC();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ACER\Documents\SMS.mdf;Integrated Security=True;Connect Timeout=30");
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("Select *from TestResults", con);
            DataTable DT = new DataTable();
            da.Fill(DT);
            dataGridView1.DataSource = DT;
            con.Close();
        }
    }
}
