using System;
using System.Windows.Forms;

namespace DVLD.Applications
{
    public partial class frmListApplicationTypes : Form
    {

        public frmListApplicationTypes()
        {
            InitializeComponent();

        }
        private void _RefreshApplicationTypes()
        {
            dgvApplicationTypes.DataSource = clsApplicationType.GetAllApplicationTypes();
            lblRecordsCount.Text = dgvApplicationTypes.Rows.Count.ToString();
        }

        private void frmManageApplicationTypes_Load(object sender, EventArgs e)
        {
            _RefreshApplicationTypes();
            dgvApplicationTypes.Columns[0].HeaderText = "ID";
            dgvApplicationTypes.Columns[0].Width = 110;

            dgvApplicationTypes.Columns[1].HeaderText = "Title";
            dgvApplicationTypes.Columns[1].Width = 400;

            dgvApplicationTypes.Columns[2].HeaderText = "Fees";
            dgvApplicationTypes.Columns[2].Width = 100;
        }

        private void editApplicationTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {

            DataGridViewCellCollection CurrentRow = dgvApplicationTypes.CurrentRow.Cells;

            new frmEditApplicationType(
                  new clsApplicationType(
                          id: (int)CurrentRow[0].Value,
                          title: (string)CurrentRow[1].Value,
                          fees: (float)CurrentRow[2].Value
                      )
                )
                .ShowDialog();

            _RefreshApplicationTypes();

        }
    }
}
