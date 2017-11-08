using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using Google.Protobuf;

namespace CoincheServer
{
    public class PlayerSession
    {
        public PlayerSession() { }

        public static void BeginRead(ref Player player)
        {
            var res = player.Socket.BeginReceive(
                player.buff, 
                0, 
                Player.BufferSize, 
                0, 
                new AsyncCallback(ReadCallback), 
                player
                );
            if (res.CompletedSynchronously)
                ReadCallback(res);
        }

        private static void ReadCallback(IAsyncResult ar)
        {
            try
            {
                Player player = ar.AsyncState as Player;
                int bytesRead = player.Socket.EndReceive(ar);
                Console.WriteLine("bytesRead = " + bytesRead.ToString());
                if (bytesRead > 0)
                {
                    byte[] tmp = new byte[bytesRead];
                    Array.Copy(player.buff, tmp, bytesRead);
                    GeneralistProto proto = GeneralistProto.Parser.ParseFrom(tmp);
                    // Send to proto to lobby manager
                }

                BeginRead(ref player);
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e.ToString());
                // Remove player
            }
        }

        public static void BeginSend(ref Player player, string data)
        {
            if (String.IsNullOrEmpty(data) || String.IsNullOrWhiteSpace(data))
                return;

            // Convert the string data to byte data using ASCII encoding.
            byte[] byteData = Encoding.ASCII.GetBytes(data);

            player.Socket.BeginSend(
                byteData,
                0,
                byteData.Length,
                0,
                new AsyncCallback(SendCallback),
                player
                );
        }

        private static void SendCallback(IAsyncResult ar)
        {
            try
            {
                Player player = ar.AsyncState as Player;
                if (player.Socket.EndSend(ar) <= 0)
                {
                    Console.Error.WriteLine("ERROR: Nothing was sent to the client.");
                    // Remove player
                }
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e.ToString());
                // Remove player
            }
        }
    }
}
