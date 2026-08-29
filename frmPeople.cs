using Persons;
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
            cboxFilterBy.SelectedIndex = 0;
        }

        private void editPersonToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            int Id = -1;

            int.TryParse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString(), out Id);


            if (new frmPerson(Id).ShowDialog() == DialogResult.OK) RefreshDataGrid();


        }

        private void button1_Click(object sender, System.EventArgs e)
        {

            if (new frmPerson(-1).ShowDialog() == DialogResult.OK) RefreshDataGrid();





        }
        private void RefreshDataGrid()
        {
            DataTable table = GetAllPeople();

            DataView view = table.AsDataView();


            if (textBox1.Text.Trim() == "")
            {
                dataGridView1.DataSource = table;
                return;
            }


            switch (cboxFilterBy.SelectedItem.ToString())
            {

                case "None":
                    break;
                case "Person ID":

                    int PersonID = 0;
                    if (!int.TryParse(textBox1.Text, out PersonID))
                    { dataGridView1.DataSource = table; break; }

                    view.RowFilter = $"[PersonID] = {PersonID}";

                    break;
                case "NationalNo":
                    view.RowFilter = $"[NationalNo] LIKE '{textBox1.Text}'";
                    break;
                case "First Name":
                    view.RowFilter = $"[FirstName] LIKE '{textBox1.Text}'";
                    break;
                case "Second Name":
                    view.RowFilter = $"[SecondName] LIKE '{textBox1.Text}'";
                    break;
                case "Third Name":
                    view.RowFilter = $"[ThirdName] LIKE '{textBox1.Text}'";
                    break;
                case "Last Name":
                    view.RowFilter = $"[LastName] LIKE '{textBox1.Text}'";
                    break;
                case "Email":
                    view.RowFilter = $"[Email] LIKE '{textBox1.Text}'";
                    break;
                case "Phone":
                    view.RowFilter = $"[Phone] LIKE '{textBox1.Text}'";
                    break;
                case "Nationality":
                    int NationalityCountryID = 0;
                    if (!int.TryParse(textBox1.Text, out NationalityCountryID))
                    { dataGridView1.DataSource = table; break; }
                    view.RowFilter = $"[NationalityCountryID] = {NationalityCountryID}";
                    break;
                case "Gender":
                    int Gender = 0;
                    if (!int.TryParse(textBox1.Text, out Gender))
                    { dataGridView1.DataSource = table; break; }
                    view.RowFilter = $"[Gender] = {Gender}";
                    break;



            }


            dataGridView1.DataSource = view;
        }

        private void filterTextChange(object sender, System.EventArgs e)
        {

            RefreshDataGrid();

        }

        private void filterIndexChange(object sender, System.EventArgs e)
        {
            textBox1.Text = "";

            if (cboxFilterBy.SelectedItem.ToString() == "None")
                textBox1.Visible = false;
            else
                textBox1.Visible = true;
        }


        private void FilterKeyPressed(object sender, KeyPressEventArgs e)
        {


            char keyPressed = e.KeyChar;

            switch (cboxFilterBy.SelectedItem.ToString())
            {


                case "Person ID":

                    if (!char.IsDigit(keyPressed) && !char.IsControl(keyPressed))
                    {
                        errorProvider1.SetError(textBox1, "Person ID Can't Have Letters !!!");
                        e.Handled = true;
                    }
                    else errorProvider1.SetError(textBox1, null); break;

                case "Nationality":
                    if (!char.IsDigit(keyPressed) && !char.IsControl(keyPressed))
                    {
                        errorProvider1.SetError(textBox1, "Nationality Can't Have Letters !!!");
                        e.Handled = true;
                    }
                    else errorProvider1.SetError(textBox1, null); break;


                case "Gender":
                    if (!char.IsDigit(keyPressed) && !char.IsControl(keyPressed))
                    {
                        errorProvider1.SetError(textBox1, "Gender Can't Have Letters !!!");
                        e.Handled = true;
                    }
                    else errorProvider1.SetError(textBox1, null); break;

                default: errorProvider1.SetError(textBox1, null); break;

            }


        }

        private void showDetailsToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            int Id = -1;
            int.TryParse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString(), out Id);


            if (new frmPersonDetails(Id).ShowDialog() == DialogResult.OK) RefreshDataGrid();

        }
    }
}
