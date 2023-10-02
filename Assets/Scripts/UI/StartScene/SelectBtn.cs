using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectBtn : MonoBehaviour
{
    const string MainSceneName = "Main Scenes";
    const string StartSceneName = "StartScene";

    public void CallMain()
    {
        SoundManager.Instance.PlayBGM(SoundManager.BGM.InGame);
        SceneManager.LoadScene(MainSceneName);
    }
    public void CallStart()
    {
        SceneManager.LoadScene(StartSceneName);
    }
}
