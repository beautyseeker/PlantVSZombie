using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;


enum SunSize
{
    Small,
    Normal
}

public class SunSupply : MonoBehaviour
{
    [SerializeField] private SunSize sunType = SunSize.Normal;
    [SerializeField] private Image sunImg;
    private int SupplyAmount
    {
        get
        {
            if (sunType == SunSize.Normal) return 50;
            else if (sunType == SunSize.Small) return 15;
            return 0;
        }
    }
    [SerializeField] private float vanishTime = 20;
    private float existTime;

    void Update()
    {
        existTime += Time.deltaTime;
        if(existTime >= vanishTime)
            SunVanish();
    }

    public void SunVanish()
    {
        Destroy(gameObject);
    }

    private void OnMouseDown()
    {
        CollectSun();
    }

    public void JumpTo(Vector3 targetPos)
    {
        targetPos.z = -1;
        Vector3 middlePos = (transform.position + targetPos) / 2;
        float toMiddleDistX = middlePos.x - transform.position.x;
        middlePos.y = transform.position.y + toMiddleDistX;
        transform.DOPath(new Vector3[] { transform.position, middlePos, targetPos }, 0.5f)
            .SetEase(Ease.OutQuad);
    }

    public void Drop()
    {
        transform.DOMoveY(Random.Range(-4f, 3f), 5f);
    }

    private void CollectSun()
    {
        sunImg.DOFade(0.5f, 0.3f);
        Vector3 leftConor = SunManager.Instance.textWorldPos;
        transform.DOMove(leftConor, 1f).SetEase(Ease.OutQuad).onComplete = () =>
        {
            SunManager.Instance.SunIncrease(SupplyAmount);
            SunVanish();
        };
    }
}
