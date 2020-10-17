using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TaskManager.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CompliteTask : ContentPage
    {
        public CompliteTask()
        {
            InitializeComponent();

            this.BindingContext = App.TaskList;
        }
    }
}