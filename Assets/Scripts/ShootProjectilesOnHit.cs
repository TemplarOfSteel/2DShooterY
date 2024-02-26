using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootProjectilesOnHit : MonoBehaviour
{
    public GameObject projectilePrefab;
    public int projectileAmount;
    public float speed = 30;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Explode();
        Destroy(this.gameObject);
    }

    private void Explode()
    {
        for(int i = 0; i < projectileAmount; i++)
        {
            var rot = i * 360 / projectileAmount;
            var rotVector = (Quaternion.Euler(0, 0, rot) * new Vector3(1, 0, 0));

            var projectile = Instantiate(projectilePrefab, this.transform.position, Quaternion.identity);
            projectile.GetComponent<Rigidbody2D>().velocity = speed * rotVector;
        }
    }
}
