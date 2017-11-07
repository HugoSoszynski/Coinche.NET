using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoincheServer
{
    public class LobbyManager
    {
        private List<Player> players;
        private List<Lobby> lobbies;

        public LobbyManager() { }

        public void Treat (ref Player player, GeneralistProto proto) {

            switch (proto.Type) {
                case CmdTarget.Authentification:
                    Auth(ref player, proto);
                    break;
                case CmdTarget.Servercmd:
                    ServerCmd(ref player, proto);
                    break;
                default:
                    FindLobbyAndTreat(ref player, proto);
                    break;
            }
        }

        private void Auth(ref Player player, GeneralistProto proto) {
            player.Name = proto.Auth.Name;
            player.Team = Team.NONE;
            players.Add(player);
        }

        private void ServerCmd(ref Player player, GeneralistProto proto) {
            switch (proto.Servercmd.Cmd) {
                case CServer.Types.Cmd.Listing:
                    LobbiesListing(ref player);
                    break;
                case CServer.Types.Cmd.Join:
                    LobbyJoinning(ref player, proto);
                    break;
                case CServer.Types.Cmd.Create:
                    LobbyCreating(ref player, proto);
                    break;
            }
        }

        private void LobbyCreating(ref Player player, GeneralistProto proto) {
            foreach (var lobby in lobbies)
                if (lobby.name.Equals(proto.Servercmd.Value)) {
                    player.sent("A lobby already exist with this name");
                    return;
                }
            Lobby newlobby = new Lobby(proto.Servercmd.Value);
            player.sent("You successfully great your lobby");
            lobbies.Add(newlobby);
            newlobby.AddPlayer(ref player);
        }

        private void LobbyJoinning(ref Player player, GeneralistProto proto) {
            foreach (var lobby in lobbies) {
                if (lobby.name.Equals(proto.Servercmd.Value)) {
                    if (lobby.AddPlayer(ref player)) {
                        players.Remove(player);
                    }
                    return;
                }
            }
            player.sent("The lobby you tried to join doesn't exist, type the command #LIST to see all the lobby");
        }

        private void LobbiesListing(ref Player player)
        {
            player.sent("Actual lobbies are :\n");
            foreach (var lobby in lobbies) {
                player.sent("Lobby: " + lobby.name);
            }
        }

        private void FindLobbyAndTreat(ref Player player, GeneralistProto proto) {
            Lobby lobby = FindLobby(ref player);
            if (lobby == null) {
                player.sent("You can't sent that type of cmd till now");
                return;
            }
            lobby.Treat(proto, ref player);
        }

        private Lobby FindLobby(ref Player player)
        {
            foreach (var lobby in lobbies)
            {
                if (lobby.IsIn(player))
                    return lobby;
            }
            return null;
        }
    }
}
