using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandManager : MonoBehaviour
{
    public static HandManager Instance;
    public GameObject plantOnHand;
    public PlantCard curPlantType;

    private void Awake()
    {
        Instance = this;
    }
    
    void Update()
    {
        if (plantOnHand != null)
        {
            Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mouseWorldPos.z = 0;
            plantOnHand.transform.position = mouseWorldPos;
        }
    }

    public void OnCellClick(Cell cell)
    {
        if (plantOnHand != null)
        {
            plantOnHand.transform.position = cell.transform.position;
            cell.plantPrefab = plantOnHand;
            SunManager.Instance.SunDecrease(curPlantType.SunCost);
            curPlantType.TransitionToCooling();
            plantOnHand = null;
        }
    }

    public void OnPlantCardClick(PlantCard card)
    {
        if (plantOnHand == null)
        {
            curPlantType = card;
            Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mouseWorldPos.z = 0;
            plantOnHand = Instantiate(card.plantInstance.gameObject, mouseWorldPos, Quaternion.identity);
        }
    }
}
