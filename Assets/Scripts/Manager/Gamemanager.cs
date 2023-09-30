using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Gamemanager : MonoBehaviour
{
    private static Gamemanager _instance = null;
    public static Gamemanager Instance
    {
        get
        {
            if (null == _instance)
            {
                return null;
            }
            return _instance;
        }
    }
    //public player player; //player script는 topDownCharacter 스크립트를 사용할예정이라 바꾸어둠  
    //public TopDownCharacter playerPrefab;
    
    public TopDownCharacter player;

    //[SerializeField] private Transform spawnPositionsRoot;
    //private List<Transform> spawnPostions = new List<Transform>();
    public List<GameObject> rewards = new List<GameObject>();

    [SerializeField] private GameObject EndPannel;

    void Awake()
    {
        if (null == _instance)
        {
            _instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }

    }

    void Start()
    {
        player = Select.Instance.currentCharacter.GetComponent<TopDownCharacter>(); 
        //player = Instantiate(playerPrefab);
        rewards.Clear();
    }

    void Update()
    {

    }
    void CreateReward()
    {
        int idx = UnityEngine.Random.Range(0, rewards.Count);
        //int posIdx = UnityEngine.Random.Range(0, spawnPostions.Count);

        GameObject obj = rewards[idx];
        //Instantiate(obj, spawnPostions[posIdx].position, Quaternion.identity);
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void GoMenu()
    {
        //문자열 대체 필요해 보임.
        SceneManager.LoadScene("StartScene");
    }



}
