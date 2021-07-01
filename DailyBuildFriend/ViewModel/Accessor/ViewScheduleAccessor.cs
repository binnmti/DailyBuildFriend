using DailyBuildFriend.Model;

namespace DailyBuildFriend.ViewModel.Accessor
{
    internal static class ViewScheduleAccessor
    {
        internal static ViewSchedule ToViewSchedule(this Schedule schedule)
         => new ViewSchedule()
            {
                Checked = schedule.Checked,
                Interval = schedule.Interval,
                Timer = schedule.Timer,
            };

        internal static Schedule ToSchedule(this ViewSchedule schedule)
             => new Schedule()
             {
                 Checked = schedule.Checked,
                 Interval = schedule.Interval,
                 Timer = schedule.Timer,
             };

    }
}
