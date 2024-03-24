using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// 豌豆类
/// </summary>
public class Peashooter : Plant
{
    public GameObject peaBullet;
    private Transform bulletSpawnPos;
    private GameObject flyingBullet;

    private void Awake()
    {
        peaBullet = Resources.Load<GameObject>("PlantInstance/PeaBullet");
        bulletSpawnPos = transform.Find("BulletSpawnPos");
    }

    public void Start()
    {
        InvokeRepeating("Shoot",0,1);
    }

    public void Shoot()
    {
        if(flyingBullet == null)
            flyingBullet = Instantiate(peaBullet, bulletSpawnPos.position, Quaternion.identity);
    }
}
