using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

/// <summary>
///子弹  负责攻击僵尸
/// </summary>
public class PeaBullet : MonoBehaviour
{
    [SerializeField] private float bulletSpeed;
    [SerializeField] private int damage = 10;

    private void Start()
    {
        Destroy(gameObject, 4);
    }

    private void Update()
    {
        transform.Translate(bulletSpeed*Time.deltaTime*Vector3.right);
    }
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Zombie")
        {
            Destroy(gameObject);
            // 豌豆子弹爆裂动画
            // 僵尸掉血
            col.GetComponent<Zombie>().ChangeHealth(damage);
        }
    }
}
