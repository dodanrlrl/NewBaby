using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using UnityEditor;
using UnityEngine;

public class player : MonoBehaviour
{
    // 변수타입 // 변수이름
    public Vector2 inputVec;
    public float speed;
    Rigidbody2D rigid;
    SpriteRenderer spriter;
    Animator anim;

    void Awake()
    {
        // 변수 생성 후 변수 초기화 생성하기
        rigid = GetComponent<Rigidbody2D>();
        spriter = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }
    void Start()
    {

    }

    void Update()
    {

        // Input = 유니티에서 받는 모든 입력을 관리하는 클래스
        inputVec.x = Input.GetAxisRaw("Horizontal");
        inputVec.y = Input.GetAxisRaw("Vertical");
    }
    void FixedUpdate()
    {
        //노멀라이즈드를 안쓰면 대각선시에 더 빨리감     //물리 프레임 하나가 소비한 시간
        Vector2 nextVec = inputVec.normalized * speed * Time.fixedDeltaTime;
        //위치 이동 ( 월드의 이동이기 떄문에 기본 리지드 포지션값을 잡아줘야함 )
        rigid.MovePosition(rigid.position + nextVec);
    }

    void LateUpdate()
    {
        // 인풋 백터.매그니튜드 = 벡터의 순수한 크기 값
        anim.SetFloat("Speed", inputVec.magnitude);
        

        // 인풋벡터가 0이 아닐때
        if (inputVec.x != 0)
        {
            spriter.flipX = inputVec.x < 0;
        }
    }
}