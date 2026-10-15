using System;
using System.Windows.Forms;

namespace DVLD.Applications
{
    public partial class frmEditApplicationType : Form
    {
        clsApplicationType _ApplicationType;

        public frmEditApplicationType(int value)
        {
            InitializeComponent();
        }

        public frmEditApplicationType(clsApplicationType applicationType)
        {
            InitializeComponent();

            _ApplicationType = applicationType;

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

            _ApplicationType.Title = txtTitle.Text;
            _ApplicationType.Fees = decimal.Parse(txtFee.Text);

            if (_ApplicationType.Save())
            {
                MessageBox.Show("Application Type Updated Successfully.",
                   "Saved.", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                MessageBox.Show("An Erro Occured, Application Type did not change.",
                   "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmUpdateApplicationType_Load(object sender, EventArgs e)
        {
            lblID.Text = _ApplicationType.ApplicationTypeID.ToString();
            txtTitle.Text = _ApplicationType.Title;
            txtFee.Text = _ApplicationType.Fees.ToString();

        }
    }
}
