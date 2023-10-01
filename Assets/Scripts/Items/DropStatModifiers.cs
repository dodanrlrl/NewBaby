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
        //TopDownCharacter.Instance.UpAttackPower(_item.attackFigures);//�÷��̾� �ν��Ͻ����ϸ� ���ٲ������ ���� �ʱ�ȭ�Ǵ� ���� ������ gamemanager�� �ִ� player�̿�
        //TopDownCharacter.Instance.UpSpeed(_item.speedFigures);
        Gamemanager.Instance.player.UpAttackPower(_item.attackFigures);
        Gamemanager.Instance.player.UpSpeed(_item.speedFigures);
    }
}
