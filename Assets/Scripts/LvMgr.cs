using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//游戏状态枚举
public enum GameState
{
    Start,
    Fight,
    End,



}

/// <summary>
/// 关卡管理
/// </summary>
public class LvMgr : MonoBehaviour
{
    public static LvMgr Instance;


    public GameState currentstate;



    private void Awake()
    {
        Instance = this;
    }
    //初始化
    private void Start()
    {
        currentstate = GameState.Start;
    }

    private void Update()
    {
        StateRefresh();
    }
    //检测状态
    public void StateRefresh()
    {
        switch (currentstate)
        {
            case GameState.Start:
                //隐藏UI 面板  播放开始动画
                UIMgr.Instance.HideUI();


                //  摄像机移动到右侧  再移回
                CameraM.Instance.CameraMove();



                //更改状态
                currentstate = GameState.Fight;


                break;
            case GameState.Fight:

                ZombieMgr.Instance.isRefresh = true;



                break;
            case GameState.End:

                GameOver();


                break;
        }


    }


    public void GameOver()
    {


        //UI  显示
        UIMgr.Instance.GameOver();
        //天空太阳停止生成
        SkyMgr.Instance.StopCreate();
        //僵尸 停止生成
        ZombieMgr.Instance.StopCreateZombie();
        // ZombieMgr.Instance.ClearZombie();

        StopAllCoroutines();

    }




}
