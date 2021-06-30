using DailyBuildFriend.ViewModel;
using System.Windows.Forms;

namespace DailyBuildFriend
{
    public partial class OptionForm : Form
    {
        private ViewOption ViewOption;

        public OptionForm(ViewOption viewOption)
        {
            InitializeComponent();
            propertyGrid1.SelectedObject = viewOption;
            ViewOption = viewOption;
        }

        private void OKButton_Click(object sender, System.EventArgs e)
            => ViewOption = propertyGrid1.SelectedObject as ViewOption ?? new ViewOption();
    }
}
