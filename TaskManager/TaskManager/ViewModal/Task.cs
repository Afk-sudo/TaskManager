using System;
using System.Collections.Generic;
using System.Text;

namespace TaskManager.ViewModal
{
    public class Task
    {
        public string TaskTitle { get; set; }
        public bool IsDone { get; set; } = false;

        public Task(string taskTitle)
        {
            TaskTitle = taskTitle;
        }
        public Task() { }
    }
}
