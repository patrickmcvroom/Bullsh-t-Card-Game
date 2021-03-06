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

    // private Card TopCard => _hand.Cards.Peek();

    public string Name { get => _name; set => _name = value; }
    public Hand Hand { get => _hand; set => _hand = value; }

    public Player(string name, Hand hand)
    {
        _name = name;
        _hand = hand;
    }

    public IEnumerator ShowCards()
    {
        //var cardsArray = _hand.Cards.ToArray();
        var cardStartingPosition = new Vector3(-120f, -30f, 0f);

        if (_hand.Cards.Count >= 13)
        {
            for (int i = 0; i < 13; i++)
            {
                _cardRenderer.DisplayCard(_hand.Cards[i], cardStartingPosition);
                cardStartingPosition.x += 20f;
                yield return new WaitForSeconds(0.05f);
            }

            cardStartingPosition.x = -120f;
            cardStartingPosition.y = -62;

            for (int i = 13; i < _hand.Cards.Count; i++)
            {
                _cardRenderer.DisplayCard(_hand.Cards[i], cardStartingPosition);
                cardStartingPosition.x += 20f;
                yield return new WaitForSeconds(0.05f);
            }
        }
        else
        {
            cardStartingPosition.y = -52;

            for (int i = 0; i < _hand.Cards.Count; i++)
            {
                _cardRenderer.DisplayCard(_hand.Cards[i], cardStartingPosition);
                cardStartingPosition.x += 20f;
                yield return new WaitForSeconds(0.05f);
            }
        }
    }
}
