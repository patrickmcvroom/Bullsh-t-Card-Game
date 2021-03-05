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
        [SerializeField] private static List<Player> _players = new List<Player>();
        [SerializeField] private int _totalPlayers;
        [SerializeField] private int _playerTurn;

        private void Start()
        {
            _gamestate = GameState.Start;

            Setup();
        }

        public void Setup()
        {
            var Nick = new Player("Nick");
            var Patrick = new Player("Patrick");

            _players.Add(Nick);
            _players.Add(Patrick);

            _totalPlayers = _players.Count;

            _deck.Shuffle();

            _gamestate = GameState.Deal;

            _deck.Deal(_players);

            _gamestate = GameState.Playing;

            _playerTurn = 0;

            //ShowPlayersCards();
            //_deck.Show();

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
            _players[_playerTurn].ShowCards();
        }
    }
}
