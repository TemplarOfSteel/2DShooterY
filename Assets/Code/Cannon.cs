using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{

    public GameObject projectilePrefab;
    public float speed = 3f;

    public float timeBetweenShoots = 1f;
    float timeLeft = 0f;



    private void Update()
    {
        if(timeLeft<=0f)
        {
            if(Input.GetKey(KeyCode.Space))
                {
                SpawnProjectile();
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
        projectile.GetComponent<Rigidbody2D>().AddForce(speed * transform.up);
    }
}
