using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zom2 : MonoBehaviour
{
    public static float HP;
    public static float speed;
    public static float AD;
    Rigidbody2D rigid;

    void Start()
    {
        HP = 50;
        rigid = GetComponent<Rigidbody2D>();
        speed = 5;
        AD = 12.0f;
    }

    void Update()
    {
        // ������ ü���� 0 ���Ϸ� �������� �ı�
        if (HP <= 0)
        {
            Destroy(gameObject);
        }
    }

    // �ٸ� ��ũ��Ʈ���� ȣ���Ͽ� ������ ü���� ���ҽ�Ű�� �޼���
    public void TakeDamage(float damage)
    {
        HP -= damage;
    }
}
