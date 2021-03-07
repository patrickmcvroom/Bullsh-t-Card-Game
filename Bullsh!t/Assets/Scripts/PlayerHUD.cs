using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerHUD : MonoBehaviour
{
    [SerializeField] private Image _playerImage;
    [SerializeField] private TextMeshProUGUI _playerName;
    [SerializeField] private TextMeshProUGUI _cardsLeft;

    public Image PlayerImage { get => _playerImage; set => _playerImage = value; }
    public TextMeshProUGUI PlayerName { get => _playerName; set => _playerName = value; }
    public TextMeshProUGUI CardsLeft { get => _cardsLeft; set => _cardsLeft = value; }
}
