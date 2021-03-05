using System;
using UnityEngine;
using TrueGames.Bullshit.DataModels;

namespace TrueGames.Bullshit
{
    public class Card
    {
        private Suit _suit;
        private Rank _rank;
        private int _cardIndex;
        private Texture _texture;
        
        public Suit Suit { get => _suit; }
        public Rank Rank { get => _rank; }
        public int CardIndex { get => _cardIndex; }
        public Texture Texture { get => _texture;  private set => _texture = value; }

        public Card(Suit suit, Rank rank, int cardIndex)
        {
            _suit = suit;
            _rank = rank;
            _cardIndex = cardIndex;
            _texture = Resources.Load<Texture>($"{suit}" + $"{rank}");
        }

        public override string ToString()
        {
            return $"{Rank} of {Suit}";
        }
    }
}
