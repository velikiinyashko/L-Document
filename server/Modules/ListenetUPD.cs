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

        public ListenetUPD(int Port)
        {
            _listenPort = Port;
            _conf = new OptionsConf();
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

                    Console.WriteLine("Received broadcast from {0} :\n {1}\n",
                        GroupEP.Address,
                        Encoding.ASCII.GetString(_bytes, 0, _bytes.Length));
                    _IPEnd = GroupEP.Address;
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
            //Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

            //byte[] SendBuf = Encoding.ASCII.GetBytes(_conf.SetConf());
            //IPEndPoint ep = new IPEndPoint(_IPEnd, 9944);
            //s.SendTo(SendBuf, ep);
            //Console.WriteLine(_conf.SetConf());
            UdpClient client = new UdpClient();
            try
            {
                while (true)
                {
                    if (_IPEnd != null)
                    {
                        _bytes = Encoding.UTF8.GetBytes(_conf.SetConf());
                        client.Send(_bytes, _bytes.Length, _IPEnd.ToString(), _listenPort);
                        Console.WriteLine(_conf.SetConf());
                    }
                }
            }
            catch(Exception e)
            {
                Console.WriteLine("{0} \n {1}", e.TargetSite, e.Message);
            }
            finally
            {
                client.Close();
            }
        }
    }
}
