﻿using DailyBuildFriend.Model;

namespace DailyBuildFriend.ViewModel
{
    internal static class ViewOptionAccessor
    {
        internal static Option ToOption(this ViewOption option)
            => new Option()
            {
                Devenv = option.Devenv,
                MSBuild = option.MSBuild,
            };

        internal static ViewOption ToViewOption(this Option option)
            => new ViewOption()
            {
                Devenv = option.Devenv,
                MSBuild = option.MSBuild,
            };
    }
}
