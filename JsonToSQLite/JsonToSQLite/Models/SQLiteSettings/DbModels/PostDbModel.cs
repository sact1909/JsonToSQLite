using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace JsonToSQLite.Models.SQLiteSettings.DbModels
{
    
    public class PostDbModel
    {
        [PrimaryKey, AutoIncrement]
        public int UserId { get; set; }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
    }
}
