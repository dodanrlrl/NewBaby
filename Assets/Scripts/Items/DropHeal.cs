using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropHeal : DropItems
{
    [SerializeField] Items _item;

    protected override void OnPickedUp(GameObject receiver)
    {
        //TopDownCharacter.Instance.TakeHeal(_item.healthFigures);
        Gamemanager.Instance.player.TakeHeal(_item.healthFigures);
    }
}
