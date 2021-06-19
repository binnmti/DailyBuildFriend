using DailyBuildFriend.Data;
using DailyBuildFriend.Model;
using DailyBuildFriend.ViewModel;

namespace DailyBuildFriend.Controller
{
    public class CommandController
    {
        internal static ViewCommand GetViewCommand(CommandType type) => ViewCommandData.Data[(int)type];
    }

}
