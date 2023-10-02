using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectBtn : MonoBehaviour
{
    const string MainSceneName = "Main Scene";
    const string StartSceneName = "StartScene";

    public void CallMain()
    {
        SceneManager.LoadScene(MainSceneName);
    }
    public void CallStart()
    {
        SoundManager.Instance.PlayBGM(SoundManager.BGM.InGame);
        SceneManager.LoadScene(StartSceneName);
    }
}
