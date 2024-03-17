using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Cell : MonoBehaviour
{
    public GameObject plantPrefab;

    private void OnMouseDown()
    {
        if (plantPrefab == null)
        {
            HandManager.Instance.OnCellClick(this);
        }

    }

    private void OnMouseEnter()
    {
        // 方格内生成植物虚影
    }

    private void OnMouseExit()
    {
        // 方格内虚影消失
    }
}
