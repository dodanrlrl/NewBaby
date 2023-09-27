using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Select : MonoBehaviour
{
    [Header("# Object ")]
    public GameObject[] characterPrefabs; //  Prefabs 배열
    private GameObject currentCharacter;   // 현재 캐릭

    public List<Vector3> Enter;
    public List<Vector3> Exit;
    public Vector3 Boss;
    public int Draw;

    private void Start()
    {

        // 소환 좌표 추가
        Enter.Add(new Vector3(-36.3f, 8.7f, 0));
        Enter.Add(new Vector3(-66.4f, -1.5f, 0));
        Enter.Add(new Vector3(-97.4f, -2.8f, 0));

        // 출구 좌표 추가
        Exit.Add(new Vector3(-43.51f, 11.41f, 0));
        Exit.Add(new Vector3(-65.39f, 11.69f, 0));
        Exit.Add(new Vector3(-95.73f, 1.26f, 0));

        Boss = new Vector3(-127.8f, -7.2f, 0);

        SpawnCharacter(0);
    }

    private void SpawnCharacter(int characterIndex)
    {

        Destroy(currentCharacter);

        // Enter.Count 는 소환 좌표의 총 갯수를 의미함
        // 총 갯수가 0 이 아닐때, 즉 모든 스테이지를 클리어하지 않을때에는 true 그렇지 않으면 false
        if (Enter.Count != 0)
        {
            // Draw 를 0 ~ 남은 스테이지 수 랜덤 수 출력함 + 캐릭터 삭제 후 생성
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
        // 캐릭 변경
        SpawnCharacter(characterIndex);
    }
}