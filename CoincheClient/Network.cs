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
            IPAddress address = iPHostEntry.AddressList[0];
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
            State.Socket.Connect(EndPoint);
            State.Socket.BeginReceive(State.Buffer, 0, NetState.BufferSize, 0, new AsyncCallback(ReceiveCallback), State);
        }

        private static void ReceiveCallback(IAsyncResult ar)
        {
            try
            {
                NetState state = ar.AsyncState as NetState;
                int len = state.Socket.EndReceive(ar);

                if (len > 0)
                    Console.Out.WriteLine(Encoding.ASCII.GetString(state.Buffer, 0, len));
                state.Socket.BeginReceive(state.Buffer, 0, NetState.BufferSize, 0, new AsyncCallback(ReceiveCallback), state);
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e.ToString());
                throw;
            }
        }

        public void Send(ref GeneralistProto proto)
        {
            int len = CodedOutputStream.ComputeMessageSize(proto);
            var data = new byte[len];
            CodedOutputStream os = new CodedOutputStream(data);
            os.WriteMessage(proto);
            State.Socket.Send(data);
        }
    }
}
