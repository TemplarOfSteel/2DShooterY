using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByDamage : MonoBehaviour, IDamagable
{
    public float hp=1;
    public int pointsOnDeath=0;

    public void TakeDamage(float damage)
    {
        hp-=damage;
        if (hp <= 0) {
            GameObject.FindGameObjectWithTag("Player").GetComponent<BetterController>().AddPoints(pointsOnDeath);
            Destroy(gameObject); 
        }
    }
}
