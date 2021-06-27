using DailyBuildFriend.ViewModel;
using System.Windows.Forms;

namespace DailyBuildFriend
{
    public partial class OptionForm : Form
    {
        private ViewOption ViewOption;

        public OptionForm()
        {
            InitializeComponent();

            ViewOption = ViewOptionAccessor.GetViewOption().Clone();
            propertyGrid1.SelectedObject = ViewOption;
        }

        private void OKButton_Click(object sender, System.EventArgs e)
            => ViewOptionAccessor.SetViewOption(ViewOption);
    }
}
