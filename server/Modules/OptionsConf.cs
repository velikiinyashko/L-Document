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
        private BaseContext _context;


        public OptionsConf()
        {

        }

        public string SetConf()
        {
            using (_context = new BaseContext())
            {
                _options = _context.Options.FirstOrDefault();
                string json = JsonConvert.SerializeObject(_options);
                return json;
            }
        }

    }
}
