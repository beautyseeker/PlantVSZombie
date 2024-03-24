using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 坚果
/// </summary>
public class WallNut : Plant
{




    public override int ChangeHealth(int damage)
    {



        currentHealth += damage;

        anim.SetFloat("pre", (float)(currentHealth / maxHealth));



        if (currentHealth <= 0)
        {
            GameObject.Destroy(gameObject);
        }

        return currentHealth;
    }


}
