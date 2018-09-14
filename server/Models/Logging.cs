using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;


namespace server.Models
{
    class Logging
    {
        [Key]
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string LevelLog { get; set; }
        public string Event { get; set; }
        public string NameMethod { get; set; }
        public string Message { get; set; }
    }
}
