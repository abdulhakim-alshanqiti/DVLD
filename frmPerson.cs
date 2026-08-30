using clsCountryBusinessLayer;
using clsPersonBusinessLayer;
using Contacts.Properties;
using System;
using System.Data;
using System.Windows.Forms;
using static clsPersonBusinessLayer.clsPerson;
using static clsPersonDataAccessLayer.clsPersonDataAccess;

namespace clsPersonPresentaionLayer
{
    public partial class frmPerson : Form
    {

        public enum enMode { AddNew = 0, Update = 1 };
        private enMode _Mode;

        int _PersonID;
        clsPerson _Person;

        public frmPerson(int PersonID)
        {
            InitializeComponent();

            _PersonID = PersonID;

            if (_PersonID == -1)
                _Mode = enMode.AddNew;
            else
                _Mode = enMode.Update;
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

            _FillCountriesInComoboBox();
            cbCountry.SelectedIndex = 0;

            if (_Mode == enMode.AddNew)
            {
                lblMode.Text = "Add New Person";
                _Person = new clsPerson();
                return;
            }

            _Person = Find(_PersonID);

            if (_Person == null)
            {
                MessageBox.Show("This form will be closed because No Person with ID = " + _PersonID);
                this.Close();

                return;
            }

            lblMode.Text = "Edit Person ID = " + _PersonID;
            lblPersonID.Text = _PersonID.ToString();
            txtFirstName.Text = _Person.FirstName;
            txtSecondName.Text = _Person.SecondName;
            txtThirdName.Text = _Person.ThirdName;
            txtLastName.Text = _Person.LastName;
            txtEmail.Text = _Person.Email;
            txtPhone.Text = _Person.Phone;
            txtAddress.Text = _Person.Address;
            txtNationalNo.Text = _Person.NationalNo;
            dtpDateOfBirth.Value = _Person.DateOfBirth;


            if (_Person.Gender == enGender.Male)
            {
                radioMale.Checked = true;
            }
            else
            {
                radioButton2.Checked = true;
            }


            if (_Person.ImagePath != "")
            {
                pictureBox1.Load(_Person.ImagePath);
            }
            else
            {



                pictureBox1.Image = _Person.Gender == clsPersonDataAccessLayer.clsPersonDataAccess.enGender.Male ? Resources.male : Resources.female;



            }


            //pictureBox1.Visible = (_Person.ImagePath != "");

            //this will select the country in the combobox.
            cbCountry.SelectedIndex = cbCountry.FindString(clsCountry.Find(_Person.NationalityCountryID).Name);

        }

