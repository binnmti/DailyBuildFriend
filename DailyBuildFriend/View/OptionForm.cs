using DailyBuildFriend.ViewModel;
using System.Windows.Forms;

namespace DailyBuildFriend.View
{
    public partial class OptionForm : Form
    {
        internal ViewOption ViewOption { get; set; } = new ViewOption();
        public OptionForm(ViewOption viewOption)
        {
            InitializeComponent();
            propertyGrid1.SelectedObject = viewOption;
            ViewOption = viewOption.Clone();
        }

        private void OKButton_Click(object sender, System.EventArgs e)
            => ViewOption = propertyGrid1.SelectedObject as ViewOption ?? new ViewOption();
    }
}
