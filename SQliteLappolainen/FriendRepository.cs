using System.Collections.Generic;
using System.Linq;
using SQLite;
using Xamarin.Forms;

namespace SQliteLappolainen
{
    public class  FriendRepository
    {
        SQLiteConnection database;
        //static object locker = new object();
        public FriendRepository(string filename)
        {
            string databasePath = DependencyService.Get<ISQLite>().GetDatabasePath(filename);
            database = new SQLiteConnection(databasePath);
            database.CreateTable<Friend>();
        }
        public IEnumerable<Friend> GetItems()
        {
            return (from i in database.Table<Friend>() select i).ToList();// Вставить в таблицу

        }
        public Friend GetItem(int id)
        {
            return database.Get<Friend>(id);
        }
        public int DeleteItem(int id) //удаляем
        {
            //lock (locker)
            {
                return database.Delete<Friend>(id);
            }
        }
        public int SaveItem(Friend item) // сохраняем
        {
            if (item.Id != 0)
            {
                database.Update(item);
                return item.Id;
            }
            else
            {
                return database.Insert(item);
            }
        }
    }
}
