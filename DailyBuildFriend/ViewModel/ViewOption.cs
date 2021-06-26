using System.ComponentModel;
using System.Drawing.Design;
using System.Windows.Forms.Design;

namespace DailyBuildFriend.ViewModel
{
    public class ViewOption
    {
        public ViewOption Clone()
        {
            return (ViewOption)MemberwiseClone();
        }

        [Description(@"Visual Studio devenv.exe C:\Program Files (x86)\Microsoft Visual Studio\2019\Enterprise\Common7\IDE\devenv.exe")]
        [Category("ファイル")]
        [Editor(typeof(FileNameEditor), typeof(UITypeEditor))]
        public string Devenv { get; set; } = @"C:\Program Files (x86)\Microsoft Visual Studio\2019\Enterprise\Common7\IDE\devenv.exe";

        [Description(@"MSBuild MSBuild.exe C:\Program Files (x86)\MSBuild\14.0\Bin\MSBuild.exe")]
        [Category("ファイル")]
        [Editor(typeof(FileNameEditor), typeof(UITypeEditor))]
        public string MSBuild { get; set; } = @"C:\Program Files (x86)\MSBuild\14.0\Bin\MSBuild.exe";
    }
}
