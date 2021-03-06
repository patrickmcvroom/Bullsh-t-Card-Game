using System;
using UnityEngine;
using TrueGames.Bullshit.DataModels;

namespace TrueGames.Bullshit
{
    public class Card
    {
        private Suit _suit;
        private Rank _rank;
        //private int _cardIndex;
        
        public Suit Suit { get => _suit; }
        public Rank Rank { get => _rank; }
        //public int CardIndex { get => _cardIndex; }

        public Card(Suit suit, Rank rank)
        {
            _suit = suit;
            _rank = rank;
            //_cardIndex = cardIndex;
        }

        public override string ToString()
        {
            return $"{Rank} of {Suit}";
        }
    }
}
