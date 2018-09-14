using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace client.Models
{
    class ConfigurationModel
    {
        public string IpServer { get; set; }
        public int PortServer { get; set; }
        public string IpDatabase { get; set; }
        public string PortDatabase { get; set; }
        public string BaseDatabase { get; set; }
        public string NameDatabase { get; set; }
        public string PasswordDatabasse { get; set; }
    }
}
