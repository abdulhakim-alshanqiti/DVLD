using clsCountryBusinessLayer;
using clsPersonBusinessLayer;
using Contacts.Properties;
using System;
using System.Windows.Forms;

namespace clsPersonPresentaionLayer
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



        private void lblEditPerson_LinkClicked(object sender, EventArgs e)
        {



            Form f = new frmPerson(_PersonID);


            f.FormClosed += (_sender, _e) =>
            {

                this.Close();

            };

            f.Show();
        }
    }
}
