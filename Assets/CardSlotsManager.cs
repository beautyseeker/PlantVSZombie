using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CardSlotsManager : MonoBehaviour
{
    // 传入关卡植物名
    public List<PlantCard> slotCards;
    static public CardSlotsManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    private void InitSlots()
    {
        
    }
}
