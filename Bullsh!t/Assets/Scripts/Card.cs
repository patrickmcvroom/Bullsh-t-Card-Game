using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TrueGames.Bullshit.DataModels;
using SRandom = System.Random;

namespace TrueGames.Bullshit
{
    public class Card
    {
        private Suit _suit;
        private Rank _rank;

        public Suit Suit { get { return _suit; } }

        public Rank Rank { get { return _rank; } }

        public Card(Suit suit, Rank rank)
        {
            _suit = suit;
            _rank = rank;
        }
    }
}
