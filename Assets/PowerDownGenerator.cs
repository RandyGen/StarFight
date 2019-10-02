using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerDownGenerator : MonoBehaviour
{
    public GameObject PowerDownPrefab;
    float spanP = 13.0f;
    float deltaP = 0;

    void Update()
    {
        this.deltaP += Time.deltaTime;
        if (this.deltaP > this.spanP)
        {
            this.deltaP = 0;
            GameObject go = Instantiate(PowerDownPrefab) as GameObject;
            int py = Random.Range(-4, 5);
            go.transform.position = new Vector3(12, py, 0);
        }
    }
}
