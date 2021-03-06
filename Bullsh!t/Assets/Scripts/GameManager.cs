using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TrueGames.Bullshit
{
    public enum GameState { Start, Deal, Playing, GameOver };

    public class GameManager : MonoBehaviour
    {
        private GameState _gamestate;

        [SerializeField] private Deck _deck;
        [SerializeField] private GameObject _player;
        [SerializeField] private static List<GameObject> _players = new List<GameObject>();
        [SerializeField] private int _totalPlayers;
        [SerializeField] private int _playerTurn;

        private void Start()
        {
            _gamestate = GameState.Start;
            Setup();
        }

        public void Setup()
        {
            var NickHand = new Hand();
            var PatrickHand = new Hand();

            var Nick = Instantiate(_player, Vector3.up, Quaternion.identity);
            Nick.GetComponent<Player>().Name = "Nick";
            Nick.GetComponent<Player>().Hand = NickHand;
            Nick.name = Nick.GetComponent<Player>().Name;

            var Patrick = Instantiate(_player, Vector3.up, Quaternion.identity);
            Patrick.GetComponent<Player>().Name = "Patrick";
            Patrick.GetComponent<Player>().Hand = PatrickHand;
            Patrick.name = Patrick.GetComponent<Player>().Name;

            _players.Add(Nick);
            _players.Add(Patrick);

            _totalPlayers = _players.Count;

            _deck.Shuffle();

            _gamestate = GameState.Deal;

            _deck.Deal(_players);

            _gamestate = GameState.Playing;

            _playerTurn = 0;

            StartCoroutine(ShowPlayersCards());
        }

        public void NextTurn()
        {
            _playerTurn ++;
            _playerTurn %= _totalPlayers;
        }

        IEnumerator ShowPlayersCards()
        {
            yield return new WaitForSeconds(1f);

            var currentPlayer = _players[_playerTurn].GetComponent<Player>();

            StartCoroutine(currentPlayer.ShowCards());
        }
    }
}
