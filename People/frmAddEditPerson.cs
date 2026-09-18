using clsCountryBusinessLayer;
using DVLD.Classes;
using DVLD_Business;
using People.Properties;
using System;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Windows.Forms;


namespace DVLD.People
{

    public partial class frmAddUpdatePerson : Form
    {

        public delegate void DataBackEventHandler(object sender, int PersonID);
        public event DataBackEventHandler DataBack;
        public enum enMode { AddNew = 0, Update = 1 };
        public enum enGender { Male = 0, Female = 1 };

        private enMode _Mode;
        private int _PersonID = -1;
        clsPerson _Person;

        public frmAddUpdatePerson()
        {
            InitializeComponent();
            _Mode = enMode.AddNew;

        }
        public frmAddUpdatePerson(int PersonID)
        {
            InitializeComponent();

            _PersonID = PersonID;
            _Mode = enMode.Update;
        }
        private void _ResetDefaultValues()
        {
            _FillCountriesInComoboBox();

            if (_Mode == enMode.AddNew)
            {
                lblMode.Text = "Add New Person";
                _Person = new clsPerson();

            }
            else lblMode.Text = "Update Person";

            pbPersonImage.Image = rbMale.Checked ? Resources.male : Resources.female;

            llRemoveImage.Visible = (pbPersonImage.ImageLocation != null);

            dtpDateOfBirth.MaxDate = DateTime.Now.AddYears(-18);
            dtpDateOfBirth.Value = dtpDateOfBirth.MaxDate;

            dtpDateOfBirth.MinDate = DateTime.Now.AddYears(-100);

            cbCountry.SelectedIndex = cbCountry.FindString("Saudi Arabia");


            lblPersonID.Text = "";
            txtFirstName.Text = "";
            txtSecondName.Text = "";
            txtThirdName.Text = "";
            txtLastName.Text = "";
            txtEmail.Text = "";
            txtPhone.Text = "";
            txtAddress.Text = "";
            txtNationalNo.Text = "";
            rbMale.Checked = true;


        }
        private void _FillCountriesInComoboBox()
        {
            DataTable dtCountries = clsCountry.GetAllCountries();


            foreach (DataRow row in dtCountries.Rows)
            {

                cbCountry.Items.Add(row["CountryName"]);

            }
        }

