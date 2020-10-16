using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.ViewModal;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TaskManager.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditingPage : ContentPage
    {
        public EditingPage(TaskList taskList)
        {
            InitializeComponent();
            this.BindingContext = taskList;
        }
    }
}