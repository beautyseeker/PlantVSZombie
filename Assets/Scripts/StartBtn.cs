using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// 
/// </summary>
public class StartBtn : MonoBehaviour
{


    public void Test1()
    {
        Debug.Log(1);

    }


    public void LoadGame()
    {
        SceneManager.LoadScene(1);
    }
}
