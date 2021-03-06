using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TrueGames.Bullshit;
using TrueGames.Bullshit.DataModels;

public class CardRenderer : MonoBehaviour
{
    private Quaternion _cardRotation = Quaternion.Euler(new Vector3(0f, 180f, 0f));

    [SerializeField] private GameObject _cardGameObject;

    public void DisplayCard(Card card, Vector3 position)
    {
        var texture = Resources.Load<Texture>($"{card.Suit}" + $"{card.Rank}");

        _cardGameObject.GetComponent<PhysicalCard>().Rank = (int)card.Rank;

        var renderer = Instantiate(_cardGameObject, position, _cardRotation).GetComponent<Renderer>();
        renderer.material.mainTexture = texture;
    }
}
