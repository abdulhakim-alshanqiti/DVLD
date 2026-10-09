using System.Windows.Forms;

namespace DVLD.Users
{
    public partial class frmShowUserInfo : Form
    {
        public frmShowUserInfo()
        {
            InitializeComponent();
        }

        internal void LoadPersonInfo(int personID)
        {
            ctrlUserCard1.LoadPersonInfo(personID);
        }

        internal void LoadUserInfo(int userID)
        {
            ctrlUserCard1.LoadUserInfo(userID);
        }
    }
}