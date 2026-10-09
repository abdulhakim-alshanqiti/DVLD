using DVLD.Global;
using DVLD_Buisness;
using System.Windows.Forms;

namespace DVLD.Login
{
    public partial class frmLogin : Form
    {
        frmMain Mainform;


        // Declare an event using the delegate



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
                clsUser tempUser = clsUser.FindUserByUsername(txtUserName.Text);

                if (tempUser == null) MessageBox.Show("Username Is incorrect !");
                else if (!tempUser.IsActive) MessageBox.Show("User Account isn't active !");
                else if (tempUser.Password != txtPassword.Text) MessageBox.Show("Password Is incorrect !");
                else
                {
                    clsGlobal.CurrentUser = tempUser;

                    MessageBox.Show("You Have Signed In Correctly !");


                    Mainform = new frmMain();

                    Mainform.DataBack += DataBackEvent;
                    Mainform.FormClosed += DataBackEvent;
                    Mainform.ShowDialog();

                }

            }

        }
        private void BtnClose_Click(object sender, System.EventArgs e) => this.Close();

        private void _closeMainForm()
        {
            Mainform.Dispose();
            txtPassword.Text = null;
            txtUserName.Text = null;
        }
        private void DataBackEvent(object sender, FormClosedEventArgs e) => _closeMainForm();


        private void DataBackEvent(object sender) => _closeMainForm();


    }
}
