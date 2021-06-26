using DailyBuildFriend.ViewModel;
using System.Windows.Forms;

namespace DailyBuildFriend
{
    public partial class OptionForm : Form
    {
        private ViewOption _viewOption;

        public OptionForm()
        {
            InitializeComponent();
            _viewOption = ViewOptionAccessor.GetViewOption().Clone();
            propertyGrid1.SelectedObject = _viewOption;
        }

        private void OKButton_Click(object sender, System.EventArgs e)
        {
            ViewOptionAccessor.SetViewOption(_viewOption);
        }
    }
}
