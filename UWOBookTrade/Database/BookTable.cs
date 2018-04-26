using SQLite;

namespace UWOBookTrade.Database {
    class BookTable {
        [PrimaryKey, AutoIncrement, Column("_Id")]
        public int BookId { get; set; }

        public string BookTitle { get; set; }

        public string Author { get; set; }

        [Unique]
        public string ISBN { get; set; }

        public string Class { get; set; }

        public byte[] Image { get; set; }
    }
}