        private void _LoadData()
        {

            _Person = clsPerson.Find(_PersonID);

            if (_Person == null)
            {
                MessageBox.Show("No Person with ID = " + _PersonID, "Person Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
                return;
            }


            lblPersonID.Text = _PersonID.ToString();
            txtFirstName.Text = _Person.FirstName;
            txtSecondName.Text = _Person.SecondName;
            txtThirdName.Text = _Person.ThirdName;
            txtLastName.Text = _Person.LastName;
            txtNationalNo.Text = _Person.NationalNo;
            dtpDateOfBirth.Value = _Person.DateOfBirth;

            if (_Person.Gender == 0)
                rbMale.Checked = true;
            else
                rbFemale.Checked = true;

            txtEmail.Text = _Person.Email;
            txtPhone.Text = _Person.Phone;
            txtAddress.Text = _Person.Address;
            cbCountry.SelectedIndex = cbCountry.FindString(_Person.CountryInfo.CountryName);






            if (_Person.ImagePath != "")
                pbPersonImage.ImageLocation = _Person.ImagePath;

            llRemoveImage.Visible = (_Person.ImagePath != "");



        }


        private void frmAddUpdatePerson_Load(object sender, EventArgs e)
        {
            _ResetDefaultValues();
            if (_Mode == enMode.Update)
                _LoadData();
        }

        private bool _HandlePersonImage()
        {

            //this procedure will handle the person image,
            //it will take care of deleting the old image from the folder
            //in case the image changed. and it will rename the new image with guid and 
            // place it in the images folder.


            //_Person.ImagePath contains the old Image, we check if it changed then we copy the new image
            if (_Person.ImagePath != pbPersonImage.ImageLocation)
            {
                if (_Person.ImagePath != "")
                {
                    //first we delete the old image from the folder in case there is any.

                    try
                    {
                        File.Delete(_Person.ImagePath);
                    }
                    catch (IOException)
                    {
                        // We could not delete the file.
                        //log it later   
                    }
                }

                if (pbPersonImage.ImageLocation != null)
                {
                    //then we copy the new image to the image folder after we rename it
                    string SourceImageFile = pbPersonImage.ImageLocation.ToString();

                    if (clsUtils.CopyImageToProjectImagesFolder(ref SourceImageFile))
                    {
                        pbPersonImage.ImageLocation = SourceImageFile;
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Error Copying Image File", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }

            }
            return true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            ;
            if (!_HandlePersonImage())
                return;

            int NationalityCountryID = clsCountry.Find(cbCountry.Text).ID;
            _Person.NationalityCountryID = NationalityCountryID;

            _Person.NationalNo = txtNationalNo.Text.Trim();
            _Person.FirstName = txtFirstName.Text.Trim();
            _Person.SecondName = txtSecondName.Text.Trim();
            _Person.ThirdName = txtThirdName.Text.Trim();
            _Person.LastName = txtLastName.Text.Trim();
            _Person.Email = txtEmail.Text.Trim();
            _Person.Phone = txtPhone.Text.Trim();
            _Person.Address = txtAddress.Text.Trim();
            _Person.DateOfBirth = dtpDateOfBirth.Value;

            _Person.Gender = rbMale.Checked ? (byte)enGender.Male : (byte)enGender.Female;


            if (pbPersonImage.ImageLocation != null)
                _Person.ImagePath = pbPersonImage.ImageLocation;
            else
                _Person.ImagePath = "";


            if (_Person.Save())
            {
                lblPersonID.Text = _Person.PersonID.ToString();
                _Mode = enMode.Update;
                lblMode.Text = "Update Person";
                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

                DataBack?.Invoke(this, _Person.PersonID);
            }
            else
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);


        }

        private void llSetImage_LinkClicked(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {

                string selectedFilePath = openFileDialog1.FileName;
                pbPersonImage.Load(selectedFilePath);
                llRemoveImage.Visible = true;

            }
        }
        private void llRemoveImage_LinkClicked(object sender, EventArgs e)
        {

            pbPersonImage.ImageLocation = null;

            pbPersonImage.Image = rbMale.Checked ?
                   Resources.male : Resources.female;


            llRemoveImage.Visible = false;


        }

        private void ValidateEmptyTextBox(object sender, CancelEventArgs e)
        {
            TextBox Temp = (TextBox)sender;

            if (string.IsNullOrWhiteSpace(Temp.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(Temp, "This Field Is Required !");

            }
            else errorProvider1.SetError(Temp, null);


        }

        private void txtEmailValidating(object sender, CancelEventArgs e)
        {
            TextBox Temp = (TextBox)sender;

            if (string.IsNullOrWhiteSpace(Temp.Text.Trim())) return;


            if (!clsValidation.ValidateEmail(txtEmail.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(Temp, "Invalid Email Address Format !");
            }
            else errorProvider1.SetError(Temp, null);



        }

        private void txtNationalNoValidating(object sender, CancelEventArgs e)
        {


            if (string.IsNullOrWhiteSpace(txtNationalNo.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtNationalNo, "This Field Is Required !");
                return;
            }
            else errorProvider1.SetError(txtNationalNo, null);

            string nationalNo = txtNationalNo.Text.Trim();
            if ((nationalNo != _Person.NationalNo) && clsPerson.DoesPersonExist(nationalNo))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtNationalNo, "National Number Is Used By Another Person !");
            }
            else errorProvider1.SetError(txtNationalNo, null);



        }


        private void radioGenderClicked(object sender, EventArgs e)
        {
            if (pbPersonImage.ImageLocation == null)
                pbPersonImage.Image = rbMale.Checked ? Resources.male : Resources.female;

        }


    }
}
