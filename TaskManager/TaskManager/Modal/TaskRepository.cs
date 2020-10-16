using SQLite;
using System.Collections.Generic;
using TaskManager.ViewModal;

namespace TaskManager.Modal
{
    public class TaskRepository
    {
        private SQLiteConnection _database;
        public TaskRepository(string databasePath)
        {
            _database = new SQLiteConnection(databasePath);
            _database.CreateTable<Task>();
        }
        public IEnumerable<Task> GetTasks()
        {
            return _database.Table<Task>().ToList();
        }
        public Task GetTask(int id) => _database.Get<Task>(id);
        public int DeleteTask(int id) => _database.Delete<Task>(id); 
        public int SaveTask(Task item)
        {
            if(item.Id != 0)
            {
                _database.Update(item);
                return item.Id;
            }
            else
            {
                return _database.Insert(item);
            }
        }

    }
}
