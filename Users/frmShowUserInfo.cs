using System.Windows.Forms;

namespace DVLD.Users
{
    public partial class frmShowUserInfo : Form
    {
        public frmShowUserInfo()
        {
            InitializeComponent();
            // ctrlUserInfoCard1.LoadPersonInfo(clsGlobal.CurrentUser.PersonID);

        }

        internal void LoadPersonInfo(int personID)
        {
            ctrlUserInfoCard1.LoadPersonInfo(personID);
        }

        internal void LoadUserInfo(int userID)
        {
            ctrlUserInfoCard1.LoadUserInfo(userID);
        }
    }
}