using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// UI  管理
/// </summary>
public class UIMgr : MonoBehaviour
{
    public static UIMgr Instance;

    private Text sunNum;

    private GameObject chooseBg;

    private ReadyAnim ready;


    private OverPannel overPannel;



    private void Awake()
    {
        Instance = this;

        sunNum = GameObject.Find("SunNum").GetComponent<Text>();
        chooseBg = GameObject.Find("ChooseBg").gameObject;


        ready = GameObject.Find("ReadyAnim").gameObject.GetComponent<ReadyAnim>();

        overPannel = GameObject.Find("OverPannel").gameObject.GetComponent<OverPannel>();



    }


    public void ChangeUICount(int num)
    {
        sunNum.text = num.ToString();
    }

    public void HideUI()
    {
        chooseBg.SetActive(false);
    }

    public void ShowUI()
    {
        chooseBg.SetActive(true);
    }


    public void ShowReady()
    {
        ready.ShowReady();
    }


    public void GameOver()
    {


        overPannel.Over();


    }


}
