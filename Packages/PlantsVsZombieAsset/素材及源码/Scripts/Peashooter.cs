using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 豌豆类
/// </summary>
public class Peashooter : Plant
{

    //public bool isOnGround;

    //开火点
    private Transform firePoint;

    //每隔几秒生成子弹
    //1.InvokeRepeating()  调雍的方法   第一次调用时的时间   每隔**秒调1次
    //2.计时器 timer  interval  update中计时
    //3. 可能会用到协程  之前在移动的时候用过

    private float timer;
    private float internel = 1.4f;


    //public int currentHealth;
    //public int maxHealth = 6;


    public override void Start()
    {
        currentHealth = maxHealth;
        firePoint = transform.Find("FirePoint");
        timer = 0;
        isOnGround = false;



    }


    //已经种植  才计时
    private void Update()
    {

        if (isOnGround == false)
        {
            return;
        }

        timer += Time.deltaTime;

        if (timer >= internel)
        {
            Fire();
            timer = 0;


        }
    }


    private void Fire()
    {
        //GameObject tmp = Resources.Load<GameObject>("Prefabs/PeaBullet");
        //GameObject go = GameObject.Instantiate(tmp, firePoint);
        GameObject go = BulletPool.Instance.GetPoolObject();
        go.transform.position = firePoint.position;


    }




    //改变血量
    //public int ChangeHealth(int damage)
    //{



    //    currentHealth += damage;
    //    if (currentHealth <= 0)
    //    {
    //        GameObject.Destroy(gameObject);
    //    }

    //    return currentHealth;
    //}
}
