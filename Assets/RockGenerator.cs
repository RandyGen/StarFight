using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockGenerator : MonoBehaviour
{
    public GameObject RockPrefab;
    float spanR = 1.0f;
    float deltaR = 0;

    void Update()
    {
        if((GameObject.FindGameObjectWithTag("Warning") || GameObject.FindGameObjectWithTag("Boss")) != true)
        { 
            this.deltaR += Time.deltaTime;
            if (this.deltaR > this.spanR)
            {
                this.deltaR = 0;
                GameObject go = Instantiate(RockPrefab) as GameObject;
                int py = Random.Range(-4, 5);
                go.transform.position = new Vector3(12, py, 0);
            }
        }
    }
}
