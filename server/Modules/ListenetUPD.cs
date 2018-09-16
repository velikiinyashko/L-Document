using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace server.Modules
{
    class ListenetUPD
    {
        private OptionsConf _conf;
        private int _listenPort { get; set; }
        private byte[] _bytes { get; set; }
        private IPAddress _IPEnd { get; set; }
        private Queue<IPAddress> _queues;

        public ListenetUPD(int Port)
        {
            _listenPort = Port;
            _conf = new OptionsConf();
            _queues = new Queue<IPAddress>();
        }

        public void StartListener()
        {
            UdpClient Listener = new UdpClient(_listenPort);
            IPEndPoint GroupEP = new IPEndPoint(IPAddress.Any, _listenPort);

            try
            {
                while (true)
                {
                    _bytes = Listener.Receive(ref GroupEP);
                    string Message = Encoding.ASCII.GetString(_bytes, 0, _bytes.Length);
                    _IPEnd = GroupEP.Address;

                    Console.WriteLine("{0} \\ Received broadcast from {1} :\n {2}\n", DateTime.Now, _IPEnd, Message);
                    while (_bytes != null)
                    {
                        ReturnConfig();
                        _bytes = null;
                    }
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
            string Message = _conf.SetConf();
            byte[] SendBuf = Encoding.ASCII.GetBytes(Message);
            IPEndPoint ep = new IPEndPoint(_IPEnd, 9944);
            s.SendTo(SendBuf, ep);
            Console.WriteLine(Message);
        }
    }
}
