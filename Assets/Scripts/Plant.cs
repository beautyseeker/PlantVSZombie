using System;
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

    protected Collider2D collider;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        collider = GetComponent<Collider2D>();
        currentHealth = maxHealth;
    }
    //改变血量的方法
    public virtual int ChangeHealth(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
        return currentHealth;
    }

    public void EnableOnHandFeature(bool onHand)
    {
        anim.enabled = !onHand;
        collider.enabled = !onHand;
    }
    

}
