using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CoincheServer {
    public class Card {

        public static int[][] _scores = new int[][] {
            new int []{0, 0, 0, 0},
            new int []{0, 0, 0, 0},
            new int []{9, 0, 14, 0},
            new int []{5, 10, 10, 10},
            new int []{14, 2, 20, 2},
            new int []{2, 3, 3, 3},
            new int []{3, 4, 4, 4},
            new int []{7, 19, 11, 11}
        };

        public static string[] _names = new string[] {
            "Seven",
            "Eight",
            "Nine",
            "Ten",
            "Jack",
            "Queen",
            "King",
            "As"
        };

        public static string[] _colors = new string[] {
            "Spade",
            "Club",
            "Heart",
            "Diamond"
        };

        public enum Face {
            Seven,
            Eight,
            Nine,
            Ten,
            Jack,
            Queen,
            King,
            As
        };

        public enum Type {
            AllTrumps,
            NoTrumps,
            OneTrump,
            IsNotTrump
        };

        public enum Color {
            Spade,
            Club,
            Heart,
            Diamond
        };

        public Face face;
        public Color color;

        public Card(Face face, Color color) {
            this.color = color;
            this.face = face;
        }
    }
}