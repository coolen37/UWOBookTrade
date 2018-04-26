using SQLite;

namespace UWOBookTrade.Database {
    class UserBookTable {
        [PrimaryKey, AutoIncrement, Column("_Id")]
        public int UserBookId { get; set; }
        
        //Foreign Key
        public int UserId { get; set; }

        //Foreign Key
        public int BookId { get; set; }
    }
}