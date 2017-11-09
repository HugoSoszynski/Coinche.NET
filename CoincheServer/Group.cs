using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CoincheServer {
    public class Group {
        public Player player1;

        public Player player2;

        public int score;

        public List<Card> stack = new List<Card>();
        
        public Group() {
            this.player1 = null;
            this.player2 = null;
            this.score = 0;
        }
        
        public void AddPlayer(ref Player player) {
            if (this.player1 == null)
                this.player1 = player;
            else
                this.player2 = player;
        }
    }
}