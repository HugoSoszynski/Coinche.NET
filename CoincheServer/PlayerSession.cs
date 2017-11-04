using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace CoincheServer
{
    class PlayerSession
    {
        #region Attributes
        private NetworkStream _Stream { get; set; }
        public NetworkStream Stream { get { return _Stream; } }
        public string Name
        {
            get { return Name; }
            set
            {
                if (!String.IsNullOrEmpty(value) && !String.IsNullOrWhiteSpace(value))
                    Name = value;
            }
        }
        #endregion

        #region Constructor
        public PlayerSession(ref Socket sock)
        {
            _Stream = new NetworkStream(sock);
        }
        #endregion

        #region Operators
        public static bool operator ==(PlayerSession lhs, PlayerSession rhs)
        {
            return lhs.Stream.Equals(rhs.Stream);
        }
        public static bool operator !=(PlayerSession lhs, PlayerSession rhs)
        {
            return !lhs.Stream.Equals(rhs.Stream);
        }
        #endregion

        #region Network Interactions
        
        #endregion
    }
}
