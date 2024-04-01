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

    protected override void Awake()
    {
        base.Awake();
        peaBullet = Resources.Load<GameObject>("PlantInstance/PeaBullet");
        bulletSpawnPos = transform.Find("BulletSpawnPos");
    }

    public void Shoot()
    {
        if(flyingBullet == null)
            flyingBullet = Instantiate(peaBullet, bulletSpawnPos.position, Quaternion.identity);
    }
    
    public override void EnableOnHandFeature(bool onHand)
    {
        base.EnableOnHandFeature(onHand);
        if(!onHand)
            InvokeRepeating("Shoot",0,1);
    }
}
