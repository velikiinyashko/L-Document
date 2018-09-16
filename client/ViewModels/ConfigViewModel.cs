using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft;
using Newtonsoft.Json;
using client.Models;

namespace client.ViewModels
{
    class ConfigViewModel
    {
        //private OptionsConf _conf;
        private int _listenPort { get; set; }
        private byte[] _bytes { get; set; }
        private IPAddress _IPEnd { get; set; }
        //private Queue<IPAddress> _queues;

        public ConfigViewModel(int Port)
        {
            _listenPort = Port;
            //_conf = new OptionsConf();
            //_queues = new Queue<IPAddress>();
        }

        public void StartListener()
        {
            UdpClient Listener = new UdpClient(_listenPort);
            IPEndPoint GroupEP = new IPEndPoint(IPAddress.Any, _listenPort);

            try
            {
                _bytes = Listener.Receive(ref GroupEP);
                string Message = Encoding.ASCII.GetString(_bytes, 0, _bytes.Length);
                _IPEnd = GroupEP.Address;

                while (_bytes != null)
                {
                    Options options = JsonConvert.DeserializeObject<Options>(Message);
                    BaseContext context = new BaseContext();
                    context.Options.Add(options);
                    context.SaveChanges();
                    _bytes = null;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} \n {1}", e.TargetSite, e.Message);

            }
            finally
            {
                Listener.Close();
            }
        }

        public void ReturnConfig()
        {
            Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            IPAddress Broadcast = IPAddress.Broadcast;

            byte[] SendBuf = Encoding.ASCII.GetBytes("L-Document");
            IPEndPoint ep = new IPEndPoint(Broadcast, 9944);
            s.SendTo(SendBuf, ep);

            StartListener();

        }
    }
}
