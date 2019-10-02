using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    private float speed = 0.2f;
    private float angle = 0.0f;
    public void Setspeed(float r, float sita)
    {
        this.speed = r;
        this.angle = sita;
    }
    
    void Update()
    {
        transform.position += AddVectorCity(this.speed, this.angle);
        
        if(transform.position.x > 11.0f || transform.position.y > 6.0f || transform.position.y < -6f)
        {
            Destroy(gameObject);
        }
    }
    public Vector3 AddVectorCity(float r,float sita)
    {
        return new Vector3(r * Mathf.Cos(sita * Mathf.Deg2Rad), r * Mathf.Sin(sita * Mathf.Deg2Rad), 0);
    }
}
