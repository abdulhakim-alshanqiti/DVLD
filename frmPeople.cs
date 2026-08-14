using System.Data;
using System.Windows.Forms;
using static clsPersonBusinessLayer.clsPerson;
namespace clsPersonPresentaionLayer
{
    public partial class frmPeople : Form
    {
        public frmPeople()
        {
            InitializeComponent();
        }

        private void frmPeople_Load(object sender, System.EventArgs e)
        {
            DataTable People = GetAllPeople();
            label1.Text = "Records : " + People.Rows.Count;

            dataGridView1.DataSource = People;
        }
    }
}
