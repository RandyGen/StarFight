using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DokutamaController : MonoBehaviour
{
    private float speed = 0.2f;
    private float angle = 0.0f;
    private GameObject gene;
    int flag = 0;

    public void Setspeed(float r, float sita)
    {
        this.speed = r;
        this.angle = sita;
    }
    void Start()
    {
        gene = GameObject.FindGameObjectWithTag("Player");
    }
    void Update()
    {
        transform.position += AddVectorCity(this.speed, this.angle);

        if (transform.position.x < -11.0f)
        {
            Destroy(gameObject);
        }
    }
    public Vector3 AddVectorCity(float r, float sita)
    {
        return new Vector3(r * Mathf.Cos(sita * Mathf.Deg2Rad), r * Mathf.Sin(sita * Mathf.Deg2Rad), 0);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && this.flag <5)
        {
            gene.GetComponent<PlayerContrller>().flag ++;
            Destroy(gameObject);
        }
    }
}
