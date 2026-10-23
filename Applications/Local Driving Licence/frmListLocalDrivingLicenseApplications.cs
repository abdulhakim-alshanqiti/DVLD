using DVLD_Business;
using System;
using System.Data;
using System.Windows.Forms;

namespace DVLD.LocalDrivingLicenseApplication
{
    public partial class frmListLocalDrivingLicenseApplications : Form
    {

        private static DataTable _dtAllLocalDrivingLicenseApplications = clsLocalDrivingLicenseApplication.GetAllLocalDrivingLicenseApplications();

        //only select the columns that you want to show in the grid
        private DataTable _dtLocalDrivingLicenseApplications = _dtAllLocalDrivingLicenseApplications.DefaultView.
            ToTable(false, "LocalDrivingLicenseApplicationID", "ClassName", "NationalNo",
            "FullName", "ApplicationDate", "PassedTestCount", "Status");




        private void _RefreshLocalDrivingLicenseApplicationsList()
        {
            _dtAllLocalDrivingLicenseApplications = clsLocalDrivingLicenseApplication.GetAllLocalDrivingLicenseApplications();
            _dtLocalDrivingLicenseApplications = _dtAllLocalDrivingLicenseApplications.DefaultView.

              ToTable(false, "LocalDrivingLicenseApplicationID", "ClassName", "NationalNo",
            "FullName", "ApplicationDate", "PassedTestCount", "Status");

            dgvLocalDrivingLicenseApplications.DataSource = _dtLocalDrivingLicenseApplications;
            lblRecordsCount.Text = dgvLocalDrivingLicenseApplications.Rows.Count.ToString();
        }

        public frmListLocalDrivingLicenseApplications()
        {
            InitializeComponent();
        }

        private void frmListLocalDrivingLicenseApplications_Load(object sender, EventArgs e)
        {

            dgvLocalDrivingLicenseApplications.DataSource = _dtLocalDrivingLicenseApplications;
            cbFilterBy.SelectedIndex = 0;
            lblRecordsCount.Text = dgvLocalDrivingLicenseApplications.Rows.Count.ToString();

            // Hides the empty row header column on the far left
            dgvLocalDrivingLicenseApplications.RowHeadersVisible = false;

            if (dgvLocalDrivingLicenseApplications.Rows.Count > 0)
            {

                dgvLocalDrivingLicenseApplications.Columns[0].HeaderText = "ID";
                dgvLocalDrivingLicenseApplications.Columns[0].Width = 70;

                dgvLocalDrivingLicenseApplications.Columns[1].HeaderText = "ClassName";
                dgvLocalDrivingLicenseApplications.Columns[1].Width = 280;


                dgvLocalDrivingLicenseApplications.Columns[2].HeaderText = "National Number";
                dgvLocalDrivingLicenseApplications.Columns[2].Width = 110;

                dgvLocalDrivingLicenseApplications.Columns[3].HeaderText = "Fullname";
                dgvLocalDrivingLicenseApplications.Columns[3].Width = 330;


                dgvLocalDrivingLicenseApplications.Columns[4].HeaderText = "Date";
                dgvLocalDrivingLicenseApplications.Columns[4].Width = 170;

                dgvLocalDrivingLicenseApplications.Columns[5].HeaderText = "Passed Tests";
                dgvLocalDrivingLicenseApplications.Columns[5].Width = 110;

                dgvLocalDrivingLicenseApplications.Columns[6].HeaderText = "Status";
                dgvLocalDrivingLicenseApplications.Columns[6].Width = 120;


            }

        }





        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {

            string FilterColumn = "";
            //Map Selected Filter to real Column name 
            switch (cbFilterBy.Text)
            {
                case "ID":
                    FilterColumn = "LocalDrivingLicenseApplicationID";
                    break;
                case "Class Name":
                    FilterColumn = "ClassName";
                    break;
                case "National No":
                    FilterColumn = "NationalNo";
                    break;

                case "Fullname":
                    FilterColumn = "Fullname";
                    break;

                case "Passed Tests":
                    FilterColumn = "PassedTestCount";
                    break;

                case "Status":
                    FilterColumn = "Status";
                    break;


                default:
                    FilterColumn = "None";
                    break;

            }

            //Reset the filters in case nothing selected or filter value conains nothing.
            if (txtFilterValue.Text.Trim() == "" || FilterColumn == "None")
            {
                _dtLocalDrivingLicenseApplications.DefaultView.RowFilter = "";
                lblRecordsCount.Text = dgvLocalDrivingLicenseApplications.Rows.Count.ToString();
                return;
            }


            if (FilterColumn == "LocalDrivingLicenseApplicationID" || FilterColumn == "PassedTestCount")
                //in this case we deal with integer not string.

                _dtLocalDrivingLicenseApplications.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtFilterValue.Text.Trim());
            else
                _dtLocalDrivingLicenseApplications.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, txtFilterValue.Text.Trim());

