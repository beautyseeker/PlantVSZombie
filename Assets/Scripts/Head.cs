using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 头
/// </summary>
public class Head : MonoBehaviour
{
    //动画播放 完毕  失活
    public void FinisHead()
    {
        gameObject.SetActive(false);
    }
}
