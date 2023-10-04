using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
    //public player player; //player script�� topDownCharacter ��ũ��Ʈ�� ����ҿ����̶� �ٲپ��  
    public TopDownCharacter player;

    //[SerializeField] private Transform spawnPositionsRoot;
    //private List<Transform> spawnPostions = new List<Transform>();
    public List<GameObject> rewards = new List<GameObject>();
    [Range(0, 100)] public int dropPer;

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
    }

    void Update()
    {
        if(player.CurrentHp <= 0)
        {
            GameOver();
        }
        
    }
    public void CreateReward(Vector3 spawnPosition)
    {
        if(UnityEngine.Random.Range(0, 100) < dropPer)
        {
            int idx = UnityEngine.Random.Range(0, rewards.Count);

            GameObject obj = rewards[idx];
            Instantiate(obj, spawnPosition, Quaternion.identity);
        }
    }
    public void GameStart()
    {
        SoundManager.Instance.PlayBGM(SoundManager.BGM.Start);
    }

    public void GameOver()
    {
        GameOverSetting();
    }
    IEnumerator GameOverSetting()
    {
        yield return new WaitForSeconds(0.5f);
        UIManager.Instance.TurnOnEndPannel();
        SoundManager.Instance.PlayEffect(SoundManager.Effect.Lose);
    }

    public void GameVictory()
    {
        GameVictorySetting();
    }
    IEnumerator GameVictorySetting()
    {
        yield return new WaitForSeconds(0.5f);
        //VictoryUI
        SoundManager.Instance.PlayEffect(SoundManager.Effect.Win);
    }
}
