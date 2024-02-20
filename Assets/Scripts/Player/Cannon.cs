using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    public GameObject projectilePrefab;
    public GameObject explosiveProjectilePrefab;
    public float speed = 3f;

    public float timeBetweenShoots = 1f;
    float timeLeft = 0f;

    int explosiveAmmo = 5;

    public void IncreaseExplosiveAmmo(int amount)
    {
        Debug.Log(explosiveAmmo);
        explosiveAmmo += amount;
    }

    private void Update()
    {
        if(timeLeft <= 0f)
        {
            if(Input.GetKey(KeyCode.Mouse0))
            {
                SpawnProjectile();
                timeLeft += timeBetweenShoots;
            }

            if (Input.GetKey(KeyCode.Mouse1) && explosiveAmmo > 0)
            {
                SpawnProjectileExplosive();
                explosiveAmmo--;
                timeLeft += timeBetweenShoots;
            }
        }
        else
        {
            timeLeft -= Time.deltaTime;
        }
    }

    public void SpawnProjectile()
    {
        var projectile = GameObject.Instantiate<GameObject>(projectilePrefab, transform.position, Quaternion.identity);
        projectile.GetComponent<Rigidbody2D>().velocity = (speed * transform.up);
    }

    public void SpawnProjectileExplosive()
    {
        var projectile = GameObject.Instantiate<GameObject>(explosiveProjectilePrefab, transform.position, Quaternion.identity);
        projectile.GetComponent<Rigidbody2D>().velocity = (speed * transform.up);
    }
}
