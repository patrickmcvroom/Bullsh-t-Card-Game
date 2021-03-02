using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TrueGames.Bullshit.DataModels;
using SRandom = System.Random;

namespace TrueGames.Bullshit
{

    public class Deck : MonoBehaviour
    {
        private Stack<Card> _cards = new Stack<Card>();
        
        public void Awake()
        {
            foreach(Suit suit in Enum.GetValues(typeof(Suit)))
            {
                foreach(Rank rank in Enum.GetValues(typeof(Rank)))
                {
                    _cards.Push(new Card(suit, rank));
                }
            }
        }

        public void Swap(Card[] cards, int a, int b)
        {
            var temp = cards[a];
            cards[a] = cards[b];
            cards[b] = temp;
        }

        public void Shuffle()
        {
            var cardsArray = _cards.ToArray();
            _cards.Clear();
            var random = new SRandom();

            for(int i = 0; i < cardsArray.Length - 1; i++)
            {
                Swap(cardsArray, i, i + random.Next(cardsArray.Length - i));
            }

            for (int i = 0; i < cardsArray.Length; i++)
            {
                _cards.Push(cardsArray[i]);
            }
        }

        public void Start()
        {
            Shuffle();

            foreach (Card card in _cards)
            {
                Debug.Log(card.Rank.ToString() + " of " + card.Suit.ToString());
            }
        }

    }

}

