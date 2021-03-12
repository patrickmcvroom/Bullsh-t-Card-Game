using System;
using UnityEngine;
using TrueGames.Bullshit;
using TrueGames.Bullshit.DataModels;
using SObject = System.Object;

namespace TrueGames.Bullshit
{
    public class DeclarationRenderer : MonoBehaviour
    {
        private Quaternion _speechBubbleRotation = Quaternion.Euler(new Vector3(0f, 180f, 0f));

        //[SerializeField] private Declaration _declaration;
        [SerializeField] private GameObject _speechBubbleGameObject;

        public void OnCardsDeclared(SObject source, EventArgs args)
        {
            var texture = Resources.Load<Texture>($"{Declaration.DeclaredRank}" + $"{Declaration.DeclaredQuantity}");

            var position = new Vector3(XPositions.HUDXPositions[GameManager.TotalPlayers], 75f, 0f);
            position.x += XPositions.HUDPositionIncrements[GameManager.PlayerTurn];

            position.x -= 13f;
            position.y -= 31f;

            var renderer = Instantiate(_speechBubbleGameObject, position, _speechBubbleRotation).GetComponent<Renderer>();
            renderer.material.mainTexture = texture;
        }
    }
}
