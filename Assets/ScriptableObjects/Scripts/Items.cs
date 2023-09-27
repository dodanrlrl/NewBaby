using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DefaultItemData", menuName = "Items/potions/Default", order = 0)]
public class Items : ScriptableObject
{

    [Header("Stats Figures")]
    [SerializeField] public int healthFigures;
    [SerializeField] public int attackFigures;
    [SerializeField] public int speedFigures;
}
