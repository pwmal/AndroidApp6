using SQLite;

namespace AndroidApp6
{
    public class DB
    {

        private readonly SQLiteConnection conn;

        public DB(string path)
        {
            conn = new SQLiteConnection(path);
            conn.CreateTable<task>();
        }

        public List<task> GetAll()
        {
            return conn.Table<task>().ToList();
        }

        public int Save(task item)
        {
            return conn.Insert(item);
        }

        public int Delete(task item)
        {
            return conn.Delete(item);
        }

        public void DeleteById(int id)
        {
            List<task> tasks = App.Db.GetAll();
            for (int i = 0; i < tasks.Count; i++)
            {
                if (tasks[i].id == id)
                {
                    App.Db.Delete(tasks[i]);
                }
            }
        }

        public int Update(task item)
        {
            return conn.Update(item);
        }
    }
}
