using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundController : MonoBehaviour
{
    void Update()
    {
        transform.Translate(-0.08f, 0, 0);
        if(transform.position.x < -24.0f)
        {
            transform.position = new Vector3(23.0f, 0, 0);
        }
    }
}
