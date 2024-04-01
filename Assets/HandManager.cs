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
            PlantFollowMouse();
            if (Input.GetMouseButtonDown(1))
            {
                Destroy(plantOnHand);
                plantOnHand = null;
            }
        }
    }

    public void OnCellClick(Cell cell)
    {
        if (plantOnHand != null)
        {
            plantOnHand.transform.position = cell.transform.position;
            cell.plantInCell = plantOnHand;
            plantOnHand.GetComponent<Plant>().EnableOnHandFeature(false);
            SunManager.Instance.SunDecrease(curPlantType.SunCost);
            curPlantType.TransitionToCooling();
            plantOnHand = null;
        }
    }

    public void OnPlantCardClick(PlantCard card)
    {
        if (plantOnHand == null)
        {
            FetchPlantOnMouse(card);
        }
    }

    private void FetchPlantOnMouse(PlantCard card)
    {
        curPlantType = card;
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPos.z = 0;
        plantOnHand = Instantiate(card.plantInstance.gameObject, mouseWorldPos, Quaternion.identity);
        plantOnHand.GetComponent<Plant>().EnableOnHandFeature(true);
    }

    private void PlantFollowMouse()
    {
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPos.z = 0;
        plantOnHand.transform.position = mouseWorldPos;
    }
}
