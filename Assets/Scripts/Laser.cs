using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    float maxLength = 300f;
    Transform _transform;
    public SpriteRenderer sprite;
    public float damage = 1f;

    // Start is called before the first frame update
    void Start()
    {
        _transform = transform;
    }

    // Update is called once per frame
    void Update()
    {
        LayerMask mask = LayerMask.GetMask("Character", "Default");

        var hit = Physics2D.Raycast(_transform.position, _transform.up, maxLength, mask);
        if(hit.transform == null)
        {
            sprite.transform.localPosition = new Vector3(0, maxLength / 2, 0);

            sprite.transform.localScale = new Vector3(sprite.transform.localScale.x,
                maxLength,
                1);

            return; 
        }

        var hitPoint = hit.point;


        Debug.Log(hit.transform.name);
        Debug.DrawLine(_transform.position, hitPoint);

        foreach(var damagable in hit.transform.GetComponents<IDamagable>())
        {
            damagable.TakeDamage(damage * Time.deltaTime);
        }

        var dist = Vector2.Distance(_transform.position, hitPoint);

        sprite.transform.localPosition = new Vector3(0, dist / 2, 0);

        sprite.transform.localScale = new Vector3(sprite.transform.localScale.x,
            dist, 
            1);
    }
}
