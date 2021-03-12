using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TrueGames.Bullshit.DataModels;
using URandom = UnityEngine.Random;
using SObject = System.Object;

namespace TrueGames.Bullshit
{
    public enum GameState { Start, Deal, Declare, Play, GameOver };

    public class GameManager : MonoBehaviour
    {
        private static GameState _gamestate;
        private static int _playerTurn;
        private static int _totalPlayers;

        [SerializeField] private Deck _deck;
        [SerializeField] private GameObject _player;
        [SerializeField] private PlayerHUD _playerHUD;
        [SerializeField] private RankButtons _rankButtons;
        [SerializeField] private GameObject _quantityButtons;
        [SerializeField] private static List<GameObject> _players = new List<GameObject>();

        public static int PlayerTurn { get => _playerTurn; }
        public static int TotalPlayers { get => _totalPlayers; }

        private void Start()
        {
            _gamestate = GameState.Start;
            StartCoroutine(Setup());
        }

        IEnumerator Setup()
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

            _gamestate = GameState.Declare;

            _playerTurn = 0;

            StartCoroutine(ShowPlayersCards());
            yield return new WaitForSeconds(0.8f);
            StartCoroutine(ShowRankButtons());
        }

        IEnumerator ShowPlayersCards()
        {
            yield return new WaitForSeconds(0.1f);

            var currentPlayer = _players[_playerTurn].GetComponent<Player>();

            StartCoroutine(currentPlayer.ShowCards());
        }
        
        IEnumerator CreatePlayerHUDs()
        {
            var GameplayCanvas = GameObject.FindGameObjectWithTag("Gameplay Canvas");

            var HUDStartPosistion = new Vector3(XPositions.HUDXPositions[_totalPlayers], 75f, 0f);

            foreach(var player in _players)
            {
                var HUDObject = Instantiate(_playerHUD, HUDStartPosistion, Quaternion.identity, GameplayCanvas.GetComponent<Transform>());
                var PlayerHUD = HUDObject.GetComponent<PlayerHUD>();

                HUDObject.name = player.GetComponent<Player>().Name + " HUD";
                PlayerHUD.PlayerImage.color = new Color(URandom.value, URandom.value, URandom.value);
                PlayerHUD.PlayerName.text = player.GetComponent<Player>().Name;
                PlayerHUD.CardsLeft.text = player.GetComponent<Player>().Hand.Cards.Count.ToString();

                HUDStartPosistion.x += 40f;
                yield return new WaitForSeconds(0.02f);
            }
        }

        IEnumerator ShowRankButtons()
        {
            string[] rankBtnTextArray = { "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K" };
            var buttonStartPosition = new Vector3(-138f, 0f, 0f);

            for(int i = 0; i < rankBtnTextArray.Length; i++)
            {
                _rankButtons.CreateRankButton(buttonStartPosition, rankBtnTextArray[i]);
                buttonStartPosition.x += 23f;
                yield return new WaitForSeconds(0.05f);
            }   
        }

        public void NextTurn()
        {
            _playerTurn++;
            _playerTurn %= _totalPlayers;
        }

        public static void OnCardsDeclared(SObject source, EventArgs args)
        {
            GameManager._gamestate = GameState.Play;
            Debug.Log("Current state is: " + _gamestate);
        }
    }
}