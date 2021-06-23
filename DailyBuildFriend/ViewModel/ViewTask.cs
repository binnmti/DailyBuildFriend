﻿using System;
using System.Collections.Generic;

namespace DailyBuildFriend.ViewModel
{
    internal class ViewTask
    {
        internal string TaskName { get; set; } = "";
        internal string FileName { get; set; } = "";
        internal string ProjectPath { get; set; } = "";
        internal string LogPath { get; set; } = "";
        internal bool Checked { get; set; }
        internal DateTime Update { get; set; }
        internal Check Timer { get; set; } = new Check();
        internal Check Interval { get; set; } = new Check();
        internal Check Report { get; set; } = new Check();
        internal TimeOut TimeOut { get; set; } = new TimeOut();
        internal DateTime WorstTime { get; set; }
        internal string LocalRevision { get; set; } = "";
        internal string ServerRevision { get; set; } = "";
        internal List<ViewCommand> ViewCommands { get; set; } = new List<ViewCommand>();
    }
}