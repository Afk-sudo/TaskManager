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
        public ObservableCollection<Task> ConformidadeTasks { get; set; }
        public ObservableCollection<Task> ComplitedTasks { get; set; }
        public string NewTaskTitle { get; set; }
        public Task SelectedTask { get; set ; }
        public ICommand AdditionTaskCommand => new Command(AddTask);
        public ICommand EditTaskCommand => new Command(EditTask);
        public ICommand DeleteTaskCommand => new Command(DeleteTask);
        public TaskList()
        {
            ConformidadeTasks = new ObservableCollection<Task>();
            ComplitedTasks = new ObservableCollection<Task>();
            var tasks = App.Database.GetTasks();
            foreach(var task in tasks)
            {
                if (task.IsDone == true)
                    ComplitedTasks.Add(task);
                else
                    ConformidadeTasks.Add(task);
                task.TaskMarkChanged += MoveTaskAnotherList;
            }

        }
        public void AddTask()
        {
            if (String.IsNullOrEmpty(NewTaskTitle))
                return;
            Task additableTask = new Task(NewTaskTitle);
            ConformidadeTasks.Add(additableTask);
            additableTask.TaskMarkChanged += MoveTaskAnotherList;
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
            if (SelectedTask.IsDone == true)
            { 
                ComplitedTasks.Remove(SelectedTask);
            }
            else
            {
                ConformidadeTasks.Remove(SelectedTask);
            }
            App.Database.DeleteTask(SelectedTask.Id);
            SelectedTask = null;
        }
        private void MoveTaskAnotherList(Task sender)
        {
            try 
            {
                if (sender.IsDone == true)
                {
                    ComplitedTasks.Add(sender);
                    ConformidadeTasks.Remove(sender);
                }
                else
                {
                    ConformidadeTasks.Add(sender);
                    ComplitedTasks.Remove(sender);
                }
            }
            catch(Exception exception)
            {
                return;
            }
        }
    }
}
