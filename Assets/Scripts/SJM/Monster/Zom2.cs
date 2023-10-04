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
            Gamemanager.Instance.CreateReward(this.transform.position);

            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Vector3 force = Vector3.Normalize(other.transform.position - transform.position);
            Gamemanager.Instance.player.TakeDamage(1, force * 2);
        }
    }

    // �ٸ� ��ũ��Ʈ���� ȣ���Ͽ� ������ ü���� ���ҽ�Ű�� �޼���
    public void TakeDamage(float damage)
    {
        HP -= damage;
    }
}
