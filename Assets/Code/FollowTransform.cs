using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTransform : MonoBehaviour
{
    Transform _transform;
    public Transform otherTransform;

    [SerializeField]
    float speed = 15f;

    // Start is called before the first frame update
    void Start()
    {
        _transform = transform;
    }

    private void FixedUpdate()
    {
        Vector3 diff = otherTransform.position - _transform.position;
        diff.z = 0;
        _transform.position += diff * Time.deltaTime * speed;
    }
}
