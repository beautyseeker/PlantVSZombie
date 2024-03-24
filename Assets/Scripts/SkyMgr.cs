using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 天空中生成太阳管理
/// </summary>
public class SkyMgr : MonoBehaviour
{
    public static SkyMgr Instance;

    private float MinX = -6.4F;
    private float MaxX = 3.7F;

    private float MinY = -3.5F;
    private float MaxY = 2.8F;

    private GameObject sunPre;
    private void Awake()
    {
        Instance = this;

        sunPre = Resources.Load<GameObject>("Prefabs/Sun");

        //InvokeRepeating("CreateSun", 2, 5);
    }
    //创建太阳
    public void StartCreateSun(float delay = 5)
    {
        InvokeRepeating("CreateSun", 5, delay);
    }

    //停止创建
    public void StopCreate()
    {
        CancelInvoke();
    }

    private void CreateSun()
    {
        //生成太阳
        GameObject go = GameObject.Instantiate(sunPre);
        Sun sun = go.GetComponent<Sun>();
        //初始化坐标
        float X = Random.Range(MinX, MaxX);
        float Y = Random.Range(MinY, MaxY);
        sun.InitSkySun(X, transform.position.y, Y);
    }

}
