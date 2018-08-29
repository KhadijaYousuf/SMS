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
    public partial class ADMIN : Form
    {
        public ADMIN()
        {
            InitializeComponent();
        }

        private void newRegistrationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form NR = new StudentRegistration();
            NR.ShowDialog();
        }

        private void staffRegistrationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form SR = new StaffRegistration();
            SR.ShowDialog();
        }

        private void feesManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Form FM = new FeesManagement();
            FM.ShowDialog();
        }


        private void updateProfileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form UpdateProfile = new UpdateProfile();
            UpdateProfile.ShowDialog();
        }



        private void viewToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void updateStaffToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form UpdateStaff = new UpdateStaff();
            UpdateStaff.ShowDialog();
        }

        private void studentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form RegisteredStudents = new RegisteredStudents();
            RegisteredStudents.ShowDialog();
        }

        private void feesListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form FeesList = new FeesList();
            FeesList.ShowDialog();
        }

        private void staffListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form StaffList = new StaffList();
            StaffList.ShowDialog();
        }

        private void notepadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("wordpad.exe");
        }

        private void calculatorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("calc.exe");
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form user = new User();
            user.ShowDialog();
        }

        private void updateNotificationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form Notice = new Notification();
            Notice.ShowDialog();
        }

        private void ADMIN_Load(object sender, EventArgs e)
        {
        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}