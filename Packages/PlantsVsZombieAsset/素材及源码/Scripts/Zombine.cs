using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 僵尸
/// </summary>
public class Zombine : MonoBehaviour
{
    //速度
    private float speed = 0.267f;
    //方向
    private Vector3 dir = new Vector3(-1, 0, 0);


    private Animator anim;



    public bool isWalk = true;

    public bool isHurt = false;

    public int damage = 100;
    //攻击间隔
    public float attackInterval = 1f;

    private float damageTime;

    public int currentHealth;

    public int maxHealth = 270;
    //掉头时的血量
    public int lostHeadHealth = 89;

    public bool isDie;

    public GameObject head;

    public bool lostHead;
    //最终点
    private Vector3 finalPoint;
    private void Start()
    {
        anim = GetComponent<Animator>();
        currentHealth = maxHealth;
        head = transform.Find("head").gameObject;
        head.SetActive(false);
        isDie = false;
        lostHead = false;

        finalPoint = new Vector3(-8.47F, -1.17F, 0);

    }

    private void Update()
    {

        //  if (LvMgr.Instance.currentstate == GameState.Fight)

        if (isDie == true)
        {
            return;
        }
        //isWalk  true

        if (isWalk == true)
        {

            transform.position += dir * Time.deltaTime * speed;

            if (transform.position.x < -6.74f)
            {
                Vector3 dir = (finalPoint - transform.position).normalized;
                transform.Translate(dir * Time.deltaTime * speed);


                if (Vector3.Distance(finalPoint, transform.position) < 0.5f)
                {
                    //游戏结束  Todo

                    LvMgr.Instance.currentstate = GameState.End;


                }
            }


        }



    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isDie == true) { return; }
        //如果我们碰到的是植物   
        if (collision.tag == "Plant")
        {

            //进入攻击状态
            isWalk = false;

            anim.SetBool("isWalk", false);
        }

    }
    //开始计时
    private void OnTriggerStay2D(Collider2D collision)
    {

        if (isDie == true) { return; }
        if (collision.tag == "Plant")
        {
            damageTime += Time.deltaTime;
            //可以攻击
            if (damageTime >= attackInterval)
            {
                //重置Time

                damageTime = 0;

                ////扣血   暂时以豌豆射手为例   后面会提Plant 类

                //Peashooter plant = collision.gameObject.GetComponent<Peashooter>();
                //if (plant != null)
                //{

                //    plant.ChangeHealth(-damage);


                //    if (plant.currentHealth <= 0)
                //    {
                //        isWalk = true;
                //        anim.SetBool("isWalk", true);
                //    }
                //}

                //SunFlower plant1 = collision.gameObject.GetComponent<SunFlower>();
                //if (plant1 != null)
                //{

                //    plant1.ChangeHealth(-damage);


                //    if (plant1.currentHealth <= 0)
                //    {
                //        isWalk = true;
                //        anim.SetBool("isWalk", true);
                //    }
                //}

                Plant plant = collision.gameObject.GetComponent<Plant>();

                if (plant != null)
                {
                    plant.ChangeHealth(-damage);
                    if (plant.currentHealth <= 0)
                    {
                        isWalk = true;
                        anim.SetBool("isWalk", true);
                    }


                }



            }

        }


    }

    //退出时  植物死亡
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (isDie == true) { return; }
        isWalk = true;

        anim.SetBool("isWalk", true);
    }


    //改变血量
    public int ChangeHealth(int damage)
    {


        isHurt = true;
        currentHealth += damage;
        Debug.Log(currentHealth);
        //血量 小于 失去头的血量
        if (currentHealth <= lostHeadHealth && !lostHead)
        {
            lostHead = true;
            anim.SetBool("isHurt", true);
            head.SetActive(true);
        }
        if (currentHealth <= 0)
        {
            //播放死亡动画
            anim.SetTrigger("Die");
            isDie = true;
            // GameObject.Destroy(gameObject);
        }

        return currentHealth;
    }

    public void DieAnim()
    {
        anim.enabled = false;

        GameObject.Destroy(gameObject);
    }
}
