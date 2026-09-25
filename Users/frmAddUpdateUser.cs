using DVLD_Buisness;
using System;
using System.Windows.Forms;

namespace DVLD.Users
{
    public partial class frmAddUpdateUser : Form
    {

        // Declare a delegate
        public delegate void DataBackEventHandler(object sender, int PersonID);

        // Declare an event using the delegate
        public event DataBackEventHandler DataBack;

        public enum enMode { AddNew = 0, Update = 1 };

        private enMode _Mode;
        private int _UserID = -1;
        private clsUser _User;
        public frmAddUpdateUser()
        {
            InitializeComponent();
            _Mode = enMode.AddNew;
        }

        public frmAddUpdateUser(int UserID)
        {
            InitializeComponent();

            if ((_User = clsUser.FindUserByUserID(UserID)) != null)
            {
                _UserID = _User.UserID;
                _Mode = enMode.Update;
                lblUserID.Text = UserID.ToString();
                lblTitle.Text = "Update User";
                txtUserName.Text = _User.Username;
                txtPassword.Text = _User.Password;
                txtConfirmPassword.Text = _User.Password;
                chkIsActive.Checked = _User.IsActive;
                ctrlPersonCardWithFilter1.LoadPersonInfo(_User.PersonID);
            }
            else
            {
                MessageBox.Show("Couldn't Find User !");
            }


        }



        private void btnClose_Click(object sender, EventArgs e)
        {
            // Trigger the event to send data back to the caller form.
            DataBack?.Invoke(this, _UserID);
        }

        private void selectedPersonChanged(int PersonID)
        {
            if (_Mode == enMode.AddNew && clsUser.DoesUserExistByPersonID(PersonID))
            {
                errorProvider1.SetError(nextBtn, "This Person Already is a User");
                nextBtn.Enabled = false;
            }
            if (PersonID == -1)
            {
                errorProvider1.SetError(nextBtn, "This Person Doesn't Exist");
                nextBtn.Enabled = false;
            }
            else
            {
                errorProvider1.SetError(nextBtn, null);
                nextBtn.Enabled = true;
            }
        }

        private void nextBtn_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage2;
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
            if (_Mode == enMode.AddNew && clsUser.DoesUserExistByUsername(txtUserName.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtUserName, "Username is used by another person!");

            }
            else
            {
                errorProvider1.SetError(txtUserName, null);
            }

        }

        private void txtPassword_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {


            if (string.IsNullOrEmpty(txtPassword.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtPassword, "This field is required!");
                return;
            }
            else
            {
                errorProvider1.SetError(txtPassword, null);
            }


        }
        private void txtConfirmPassword_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtConfirmPassword.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtConfirmPassword, "This field is required!");
                return;
            }
            else
            {
                errorProvider1.SetError(txtConfirmPassword, null);
            }

            if (txtConfirmPassword.Text != txtPassword.Text)
            {
                e.Cancel = true;
                errorProvider1.SetError(txtConfirmPassword, "passwords don't match!");
                return;
            }
            else
            {
                errorProvider1.SetError(txtConfirmPassword, null);
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren())
            {

                if (_Mode == enMode.AddNew)
                {
                    int UserID = clsUser.AddUser(ctrlPersonCardWithFilter1.PersonID,
                        txtUserName.Text.Trim(), txtPassword.Text, chkIsActive.Checked);

                    if (UserID == -1)
                    {
                        MessageBox.Show("Couldn't Create User !");
                    }
                    else
                    {


                        MessageBox.Show("Added a new User !");
                        _UserID = UserID;
                        _Mode = enMode.Update;
                        lblUserID.Text = UserID.ToString();
                        lblTitle.Text = "Update User";

                    }

                }
                else
                {
                    if (clsUser.UpdateUser(_UserID, ctrlPersonCardWithFilter1.PersonID,
                          txtUserName.Text.Trim(), txtPassword.Text, chkIsActive.Checked))
                    {
                        MessageBox.Show("Updated User Succefully !");
                    }
                    else
                    {
                        MessageBox.Show("Failed to Update User !");
                    }
                }


            }
            else
            {
                MessageBox.Show("Make Sure Info Is Correct !");
            }


        }

        private void ChoosePerson(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (ctrlPersonCardWithFilter1.PersonID == -1)
            {

                e.Cancel = true;
                errorProvider1.SetError(nextBtn, "You Haven't Selected A Person");
                return;
            }
            else
            {
                errorProvider1.SetError(nextBtn, null);
            }


            if (_Mode == enMode.AddNew && clsUser.DoesUserExistByPersonID(ctrlPersonCardWithFilter1.PersonID))
            {

                e.Cancel = true;
                errorProvider1.SetError(nextBtn, "This Person Already is a User");
                return;
            }
            else
            {
                errorProvider1.SetError(nextBtn, null);
            }


        }
    }
}
