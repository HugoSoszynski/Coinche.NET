using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace CoincheServer
{
    enum Team {
        BLUE = 0,
        RED = 1,
        NONE = 3
    }

    public class Player
    {
        public Socket Socket { get; }
        public const int BufferSize = 4096;
        public byte[] buff = new byte[BufferSize];
        public string Name { get; set; }
        public Team Team { get; set; }

        public Player(ref Socket socket)
        {
            this.Socket = socket;
        }

        ~Player()
        {
            this.Socket.Shutdown(SocketShutdown.Both);
            this.Socket.Close();
        }
    }
}
