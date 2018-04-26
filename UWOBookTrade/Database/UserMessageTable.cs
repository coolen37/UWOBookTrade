using SQLite;

namespace UWOBookTrade.Database {
    class UserMessageTable {
        [PrimaryKey, AutoIncrement, Column("_Id")]
        public int UserMessageId { get; set; }

        //Foreign Key
        public int User1Id { get; set; }

        //Foreign Key
        public int User2Id { get; set; }
    }
}