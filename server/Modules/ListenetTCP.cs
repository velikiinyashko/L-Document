using System;
using System.Collections.Generic;
using System.Text;
using server.Models;
using System.Net;
using System.Net.Sockets;

namespace server.Modules
{
    class ListenetTCP
    {
        private TcpListener _server = null;
        private TcpClient _client = null;
        private int _listenPort { get; set; }
        private IPAddress _ipServer { get; set; }
        private byte[] _buffer { get; set; }
        private string _data { get; set; }

        public ListenetTCP(int Port)
        {
            _ipServer = IPAddress.Any;
            _listenPort = Port;
            _server = new TcpListener(_ipServer, _listenPort);
        }

        public void ListenetStart()
        {
            _server.Start();

            while (true)
            {
                Console.WriteLine("Waiting connection...");
                _client = _server.AcceptTcpClient();
                NetworkStream stream = _client.GetStream();
                int i;
                while((i = stream.Read(_buffer, 0, _buffer.Length)) != 0)
                {
                    _data = Encoding.UTF8.GetString(_buffer, 0, i);
                }
            }
        }
    }
}
