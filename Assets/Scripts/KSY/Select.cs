using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Select : Singleton<Select>
{
    [Header("# Object ")]
    public GameObject[] characterPrefabs; //  Prefabs 배열
    [HideInInspector]
    public GameObject currentCharacter;   // 현재 캐릭

    public List<Vector3> Enter;
    public List<Vector3> Exit;
    public List<GameObject> Door;
    public Vector3 Boss;
    public int Draw;

    public static int Dies = 0;

    [Header("# Doors ")]

    public GameObject[] Doors;

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

        currentCharacter = Instantiate(characterPrefabs[0], Enter[Draw], Quaternion.identity);
        SpawnCharacter();
        Door.Add(GameObject.Find("Door1"));
        Door.Add(GameObject.Find("Door2"));
        Door.Add(GameObject.Find("Door3"));
    }

    private void SpawnCharacter()
    {

        //Enter.Count 는 소환 좌표의 총 갯수를 의미함 
        // 총 갯수가 0 이 아닐때, 즉 모든 스테이지를 클리어하지 않을때에는 true 그렇지 않으면 false
        if (Enter.Count != 0)
        {
            Draw = Random.Range(0, Enter.Count);
            currentCharacter.transform.position = Enter[Draw];
            Enter.RemoveAt(Draw);
        }
        else
        {
            currentCharacter.transform.position = Boss;
        }
    }

    public void Update()
    {
        if (Exit.Count != 0)
        {
            if (Vector3.Distance(currentCharacter.transform.localPosition, Exit[Draw]) <= 1)
            {
                UIManager.Instance.MoveMaps();
                Exit.RemoveAt(Draw);
                SpawnCharacter();
            }
           
        }
    }

    public void NextStage()
    {
         Door[Draw].SetActive(false);
         Door.RemoveAt(Draw);
    }

    public void ChangeCharacter(int characterIndex)
    {
        // 캐릭 변경 수정 1차
        //SpawnCharacter();
    }
}