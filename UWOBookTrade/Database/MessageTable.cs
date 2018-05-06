using SQLite;

namespace UWOBookTrade.Database {
    class MessageTable {
        [PrimaryKey, AutoIncrement, Column("_Id")]
        public int MessageId { get; set; }

        public string Message { get; set; }

        public string User1 { get; set; }

        public string User2 { get; set; }

        public string DisplayName() {
            return User2;
        }

        public string DisplayMessage() {
            return Message;
        }
    }
}