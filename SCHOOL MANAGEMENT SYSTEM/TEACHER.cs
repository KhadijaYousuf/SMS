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
    public partial class TEACHER : Form
    {
        public TEACHER()
        {
            InitializeComponent();
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form user = new User();
            user.ShowDialog();
        }

        private void notepadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("wordpad.exe");
        }

        private void calculatorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("calc.exe");
        }

        private void TEACHER_Load(object sender, EventArgs e)
        {
            
        }

        private void updateHomeworkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form user = new Homework();
            user.ShowDialog();
        }

        private void newResultToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            TestResult tr = new TestResult();
            tr.ShowDialog();
        }
    }
}
