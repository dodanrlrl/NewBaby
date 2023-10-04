using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem.XR;



public class Monster : MonoBehaviour
{

    // public Gameobject select;
    public Select sel;
    public float HP;
    public static float speed;
    public static float AD;
    Rigidbody2D rigid;

    void Start()
    {

        HP = 25;
        rigid = GetComponent<Rigidbody2D>();
        speed = 1.5f;
        AD = 10.0f;
        sel = FindObjectOfType<Select>();
        // select = GetComponent<Gameobject>().Nex;
    }

    void Update()
    {
        if (HP <= 0)
        {
            Gamemanager.Instance.CreateReward(this.transform.position);
            Select.Dies = Select.Dies += 1;
            Destroy(gameObject);
        }
        //Debug.Log(Select.Dies);
        if (Select.Dies >= 5)
        {
            sel.NextStage();
            Select.Dies = 0;

        }
        rigid.velocity = Vector3.zero;//충돌시 날라가는거 방지

    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Vector3 force = Vector3.Normalize(other.transform.position - transform.position);
            Gamemanager.Instance.player.TakeDamage(1,force*2);
        }
    }

    public void TakeDamage(float damage)
    {
        HP -= damage;
    }
}