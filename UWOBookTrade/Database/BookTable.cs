using SQLite;

namespace UWOBookTrade.Database {
    class BookTable {
        [PrimaryKey, AutoIncrement, Column("_Id")]
        public int BookId { get; set; }

        public string BookTitle { get; set; }

        public string Author { get; set; }

        public string ISBN { get; set; }

        public string Price { get; set; }
        
        public byte[] Image { get; set; }

        public override string ToString() {
            return BookId + "\n" + Price + "\n" + BookTitle + ": " + Author + "\n" + ISBN;
        }
    }
}