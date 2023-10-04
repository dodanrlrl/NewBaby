using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private static UIManager _instance;
    public static UIManager Instance
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
    public HP hp;

    [SerializeField] private GameObject EndPannel;
    private const string StartScene = "StartScene";
    private const string MainScene = "Main Scenes";

    public Image[] maps;
    private int curMapIndex;

    private void Awake()
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
    private void Start()
    {
        curMapIndex = 0;
    }

    public void InitializeHp()
    {
        hp.UpdateHP();
    }
    public void TurnOnEndPannel()
    {
        EndPannel.SetActive(true);
    }
    public void PressMainButton()
    {
        EndPannel.SetActive(false);
        SceneManager.LoadScene(StartScene);
    }
    public void PressRestartButton()
    {
        EndPannel.SetActive(false);
        SceneManager.LoadScene(MainScene);
    }
    public void MoveMaps()
    {
        maps[curMapIndex].color = Color.white;

        if (curMapIndex == maps.Length)
        {
            SoundManager.Instance.PlayBGM(SoundManager.BGM.Boss);
        }

        if (curMapIndex < maps.Length - 1)  //½ÃÀÛ ±âÁØÀ¸·Î, ´ÙÀ½ Ä­, ´Ù´ÙÀ½Ä­, º¸½ºÄ­. ÃÑ ¼¼°³ÀÇ ÀÎµ¦½º
        {
            maps[curMapIndex + 1].gameObject.SetActive(true);
            curMapIndex++;
        }
    }
    public void PressUseButton()
    {
        if (Inventory.Instance.slots[Inventory.Instance.selectedItemIndex].quantity != 0)
        {
            Gamemanager.Instance.player.TakeHeal(Inventory.Instance.selectedItem.item.healthFigures, 0);
            Gamemanager.Instance.player.GetComponent<TopDownCharacter>().UpAttackPower(Inventory.Instance.selectedItem.item.attackFigures);
            Gamemanager.Instance.player.GetComponent<TopDownCharacter>().UpSpeed(Inventory.Instance.selectedItem.item.speedFigures);
            Inventory.Instance.slots[Inventory.Instance.selectedItemIndex].quantity--;
            Inventory.Instance.UpdateUI();
        }
        if (Inventory.Instance.slots[Inventory.Instance.selectedItemIndex].quantity == 0)
            Inventory.Instance.ClearSlot(Inventory.Instance.selectedItemIndex);
    }
}
