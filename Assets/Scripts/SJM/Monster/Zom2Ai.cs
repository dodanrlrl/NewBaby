using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zom2Ai : MonoBehaviour
{
    Transform target; //당연히 타겟은 플레이어 일 것이다. Transform으로 Target의 위치를 받아온다.

    private void Start()
    {
        target = Gamemanager.Instance.player.transform;
    }

    void Update()
    {
        float dis = Vector3.Distance(transform.position, target.position); //내위치와 target의 위치 사이의 거리를 구함
        if (dis <= 10) // 거리가 10칸 안으로 좁혀졌으면 쫒기 시작
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

        // 이미지의 방향을 결정하여 좌우 반전을 적용합니다.
        if (direction.x > 0) // 플레이어가 오른쪽에 있을 때
        {
            transform.localScale = new Vector3(3, 3, 3); // 이미지를 원래 방향으로 설정
        }
        else if (direction.x < 0) // 플레이어가 왼쪽에 있을 때
        {
            transform.localScale = new Vector3(-3, 3, 3); // 이미지를 좌우 반전
        }

        // 이제 방향에 따라 이동합니다.
        transform.Translate(direction * Monster.speed * Time.deltaTime);

    }
}
