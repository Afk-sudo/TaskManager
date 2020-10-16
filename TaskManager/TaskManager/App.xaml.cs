using System;
using TaskManager.Modal;
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

           
        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
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
