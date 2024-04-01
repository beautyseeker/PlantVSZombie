using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///子弹  负责攻击僵尸
/// </summary>
public class PeaBullet : MonoBehaviour
{

    //速度
    private float speed = 1.5f;
    //方向
    private Vector3 dir = new Vector3(1, 0, 0);
    //伤害
    public int damage = 20;

    private void Start()
    {
        StartCoroutine(DeleteBullet());
    }
    private IEnumerator DeleteBullet()
    {
        //等待5f    子弹销毁
        yield return new WaitForSeconds(5);
        //GameObject.Destroy(gameObject);
        gameObject.SetActive(false);
    }


    private void Update()
    {
        transform.Translate(dir * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 如果是僵尸   僵尸减血   子弹失活

        if (collision.tag == "Zombie")
        {
            Zombine zom = collision.GetComponent<Zombine>();

            if (zom != null)
            {


                zom.ChangeHealth(-damage);

                gameObject.SetActive(false);
            }

        }
    }

}
