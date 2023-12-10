
namespace AndroidApp6
{
    public partial class App : Application
    {
        private static DB db;

        public static DB Db
        {
            get
            {
                if (db == null)
                {
                    db = new DB(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "task.db"));
                }
                return db;
            }
        }
    }
}
