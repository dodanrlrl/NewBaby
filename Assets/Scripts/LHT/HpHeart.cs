using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpHeart : MonoBehaviour
{
    //�ִ�ü�µ��� private���� ������ ��� �������?

    [SerializeField] GameObject emptyHeart;
    [SerializeField] GameObject heart;
    public void TurnOnHeart()
    {
        emptyHeart.SetActive(false);
    }
    public void TurnOffHeart()
    {
        emptyHeart.SetActive(true);
    }
    public void AddHeart()
    {

    }
}