            lblRecordsCount.Text = dgvLocalDrivingLicenseApplications.Rows.Count.ToString();

        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {

            txtFilterValue.Visible = (cbFilterBy.Text != "None");

            if (txtFilterValue.Visible)
            {
                txtFilterValue.Text = "";
                txtFilterValue.Focus();
            }

        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //int LocalDrivingLicenseApplicationID = (int)dgvLocalDrivingLicenseApplications.CurrentRow.Cells[0].Value;
            //Form frm = new frmShowLocalDrivingLicenseApplicationInfo(LocalDrivingLicenseApplicationID);
            //frm.ShowDialog();

            MessageBox.Show("This Feature Is Not Implemented Yet!", "Not Ready!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Form frm = new frmAddUpdateLocalDrivingLicenseApplication((int)dgvLocalDrivingLicenseApplications.CurrentRow.Cells[0].Value);
            frm.ShowDialog();

            _RefreshLocalDrivingLicenseApplicationsList();

        }

        private void sendEmailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This Feature Is Not Implemented Yet!", "Not Ready!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

        }

        private void phoneCallToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This Feature Is Not Implemented Yet!", "Not Ready!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Are you sure you want to delete Local Driving License Application with ID [" + dgvLocalDrivingLicenseApplications.CurrentRow.Cells[0].Value + "]", "Confirm Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)

            {

                //Perform Delele and refresh
                if (clsLocalDrivingLicenseApplication.DeleteLocalDrivingLicenseApplicationByLocalDrivingLicenseApplicationID((int)dgvLocalDrivingLicenseApplications.CurrentRow.Cells[0].Value))
                {
                    MessageBox.Show("LocalDrivingLicenseApplication Deleted Successfully.", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _RefreshLocalDrivingLicenseApplicationsList();
                }

                else
                    MessageBox.Show("LocalDrivingLicenseApplication was not deleted because it has data linked to it.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form frm = new frmAddUpdateLocalDrivingLicenseApplication();
            frm.ShowDialog();

            _RefreshLocalDrivingLicenseApplicationsList();
        }

        private void btnAddLocalDrivingLicenseApplication_Click(object sender, EventArgs e)
        {
            Form frm1 = new frmAddUpdateLocalDrivingLicenseApplication();
            frm1.ShowDialog();
            _RefreshLocalDrivingLicenseApplicationsList();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvLocalDrivingLicenseApplications_DoubleClick(object sender, EventArgs e)
        {
            //Form frm = new frmShowLocalDrivingLicenseApplicationInfo((int)dgvLocalDrivingLicenseApplications.CurrentRow.Cells[0].Value);
            //frm.ShowDialog();

            MessageBox.Show("This Feature Is Not Implemented Yet!", "Not Ready!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            //we allow number incase person id is selected.
            if (cbFilterBy.Text == "LocalDrivingLicenseApplication ID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
