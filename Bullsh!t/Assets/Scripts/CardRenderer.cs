using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TrueGames.Bullshit;
using TrueGames.Bullshit.DataModels;

public class CardRenderer : MonoBehaviour
{
    private Card _card;

    [SerializeField] private GameObject _cardGameObject;

    public void DisplayCard(Card card, Vector3 position)
    {
        _cardGameObject.GetComponent<Renderer>().material.color = new Color(103, 31, 55);
        Instantiate(_cardGameObject, position, Quaternion.identity);
    }
}
