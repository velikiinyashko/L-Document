using System;
using System.Collections.Generic;
using System.Text;
using server.Models;
using Newtonsoft;
using Newtonsoft.Json;

namespace server.Modules
{
    class Logger<T> where T :  class
    {
        private T _log { get; set; }
        private BaseContext _context = null;
        private string _logMessage;
        private Logging _logging { get; set; }

        public Logger()
        {
            
        }

        public void WriteLog(DateTime dateTime, T Log)
        {
            _log = Log;
            _logMessage = JsonConvert.SerializeObject(Log);
            _logging = new Logging { Date = dateTime, Message = _logMessage };
            _context.Loggings.Add(_logging);
            _context.SaveChanges();
        }

    }
}
