using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByTimer : MonoBehaviour
{
    public float destroyAfter=5f;



    // Update is called once per frame
    void Update()
    {
        destroyAfter -= Time.deltaTime;

        if(destroyAfter<=0)
        {
            Destroy(gameObject);
        }
    }
}
