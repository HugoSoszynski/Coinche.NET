using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoincheClient
{
    class Program
    {
        private static void StartInteraction(ref AsyncClient client) {
            string Order;
            while (true) {
                GeneralistProto proto;

                Order = Console.In.ReadLine();
                proto = OrderFactory.Generate(Order);
                if (proto == null)
                    return;
                client.Send(ref proto);
            }
        }

        private static void ConnectAndStart() {
            Console.Out.WriteLine("Please insert your name, you little peace of shit:");
            var name = Console.In.ReadLine();
            AsyncClient client = new AsyncClient("localhost", 42000);
            client.Start();
            GeneralistProto proto = new GeneralistProto {
                Type = CmdTarget.Authentification,
                Auth = new Authentification {
                    Name = name
                },
                //optional timestamp
            };
            client.Send(ref proto);
            StartInteraction(ref client);
        }

        static void Main(string[] args)
        {
            Console.Out.WriteLine("Hello, welcome to Coinche.NET");
            try {
                ConnectAndStart();
            } catch (Exception e) {
                Console.Error.WriteLine(e.Message);
            }
        }
    }
}
