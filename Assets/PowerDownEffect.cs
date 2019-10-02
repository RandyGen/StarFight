using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerDownEffect : MonoBehaviour
{
    private GameObject gene;
    public GameObject PowerD;

    void Start()
    {
        gene = GameObject.FindGameObjectWithTag("Generator");
    }
    void Update()
    {
        transform.Translate(-0.2f, 0, 0);

        if (transform.position.x < -11)
        {
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            GameObject go = Instantiate(PowerD, transform.position, Quaternion.identity);
            if (gene.GetComponent<BulletGenerator>().power > 0)
                gene.GetComponent<BulletGenerator>().power = gene.GetComponent<BulletGenerator>().power/2;
        }
    }
}
