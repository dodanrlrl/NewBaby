using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpHeart : MonoBehaviour
{
    //최대체력들을 private으로 돌리면 어떻게 사용하지?

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
