using DVLD.Global;
using DVLD_Buisness;
using System.Windows.Forms;

namespace DVLD.Login
{
    public partial class frmLogin : Form
    {
        frmMain Mainform;


        // Declare an event using the delegate


        private clsUser _SignedInUser;


        public clsUser SignedInUser
        {
            get { return _SignedInUser; }

        }
        public frmLogin()
        {
            InitializeComponent();
        }

        private void txtUserName_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtUserName.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtUserName, "This field is required!");
                return;
            }
            else
            {
                errorProvider1.SetError(txtUserName, null);
            }

            //Make sure the Username is not used by another person
            if (!clsUser.DoesUserExistByUsername(txtUserName.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtUserName, "Username Isn't Correct!");

            }
            else
            {
                errorProvider1.SetError(txtUserName, null);
            }
        }

        private void txtPassword_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtUserName.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtUserName, "This field is required!");
                return;
            }
            else
            {
                errorProvider1.SetError(txtUserName, null);
            }
        }

        private void btnLogin_Click(object sender, System.EventArgs e)
        {
            if (this.ValidateChildren())
            {
                clsUser tempUser;

                if ((tempUser = clsUser.FindUserByUsername(txtUserName.Text)) == null)
                    MessageBox.Show("Username Is incorrect !");

                else
                    if (tempUser.Password != txtPassword.Text)
                        MessageBox.Show("Password Is incorrect !");
                    else
                    {
                        clsGlobal.CurrentUser = tempUser;

                        MessageBox.Show("You Have Signed In Correctly !");


                        Mainform = new frmMain();

                        Mainform.DataBack += DataBackEvent;
                        Mainform.ShowDialog();

                    }

            }

        }

        private void DataBackEvent(object sender)
        {
            Mainform.Dispose();
            txtPassword.Text = null;
            txtUserName.Text = null;

        }
    }
}
