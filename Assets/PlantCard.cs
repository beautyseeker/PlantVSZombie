using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public enum CardState
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
    public CardState curState = CardState.Cooling;

    [SerializeField] private float CDTime = 4;
    [SerializeField] private int sunCost = 50;

    public int SunCost
    {
        get { return sunCost; }
    }
    private float eclipsedTime;

    [SerializeField] private Button button;

    public Plant plantInstance;

    private void Start()
    {
        button.onClick.AddListener(OnCardPick);
    }

    private void OnCardPick()
    {
        HandManager.Instance.OnPlantCardClick(this);
    }

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

    public void TransitionToCooling()
    {
        // 检测到点击且放置后则切换为Cooling态
        cardLight.SetActive(false);
        cardGray.SetActive(true);
        coolingMask.gameObject.SetActive(true);
        curState = CardState.Cooling;
    }

    private void WaitSunUpdate()
    {

        if (SunManager.Instance.SunAmount >= sunCost)
        {
            cardLight.SetActive(true);
            cardGray.SetActive(false);
            coolingMask.gameObject.SetActive(false);
            curState = CardState.Ready;
        }
    }
    
}
