using DVLD.Global;
using DVLD_Business;
using System;
using System.Data;
using System.Windows.Forms;

namespace DVLD.LocalDrivingLicenseApplication
{
    public partial class frmAddUpdateLocalDrivingLicenseApplication : Form
    {

        public enum enMode { AddNew = 0, Update = 1 };
        private enMode _Mode;
        private int _LocalDrivingLicenseApplicationID = -1;
        clsLocalDrivingLicenseApplication _LocalDrivingLicenseApplication;

        public frmAddUpdateLocalDrivingLicenseApplication()
        {
            InitializeComponent();

            _Mode = enMode.AddNew;
        }

        public frmAddUpdateLocalDrivingLicenseApplication(int LocalDrivingLicenseApplicationID)
        {
            InitializeComponent();

            _Mode = enMode.Update;
            _LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
        }

        private void _FillLicenseClassesInComoboBox()
        {
            DataTable dtLicenseClasses = clsLicenseClass.GetAllLicenseClasses();

            foreach (DataRow row in dtLicenseClasses.Rows)
            {
                cbLicenseClasses.Items.Add(row["ClassName"]);
            }
        }


        private void _ResetDefualtValues()
        {
            //this will initialize the reset the defaule values
            _FillLicenseClassesInComoboBox();


            if (_Mode == enMode.AddNew)
            {
                lblTitle.Text = "Add New Local Driving License Application";
                this.Text = "Add New Local Driving License Application";
                _LocalDrivingLicenseApplication = new clsLocalDrivingLicenseApplication();


                tpApplicationInfo.Enabled = false;

                ctrlPersonCardWithFilter1.FilterFocus();
            }
            else
            {
                lblTitle.Text = "Update Local Driving License Application";
                this.Text = "Update Local Driving License Application";

                tpApplicationInfo.Enabled = true;
                btnSave.Enabled = true;


            }




        }

        private void _LoadData()
        {

            _LocalDrivingLicenseApplication = clsLocalDrivingLicenseApplication.FindLocalDrivingLicenseApplicationByApplicationID(_LocalDrivingLicenseApplicationID);
            ctrlPersonCardWithFilter1.FilterEnabled = false;

            if (_LocalDrivingLicenseApplication == null)
            {
                MessageBox.Show("No LocalDrivingLicenseApplication with ID = " + _LocalDrivingLicenseApplication, "LocalDrivingLicenseApplication Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();

                return;
            }

            //the following code will not be executed if the person was not found
            lblLocalDrivingLicenseApplicationID.Text = _LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID.ToString();

            //txtLocalDrivingLicenseApplicationname.Text = _LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationname;
            //txtPassword.Text = _LocalDrivingLicenseApplication.Password;
            //txtConfirmPassword.Text = _LocalDrivingLicenseApplication.Password;
            //chkIsActive.Checked = _LocalDrivingLicenseApplication.IsActive;
            //ctrlPersonCardWithFilter1.LoadPersonInfo(_LocalDrivingLicenseApplication.PersonID);
        }

        private void frmNewLocalDrivingLicense_Load(object sender, EventArgs e)
        {


            _ResetDefualtValues();

            if (_Mode == enMode.Update)
                _LoadData();

        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            if (!this.ValidateChildren())
            {
                //Here we dont continue becuase the form is not valid
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            //_LocalDrivingLicenseApplication.PersonID = ctrlPersonCardWithFilter1.PersonID;
            //_LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationname = txtLocalDrivingLicenseApplicationname.Text.Trim();
            //_LocalDrivingLicenseApplication.Password = txtPassword.Text.Trim();
            //_LocalDrivingLicenseApplication.IsActive = chkIsActive.Checked;

            if (clsLocalDrivingLicenseApplication.DoesPersonHaveActiveApplication(_LocalDrivingLicenseApplication.ApplicantPersonID, _LocalDrivingLicenseApplication.LicenseClassID))
            {
                //Here we dont continue becuase the form is not valid
                MessageBox.Show("Person Already Has An Active Application For This Class Of Driving Licenses",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }
            if (_LocalDrivingLicenseApplication.Save(clsGlobal.CurrentUser.UserID))
            {

                lblLocalDrivingLicenseApplicationID.Text = _LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID.ToString();
                lblApplicationDate.Text = _LocalDrivingLicenseApplication.ApplicationDate.ToLongDateString();
                //change form mode to update.
                _Mode = enMode.Update;
                lblTitle.Text = "Update LocalDrivingLicenseApplication";
                this.Text = "Update LocalDrivingLicenseApplication";

                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }



        private void btnPersonInfoNext_Click(object sender, EventArgs e)
        {
            if (_Mode == enMode.Update)
            {
                btnSave.Enabled = true;
                tpApplicationInfo.Enabled = true;
                tcLocalDrivingLicenseApplicationInfo.SelectedTab = tcLocalDrivingLicenseApplicationInfo.TabPages["tpApplicationInfo"];
                return;
            }

            //incase of add new mode.
            if (ctrlPersonCardWithFilter1.PersonID != -1)
            {
                _LocalDrivingLicenseApplication.ApplicantPersonID = ctrlPersonCardWithFilter1.PersonID;


                btnSave.Enabled = true;
                tpApplicationInfo.Enabled = true;
                tcLocalDrivingLicenseApplicationInfo.SelectedTab = tcLocalDrivingLicenseApplicationInfo.TabPages["tpApplicationInfo"];
            }

            else

            {
                MessageBox.Show("Please Select a Person", "Select a Person", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ctrlPersonCardWithFilter1.FilterFocus();

            }

        }


        private void frmNewLocalDrivingLicense_Activated(object sender, EventArgs e)
        {
            ctrlPersonCardWithFilter1.FilterFocus();
        }

        private void cbLicenseClasses_IndexChanged(object sender, EventArgs e)
        {
            string ClassName = cbLicenseClasses.Text;

            clsLicenseClass licenseClass = clsLicenseClass.FindLicenseClassByClassName(ClassName);

            if (licenseClass != null)
            {
                _LocalDrivingLicenseApplication.LicenseClassID = licenseClass.ID;

            }

        }
    }
}
