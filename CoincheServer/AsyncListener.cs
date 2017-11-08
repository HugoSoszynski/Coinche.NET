using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace CoincheServer
{
    public class AsyncListener
    {
        public static ManualResetEvent acceptConnection = new ManualResetEvent(false);

        public AsyncListener() { }

        public static void Start()
        {
            byte[] buff = new byte[1024];
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Any, 42000);
            Socket listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            try
            {
                listener.Bind(endPoint);
                listener.Listen(100);

                for (;;)
                {
                    acceptConnection.Reset();
                    listener.BeginAccept(new AsyncCallback(AcceptCallback), listener);
                    acceptConnection.WaitOne();
                }
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e.ToString());
            }
        }

        private static void AcceptCallback(IAsyncResult ar)
        {
            // Signal we can accept another connection
            acceptConnection.Set();

            Console.WriteLine("New connection");

            Socket listener = ar.AsyncState as Socket;
            Socket client = listener.EndAccept(ar);

            Player player = new Player(ref client);
            PlayerSession.BeginRead(ref player);
        }
    }
}
