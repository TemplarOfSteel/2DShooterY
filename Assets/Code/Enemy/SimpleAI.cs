using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleAI : MonoBehaviour
{
    public float speed = 5f;
    public float searchDistance = 25f;
    Transform _transform;
    Transform _otherTransform;

    // Start is called before the first frame update
    void Start()
    {
        _transform = transform;
        _otherTransform = CharacterController2D.singleton.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if((transform.position - _otherTransform.position).sqrMagnitude <= Mathf.Pow(searchDistance, 2))
        {
            _transform.position += (_otherTransform.position - _transform.position).normalized * speed * Time.deltaTime;
        }
    }
}
