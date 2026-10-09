using DVLD.Global;
using DVLD.People;
using DVLD.Users;
using System;
using System.Drawing;
using System.Windows.Forms;
namespace DVLD
{
    public partial class frmMain : Form
    {



        frmListPeople PeopleForm;
        frmListUsers UsersForm;
        public delegate void DataBackEventHandler(object sender);

        // Declare an event using the delegate
        public event DataBackEventHandler DataBack;

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

        private void peopleToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (PeopleForm == null || PeopleForm.IsDisposed == true)
            {
                PeopleForm = new frmListPeople();
            }

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

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (UsersForm == null || UsersForm.IsDisposed == true)
            {
                UsersForm = new frmListUsers();
            }
            UsersForm.MdiParent = this;

            if (UsersForm.Visible)
                UsersForm.Hide();
            else
                UsersForm.Show();
        }

        private void signOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsGlobal.CurrentUser = null;

            DataBack.Invoke(sender);

        }

        private void currentUserInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShowUserInfo UserInfoCard = new frmShowUserInfo();

            UserInfoCard.LoadPersonInfo(clsGlobal.CurrentUser.PersonID);

            UserInfoCard.ShowDialog();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChangePassword ChangePasswordForm = new frmChangePassword();
            ChangePasswordForm.LoadUserInfo(clsGlobal.CurrentUser.UserID);
            ChangePasswordForm.ShowDialog();
        }
    }
}
