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
        private Game game;

        public Lobby(String name) {
            this.name = name;
            game = null;
        }

        public void Broadcast(String msg, ref Player player)
        {
            foreach (var inPlayer in players) {
                if (!inPlayer.Equals(player))
                    inPlayer.sent(player.Name + " has said: " + msg);
            }
        }

        public void Send(string msg, Player player) {
            player.sent(msg);
        }

        private void LobbyCmd(ref Player player, GeneralistProto proto) {
            switch (proto.Lobbycmd.Cmd) {
                case CLobby.Types.Cmd.Team:
                    JoinningTeam(ref player, proto);
                    break;
                case CLobby.Types.Cmd.Username:
                    ChangingUsername(ref player, proto);
                    break;
            }
        }

        private void ChangingUsername(ref Player player, GeneralistProto proto) {
            player.Name = proto.Lobbycmd.Value;
            player.sent("You succesfully change your name!!");
        }

        private Boolean TeamFull(GeneralistProto proto)
        {
            int cpt = 0;
            foreach (var player in players)
            {
                if (proto.Lobbycmd.Team == player.Team)
                    ++cpt;
            }
            if (cpt == 2)
                return true;
            return false;
        }

        private void JoinningTeam(ref Player player, GeneralistProto proto) {
            if (player.Team == proto.Lobbycmd.Team)
            {
                player.sent("You can't join a team, you are already in");
                return;
            }
            if (TeamFull(proto))
            {
                player.sent("The time you are trying to joi is already full.");
                return;
            }
            player.Team.set(proto.Lobbycmd.Team);
            player.sent("You join the team you wanted");
            // can do here the check if we should launch the game

        }

        public void Treat(GeneralistProto proto, ref Player player){
            switch (proto.Type) {
                case CmdTarget.Chat:
                    Broadcast(proto.Chat.Msg, ref player);
                    break;
                case CmdTarget.Lobbycmd:
                    LobbyCmd(ref player, proto);
                    break;
                case CmdTarget.Gamecmd:
                    if (this.game == null) {
                        player.sent("You can't send game order, because the game is not running atm");
                        return;
                    }
                    game.Treat(proto, ref player);
                    break;
            }
        }

        public bool AddPlayer(ref Player player) {
            if (players.Count == 4) {
                player.sent("The lobby you try to join is already full.");
                return false;
            }
            if (players.Contains(player)) {
                player.sent("You already are in this lobby dumbass.");
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
