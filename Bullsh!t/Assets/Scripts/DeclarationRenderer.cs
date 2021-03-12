using System;
using UnityEngine;
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

            var renderer = Instantiate(_speechBubbleGameObject, Vector3.zero, _speechBubbleRotation).GetComponent<Renderer>();
            renderer.material.mainTexture = texture;
        }
    }
}
