using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAITest : MonoBehaviour
{
    public Transform target; //�翬�� Ÿ���� �÷��̾� �� ���̴�. Transform���� Target�� ��ġ�� �޾ƿ´�.
    private void Start()
    {
        target = Gamemanager.Instance.player.transform;
    }
    void Update()
    {
        float dis = Vector3.Distance(transform.position, target.position); //����ġ�� target�� ��ġ ������ �Ÿ��� ����
        if (dis <= 100) // �Ÿ��� 10ĭ ������ ���������� �i�� ����
        {
            Move();
        }
        else return;
    }

    void Move()
    {
        Vector2 targetPosition = new Vector2(target.position.x, target.position.y); // ��ǥ ��ġ�� �����ɴϴ�.
        Vector2 currentPosition = new Vector2(transform.position.x, transform.position.y); // ���� ��ġ�� �����ɴϴ�.

        Vector2 direction = (targetPosition - currentPosition).normalized; // ��ǥ������ ������ ����ȭ�մϴ�.

        transform.Translate(direction * Monster.speed * Time.deltaTime);

    }
}