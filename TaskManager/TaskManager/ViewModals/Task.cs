using SQLite;
using System.ComponentModel;

namespace TaskManager.ViewModal
{
    [Table("Tasks")]
    public class Task : INotifyPropertyChanged
    {
        [PrimaryKey, AutoIncrement, Column("id")]
        public int Id { get; set; }
        public string TaskTitle 
        {
            get => _taskTitle;
            set
            {
                if (_taskTitle == value)
                    return;
                _taskTitle = value;
                OnPropertyChanged("TaskTitle");
            }
        }
        private string _taskTitle;
        public bool IsDone
        {
            get => _isDone;
            set
            {
                if (_isDone == value)
                    return;
                _isDone = value;
                App.Database.SaveTask(this);
            }
        }
        private bool _isDone = false;

        public Task(string taskTitle)
        {
            TaskTitle = taskTitle;
        }
        public Task() { }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
