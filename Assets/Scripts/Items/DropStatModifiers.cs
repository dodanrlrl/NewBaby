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
        TopDownCharacter.Instance.UpAttackPower(_item.attackFigures);
        TopDownCharacter.Instance.UpSpeed(_item.speedFigures);
    }
}
