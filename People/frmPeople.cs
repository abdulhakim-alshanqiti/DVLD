
using DVLD_Business;
using System.Data;
using System.Windows.Forms;
using static DVLD_Business.clsPerson;
namespace DVLD.People
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




            Form f = new frmAddUpdatePerson(Id);


            f.FormClosed += (_sender, _e) =>
            {

                RefreshDataGrid();


            };

            f.Show();


        }

        private void addButton_Click(object sender, System.EventArgs e)
        {


            Form f = new frmAddUpdatePerson(-1);


            f.FormClosed += (_sender, _e) =>
            {

                RefreshDataGrid();


            };

            f.Show();



        }
        private void RefreshDataGrid()
        {
            DataTable table = GetAllPeople();

            DataView view = table.AsDataView();


            if (textBox1.Text.Trim() == "")
            {
                dataGridView1.DataSource = table;
                label1.Text = "Records : " + table.Rows.Count;
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
            label1.Text = "Records : " + view.Count;

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
            string Validation_Message = Validate_Person(e.KeyChar, cboxFilterBy.SelectedItem.ToString());

            if (Validation_Message != null)
            {
                errorProvider1.SetError(textBox1, Validation_Message);
                e.Handled = true;
            }
            else errorProvider1.SetError(textBox1, null);


        }

        private void showDetailsToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            int Id = -1;
            int.TryParse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString(), out Id);



            Form f = new frmShowPersonInfo(Id);


            f.FormClosed += (_sender, _e) =>
            {

                RefreshDataGrid();

            };

            f.Show();

        }

        private void deletePersonToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            int Id = -1;

            int.TryParse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString(), out Id);

            clsPerson person = clsPerson.Find(Id);

            if (MessageBox.Show($"Are You Sure You Want to Delete Person with this Info : " +
                  $"\nID: {person.PersonID}" +
                  $"\nNationalNo: {person.NationalNo}" +
                  $"\nName: {person.FullName()}", "Are You Sure", MessageBoxButtons.OKCancel)
                == DialogResult.OK
                  )
            {
                if (person.Delete(person.PersonID))
                {
                    MessageBox.Show("Person Deleted Succesfully ");


                    RefreshDataGrid();
                }
                else
                {
                    MessageBox.Show("Error While Deleting Person");
                }


            }

        }

        private void addPersonToolStripMenuItem_Click(object sender, System.EventArgs e)
        {

            Form f = new frmAddUpdatePerson(-1);


            f.FormClosed += (_sender, _e) =>
            {

                RefreshDataGrid();


            };

            f.Show();
        }
    }
}
