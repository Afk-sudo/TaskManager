using System;
using TaskManager.View;
using TaskManager.ViewModal;
using Xamarin.Forms;

namespace TaskManager
{
    public partial class AllTask : ContentPage
    {
        public AllTask()
        {
            InitializeComponent();
            this.BindingContext = App.TaskList;
        }
        public void OpenAdditionPage(object sender, EventArgs eventArgs)
        {
            AdditionalPage additionalPage = new AdditionalPage(App.TaskList);
            Navigation.PushModalAsync(additionalPage);
        }
        public void OpenEditingPage(object sender, EventArgs eventArgs)
        {
            if (App.TaskList.SelectedTask == null)
                return;
            EditingPage editingPage = new EditingPage(App.TaskList);
            Navigation.PushModalAsync(editingPage);
        }
    }
}
