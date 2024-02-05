using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByDamage : MonoBehaviour, IDamagable
{
    public float hp=1;

    public void TakeDamage(float damage)
    {
        hp-=damage;
        if (hp <= 0) { Destroy(gameObject); }
    }
}
