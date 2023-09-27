using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpUI : MonoBehaviour
{
    float fSliderBarTime;
    Slider slHP;

    [SerializeField] Transform fillArea;
    [SerializeField] Transform backGround;
    private void Start()
    {
        slHP = GetComponent<Slider>();
    }
    private void Update()
    {
        SetSlider();
    }
    private void SetSlider()
    {
        if (slHP.value <= 0)
            fillArea.gameObject.SetActive(false);
        else if (slHP.value >= 1)
            backGround.gameObject.SetActive(false);
        else
        {
            fillArea.gameObject.SetActive(true);
            backGround.gameObject.SetActive(true);
        }
    }
}
