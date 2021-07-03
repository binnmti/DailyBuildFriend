using DailyBuildFriend.Model;

namespace DailyBuildFriend.ViewModel.Accessor
{
    internal static class ViewOptionAccessor
    {
        internal static Option ToOption(this ViewOption option)
            => new Option()
            {
                Devenv = option.Devenv,
                MSBuild = option.MSBuild,
                VsTest = option.VsTest,
            };

        internal static ViewOption ToViewOption(this Option option)
            => new ViewOption()
            {
                Devenv = option.Devenv,
                MSBuild = option.MSBuild,
                VsTest = option.VsTest,
            };
    }
}
