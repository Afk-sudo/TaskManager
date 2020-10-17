using System;
using TaskManager.Modal;
using TaskManager.View;
using TaskManager.ViewModal;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TaskManager
{
    public partial class App : Application
    {
        public const string DATABASE_NAME = "Tasks.db";
        public static TaskRepository Database
        {
            get
            {
                if(_database == null)
                {
                    _database = new TaskRepository(SQLite.GetDatabasePath(DATABASE_NAME));
                }
                return _database;
            }
        }
        private static TaskRepository _database;
        public static TaskList TaskList { get; private set; }
        public App()
        {
            InitializeComponent();
            TaskList = new TaskList();
            CarouselPage carouselPage = new CarouselPage();
            carouselPage.Children.Add(new AllTask());
            carouselPage.Children.Add(new CompliteTask());
            MainPage = carouselPage;
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
