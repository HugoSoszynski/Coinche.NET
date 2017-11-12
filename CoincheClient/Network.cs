using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Google.Protobuf;

namespace CoincheClient
{
    public class NetState
    {
        public Socket Socket = null;
        public const int BufferSize = 4096;
        public byte[] Buffer = new byte[BufferSize];
    }
    public class AsyncClient
    {
        public IPEndPoint EndPoint { get; private set; }
        private NetState State;

        public AsyncClient(string host, int port)
        {
            IPHostEntry iPHostEntry = Dns.GetHostEntry(host);
            IPAddress address = iPHostEntry.AddressList[1];
            this.EndPoint = new IPEndPoint(address, port);
            State = new NetState();
            State.Socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }

        ~AsyncClient()
        {
            if (State.Socket != null)
            {
                State.Socket.Shutdown(SocketShutdown.Both);
                State.Socket.Close();
            }
        }

        public void Start()
        {
            try
            {
                State.Socket.Connect(EndPoint);
                State.Socket.BeginReceive(State.Buffer, 0, NetState.BufferSize, 0, new AsyncCallback(ReceiveCallback), State);
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e.ToString());
                Environment.Exit(84);
            }
        }

        private static void ReceiveCallback(IAsyncResult ar)
        {
            try
            {
                NetState state = ar.AsyncState as NetState;
                int len = state.Socket.EndReceive(ar);

                if (len > 0)
                {
                    Console.Out.Write(Encoding.ASCII.GetString(state.Buffer, 0, len));
                    state.Socket.BeginReceive(state.Buffer, 0, NetState.BufferSize, 0, new AsyncCallback(ReceiveCallback), state);
                }
                else
                {
                    Console.Out.WriteLine("You have been disconected from the server. Exiting.");
                    Console.Out.WriteLine("Press ENTER to quit...");
                    Console.ReadLine();
                    Environment.Exit(84);
                }
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e.ToString());
                Console.Out.WriteLine("You have been disconected from the server. Exiting.");
                Console.Out.WriteLine("Press ENTER to quit...");
                Console.ReadLine();
                Environment.Exit(84);
            }
        }

        public void Send(ref GeneralistProto proto)
        {
            try
            {
                var data = proto.ToByteArray();
                State.Socket.Send(data);
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e.ToString());
                Environment.Exit(84);
            }
        }
    }
}
