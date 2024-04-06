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
        float curHPPct = (float)currentHealth / maxHealth;
        anim.SetFloat("curHPPct", curHPPct);
        return base.ChangeHealth(damage);
    }

    public void RecoverComplete()
    {
        currentHealth = maxHealth;
        anim.SetTrigger("Heal");
    }
}
