using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicalCard : MonoBehaviour
{
    [SerializeField] private int _rank;

    public int Rank { get => _rank; set => _rank = value; }
}
