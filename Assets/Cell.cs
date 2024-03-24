using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Cell : MonoBehaviour
{
    public GameObject plantInCell;

    private void OnMouseDown()
    {
        if (plantInCell == null)
        {
            HandManager.Instance.OnCellClick(this);
        }

    }

    private void OnMouseEnter()
    {
        if (HandManager.Instance.plantOnHand != null && plantInCell != null)
        {
            // 方格内生成植物虚影
        }

    }

    private void OnMouseExit()
    {
        if (HandManager.Instance.plantOnHand != null && plantInCell != null)
        {
            // 方格内虚影消失
        }

    }
}
