using System.Collections;
using System.Collections.Generic;
using UnityEngine;





/// <summary>
/// 游戏管理
/// </summary>
public class GameMgr : MonoBehaviour
{
    public static GameMgr Instance;
    //太阳数
    private int sunCount;



    //public Transform[] bornPoint;

    //public GameObject zombiePrefab;

    //private int layerIndex = 0;


    ////1.利用路点随机生成
    ////暂时  等待一定时间 生成
    //private IEnumerator CreateZombine(float createTime)
    //{
    //    //等待一定时间
    //    yield return new WaitForSeconds(createTime);
    //    //生成物体
    //    GameObject go = GameObject.Instantiate(zombiePrefab);
    //    //随机坐标
    //    int index = Random.Range(0, 5);//0 1 2 3 4
    //    go.transform.parent = bornPoint[index];
    //    go.transform.localPosition = Vector3.zero;

    //    //设置层级
    //    layerIndex += 1;

    //    go.GetComponent<SpriteRenderer>().sortingOrder = layerIndex;

    //    //再生成
    //    StartCoroutine(CreateZombine(3));
    //}


    //public void CreateEnemy()
    //{
    //    //StartCoroutine(CreateZombine(3));
    //}



    private void Start()
    {
        Instance = this;
        //sunCount = 100;
        //UIMgr.Instance.ChangeUICount(sunCount);

        //CreateEnemy();
        SoundMgr.Instance.PlayBGM(Config.Bgm1, 1);
    }
    //获取阳光
    public int GetSun()
    {
        return sunCount;
    }
    //更新阳光数量及显示
    public void ChangSun(int num)
    {
        if (sunCount + num < 0)
        {
            return;
        }
        //数据

        sunCount += num;

        //UI
        UIMgr.Instance.ChangeUICount(sunCount);

    }





}
