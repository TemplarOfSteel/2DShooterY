using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageOnHit : MonoBehaviour
{
    public float damage = 1f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        foreach( var damagable in collision.gameObject.GetComponents<IDamagable>())
        {
            damagable.TakeDamage(damage);
        }

        Destroy(gameObject);
    }
}
