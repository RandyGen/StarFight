using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleController : MonoBehaviour
{
    public GameObject obj;

    void Start()
    {
        Destroy(obj, 2);
    }
}
