using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CoincheServer {

    public class Contract {
        public enum ContractType {
            Spades,
            Clubs,
            Hearts,
            Diamonds,
            AllTrumps,
            NoTrumps,
        };

        public ContractType type;
        public int scale;
        public int coinche;
        public Team team;

        public Contract(ContractType type, int scale, int coinche, Team team) {
            this.type = type;
            this.scale = scale;
            this.coinche = coinche;
            this.team = team;
        }
    }
}