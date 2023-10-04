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
        HP = 1;
        rigid = GetComponent<Rigidbody2D>();
        speed = 3;
        AD = 10.0f;
        sel = FindObjectOfType<Select>();
        // select = GetComponent<Gameobject>().Nex;
    }

    void Update()
    {
        // ������ ü���� 0 ���Ϸ� �������� �ı�
        if (HP <= 0)
        {
            Select.Dies = Select.Dies += 1;
            Destroy(gameObject);
        }
        //Debug.Log(Select.Dies);
        if (Select.Dies >= 5)
        {
            sel.NextStage();
            Select.Dies = 0;

        }

    }

    // �ٸ� ��ũ��Ʈ���� ȣ���Ͽ� ������ ü���� ���ҽ�Ű�� �޼���
    public void TakeDamage(float damage)
    {
        HP -= damage;
    }
}