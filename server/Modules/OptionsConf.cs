using System;
using System.Collections.Generic;
using System.Text;
using server.Models;
using Newtonsoft;
using Newtonsoft.Json;
using System.Linq;

namespace server.Modules
{
    class OptionsConf
    {
        private Options _options;
        private BaseContext _context = new BaseContext();


        public OptionsConf()
        {
            _options = _context.Options.FirstOrDefault();
        }

        public string SetConf()
        {
            string json = JsonConvert.SerializeObject(_options);
            return json;
        }

    }
}
