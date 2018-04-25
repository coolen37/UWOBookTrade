﻿using SQLite;

namespace UWOBookTrade.Database {
    class UserTable {
        [PrimaryKey, AutoIncrement, Column("_Id")]
        public int Id { get; set; }

        [Unique]
        public string Email { get; set; }

        public string Password { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}