using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace SQliteLappolainen
{
    [Table("Friends")]
    public class Friend
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Opis { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}
