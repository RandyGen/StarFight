using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHpController : MonoBehaviour
{
    public int MaxHp;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Change(int nowHp)
    {
        GetComponent<Transform>().localScale = new Vector3( nowHp / this.MaxHp,gameObject.transform.localScale.y,0);
    }
}
