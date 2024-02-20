using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageOnHit : MonoBehaviour
{
    public float damage = 1f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var damagables = collision.gameObject.GetComponents<IDamagable>();
        foreach (var damagable in damagables)
        {
            damagable.TakeDamage(damage);
        }

        if(damagables.Length != 0)
        {
            Destroy(gameObject);
        }
    }
}
