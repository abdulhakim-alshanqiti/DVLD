using clsCountryBusinessLayer;
using clsPersonBusinessLayer;
using Contacts.Properties;
using System;
using System.Windows.Forms;

namespace Persons
{
    public partial class frmPersonDetails : Form
    {


        int _PersonID;
        clsPerson _Person;

        public frmPersonDetails(int PersonID)
        {
            InitializeComponent();

            _PersonID = PersonID;


        }

        private void _LoadData()
        {

            _Person = clsPerson.Find(_PersonID);


            if (_Person == null)
            {
                MessageBox.Show("This form will be closed because No Person with ID = " + _PersonID);
                this.Close();

                return;
            }


            lblMode.Text = "Edit Person ID = " + _PersonID;
            lblPersonID.Text = _PersonID.ToString();
            lblname.Text = $"{_Person.FirstName} {_Person.SecondName} {_Person.ThirdName} {_Person.LastName}";
            lblemail.Text = _Person.Email;
            lblphone.Text = _Person.Phone;
            lbladdress.Text = _Person.Address;
            lblnationalnumber.Text = _Person.NationalNo;
            lbldate.Text = _Person.DateOfBirth.ToLongDateString();
            lblgender.Text = (_Person.Gender == 0) ? "Male" : "Female";

            if (_Person.ImagePath != "") pictureBox1.Load(_Person.ImagePath);
            else pictureBox1.Image = _Person.Gender == 0 ? Resources.male : Resources.female;


            lblcountry.Text = clsCountry.Find(_Person.NationalityCountryID).Name;

        }

        private void frmPersonDetails_Load(object sender, EventArgs e)
        {
            _LoadData();
        }





        private void llOpenFileDialog_LinkClicked(object sender, EventArgs e)
        {
            //openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            //openFileDialog1.FilterIndex = 1;
            //openFileDialog1.RestoreDirectory = true;

            //if (openFileDialog1.ShowDialog() == DialogResult.OK)
            //{

            //    string selectedFilePath = openFileDialog1.FileName;

            //    pictureBox1.Load(selectedFilePath);
            //    _Person.ImagePath = selectedFilePath;

            //}
        }

        private void lblEditPerson_LinkClicked(object sender, EventArgs e)
        {
            if (new frmPerson(_PersonID).ShowDialog() == DialogResult.OK) this.Close();
        }
    }
}
