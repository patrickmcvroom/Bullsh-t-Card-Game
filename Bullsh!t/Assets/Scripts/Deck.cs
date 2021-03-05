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
        private int _cardIndex = 0;

        public Stack<Card> Cards { get { return _cards; } }

        public void Awake()
        {
            foreach(Suit suit in Enum.GetValues(typeof(Suit)))
            {
                foreach(Rank rank in Enum.GetValues(typeof(Rank)))
                {
                    _cards.Push(new Card(suit, rank, _cardIndex));
                    _cardIndex++;
                }
            }
        }

        public void Swap(Card[] cards, int a, int b)
        {
            var temp = cards[a];
            cards[a] = cards[b];
            cards[b] = temp;
        }

        public void Show()
        {
            //foreach (var card in Cards)
            //{
            //    Debug.Log(card.ToString());
            //}
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

        /// <summary>
        /// Distributes all of the cards in the deck as evenly as possible to all hands.
        /// </summary>
        /// <param name="hands">
        /// The group of hands.
        /// </param>
        public void Deal(List<GameObject> players)
        {
            while(_cards.Count != 0)
            {
                foreach(var player in players)
                {
                    if (_cards.Count != 0)
                    {
                        player.GetComponent<Player>().Hand.Cards.Push(this._cards.Pop());
                    }
                    else return;
                }
            }
        }

        public List<Card> LastCardsDrawn(int drawAmount)
        {
            return new List<Card>();
        }
    }
}

