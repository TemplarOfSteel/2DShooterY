using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootOnDamage : MonoBehaviour, IDamagable
{
    float health = 1;

    public void TakeDamage(float damage)
    {
        health -= damage;

        if(health<=0)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<Cannon>().IncreaseExplosiveAmmo(Random.Range(1, 4));

            Destroy(this.gameObject);
        }
    }
}
