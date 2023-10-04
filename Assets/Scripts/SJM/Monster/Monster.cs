using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem.XR;

public class Monster : MonoBehaviour
{


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
    }

    void Update()
    {
        // 몬스터의 체력이 0 이하로 떨어지면 파괴
        if (HP <= 0)
        {
            Gamemanager.Instance.CreateReward(this.transform.position);

            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            //Debug.Log("충돌");
            Gamemanager.Instance.player.TakeDamage(1);
        }
    }
    // 다른 스크립트에서 호출하여 몬스터의 체력을 감소시키는 메서드
    public void TakeDamage(float damage)
    {
        HP -= damage;
    }
}