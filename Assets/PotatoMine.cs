using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PotatoMine : Plant
{
    private enum MineStat
    {
        UnderGround,
        Grow
    }
    
    private float existTime;
    private MineStat _mineStat = MineStat.UnderGround;
    [SerializeField] private SpriteRenderer underGround;
    [SerializeField] private SpriteRenderer explode;

    private void Start()
    {
        anim = GetComponentInChildren<Animator>();
        existTime = 0;
    }

    private void Update()
    {
        existTime += Time.deltaTime;
        if (existTime > 10 && _mineStat == MineStat.UnderGround)
        {
            UnderGroundTransitionToGrow();
            existTime = 0;
        }
        
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if (_mineStat == MineStat.Grow && col.tag == "Zombie")
        {
            // 播放爆炸动画
            underGround.enabled = false;
            explode.enabled = true;
            // 立刻秒杀僵尸
            Destroy(col.gameObject);
            Invoke("Vanish", 2f);
        }
    }

    private void UnderGroundTransitionToGrow()
    {
        underGround.sprite = null;
        anim.SetTrigger("MineGrow");
        _mineStat = MineStat.Grow;
        // transform.Translate(Time.deltaTime*Vector3.right);
    }

    private void Vanish()
    {
        Destroy(gameObject);
    }
}
