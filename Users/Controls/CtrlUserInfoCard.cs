using DVLD_Buisness;
using System.Windows.Forms;

namespace DVLD.Controls
{
    public partial class CtrlUserInfoCard : UserControl
    {


        public CtrlUserInfoCard()
        {
            InitializeComponent();

        }

        internal void LoadPersonInfo(int personID)
        {
            ctrlPersonCard1.LoadPersonInfo(personID);
            clsUser user = clsUser.FindUserByPersonID(personID);
            lblUserID.Text = user.UserID.ToString();
            lblUserName.Text = user.Username;
            lblIsActive.Text = user.IsActive ? "Yes" : "No";
        }

        internal void LoadUserInfo(int userID)
        {

            clsUser user = clsUser.FindUserByUserID(userID);
            lblUserID.Text = user.UserID.ToString();
            lblUserName.Text = user.Username;
            lblIsActive.Text = user.IsActive ? "Yes" : "No";

            ctrlPersonCard1.LoadPersonInfo(user.PersonID);
        }

    }












}
