using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 格子类   坐标 基点
/// </summary>
public class Grid : MonoBehaviour
{
    private void Start()
    {
        CreateGrid();
    }
    public void CreateGrid()
    {
        GameObject go = new GameObject();

        go.AddComponent<BoxCollider2D>();

        go.GetComponent<BoxCollider2D>().size = new Vector2(1f, 1.5f);

        go.transform.position = transform.position;


        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 5; j++)
            {

                GameObject tmp = Instantiate(go);

                tmp.tag = "Land";

                tmp.transform.position = transform.position + new Vector3(1.33f * i, 1.63f * j, 0);

                tmp.name = i + "_" + j;
            }

        }

    }
}
