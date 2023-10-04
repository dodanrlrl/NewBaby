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

    [Range(0.0f, 1.0f)] public float itemSpawnPer;

    void Start()
    {
        HP = 100;
        rigid = GetComponent<Rigidbody2D>();
        speed = 3;
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

    // 다른 스크립트에서 호출하여 몬스터의 체력을 감소시키는 메서드
    public void TakeDamage(float damage)
    {
        HP -= damage;
    }
}