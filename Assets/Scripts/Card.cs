using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

/// <summary>
///      卡片     
/// </summary>
public class Card : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    //冷却时间
    public float coolTime = 4;
    //计时器
    private float timer;

    private Image image;

    private GameObject bg;
    //花费的阳光
    public int costSun;

    //要创建的植物物体
    public GameObject plantPrefab;



    //当前的物体
    public GameObject curObj;






    private void Start()
    {
        //初始化
        costSun = 50;
        timer = 0;
        image = transform.Find("progress").GetComponent<Image>();
        bg = transform.Find("bg").gameObject;

        //string[] cardName = name.Split("_");
        //string resPath = "Prefabs/" + cardName[1];
        //Debug.Log(resPath);
        LoadByName(gameObject.name);
    }


    private void Update()
    {
        //计时 更新UI
        timer += Time.deltaTime;
        UpdateProgress();
        UpdateBg();

    }


    private void UpdateProgress()
    {
        //计算相应的百分比
        float per = Mathf.Clamp(timer / coolTime, 0, 1);

        image.fillAmount = 1 - per;
    }


    private void UpdateBg()
    {
        //1.是否冷却  fillAmount=0
        //2.如果当前拥有的阳光  比消耗的阳光多  

        if (image.fillAmount == 0 && GameMgr.Instance.GetSun() >= costSun)
        {


            bg.SetActive(false);

        }
        else
        {
            bg.SetActive(true);
        }
    }


    //屏幕坐标  转  z为0的世界坐标
    public Vector3 ScreenToWorld(Vector3 pos)
    {

        Vector3 po = Camera.main.ScreenToWorldPoint(pos);

        //确保pos 为0；
        Vector3 final = new Vector3(po.x, po.y, 0);
        return final;

    }
    //根据名字 加载 物体
    public void LoadByName(string name)
    {
        // 切割字符串
        string[] cardName = name.Split("_");
        //加载预制体
        string resPath = "Prefabs/" + cardName[1];
        plantPrefab = Resources.Load<GameObject>(resPath);


    }


    //生成一个物体  出现在鼠标所对应的世界处坐标
    public void OnBeginDrag(PointerEventData eventData)
    {
        //  Debug.Log(eventData.position);  
        //  eventData.position  不是  世界坐标    做转换
        // unity 坐标系   1. 世界坐标系   2.屏幕坐标系     3.视口坐标  ***

        //如果黑色背景激活
        if (bg.activeSelf)
        {
            return;
        }
        curObj = Instantiate(plantPrefab);
        curObj.transform.position = ScreenToWorld(eventData.position);


    }

    //  让物体 跟随 着鼠标
    public void OnDrag(PointerEventData eventData)
    {
        if (curObj != null)
        {
            curObj.transform.position = ScreenToWorld(eventData.position);
        }
    }
    //让物体生成在点击到的格子上
    public void OnEndDrag(PointerEventData eventData)
    {

        //计时器重置
        timer = 0;

        //UI更新  
        GameMgr.Instance.ChangSun(-costSun);

        UIMgr.Instance.ChangeUICount(GameMgr.Instance.GetSun());

        //开始正式种植
        if (curObj == null) { return; }


        Collider2D[] col = Physics2D.OverlapPointAll(ScreenToWorld(eventData.position));

        // 遍历所有的格子

        for (int i = 0; i < col.Length; i++)
        {

            //1 是格子

            //2有没有植物
            if (col[i].tag == "Land" && col[i].gameObject.transform.childCount == 0)
            {

                curObj.transform.position = col[i].transform.position;

                curObj.transform.SetParent(col[i].transform);


                //这里我们生成的是游戏物体  拖动时会调用方法
                //会出现 拖动时发射子弹的bug
                //设置isOnGround 为true


                //以豌豆为例 后续会提取Plant 类
                //Peashooter obj = curObj.GetComponent<Peashooter>();

                //if (obj != null)
                //{

                //    obj.isOnGround = true;

                //}

                Plant obj = curObj.GetComponent<Plant>();
                




                curObj = null;
                return;


            }

        }
        // 如果没有合适的格子   curob还在

        if (curObj != null)
        {
            GameObject.Destroy(curObj);
            curObj = null;
        }







    }
}
