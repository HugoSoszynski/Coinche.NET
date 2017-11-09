using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoincheServer
{
    public class Game
    {
        List<Player> players;
        List<Card> deck;
        List<PlayedCard> turn = new List<PlayedCard>();
        Group red = new Group();
        Group blue = new Group();


        public Game(ref List<Player> players) {
            this.players = players;
            Broadcast("The game is create it will start in seconds");
            var list = players.ToArray();
            for (int i = 0; i < list.Length; ++i) {
                if (list[i].Team == Team.Blue)
                    blue.AddPlayer(ref list[i]);
                else
                    red.AddPlayer(ref list[i]);
            }
            blue.player1.starter = true;
            generateDeck();
            Broadcast("Command you can use for the game:\n" + 
                    "#CARD [CardName] [CardColor] - Play a card of name [CardName] and color [CardColor]\n" +
                    "#HAND - Shows your hand.\n" +
                    "#CONTRACT [ContractColor] [ContractValue] - Posting a contract on the turn.\n" +
                    "Contract can be: [Spades] | [Hearts] | [Diamonds] | [Clubs] | [AllTrumps] | [NoTrumps] | [Pass]\n\n");
            this.Run();
        }

        private void Run() {
            DistribCard();
            for (int i = 0; i < 4; ++i)
                turn.Add(new PlayedCard());
            turn.ElementAt(0).player =  blue.player1;
            turn.ElementAt(0).orderPlay = 0;
            turn.ElementAt(1).player = red.player1;
            turn.ElementAt(1).orderPlay = 1;
            turn.ElementAt(2).player = blue.player2;
            turn.ElementAt(2).orderPlay = 2;
            turn.ElementAt(3).player = red.player2;
            turn.ElementAt(3).orderPlay = 3;
            PlayerSession.BeginSend(ref blue.player1, "You are the first to play, it's your turn to put a contract on.");
        }

        public void DistribCard() {
            givenCard(3, ref blue.player1);
            givenCard(3, ref blue.player2);
            givenCard(3, ref red.player1);
            givenCard(3, ref red.player2);
            givenCard(2, ref blue.player1);
            givenCard(2, ref blue.player2);
            givenCard(2, ref red.player1);
            givenCard(2, ref red.player2);
            givenCard(3, ref blue.player1);
            givenCard(3, ref blue.player2);
            givenCard(3, ref red.player1);
            givenCard(3, ref red.player2);
        }

        public void givenCard(int number, ref Player player) {
            string str;
            int ret;
            Random rnd = new Random();


            str = "You recieved ";
            ret = rnd.Next(0, deck.Count);
            for (int i = 0; i < number; i++) {
                player.hand.Add(deck.ElementAt(ret));
                str += Card._names[(int)this.deck.ElementAt(ret).face] + " " + Card._colors[(int)this.deck.ElementAt(ret).color];
                this.deck.RemoveAt(ret);
            }
            PlayerSession.BeginSend(ref player, str);
        }

        private void generateDeck() {
            for (int i = 0; i <= 4; ++i)
                for (int j = 0; j <= 7; ++j)
                    deck.Add(new Card((Card.Face)j, (Card.Color)i));

            // debug print

            foreach(Card card in deck) {
                System.Console.Out.WriteLine("all deck:");
                System.Console.Out.WriteLine(Card._names[(int)card.face] + " " + Card._colors[(int)card.color]);
            }

            // --END--
        }

        private void Broadcast(string msg) {
            var list = players.ToArray();
            for (int i = 0; i < list.Length; ++i) {
                PlayerSession.BeginSend(ref list[i], msg);
            }
        }

        public void Treat(GeneralistProto proto, ref Player player) {
            switch (proto.Gamecmd.Cmd) {
                case CGame.Types.Cmd.Contract:
                    Contract(proto, ref player);
                    break;
                case CGame.Types.Cmd.Card:
                    PlayCard(proto, ref player);
                    break;
                case CGame.Types.Cmd.Hand:
                    Hand(proto, ref player);
                    break;
                    
            }        
        }

        public void Contract(GeneralistProto proto, ref Player player) {

        }

        public void PlayCard(GeneralistProto proto, ref Player player) {

        }

        public void Hand(GeneralistProto proto, ref Player player) {

        }

    }
}
