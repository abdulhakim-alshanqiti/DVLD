using DVLD.Global;
using DVLD_Buisness;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace DVLD.Users
{
    public partial class frmChangePassword : Form
    {
        public frmChangePassword()
        {
            InitializeComponent();
        }

        private void CurrentPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtCurrentPassword.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtCurrentPassword, "This field is required!");
            }
            else if (clsGlobal.CurrentUser.Password != txtCurrentPassword.Text)
            {
                e.Cancel = true;
                errorProvider1.SetError(txtCurrentPassword, "The Password Isn't Correct!");

            }
            else
            {
                //e.Cancel = false;
                errorProvider1.SetError(txtCurrentPassword, null);
            }
        }

        private void NewPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtNewPassword.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtNewPassword, "This field is required!");
            }
            else if (clsGlobal.CurrentUser.Password == txtNewPassword.Text)
            {
                e.Cancel = true;
                errorProvider1.SetError(txtNewPassword, "The Password Is The Same as the Old Password!");

            }
            else
            {
                //e.Cancel = false;
                errorProvider1.SetError(txtNewPassword, null);
            }
        }

        private void ConfirmPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtConfirmPassword.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtConfirmPassword, "This field is required!");
            }
            else if (clsGlobal.CurrentUser.Password == txtConfirmPassword.Text)
            {
                e.Cancel = true;
                errorProvider1.SetError(txtConfirmPassword, "The Password Is The Same as the Old Password!");

            }
            else if (txtConfirmPassword.Text != txtNewPassword.Text)
            {
                e.Cancel = true;
                errorProvider1.SetError(txtConfirmPassword, "The Passwords Don't Match!");

            }
            else
            {
                //e.Cancel = false;
                errorProvider1.SetError(txtConfirmPassword, null);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.ValidateChildren();
            if (clsUser.UpdateUser(

                clsGlobal.CurrentUser.UserID,
                clsGlobal.CurrentUser.PersonID,
                clsGlobal.CurrentUser.Username,
                txtNewPassword.Text,
                clsGlobal.CurrentUser.IsActive


            ))
            {
                MessageBox.Show("User Password Updated Successfully");
                clsGlobal.CurrentUser.Password = txtNewPassword.Text;
            }
            else
                MessageBox.Show("Couldn't Update The User Successfully");
        }

        internal void LoadPersonInfo(int personID)
        {
            ctrlUserInfoCard1.LoadPersonInfo(personID);
        }
        internal void LoadUserInfo(int UserID)
        {
            ctrlUserInfoCard1.LoadUserInfo(UserID);
        }
    }
}
