using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTest : MonoBehaviour
{
    public TopDownCharacter player;
    // Start is called before the first frame update

    void Start()
    {
        player = Gamemanager.Instance.player;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            Debug.Log("Ãæµ¹");
            player.TakeDamage(1);
        }
    }
}
