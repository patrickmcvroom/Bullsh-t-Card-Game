using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TrueGames.Bullshit.DataModels;

namespace TrueGames.Bullshit
{
    public class Card : MonoBehaviour
    {
        private Rank _rank;
        private Suit _suit;

        public Card(Rank rank, Suit suit)
        {
            _rank = rank;
            _suit = suit;
        }
    }
}
