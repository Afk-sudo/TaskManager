using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.View;
using TaskManager.ViewModal;
using Xamarin.Forms;

namespace TaskManager
{
    public partial class MainPage : ContentPage
    {
        public TaskList TaskList;
        public MainPage()
        {
            InitializeComponent();
            TaskList = new TaskList();
            this.BindingContext = TaskList;
        }
        public void OpenAdditionPage(object sender, EventArgs eventArgs)
        {
            AdditionalPage additionalPage = new AdditionalPage(TaskList);
            Navigation.PushModalAsync(additionalPage);
        }
        public void OpenEditingPage(object sender, EventArgs eventArgs)
        {
            if (TaskList.SelectedTask == null)
                return;
            EditingPage editingPage = new EditingPage(TaskList);
            Navigation.PushModalAsync(editingPage);
        }
        public void OnClickAllTaskButton(object sender, EventArgs eventArgs)
        {
            todoList.IsVisible = true;
            CompliteTask.IsVisible = false;
        }
        public void OnClickCompliteTaskButton(object sender, EventArgs eventArgs)
        {
            todoList.IsVisible = false;
            CompliteTask.IsVisible = true;
        }
    }
}
