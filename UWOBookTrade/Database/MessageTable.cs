using SQLite;

namespace UWOBookTrade.Database {
    class MessageTable {
        [PrimaryKey, AutoIncrement, Column("_Id")]
        public int MessageId { get; set; }

        public string Message { get; set; }
    }
}