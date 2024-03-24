using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

/// <summary>
/// 太阳花
/// </summary>
public class SunFlower : Plant
{
    private float timer;

    private float sunGenerateInternel = 10f;

    [SerializeField] private GameObject sunSupply;

    public void Start()
    {
        timer = 0;
        isOnGround = false;
        currentHealth = maxHealth;
    }

    private void Update()
    {
        timer += Time.deltaTime;
        
        if (timer >= sunGenerateInternel)
        {
            anim.SetTrigger("isGlowing");
            SpawnSun();
            timer = 0;
        }
    }

    private void SpawnSun()
    {
        bool isLeft;
        isLeft = Random.Range(0, 2) < 1;
        if (isLeft)
        {
            float X = Random.Range(transform.position.x - 1.1f, transform.position.x - 1.5f);
            GameObject sun = Instantiate(sunSupply, transform.position, Quaternion.identity);
            sun.GetComponent<SunSupply>().JumpTo(new Vector3(X, transform.position.y, 0));
        }
        else
        {
            float X = Random.Range(transform.position.x + 1.1f, transform.position.x + 1.5f);
            GameObject sun = Instantiate(sunSupply, transform.position, Quaternion.identity);
            sun.GetComponent<SunSupply>().JumpTo(new Vector3(X, transform.position.y, 0));
        }

    }
}
