using DailyBuildFriend.Model;

namespace DailyBuildFriend.ViewModel
{
    internal static class ViewScheduleAccessor
    {
        internal static ViewSchedule ToViewSchedule(this Schedule schedule)
         => new ViewSchedule()
            {
                Check = schedule.Check,
                Interval = schedule.Interval,
                Timer = schedule.Timer,
            };

        internal static Schedule ToSchedule(this ViewSchedule schedule)
             => new Schedule()
             {
                 Check = schedule.Check,
                 Interval = schedule.Interval,
                 Timer = schedule.Timer,
             };

    }
}
