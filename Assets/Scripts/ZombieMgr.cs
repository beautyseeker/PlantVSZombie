using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 僵尸管理
/// </summary>
public class ZombieMgr : MonoBehaviour
{
    public static ZombieMgr Instance;

    public GameObject zombiePrefab;
    //生成点列表
    public Transform[] bornPoint;
    //存储的列表
    public List<Zombine> zombies = new List<Zombine>();

    public List<Zombine> zombineShow = new List<Zombine>();
    private int layerIndex = 0;
    //是否刷新
    public bool isRefresh = false;


    private void Awake()
    {
        Instance = this;
    }



    public void CreateZombine()
    {
        //生成物体
        GameObject go = GameObject.Instantiate(zombiePrefab);
        //随机坐标
        int index = Random.Range(0, 5);//0 1 2 3 4
        go.transform.parent = bornPoint[index];
        go.transform.localPosition = Vector3.zero;


        //设置层级
        layerIndex += 1;

        go.GetComponent<SpriteRenderer>().sortingOrder = layerIndex;
        AddZombine(go.GetComponent<Zombine>());
    }

    public void AddZombine(Zombine zom)
    {
        zombies.Add(zom);
    }

    public void RemoveZombine(Zombine zom)
    {
        zombies.Remove(zom);
    }


    public void CreateStartZombie()
    {
        for (int i = 0; i < 3; i++)
        {
            GameObject go = GameObject.Instantiate(zombiePrefab);
            //随机坐标
            int index = Random.Range(0, 5);//0 1 2 3 4
            go.transform.parent = bornPoint[index];
            go.transform.localPosition = Vector3.zero;

            Zombine zombine = go.GetComponent<Zombine>();
            zombineShow.Add(zombine);
            go.GetComponent<Animator>().speed = 0;

            zombine.isWalk = false;
        }
    }





    public void DestoryZombieShow()
    {

        for (int i = 0; i < zombineShow.Count; i++)
        {
            GameObject.Destroy(zombineShow[i].gameObject);
        }
    }

    public void Start()
    {
        CreateByTime();
    }
    public void CreateByTime()
    {
        StartCoroutine(CreateSomeZombie());
    }

    //使用假数据
    private IEnumerator CreateSomeZombie()
    {
        while (layerIndex < 12)
        {
            //是否在刷
            if (isRefresh == true)
            {
                int delay = Random.Range(2, 5);
                yield return new WaitForSeconds(delay);

                int randomNum = Random.Range(1, 4);
                for (int i = 0; i < randomNum; i++)
                {
                    CreateZombine();
                }
            }
            yield return new WaitForSeconds(5);
        }
        yield return new WaitForSeconds(5);
        StartCoroutine(CreateSomeZombie());
    }

    public void StopCreateZombie()
    {
        StopAllCoroutines();
    }


    public void ClearZombie()
    {
        isRefresh = false;
        for (int i = 0; i < zombies.Count; i++)
        {
            GameObject.Destroy(zombies[i].gameObject);

        }
        //zombies.Clear();
    }






}