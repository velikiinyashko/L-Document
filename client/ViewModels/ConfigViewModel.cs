﻿using System;
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
    class ConfigViewModel : IDisposable
    {
        private byte[] _buffer = null;
        private int _listenPort { get; set; }
        private UdpClient _client = null;
        private bool _furtStart;
        private BaseContext _context = null;
        private Options _options;

        public ConfigViewModel(int Port, bool FurstStart)
        {
            _listenPort = Port;
            _furtStart = FurstStart;
            _context = new BaseContext();
        }

        public void ListenerUDP()
        {
            _client = new UdpClient(_listenPort);
            IPEndPoint IPEnd = new IPEndPoint(IPAddress.Any, _listenPort);
            while (_furtStart)
            {
                _buffer = _client.Receive(ref IPEnd);
                if (_buffer != null)
                {
                    string Message = Encoding.UTF8.GetString(_buffer, 0, _buffer.Length);
                    _options = JsonConvert.DeserializeObject<Options>(Message);
                    _context.Options.Add(_options);
                    _context.SaveChanges();
                }
            }
        }

        public void SendBroadcastUDP(string Message, string IpBradcast = "192.168.0.255")
        {
            Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            byte[] SendBuffer = Encoding.UTF8.GetBytes(Message);
            IPAddress IpBroad = IPAddress.Parse(IpBradcast);
            IPEndPoint IpEnd = new IPEndPoint(IpBroad, _listenPort);
            s.SendTo(SendBuffer, IpEnd);
        }

        public void Dispose()
        {
            _client = null;
            _context = null;
            _options = null;
            _buffer = null;
        }
    }
}
