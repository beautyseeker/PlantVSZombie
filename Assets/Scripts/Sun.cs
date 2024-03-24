using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
//太阳 ：天上掉落  太阳花掉落
/// </summary>
public class Sun : MonoBehaviour
{
    //是否是天上掉落的
    private bool isSkySun;




    //天空中的太阳下落的目标点
    private float TargetY;

    //速度
    private float speed = 1;

    private GameObject sunNum;
    //是否被点击
    private bool isClick = false;

    private void Start()
    {
        sunNum = GameObject.Find("SunNum");
    }



    //初始化天上的太阳 初始化开始的位置 及TargetY
    public void InitSkySun(float x, float y, float targetY)
    {
        transform.position = new Vector3(x, y, 0);

        TargetY = targetY;

        isSkySun = true;


    }


    private void Update()
    {

        if (isSkySun == true)
        {
            // 天空下落的太阳   过程中 未被点击  
            if (isClick == false)
                if (transform.position.y > TargetY)
                {
                    transform.Translate(new Vector3(0, -1, 0) * Time.deltaTime * speed);
                }
                else
                {
                    Destroy(gameObject, 3f);
                }

        }
    }


    //鼠标点击事件
    private void OnMouseDown()
    {
        isClick = true;
        //数据区更新  UI更新
        GameMgr.Instance.ChangSun(50);

        UIMgr.Instance.ChangeUICount(GameMgr.Instance.GetSun());


        //  坐标转换

        Vector3 target = Camera.main.ScreenToWorldPoint(sunNum
             .transform.position);



        //调用方法
        StartCoroutine(FlyTO(target));
    }

    private IEnumerator FlyTO(Vector3 target)
    {
        //获取方向向量
        Vector3 dir = (target - transform.position).normalized;
        //判断距离

        while (Vector3.Distance(target, transform.position) > 0.1f)
        {
            //等待0.01 f
            yield return new WaitForSeconds(0.02f);
            transform.Translate(dir * 0.4f);
        }

        //当距离小于0.1
        GameObject.Destroy(gameObject);
    }



}
