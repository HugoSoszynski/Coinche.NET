using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoincheServer
{
    public class Lobby
    {
        public String name;
        private List<Player> players;

        public Lobby(String name) {
            this.name = name;
        }

        public void Broadcast(String msg)
        {
            foreach (var player in players) {

            }
        }

        public void Send(string msg, Player player) {

        }

        public void Treat(GeneralistProto proto, ref Player player){

        }

        public bool AddPlayer(ref Player player) {
            if (players.Count == 4) {
                player.sent("The lobby you try to join is already full.");
                return false;
            }
            if (players.Contains(player)) {
                player.sent("You already are in this lobby cunt.");
                return false;
            }
            players.Add(player);
            player.sent("You successfully join this lobby");
            return true;
        }

        public bool IsIn(Player player)
        {
            foreach (var inPlayer in players)
                if (inPlayer == player)
                    return true;
            return false;
        }
    }
}
