using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    Transform _transform;

    public float speed = 0;

    // Start is called before the first frame update
    void Start()
    {
        _transform = transform;
    }

    // Update is called once per frame
    void Update()
    {
        _transform.rotation = Quaternion.Euler(0, 0, Time.time * speed * 360);
    }
}
