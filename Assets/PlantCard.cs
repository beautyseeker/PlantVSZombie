using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


enum CardState
{
    Cooling,
    WaitSun,
    Ready
}
public class PlantCard : MonoBehaviour
{
    [SerializeField] private GameObject cardLight;
    [SerializeField] private GameObject cardGray;
    [SerializeField] private Image coolingMask;
    private CardState curState = CardState.Cooling;

    [SerializeField] private float CDTime = 4;
    [SerializeField] private int sunCost = 50;
    private float eclipsedTime;

    private void Update()
    {
        switch (curState)
        {
            case CardState.Cooling:
                CoolingUpdate();
                break;
            case CardState.WaitSun:
                WaitSunUpdate();
                break;
            case CardState.Ready:
                ReadyUpdate();
                break;
        }
        
    }

    private void CoolingUpdate()
    {
        eclipsedTime += Time.deltaTime;
        coolingMask.fillAmount =  1 - eclipsedTime / CDTime;
        if (eclipsedTime >= CDTime)
        {
            eclipsedTime = 0;
            cardLight.SetActive(false);
            cardGray.SetActive(true);
            coolingMask.gameObject.SetActive(false);
            curState = CardState.WaitSun;
        }
    }

    private void ReadyUpdate()
    {
        // 检测到点击且放置后则切换为Cooling态
    }

    private void WaitSunUpdate()
    {

        if (SunManager.Instance.SunAmount >= sunCost)
        {
            SunManager.Instance.SunDecrease(sunCost);
            cardLight.SetActive(true);
            cardGray.SetActive(false);
            coolingMask.gameObject.SetActive(false);
            curState = CardState.Ready;
            // curState = CardState.Cooling;
            // cardLight.SetActive(false);
            // cardGray.SetActive(true);
            // coolingMask.gameObject.SetActive(false);
        }
    }
    
}
