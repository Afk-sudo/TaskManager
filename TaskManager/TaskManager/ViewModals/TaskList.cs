using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace TaskManager.ViewModal
{
    public class TaskList
    {
        public ObservableCollection<Task> Tasks { get; set; }
        public ObservableCollection<Task> CompliteTask { get; set; }
        public string NewTaskTitle { get; set; }
        public Task SelectedTask { get; set; }
        public ICommand AdditionTaskCommand => new Command(AddTask);
        public ICommand EditTaskCommand => new Command(EditTask);
        public ICommand DeleteTaskCommand => new Command(DeleteTask);
        public TaskList()
        {
            Tasks = new ObservableCollection<Task>();
            CompliteTask = new ObservableCollection<Task>();
            var tasks = App.Database.GetTasks();
            foreach(var task in tasks)
            {
                if (task.IsDone == true)
                    CompliteTask.Add(task);
                else
                    Tasks.Add(task);
            }

        }
        public void AddTask()
        {
            if (String.IsNullOrEmpty(NewTaskTitle))
                return;
            Task additableTask = new Task(NewTaskTitle);
            Tasks.Add(additableTask);
            App.Database.SaveTask(additableTask);
            NewTaskTitle = "";
        }
        public void EditTask()
        {
            if (String.IsNullOrEmpty(NewTaskTitle))
                return;
            SelectedTask.TaskTitle = NewTaskTitle;
            App.Database.SaveTask(SelectedTask);
            NewTaskTitle = "";
            SelectedTask = null;
        }
        public void DeleteTask()
        {
            if (SelectedTask == null)
                return;
            int idDeletedTask = Tasks.IndexOf(SelectedTask);
            Tasks.Remove(SelectedTask);
            App.Database.DeleteTask(idDeletedTask);
            SelectedTask = null;
        }
    }
}
