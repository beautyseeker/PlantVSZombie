using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 摄像机  注不能命名为Camera 否则冲突  单例
/// </summary>
public class CameraM : MonoBehaviour
{
    public static CameraM Instance;


    private void Awake()
    {
        Instance = this;
        // 初始化坐标
        transform.position = new Vector3(-3, 0, -10);
    }

    private void Start()
    {
        //测试
        // CameraMove();
    }

    public void CameraMove()
    {
        StartCoroutine(MoveRight());
    }




    //-3        1
    private IEnumerator MoveRight()
    {
        //相机移动到右边时  创建用于显示的僵尸
        ZombieMgr.Instance.CreateStartZombie();
        //当 x<1 是  每隔0.02   向右移动0.04
        while (transform.position.x <= 1)
        {
            yield return new WaitForSeconds(0.02f);
            transform.position += new Vector3(0.04f, 0, 0);
        }



        StartCoroutine(MoveLeft());

    }


    private IEnumerator MoveLeft()
    {
        //当 x>=-3 是  每隔0.02   向左移动0.04
        while (transform.position.x >= -3)
        {
            yield return new WaitForSeconds(0.02f);
            transform.position -= new Vector3(0.04f, 0, 0);
        }

        // 消除  显示的僵尸
        ZombieMgr.Instance.DestoryZombieShow();
        //显示UI
        UIMgr.Instance.ShowUI();

        UIMgr.Instance.ChangeUICount(GameMgr.Instance.GetSun());
        //显示准备动画
        UIMgr.Instance.ShowReady();

        //阳光开始创建

        SkyMgr.Instance.StartCreateSun();
        //*****


    }
}
