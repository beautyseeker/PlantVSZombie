using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunManager : MonoBehaviour
{
    public static SunManager Instance;
    [SerializeField] private int sunAmount;

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
    }
}
