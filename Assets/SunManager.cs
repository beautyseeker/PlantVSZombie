using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class SunManager : MonoBehaviour
{
    public static SunManager Instance;
    [SerializeField] private int sunAmount = 50;
    [SerializeField] private TextMeshProUGUI sunText;
    public Vector3 textWorldPos;
    [SerializeField] private GameObject sunSupply;
    [SerializeField] private float spawnDropSunInterval = 20;
    private float timer;
    private void Awake()
    {
        sunText.text = SunAmount.ToString();
        textWorldPos = Camera.main.ScreenToWorldPoint(sunText.transform.position);
        Instance = this;
    }

    public int SunAmount
    {
        get
        {
            return sunAmount;
        }
    }

    public void SunDecrease(int sunCost)
    {
        sunAmount -= sunCost;
        sunText.text = SunAmount.ToString();
    }

    public void SunIncrease(int sunCollect)
    {
        sunAmount += sunCollect;
        sunText.text = sunAmount.ToString();
    }

    public void SpawnDropSun()
    {
        Vector3 randomHorizontalPos = new Vector3(Random.Range(-7f, 4f), 5.5f, -1);
        var sun = Instantiate(sunSupply, randomHorizontalPos, Quaternion.identity);
        sun.GetComponent<SunSupply>().Drop();
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer > spawnDropSunInterval)
        {
            SpawnDropSun();
            timer = 0;
        }
    }
}
