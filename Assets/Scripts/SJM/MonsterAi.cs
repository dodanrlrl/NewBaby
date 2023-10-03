using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAi : MonoBehaviour
{
    public Transform target; //�翬�� Ÿ���� �÷��̾� �� ���̴�. Transform���� Target�� ��ġ�� �޾ƿ´�.
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

        // �̹����� ������ �����Ͽ� �¿� ������ �����մϴ�.
        if (direction.x > 0) // �÷��̾ �����ʿ� ���� ��
        {
            transform.localScale = new Vector3(1, 1, 1); // �̹����� ���� �������� ����
        }
        else if (direction.x < 0) // �÷��̾ ���ʿ� ���� ��
        {
            transform.localScale = new Vector3(-1, 1, 1); // �̹����� �¿� ����
        }

        // ���� ���⿡ ���� �̵��մϴ�.
        transform.Translate(direction * Monster.speed * Time.deltaTime);

    }
}
