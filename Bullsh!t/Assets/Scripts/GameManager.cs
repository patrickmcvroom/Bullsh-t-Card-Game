using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TrueGames.Bullshit.DataModels;
using URandom = UnityEngine.Random;

namespace TrueGames.Bullshit
{
    public enum GameState { Start, Deal, Playing, GameOver };

    public class GameManager : MonoBehaviour
    {
        private GameState _gamestate;

        [SerializeField] private Deck _deck;
        [SerializeField] private GameObject _player;
        [SerializeField] private GameObject _playerHUD;
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

            

            // EVERYTHING ABOVE WILL GO INTO AN INPUT PLAYERS METHOD.

            _deck.Shuffle();

            _gamestate = GameState.Deal;

            _deck.Deal(_players);

            StartCoroutine(CreatePlayerHUDs());

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
        
        IEnumerator CreatePlayerHUDs()
        {
            var _gameplayCanvas = GameObject.FindGameObjectWithTag("Gameplay Canvas");

            var HUDStartPosistion = new Vector3(XPositions.HUDXPositions[_players.Count], 75f, 0f);

            for (int i = 0; i < _players.Count; i++)
            {
                var HUDObject = Instantiate(_playerHUD, HUDStartPosistion, Quaternion.identity, _gameplayCanvas.GetComponent<Transform>());
                var PlayerHUD = HUDObject.GetComponent<PlayerHUD>();

                PlayerHUD.PlayerImage.color = new Color(URandom.value, URandom.value, URandom.value);
                PlayerHUD.PlayerName.text = _players[i].GetComponent<Player>().Name;
                PlayerHUD.CardsLeft.text = _players[i].GetComponent<Player>().Hand.Cards.Count.ToString();

                HUDStartPosistion.x += 40f;
                yield return new WaitForSeconds(0.1f);
            }
        }
    }
}