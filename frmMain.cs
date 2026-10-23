using DVLD.Applications;
using DVLD.Global;
using DVLD.LocalDrivingLicenseApplication;
using DVLD.Login;
using DVLD.People;
using DVLD.Tests;
using DVLD.User;
using DVLD.Users;
using System;
using System.Drawing;
using System.Windows.Forms;
namespace DVLD
{
    public partial class frmMain : Form
    {

        frmLogin _frmLogin;

        public delegate void DataBackEventHandler(object sender);

        // Declare an event using the delegate
        public event DataBackEventHandler DataBack;

        public frmMain(Login.frmLogin frm)
        {


            InitializeComponent();

            _frmLogin = frm;
        }




        private void peopleToolStripMenuItem_Click(object sender, EventArgs e)
        {

            frmListPeople PeopleForm = new frmListPeople()
            ;

            PeopleForm.ShowDialog();
        }
        private void frmMain_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.White;
            //lblLoggedInUser.Text = "LoggedIn User: " + clsGlobal.CurrentUser.UserName;
            this.Refresh();

        }
        private void applicationToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {

        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {

            frmListUsers UsersForm = new frmListUsers()
            ;



            UsersForm.ShowDialog();
        }

        private void signOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsGlobal.CurrentUser = null;
            _frmLogin.Show();
            this.Close();

        }


        private void currentUserInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShowUserInfo UserInfoCard = new frmShowUserInfo(clsGlobal.CurrentUser.UserID)
            ;

            UserInfoCard.ShowDialog();

        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChangePassword ChangePasswordForm = new frmChangePassword(clsGlobal.CurrentUser.UserID)
            ;
            ChangePasswordForm.ShowDialog();
        }

        private void manageApplicationTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListApplicationTypes ApplicationTypesForm = new frmListApplicationTypes();
            ApplicationTypesForm.ShowDialog();
        }

        private void manageTestTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListTestTypes TestTypesForm = new frmListTestTypes();
            TestTypesForm.ShowDialog();
        }

        private void FormClosed_MainForm(object sender, FormClosedEventArgs e)
        {
            _frmLogin.Close();
        }

        private void newLocalDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddUpdateLocalDrivingLicenseApplication NewLocalDrivingLicense = new frmAddUpdateLocalDrivingLicenseApplication();
            NewLocalDrivingLicense.ShowDialog();
        }

        private void localDrivingLicenseApplicationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListLocalDrivingLicenseApplications ListLocalDrivingLicenseApplications = new frmListLocalDrivingLicenseApplications();
            ListLocalDrivingLicenseApplications.ShowDialog();
        }
    }
}
