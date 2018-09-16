using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using System.ComponentModel;

namespace client.Models
{
    public class Options : INotifyPropertyChanged
    {
        private string ipServer;
        private string portServer;
        private string ipDatabase;
        private string portDatabase;
        private string baseDatabase;
        private string nameDatabase;
        private string passwordDatabase;

        public int Id { get; set; }

        public string IpServer
        {
            get { return ipServer; }
            set
            {
                ipServer = value;
                OnPropertyChanged("IpServer");
            }
        }

        public string PortServer
        {
            get { return portServer; }
            set
            {
                portServer = value;
                OnPropertyChanged("PortServer");
            }
        }
        public string IpDatabase
        {
            get { return ipDatabase; }
            set
            {
                ipDatabase = value;
                OnPropertyChanged("IpDatabase");
            }
        }
        public string BaseDatabse
        {
            get { return baseDatabase; }
            set
            {
                baseDatabase = value;
                OnPropertyChanged("baseDatabase");
            }
        }
        public string PortDatabase
        {
            get { return portDatabase; }
            set
            {
                ipServer = value;
                OnPropertyChanged("portDatabase");
            }
        }
        public string NameDatabase
        {
            get { return nameDatabase; }
            set
            {
                ipServer = value;
                OnPropertyChanged("nameDatabase");
            }
        }
        public string PasswordDatabase
        {
            get { return passwordDatabase; }
            set
            {
                ipServer = value;
                OnPropertyChanged("PasswordDatabase");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = " ")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
