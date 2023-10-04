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
        // ������ ü���� 0 ���Ϸ� �������� �ı�
        if (HP <= 0)
        {
            Gamemanager.Instance.CreateReward(this.transform.position);

            Destroy(gameObject);
        }
    }

    // �ٸ� ��ũ��Ʈ���� ȣ���Ͽ� ������ ü���� ���ҽ�Ű�� �޼���
    public void TakeDamage(float damage)
    {
        HP -= damage;
    }
}