using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace TaskManager.ViewModal
{
    public class TaskList
    {
        public BindingList<Task> Tasks { get; set; }
        public string NewTaskTitle { get; set; }
        private int _idSelectTask { get; set; }
        public ICommand AdditionTaskCommand => new Command(AddTask);
        public ICommand MarkingTaskComplitionCommand => new Command(MarkTaskComplite);
        
        public TaskList()
        {
            Tasks = new BindingList<Task>();
            Tasks.Add(new Task("Additoion task"));
           
        }
        public void AddTask()
        {
            Tasks.Add(new Task(NewTaskTitle));
        }
        public void MarkTaskComplite()
        {
            return;
        }
    }
}
