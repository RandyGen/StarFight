using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpEffect : MonoBehaviour
{
    private GameObject gene;
    public GameObject PowerU;

    void Start()
    {
        gene= GameObject.FindGameObjectWithTag("Generator");
    }
    void Update()
    {
        transform.Translate(-0.2f, 0, 0);

        if(transform.position.x < -12)
        {
            Destroy(gameObject);
        }
    }
 
    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            GameObject go = Instantiate(PowerU, transform.position, Quaternion.identity);
            gene.GetComponent<BulletGenerator>().power ++;
        }
    }
}