        private void frmPerson_Load(object sender, EventArgs e)
        {
            _LoadData();
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            int NationalityCountryID = clsCountry.Find(cbCountry.Text).ID;

            _Person.NationalNo = txtNationalNo.Text;
            _Person.FirstName = txtFirstName.Text;
            _Person.SecondName = txtSecondName.Text;
            _Person.ThirdName = txtThirdName.Text;
            _Person.LastName = txtLastName.Text;
            _Person.Email = txtEmail.Text;
            _Person.Phone = txtPhone.Text;
            _Person.Address = txtAddress.Text;
            _Person.DateOfBirth = dtpDateOfBirth.Value;
            _Person.NationalityCountryID = NationalityCountryID;

            _Person.Gender = (radioMale.Checked) ? enGender.Male : enGender.Female;

            //Validate_Person();


            if (string.IsNullOrWhiteSpace(_Person.NationalNo))
            {
                errorProvider1.SetError(txtNationalNo, "National Number Isn't Valid");
                MessageBox.Show("Error: Data Is not Saved Successfully.");
                return;
            }

            if (string.IsNullOrWhiteSpace(_Person.FirstName))
            {
                errorProvider1.SetError(txtFirstName, "First Name Isn't Valid");
                MessageBox.Show("Error: Data Is not Saved Successfully.");
                return;
            }

            if (string.IsNullOrWhiteSpace(_Person.SecondName))
            {
                errorProvider1.SetError(txtSecondName, "Second Name Isn't Valid");
                MessageBox.Show("Error: Data Is not Saved Successfully.");
                return;
            }


            if (string.IsNullOrWhiteSpace(_Person.ThirdName))
            {
                errorProvider1.SetError(txtThirdName, "Third Name Isn't Valid");
                MessageBox.Show("Error: Data Is not Saved Successfully.");
                return;
            }

            if (string.IsNullOrWhiteSpace(_Person.LastName))
            {
                errorProvider1.SetError(txtLastName, "Last Name Isn't Valid");
                MessageBox.Show("Error: Data Is not Saved Successfully.");
                return;
            }

            if (string.IsNullOrWhiteSpace(_Person.Email))
            {
                errorProvider1.SetError(txtEmail, "Email Isn't Valid");
                MessageBox.Show("Error: Data Is not Saved Successfully.");
                return;
            }

            if (string.IsNullOrWhiteSpace(_Person.Phone))
            {
                errorProvider1.SetError(txtPhone, "Phone Isn't Valid");
                MessageBox.Show("Error: Data Is not Saved Successfully.");
                return;
            }

            if (string.IsNullOrWhiteSpace(_Person.Address))
            {
                errorProvider1.SetError(txtAddress, "Address Isn't Valid");
                MessageBox.Show("Error: Data Is not Saved Successfully.");
                return;
            }


            if (_Person.NationalityCountryID == -1)
            {
                errorProvider1.SetError(cbCountry, "You Haven't Selected a Contry");
                MessageBox.Show("Error: Data Is not Saved Successfully.");
                return;
            }



            if (_Person.DateOfBirth > (DateTime.Now.AddYears(-18)))
            {
                errorProvider1.SetError(dtpDateOfBirth, "Make Sure the Date Of Birth Is Above 18");
                MessageBox.Show("Error: Data Is not Saved Successfully.");
                return;
            }



            if (openFileDialog1.FileName != "openFileDialog1")
            {
                pictureBox1.Load(openFileDialog1.FileName);
                _Person.ImagePath = openFileDialog1.FileName;
            }


            if (_Person.Save())
            {
                MessageBox.Show("Data Saved Successfully.");
                if (_Mode == enMode.AddNew)
                {
                    _Mode = enMode.Update;
                    lblMode.Text = "Edit Person ID = " + _Person.ID;
                    lblPersonID.Text = _Person.ID.ToString();

                }

            }
            else
                MessageBox.Show("Error: Data Is not Saved Successfully.");





        }
        struct CountryItem
        {
            public string Text;
            public int Value;
            public CountryItem(string Text, int Value)
            {
                this.Text = Text;
                this.Value = Value;
            }
        }



        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();

        }



        private void llRemoveImage_LinkClicked(object sender, EventArgs e)
        {

            _Person.ImagePath = "";
            pictureBox1.Image =

                 radioMale.Checked ?
                   Resources.male : Resources.female;


            //pictureBox1.Visible = false;


        }

        private void radioGenderClicked(object sender, EventArgs e)
        {
            if (_Person.ImagePath == "")
            {

                pictureBox1.Image =

                  radioMale.Checked ?
                    Resources.male : Resources.female;



            }


        }

        private void llOpenFileDialog_LinkClicked(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {

                string selectedFilePath = openFileDialog1.FileName;

                pictureBox1.Load(selectedFilePath);
                _Person.ImagePath = selectedFilePath;

            }
        }

        private void Validation(Control Control, KeyPressEventArgs e, string Type)
        {
            string Validation_Message = Validate_Person(e.KeyChar, Type);

            if (Validation_Message != null)

            {
                errorProvider1.SetError(Control, Validation_Message);
                e.Handled = true;
            }
            else errorProvider1.SetError(Control, null);
        }
        private void NamesValidation(object sender, KeyPressEventArgs e) =>
            Validation((Control)sender, e, "First Name");



        private void NationalNoValidation(object sender, KeyPressEventArgs e) =>
            Validation((Control)sender, e, "National No");

        private void PhoneValidation(object sender, KeyPressEventArgs e)
            => Validation((Control)sender, e, "Phone");
        private void EmailValidation(object sender, KeyPressEventArgs e)
    => Validation((Control)sender, e, "Email");
    }
}
