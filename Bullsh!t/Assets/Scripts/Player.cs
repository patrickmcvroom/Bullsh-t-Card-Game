using System.Collections;
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
        // var cardMiddlePosition = new Vector3(0f, -30f, 0f);

        if (_hand.Cards.Count > 13)
        {
            var cardCount = _hand.Cards.Count;
            int halfCardCount = (int)(cardCount * 0.5f);

            var cardStartingPosition = new Vector3(XPositions.CardXPositions[halfCardCount], -30f, 0f);

            for (int i = 0; i < (halfCardCount); i++)
            {
                _cardRenderer.DisplayCard(_hand.Cards[i], cardStartingPosition);
                cardStartingPosition.x += 20f;
                yield return new WaitForSeconds(0.05f);
            }

            cardStartingPosition.x = XPositions.CardXPositions[cardCount - halfCardCount];
            cardStartingPosition.y = -62;

            for (int i = halfCardCount; i < cardCount; i++)
            {
                _cardRenderer.DisplayCard(_hand.Cards[i], cardStartingPosition);
                cardStartingPosition.x += 20f;
                yield return new WaitForSeconds(0.05f);
            }
        }
        else
        {
            var cardCount = _hand.Cards.Count;

            var cardStartingPosition = new Vector3(XPositions.CardXPositions[cardCount], -52f, 0f);

            for (int i = 0; i < cardCount; i++)
            {
                _cardRenderer.DisplayCard(_hand.Cards[i], cardStartingPosition);
                cardStartingPosition.x += 20f;
                yield return new WaitForSeconds(0.05f);
            }
        }
    }
}
