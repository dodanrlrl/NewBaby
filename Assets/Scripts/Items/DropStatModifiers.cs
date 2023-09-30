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
        //TopDownCharacter.Instance.UpAttackPower(_item.attackFigures);//플레이어 인스턴스에하면 씬바뀌었을때 값이 초기화되는 문제 때문에 gamemanager에 있는 player이용
        //TopDownCharacter.Instance.UpSpeed(_item.speedFigures);
        Gamemanager.Instance.player.UpAttackPower(_item.attackFigures);
        Gamemanager.Instance.player.UpSpeed(_item.speedFigures);
    }
}
