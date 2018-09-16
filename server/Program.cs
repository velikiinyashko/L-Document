using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using server.Models;
using server.Modules;
using System.Threading;

namespace server
{
    class Program
    {
        static void Main(string[] args)
        {
            BaseContext context = new BaseContext();

            context.Database.EnsureCreated();

            Console.WriteLine("start Server L-Document");

            Console.WriteLine("Waiting for client");
            ListenetUPD listenet = new ListenetUPD(9944);

            //listenet.StartListener();
            Thread ReceiveThread = new Thread(new ThreadStart(listenet.StartListener));
            ReceiveThread.Start();
            //listenet.ReturnConfig();
            Console.ReadKey();

        }
    }
}
