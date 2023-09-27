using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using UnityEditor;
using UnityEngine;

public class player : MonoBehaviour
{
    // ����Ÿ�� // �����̸�
    public Vector2 inputVec;
    public float speed;
    Rigidbody2D rigid;
    SpriteRenderer spriter;
    Animator anim;

    void Awake()
    {
        // ���� ���� �� ���� �ʱ�ȭ �����ϱ�
        rigid = GetComponent<Rigidbody2D>();
        spriter = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }
    void Start()
    {

    }

    void Update()
    {

        // Input = ����Ƽ���� �޴� ��� �Է��� �����ϴ� Ŭ����
        inputVec.x = Input.GetAxisRaw("Horizontal");
        inputVec.y = Input.GetAxisRaw("Vertical");
    }
    void FixedUpdate()
    {
        //��ֶ�����带 �Ⱦ��� �밢���ÿ� �� ������     //���� ������ �ϳ��� �Һ��� �ð�
        Vector2 nextVec = inputVec.normalized * speed * Time.fixedDeltaTime;
        //��ġ �̵� ( ������ �̵��̱� ������ �⺻ ������ �����ǰ��� �������� )
        rigid.MovePosition(rigid.position + nextVec);
    }

    void LateUpdate()
    {
        // ��ǲ ����.�ű״�Ʃ�� = ������ ������ ũ�� ��
        anim.SetFloat("Speed", inputVec.magnitude);
        

        // ��ǲ���Ͱ� 0�� �ƴҶ�
        if (inputVec.x != 0)
        {
            spriter.flipX = inputVec.x < 0;
        }
    }
}