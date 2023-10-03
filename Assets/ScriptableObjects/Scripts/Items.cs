using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DefaultItemData", menuName = "Items/potions/Default", order = 0)]
public class Items : ScriptableObject
{
    [Header("Info")]
    public string displayName;
    public string description;
    public Sprite icon;
    public GameObject dropPrefab;

    [Header("Stats Figures")]
    public int healthFigures;
    public int attackFigures;
    public int speedFigures;

    [Header("Stacking")]
    public bool canStack;
    public int maxStackAmount;
}
