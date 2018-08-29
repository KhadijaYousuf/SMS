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
    public partial class PARENTS : Form
    {
        public PARENTS()
        {
            InitializeComponent();
        }

        string SId = "SId#";
        private void PARENTS_Load(object sender, EventArgs e)
        {

        }

        private void GId()
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ACER\Documents\SMS.mdf;Integrated Security=True;Connect Timeout=30");
            con.Open();
            SqlCommand cmd = new SqlCommand("select count(SID) from FeesAdmin", con);
            int i = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();
            i++;
            textBox1.Text = SId + i.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ACER\Documents\SMS.mdf;Integrated Security=True;Connect Timeout=30");
                con.Open();
                SqlCommand cmd = new SqlCommand("select *from FeesAdmin where SID='" + textBox1.Text + "'", con);
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

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form User = new User();
            User.ShowDialog();
        }
    }
}
