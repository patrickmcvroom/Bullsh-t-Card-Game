using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TrueGames.Bullshit
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private string _name;
        [SerializeField] private CardRenderer _cardRenderer;

        public string Name { get => _name; set => _name = value; }
        public Stack<Card> Cards = new Stack<Card>();

        public Player(string name)
        {
            _name = name;
        }

        public void ShowCards()
        {
            _cardRenderer.DisplayCard(Cards.Peek(), Vector3.zero);
        }

        public void Declare()
        {
            // Player declares what card he/she will put down.
        }

        public void Draw()
        {
            // Player puts down a card into the pile.
        }

        public void Bullshit()
        {
            // Check if the recent cards in the pile is EQUAL to what the previous player declared.
        }
    }
}

