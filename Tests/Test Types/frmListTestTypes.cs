using DVLD_Buisness;
using System;
using System.Windows.Forms;

namespace DVLD.Tests
{
    public partial class frmListTestTypes : Form
    {

        public frmListTestTypes()
        {
            InitializeComponent();

        }
        private void _RefreshTestTypes()
        {
            dgvTestTypes.DataSource = clsTestType.GetAllTestTypes();
            lblRecordsCount.Text = dgvTestTypes.Rows.Count.ToString();
        }

        private void frmManageTestTypes_Load(object sender, EventArgs e)
        {
            _RefreshTestTypes();
            dgvTestTypes.Columns[0].HeaderText = "ID";
            dgvTestTypes.Columns[0].Width = 110;

            dgvTestTypes.Columns[1].HeaderText = "Title";
            dgvTestTypes.Columns[1].Width = 110;

            dgvTestTypes.Columns[2].HeaderText = "Description";
            dgvTestTypes.Columns[2].Width = 400;

            dgvTestTypes.Columns[3].HeaderText = "Fees";
            dgvTestTypes.Columns[3].Width = 100;
        }

        private void editTestTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {


            new frmEditTestType((int)dgvTestTypes.CurrentRow.Cells[0].Value)
                .ShowDialog();

            _RefreshTestTypes();

        }
    }
}
