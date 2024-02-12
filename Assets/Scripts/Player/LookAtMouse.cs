using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtMouse : MonoBehaviour
{
    Transform _transform;
    Camera _camera;

    // Start is called before the first frame update
    void Start()
    {
        _transform = transform;
        _camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 lookAt = _camera.ScreenToWorldPoint(Input.mousePosition) - _transform.position;
        _transform.rotation = Quaternion.LookRotation(Vector3.back, lookAt);
    }
}
