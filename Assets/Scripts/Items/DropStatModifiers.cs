using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.AI;

public class DropStatModifiers : DropItems
{
    [SerializeField] Items _item;

    protected override void OnPickedUp(GameObject receiver)
    {
        Inventory.instance.AddItem(_item);
        //Gamemanager.Instance.player.UpAttackPower(_item.attackFigures);
        //Gamemanager.Instance.player.UpSpeed(_item.speedFigures);
    }
}
