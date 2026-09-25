using DVLD.People;
using DVLD.Users;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace DVLD
{
    public partial class frmMain : Form
    {
        Form PeopleForm = new frmListPeople();
        Form UsersForm = new frmListUsers();
        public frmMain()
        {
            InitializeComponent();
        }


        private void frmMain_Paint(object sender, PaintEventArgs e)
        {
            foreach (Control c in this.Controls)
            {
                if (c is MdiClient mdiClient)
                {
                    mdiClient.BackColor = Color.FromArgb(82, 152, 241);
                    break;
                }
            }
        }

        private void peopleToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            PeopleForm.MdiParent = this;

            if (PeopleForm.Visible)
                PeopleForm.Hide();
            else
                PeopleForm.Show();
        }

        private void applicationToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            UsersForm.MdiParent = this;

            if (UsersForm.Visible)
                UsersForm.Hide();
            else
                UsersForm.Show();
        }
    }
}
