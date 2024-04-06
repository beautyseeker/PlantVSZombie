using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    private int HPMax = 100;
    [SerializeField] private int HPCurrent = 100;

    private float CurrentHPPercent
    {
        get => (float)HPCurrent / HPMax;
    }
    [SerializeField] private float moveSpeed = 0.2f;
    [SerializeField] private int atkDmg = 8;
    private float atkInterval = 1;
    private bool hasAttackAbility = true;
    private Animator animController;
    [SerializeField] private Plant attackingTarget;

    private void Awake()
    {
        HPCurrent = HPMax;
        animController = GetComponent<Animator>();
        animController.SetFloat("HPPercent", CurrentHPPercent);
    }
    
    private void Update()
    {
        transform.Translate(moveSpeed*Time.deltaTime*Vector3.left);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Plant")
        {
            // 播放攻击动画并停止移动
            moveSpeed = 0;
            animController.SetTrigger("Eat");
            // 植物开始掉血
            if (hasAttackAbility && other != null)
            {
                attackingTarget = other.GetComponent<Plant>();
            }
        }
    }

    public void Attack()
    {
        if (attackingTarget != null)
            attackingTarget.ChangeHealth(atkDmg);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Plant")
        {
            // 播放攻击动画并恢复移动
            attackingTarget = null;
            moveSpeed = 0.2f;
            animController.SetTrigger("Move");
        }
    }

    public virtual int ChangeHealth(int damage)
    {
        HPCurrent -= damage;
        animController.SetFloat("HPPercent", CurrentHPPercent);
        if (HPCurrent <= 0)
        {
            // 丧失攻击能力
            hasAttackAbility = false;
            // 继续播放当前动画状态，3s后播放倒地动画
            Invoke("ZombieDown", 3);
        }
        return HPCurrent;
    }

    protected void ZombieDown()
    {
        // 播放倒地动画并停止移动,取消碰撞体,三秒钟后淡出并销毁
        animController.SetTrigger("Down");
        moveSpeed = 0;
        GetComponent<Collider2D>().enabled = false;
        Invoke("FadeOut", 3);
    }
    
    private void FadeOut()
    {
        Destroy(gameObject);
    }
}
