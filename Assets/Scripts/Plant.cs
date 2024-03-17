using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 植物类
/// </summary>
public class Plant : MonoBehaviour
{
    public int currentHealth;

    public int maxHealth = 300;

    public bool isOnGround;
    
    protected Animator anim;
    
    public virtual void Start()
    {
        anim = GetComponent<Animator>();
        currentHealth = maxHealth;
    }
    //改变血量的方法
    public virtual int ChangeHealth(int damage)
    {
        currentHealth += damage;
        if (currentHealth <= 0)
        {
            GameObject.Destroy(gameObject);
        }
        return currentHealth;
    }

}
