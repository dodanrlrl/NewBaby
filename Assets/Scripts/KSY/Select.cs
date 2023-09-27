using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Select : MonoBehaviour
{
    [Header("# Object ")]
    public GameObject[] characterPrefabs; //  Prefabs �迭
    private GameObject currentCharacter;   // ���� ĳ��

    public List<Vector3> Enter;
    public List<Vector3> Exit;
    public Vector3 Boss;
    public int Draw;

    private void Start()
    {

        // ��ȯ ��ǥ �߰�
        Enter.Add(new Vector3(-36.3f, 8.7f, 0));
        Enter.Add(new Vector3(-66.4f, -1.5f, 0));
        Enter.Add(new Vector3(-97.4f, -2.8f, 0));

        // �ⱸ ��ǥ �߰�
        Exit.Add(new Vector3(-43.51f, 11.41f, 0));
        Exit.Add(new Vector3(-65.39f, 11.69f, 0));
        Exit.Add(new Vector3(-95.73f, 1.26f, 0));

        Boss = new Vector3(-127.8f, -7.2f, 0);

        SpawnCharacter(0);
    }

    private void SpawnCharacter(int characterIndex)
    {

        Destroy(currentCharacter);

        // Enter.Count �� ��ȯ ��ǥ�� �� ������ �ǹ���
        // �� ������ 0 �� �ƴҶ�, �� ��� ���������� Ŭ�������� ���������� true �׷��� ������ false
        if (Enter.Count != 0)
        {
            // Draw �� 0 ~ ���� �������� �� ���� �� ����� + ĳ���� ���� �� ����
            Draw = Random.Range(0, Enter.Count);
            currentCharacter = Instantiate(characterPrefabs[characterIndex], Enter[Draw], Quaternion.identity);
            Enter.RemoveAt(Draw);
        }
        else
        {
            currentCharacter = Instantiate(characterPrefabs[characterIndex], Boss, Quaternion.identity);
        }
    }

    public void Update()
    {
        if (Exit.Count != 0)
        {
            if (Vector3.Distance(currentCharacter.transform.localPosition, Exit[Draw]) <= 1)
            {
                Exit.RemoveAt(Draw);
                SpawnCharacter(0);
            }
        }
    }
    public void ChangeCharacter(int characterIndex)
    {
        // ĳ�� ����
        SpawnCharacter(characterIndex);
    }
}