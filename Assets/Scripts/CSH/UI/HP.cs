using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HP : MonoBehaviour
{
    public GameObject FullHeart;
    public GameObject HalfHeart;
    public GameObject EmptyHeart;

    public TopDownCharacter player;
    // Start is called before the first frame update
    void Start()
    {
        player = Gamemanager.Instance.player;
        UpdateHP();

    }

    // Update is called once per frame
    public void UpdateHP()
    {

        int count = transform.childCount;
        for(int i = 0; i < count; i++) 
        {
            Destroy(transform.GetChild(i).gameObject);  
        }
        for(int i = 0; i < player.CurrentHp/2;i++)
        {
            Instantiate(FullHeart, transform);
        }
        for(int i = 0;i < player.CurrentHp%2;i++)
        {
            Instantiate(HalfHeart, transform);
        }
        for(int i =0;i < (player.MaxHP - player.CurrentHp)/2; i++)
        {
            Instantiate(EmptyHeart, transform);
        }
        
    }
}
