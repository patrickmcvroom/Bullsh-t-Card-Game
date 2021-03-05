using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TrueGames.Bullshit;
using TrueGames.Bullshit.DataModels;

public class Player : MonoBehaviour
{
    private string _name;
    private Hand _hand;

    [SerializeField] private CardRenderer _cardRenderer;

    private Card TopCard => _hand.Cards.Peek();

    public string Name { get => _name; set => _name = value; }
    public Hand Hand { get => _hand; set => _hand = value; }

    public Player(string name, Hand hand)
    {
        _name = name;
        _hand = hand;
    }

    public void ShowCards()
    {
        _cardRenderer.DisplayCard(TopCard, Vector3.zero);
    }
}
