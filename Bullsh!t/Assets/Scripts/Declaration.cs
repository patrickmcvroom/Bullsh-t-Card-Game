using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TrueGames.Bullshit.DataModels;

namespace TrueGames.Bullshit
{
    [Serializable]
    public class Declaration
    {
        [SerializeField]
        private Rank _declaredRank;
        [SerializeField]
        private int _declaredQuantity;

        public Rank DeclaredRank { get => _declaredRank; set => _declaredRank = value; }
        public int DeclaredQuantity { get => _declaredQuantity; set => _declaredQuantity = value; }

        private Declaration(Rank rank, int quantity)
        {
            _declaredRank = rank;
            _declaredQuantity = quantity;
        }
    }
}
