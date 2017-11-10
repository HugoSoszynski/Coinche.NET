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
        List<Card> deck = new List<Card>();
        List<PlayedCard> turn = new List<PlayedCard>();
        Group red = new Group();
        Group blue = new Group();
        CGame.Types.Cmd isWaited = CGame.Types.Cmd.Contract;
        private int hasToPlay = 0;
        private Contract _contract = null;
        public bool isOver = false;


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
            for (int i = 0; i < number; i++) {
                ret = rnd.Next(0, deck.Count);
                player.hand.Add(deck.ElementAt(ret));
                str += Card._names[(int)this.deck.ElementAt(ret).face] + " " + Card._colors[(int)this.deck.ElementAt(ret).color] + " ";
                this.deck.RemoveAt(ret);
            }
            PlayerSession.BeginSend(ref player, str + "\n");
        }

        private void generateDeck() {
            for (int i = 0; i < 4; ++i)
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

        private bool HisTurn(ref Player player) {
            foreach (PlayedCard card in turn)
                if (card.orderPlay == this.hasToPlay)
                    if (card.player.Equals(player))
                        return true;
            return false;
        }

        private Player GetToPlay() {
            foreach (PlayedCard card in turn)
                if (card.orderPlay == this.hasToPlay)
                    return card.player;
            return null;
        }

        public static string[] _contracts = new string[] {
            "Spades",
            "Clubs",
            "Hearts",
            "Diamonds",
            "AllTrumps",
            "NoTrumps"
        };

        public Contract getFromCmd(ref Player player, GeneralistProto proto) {
            int index = -1;

            for (int i = 0; i < _contracts.Length; ++i) {
                if (proto.Gamecmd.Value.Split(' ')[0].Equals(_contracts[i]))
                    index = i;
            }
            if (index == -1)
                throw new Exception("Can't find your contract on the possibility");
            int scale = Int32.Parse(proto.Gamecmd.Value.Split(' ')[1]);

            // DEBUG -- PRINT
            System.Console.Out.WriteLine("Contract: " + _contracts[index] + "value of " + scale);
            //

            Contract contract = new Contract((CoincheServer.Contract.ContractType)index, scale, 1, player.Team);
            return contract;
        }

        public void NewContract(ref Player player, ref Contract contract) {
            if (this._contract == null) {
                this._contract = contract;
                return;
            }
            if (this._contract.team == player.Team)
                throw new Exception("You can't put an contract on your proper team bet.");
            if (this._contract.scale >= contract.scale)
                throw new Exception("You can't do a bet inferior to the one already etablished.");
            if (this._contract.coinche > 1)
                throw new Exception("You can't make a new contract on a coinche contract.");
            this._contract = contract;
        }

        private void TurnStarter() {
            turn.ElementAt(0).orderPlay = (turn.ElementAt(0).orderPlay + 1) % 4;
            turn.ElementAt(1).orderPlay = (turn.ElementAt(0).orderPlay + 1) % 4;
            turn.ElementAt(2).orderPlay = (turn.ElementAt(0).orderPlay + 1) % 4;
            turn.ElementAt(3).orderPlay = (turn.ElementAt(0).orderPlay + 1) % 4;
        }

        private void NextTurn() {
            deck.AddRange(blue.stack);
            deck.AddRange(red.stack);
            deck.AddRange(blue.player1.hand);
            deck.AddRange(blue.player2.hand);
            deck.AddRange(red.player1.hand);
            deck.AddRange(red.player2.hand);
            blue.stack.Clear();
            red.stack.Clear();
            blue.player1.hand.Clear();
            blue.player2.hand.Clear();
            red.player1.hand.Clear();
            red.player2.hand.Clear();
            DistribCard();
            TurnStarter();
            Player p = GetToPlay();
            PlayerSession.BeginSend(ref p, "You are the first to play, it's your turn to put a contract on.");
        }

        private PlayedCard getFirstPlayed() {
            foreach (PlayedCard card in turn)
                if (card.orderPlay == 0)
                    return (card);
            return null;
        }

        private PlayedCard GetHigherCardAllTrump() {
            PlayedCard winner = getFirstPlayed();

            foreach (PlayedCard played in turn)
                if (played != winner)
                    if (played.card.color == winner.card.color)
                        if (Card._scores[(int)played.card.face][(int)Card.Type.AllTrumps] > Card._scores[(int)winner.card.face][(int)Card.Type.AllTrumps])
                            winner = played;
            return winner;
        }

        private PlayedCard GetHigherCardNoTrump() {
            PlayedCard winner = getFirstPlayed();

            foreach (PlayedCard played in turn)
                if (played != winner)
                    if (played.card.color == winner.card.color)
                        if (Card._scores[(int)played.card.face][(int)Card.Type.NoTrumps] > Card._scores[(int)winner.card.face][(int)Card.Type.NoTrumps])
                            winner = played;
            return winner;
        }

        private bool HereIsTrump() {
            foreach (PlayedCard card in turn)
                if ((int)card.card.color == (int)_contract.type)
                    return true;
            return false;
        }

        private PlayedCard GetHigherCard() {
            PlayedCard winner = null;

            if (!HereIsTrump())
                return GetHigherCardNoTrump();
            foreach (PlayedCard card in turn) {
                if ((int)card.card.color == (int)_contract.type)
                    if (winner == null || Card._scores[(int)card.card.face][(int)Card.Type.OneTrump] > Card._scores[(int)winner.card.face][(int)Card.Type.OneTrump])
                        winner = card;
            }
            return winner;
        }

        private void ConcludeTurn() {
            PlayedCard winner = null;

            Broadcast("The contract is: " + _contracts[(int)_contract.type]);
            Broadcast("Played card are: ");
            foreach (PlayedCard card in turn)
                Broadcast(card.player.Name + " played " + Card._names[(int)card.card.face] + " " + Card._colors[(int)card.card.color] + "\n");

            switch (_contract.type) {
                case CoincheServer.Contract.ContractType.Clubs:
                case CoincheServer.Contract.ContractType.Spades:
                case CoincheServer.Contract.ContractType.Hearts:
                case CoincheServer.Contract.ContractType.Diamonds:
                    winner = GetHigherCard();
                    break;
                case CoincheServer.Contract.ContractType.NoTrumps:
                    winner = GetHigherCardNoTrump();
                    break;
                case CoincheServer.Contract.ContractType.AllTrumps:
                    winner = GetHigherCardAllTrump();
                    break;
            }

            Broadcast(winner.player.Name + " won this turn");
            while (winner.orderPlay != 0)
                foreach (PlayedCard played in turn)
                    played.orderPlay = (played.orderPlay + 1) % 4;

            if (winner.player.Team == Team.Blue)
                foreach (PlayedCard card in turn)
                    blue.stack.Add(card.card);
            else
                foreach (PlayedCard card in turn)
                    red.stack.Add(card.card);

            // Debug

            System.Console.Out.WriteLine("Blue has: " + blue.stack.Count);
            System.Console.Out.WriteLine("Red has: " + red.stack.Count);

            //

            turn.ElementAt(0).card = null;
            turn.ElementAt(1).card = null;
            turn.ElementAt(2).card = null;
            turn.ElementAt(3).card = null;
        }

        public void Contract(GeneralistProto proto, ref Player player) {
            if (this.isWaited != CGame.Types.Cmd.Contract) {
                PlayerSession.BeginSend(ref player, "It's not the time to put a contract up.");
                return;
            }
            if (!HisTurn(ref player)) {
                PlayerSession.BeginSend(ref player, "Please wait your turn to do a contract.");
                return;
            }
            PlayerSession.BeginSend(ref player, "We are taking into count your contract");
            try {
                Contract contract = getFromCmd(ref player, proto);
                try {
                    NewContract(ref player, ref contract);
                    Broadcast(player.Name + " has put a contract on " + _contracts[(int)contract.type] + " of value " + contract.scale);
                } catch (Exception e) {
                    PlayerSession.BeginSend(ref player, e.Message);
                    return;
                }
            } catch (Exception e) {
                System.Console.Error.WriteLine(e.Message);
                if (proto.Gamecmd.Value.Split(' ')[0].Equals("Coinche")) {
                    if (_contract == null) {
                        PlayerSession.BeginSend(ref player, "You can't put a coinche, if there is not existing contract");
                        return;
                    }
                    if (_contract.team == player.Team && _contract.coinche != 2) {
                        PlayerSession.BeginSend(ref player, "You can't put a coinche on your team contract");
                        return;
                    }
                    _contract.coinche *= 2;
                    Broadcast(player.Name + " has put a coinche on the actual contract");
                } else if (proto.Gamecmd.Value.Split(' ')[0].Equals("Pass")) {
                    Broadcast(player.Name + " has pass this turn");
                } else {
                    PlayerSession.BeginSend(ref player, "Unrecognized contract");
                    return;
                }
            }
            Player tmp;


            if (hasToPlay < 3) {
                hasToPlay += 1;
                tmp = GetToPlay();
                PlayerSession.BeginSend(ref tmp, "It's your turn to put a contract.");
            } else {
                if (_contract == null) {
                    NextTurn();
                    return;
                }
                hasToPlay = 0;
                Broadcast("The contract turn is now over, first turn of game can start\n");
                tmp = GetToPlay();
                PlayerSession.BeginSend(ref tmp, "It's your turn to play a card");
                isWaited = CGame.Types.Cmd.Card;
            }

        }

        public Card GetCard(GeneralistProto proto, ref Player player) {
            Card card = null;
            int face = -1;
            int color = -1;

            for (int i = 0; i < Card._names.Length; ++i)
                if (proto.Gamecmd.Value.Split(' ')[0].Equals(CoincheServer.Card._names[i]))
                    face = i;
            for (int i = 0; i < Card._colors.Length; ++i)
                if (proto.Gamecmd.Value.Split(' ')[1].Equals(CoincheServer.Card._colors[i]))
                    color = i;
            if (face == -1 || color == -1)
                throw new Exception("You're card doesn't exist, retype it correctly please");

            foreach (Card pcard in player.hand) {
                if (pcard.face == (Card.Face)face && pcard.color == (Card.Color)color)
                    card = pcard;
            }
            if (card == null)
                throw new Exception("You doesn't have this card");
            return card;
        }

        private void CountNoTrumpContract() {
            foreach (Card card in blue.stack)
                blue.score += Card._scores[(int)card.face][(int)Card.Type.NoTrumps];
            foreach (Card card in red.stack)
                red.score += Card._scores[(int)card.face][(int)Card.Type.NoTrumps];
        }

        private void CountAllTrumpContract() {
            foreach (Card card in blue.stack)
                blue.score += Card._scores[(int)card.face][(int)Card.Type.AllTrumps];
            foreach (Card card in red.stack)
                red.score += Card._scores[(int)card.face][(int)Card.Type.AllTrumps];
        }

        private void CountClassicContract() {
            foreach (Card card in blue.stack) {
                if ((int)card.color == (int)_contract.type)
                    blue.score += Card._scores[(int)card.face][(int)Card.Type.OneTrump];
                else
                    blue.score += Card._scores[(int)card.face][(int)Card.Type.IsNotTrump];
            }
            foreach (Card card in red.stack) {
                if ((int)card.color == (int)_contract.type)
                    red.score += Card._scores[(int)card.face][(int)Card.Type.OneTrump];
                else
                    red.score += Card._scores[(int)card.face][(int)Card.Type.IsNotTrump];
            }
        }

        private void CountPoint() {
            switch (_contract.type) {
                case CoincheServer.Contract.ContractType.Clubs:
                case CoincheServer.Contract.ContractType.Spades:
                case CoincheServer.Contract.ContractType.Hearts:
                case CoincheServer.Contract.ContractType.Diamonds:
                    CountClassicContract();
                    break;
                case CoincheServer.Contract.ContractType.NoTrumps:
                    CountNoTrumpContract();
                    break;
                case CoincheServer.Contract.ContractType.AllTrumps:
                    CountAllTrumpContract();
                    break;
            }
        }

        private void Reset() {
            int scoreRed = red.score;
            int scoreBlue = blue.score;

            CountPoint();
            scoreRed = red.score - scoreRed;
            scoreBlue = blue.score - scoreBlue;

            deck.AddRange(blue.stack);
            deck.AddRange(red.stack);

            // DEBUG 
            System.Console.Out.WriteLine("Red has scored: " + scoreRed);
            System.Console.Out.WriteLine("Blue has scored: " + scoreBlue);
            //

            if (_contract.team == Team.Blue) {
                if (_contract.scale > scoreBlue) {
                    Broadcast("Blue team has failed their contract");
                    blue.score -= scoreBlue;
                    red.score = (red.score - scoreRed + 162) + (_contract.scale * _contract.coinche);
                } else {
                    Broadcast("Blue team has made their contract");
                    blue.score += (_contract.scale * _contract.coinche);
                    if (_contract.coinche != 1)
                        red.score -= scoreRed;
                }
            } else {
                if (_contract.scale > scoreRed) {
                    Broadcast("Red team has failed their contract");
                    red.score -= scoreRed;
                    blue.score = (blue.score - scoreBlue + 162) + (_contract.scale * _contract.coinche);
                }
                else {
                    Broadcast("Red team has made their contract");
                    red.score += (_contract.scale * _contract.coinche);
                    if (_contract.coinche != 1)
                        blue.score -= scoreBlue;
                }
            }

            Broadcast("The blue team score is now: " + blue.score);
            Broadcast("The red team score is now: " + red.score);

            if (blue.score > 1000 || red.score > 1000) {
                isOver = true;
                if (blue.score > 1000)
                    Broadcast("The blue team won this game !!!!");
                else
                    Broadcast("The red team won this game !!!!");
                return;
            }
            DistribCard();
        }

        private bool IsOver() {
            return isOver;
        }

        public void PlayCard(GeneralistProto proto, ref Player player) {
            Card card;

            if (this.isWaited != CGame.Types.Cmd.Card) {
                PlayerSession.BeginSend(ref player, "It's not the time to put a contract up.");
                return;
            }
            if (!HisTurn(ref player)) {
                PlayerSession.BeginSend(ref player, "Please wait your turn to do a contract.");
                return;
            }
            
            try {
                card = GetCard(proto, ref player);
            } catch (Exception e) {
                PlayerSession.BeginSend(ref player, e.Message);
                return;
            }

            foreach (PlayedCard toplay in turn)
                if (player.Name.Equals(toplay.player.Name))
                    toplay.card = card;

            Broadcast(player.Name + " played: " + Card._names[(int)card.face] + " " + Card._colors[(int)card.color]);
            player.hand.Remove(card);

            Player tmp;

            if (hasToPlay < 3) {
                hasToPlay += 1;
                tmp = GetToPlay();
                PlayerSession.BeginSend(ref tmp, "It's your turn to play a card.");
            } else {
                hasToPlay = 0;
                ConcludeTurn();
                if (blue.player1.hand.Count == 0) {
                    Broadcast("This hand is over, a new one will begin soon");
                    Reset();
                    if (IsOver())
                        return;
                    Broadcast("Your card has been redistribute");
                    isWaited = CGame.Types.Cmd.Contract;
                    return;
                }
                tmp = GetToPlay();
                PlayerSession.BeginSend(ref tmp, "It's your turn to play a card");
            }
        }

        public void Hand(GeneralistProto proto, ref Player player) {
            PlayerSession.BeginSend(ref player, "In your hand:");
            foreach (Card card in player.hand)
                PlayerSession.BeginSend(ref player, Card._names[(int)card.face] + " " + Card._colors[(int)card.color]);
        }
    }
}
