using SQLite;

namespace AndroidApp6
{
    public class task
    {
        [PrimaryKey]
        public int id { get; set; }

        public string name { get; set; }

        public string description { get; set; }

        public string time { get; set; }

    }
}
