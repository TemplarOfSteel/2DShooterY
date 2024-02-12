using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController2D : MonoBehaviour
{
    public static CharacterController2D singleton;


    Rigidbody2D _rb;
    Transform _transform;

    [SerializeField]
    float _speed = 150f;

    [SerializeField]
    float _acceleration = 5000f;

    [SerializeField]
    float _deacceleration = 5000f;


    private void Awake()
    {
        if(singleton==null)
        {
            singleton = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Hello world");
        _transform = gameObject.transform;
        _rb = _transform.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        Vector2 dir = new Vector2(0,0);

        if (Input.GetKey(KeyCode.W)) { dir += Vector2.up; }
        if (Input.GetKey(KeyCode.A)) { dir += new Vector2(-1, 0); }
        if (Input.GetKey(KeyCode.S)) { dir += new Vector2(0, -1); }
        if (Input.GetKey(KeyCode.D)) { dir += new Vector2(1, 0); }

        dir = dir.normalized * _speed;

        if(dir!= Vector2.zero)
        {
            var exessivespeed = Vector2.Dot(_rb.velocity, dir) - _speed;
            
            if (exessivespeed<0)
            {
                _rb.AddForce(_acceleration * dir * Time.fixedDeltaTime);
            }
        }
        else
        {
            _rb.AddForce(_deacceleration * - _rb.velocity.normalized * Time.fixedDeltaTime);
        }
    }
}
