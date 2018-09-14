using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace server.Models
{
    class Options
    {
        [Key]
        public int Id { get; set; }
        public string IpServer { get; set; }
        public string PortServer { get; set; }
        public string IpDatabase { get; set; }
        public string PortDatabase { get; set; }
        public string BaseDatabase { get; set; }
        public string NameDatabase { get; set; }
        public string PasswordDatabasse { get; set; }
    }
}
