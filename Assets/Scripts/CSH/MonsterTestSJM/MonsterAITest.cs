using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAITest : MonoBehaviour
{
    public Transform target; //당연히 타겟은 플레이어 일 것이다. Transform으로 Target의 위치를 받아온다.
    private void Start()
    {
        target = Gamemanager.Instance.player.transform;
    }
    void Update()
    {
        float dis = Vector3.Distance(transform.position, target.position); //내위치와 target의 위치 사이의 거리를 구함
        if (dis <= 100) // 거리가 10칸 안으로 좁혀졌으면 쫒기 시작
        {
            Move();
        }
        else return;
    }

    void Move()
    {
        Vector2 targetPosition = new Vector2(target.position.x, target.position.y); // 목표 위치를 가져옵니다.
        Vector2 currentPosition = new Vector2(transform.position.x, transform.position.y); // 현재 위치를 가져옵니다.

        Vector2 direction = (targetPosition - currentPosition).normalized; // 목표까지의 방향을 정규화합니다.

        transform.Translate(direction * Monster.speed * Time.deltaTime);

    }
}
