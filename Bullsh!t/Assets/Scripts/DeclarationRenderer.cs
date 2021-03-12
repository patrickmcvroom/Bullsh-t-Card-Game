using System;
using UnityEngine;

namespace TrueGames.Bullshit
{
    public class DeclarationRenderer : MonoBehaviour
    {
        private Declaration _declaration;
        private Quaternion _speechBubbleRotation = Quaternion.Euler(new Vector3(0f, 180f, 0f));

        [SerializeField] private GameObject _speechBubbleGameObject;

        private void RenderDeclaration()
        {
            var texture = Resources.Load<Texture>($"{_declaration.DeclaredRank}" + "x" + $"{_declaration.DeclaredQuantity}");

        }
    }
}
