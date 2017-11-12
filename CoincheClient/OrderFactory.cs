using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CoincheClient {
    public class OrderFactory {

        private static readonly string[] keys = new string[] {
            "#CREATE",
            "#JOIN",
            "#LIST",
            "#USERNAME",
            "#TEAM",
            "#CARD",
            "#CONTRACT",
            "#HAND",
            "#EXIT"
        };

        private static GeneralistProto Create(string Order) {
            if (Order.Length < 8)
                return null;
            GeneralistProto proto = new GeneralistProto {
                Type = CmdTarget.Servercmd,
                Servercmd = new CServer {
                    Cmd = CServer.Types.Cmd.Create,
                    Value = Order.Substring(8)
                }
            };
            return proto;
        }

        private static GeneralistProto Join(string Order) {
            if (Order.Length < 6)
                return null;
            GeneralistProto proto = new GeneralistProto {
                Type = CmdTarget.Servercmd,
                Servercmd = new CServer {
                    Cmd = CServer.Types.Cmd.Join,
                    Value = Order.Substring(6)
                }
            };
            return proto;
        }

        private static GeneralistProto List(string Order) {
            GeneralistProto proto = new GeneralistProto {
                Type = CmdTarget.Servercmd,
                Servercmd = new CServer {
                    Cmd = CServer.Types.Cmd.Listing
                }
            };
            return proto;
        }

        private static GeneralistProto Username(string Order) {
            if (Order.Length < 10)
                return null;
            GeneralistProto proto = new GeneralistProto {
                Type = CmdTarget.Lobbycmd,
                Lobbycmd = new CLobby {
                    Cmd = CLobby.Types.Cmd.Username,
                    Value = Order.Substring(10)
                }
            };
            return proto;
        }

        private static GeneralistProto Team(string Order) {
            if (Order.Length < 6)
                return null;
            GeneralistProto proto = new GeneralistProto {
                Type = CmdTarget.Lobbycmd,
                Lobbycmd = new CLobby {
                    Cmd = CLobby.Types.Cmd.Team,
                    Team = (Order.Substring(6).Equals("BLUE")) ? CoincheClient.Team.Blue : CoincheClient.Team.Red
                }
            };
            return proto;
        }

        private static GeneralistProto Card(string Order) {
            if (Order.Length < 6)
                return null;
            GeneralistProto proto = new GeneralistProto {
                Type = CmdTarget.Gamecmd,
                Gamecmd = new CGame {
                    Cmd = CGame.Types.Cmd.Card,
                    Value = Order.Substring(6)
                }
            };
            return proto;
        }

        private static GeneralistProto Contract(string Order) {
            if (Order.Length < 10)
                return null;
            GeneralistProto proto = new GeneralistProto {
                Type = CmdTarget.Gamecmd,
                Gamecmd = new CGame {
                    Cmd = CGame.Types.Cmd.Contract,
                    Value = Order.Substring(10)
                }
            };
            return proto;
        }

        private static GeneralistProto Hand(string Order) {
            GeneralistProto proto = new GeneralistProto {
                Type = CmdTarget.Gamecmd,
                Gamecmd = new CGame {
                    Cmd = CGame.Types.Cmd.Hand
                }
            };
            return proto;
        }

        private static GeneralistProto Chat(string Order) {
            GeneralistProto proto = new GeneralistProto {
                Type = CmdTarget.Chat,
                Chat = new Chat {
                    Msg = Order
                }
            };
            return proto;
        }

        public static GeneralistProto Generate(string Order) {
            GeneralistProto Proto;

            string keyResult = keys.FirstOrDefault<string>(s => Order.Contains(s));
            switch (keyResult) {
                case "#CREATE":
                    Proto = Create(Order);
                    break;
                case "#JOIN":
                    Proto = Join(Order);
                    break;
                case "#LIST":
                    Proto = List(Order);
                    break;
                case "#USERNAME":
                    Proto = Username(Order);
                    break;
                case "#TEAM":
                    Proto = Team(Order);
                    break;
                case "#CARD":
                    Proto = Card(Order);
                    break;
                case "#CONTRACT":
                    Proto = Contract(Order);
                    break;
                case "#HAND":
                    Proto = Hand(Order);
                    break;
                case "#EXIT":
                    return null;
                default:
                    Proto = Chat(Order);
                    break;
            }
            return Proto;
        }
    }
}