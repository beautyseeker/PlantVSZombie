using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 太阳花
/// </summary>
public class SunFlower : Plant
{

    //
    private float timer;

    private float internel = 10f;

    //private Animator anim;



    //public bool isOnGround;


    //public int currentHealth;

    //public int maxHealth = 6;

    public override void Start()
    {
        anim = GetComponent<Animator>();
        timer = 0;
        isOnGround = false;
        currentHealth = maxHealth;


    }

    private void Update()
    {
        if (isOnGround == false) { return; }
        timer += Time.deltaTime;

        if (timer >= internel)
        {
            //播放动画    动画播放完毕  产生太阳
            anim.SetBool("isLight", true);

        }
    }


    public void FinishSunAnimOver()
    {
        //创建阳光
        CreateSun();
        //重置timer  播放变暗动画

        anim.SetBool("isLight", false);

        timer = 0;
    }


    private void CreateSun()
    {

        //判断阳光生成在哪边
        bool isLeft;
        // Random.Range(0,2) 返回0 1
        isLeft = Random.Range(0, 2) < 1;
        GameObject go = Resources.Load<GameObject>("Prefabs/Sun");
        if (isLeft)
        {
            float X = Random.Range(transform.position.x - 1.5f, transform.position.x - 1.1f);
            float Y = Random.Range(transform.position.y - 0.9f, transform.position.x + 0.6f);
            GameObject sun = Instantiate(go);
            sun.transform.position = new Vector3(X, Y, 0);

        }
        else
        {
            float X = Random.Range(transform.position.x + 1.1f, transform.position.x + 1.5f);
            float Y = Random.Range(transform.position.y + 0.6f, transform.position.x + 0.9f);
            GameObject sun = Instantiate(go);
            sun.transform.position = new Vector3(X, Y, 0);
        }
    }

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
