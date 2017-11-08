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
            players = new List<Player>();
        }

        public void Broadcast(String msg, ref Player player)
        {
            var list = players.ToArray();
            for (int i = 0; i < list.Length; ++i)
            {
                if (!list[i].Equals(player))
                    PlayerSession.BeginSend(ref list[i], player.Name + " said: " + msg);
            }
        }

        public void Send(string msg, Player player) {
            PlayerSession.BeginSend(ref player, msg);
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
            PlayerSession.BeginSend(ref player, "You succesfully change your name!!");
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
                PlayerSession.BeginSend(ref player, "You can't join a team, you are already in");
                return;
            }
            if (TeamFull(proto))
            {
                PlayerSession.BeginSend(ref player, "The time you are trying to joi is already full.");
                return;
            }
            player.Team = proto.Lobbycmd.Team;
            PlayerSession.BeginSend(ref player, "You join the team you wanted");
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
                        PlayerSession.BeginSend(ref player, "You can't send game order, because the game is not running atm");
                        return;
                    }
                    game.Treat(proto, ref player);
                    break;
            }
        }

        public bool AddPlayer(ref Player player) {
            if (players.Count == 4) {
                PlayerSession.BeginSend(ref player, "The lobby you try to join is already full.");
                return false;
            }
            if (players.Contains(player)) {
                PlayerSession.BeginSend(ref player, "You already are in this lobby dumbass.");
                return false;
            }
            players.Add(player);
            PlayerSession.BeginSend(ref player, "You successfully join this lobby");
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
