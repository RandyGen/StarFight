using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterController : MonoBehaviour
{
    private int hp = 80;
    public GameObject explosionPrefab;
    public GameObject Monster;
    public GameObject Tama;
    public GameObject Dokutama;
    float span = 0.8f;
    float delta = 0;
    float px;
    float py;
    //private GameObject gene;

    void Start()
    {
        //gene = GameObject.FindGameObjectWithTag("Finish");
    }
    void Update()
    {
        if (transform.position.x > 5.0f)
        {
            transform.Translate(-0.1f, 0, 0);
        }
        this.delta += Time.deltaTime;
        if (this.delta > this.span)
        {
            this.delta = 0;
            this.px = this.Monster.transform.position.x;
            this.py = this.Monster.transform.position.y + Random.Range(-4, 5);
            for (int i = 0; i < 3; i++)
            {
                GameObject go = Instantiate(Dokutama) as GameObject;
                go.transform.position = new Vector3(this.px, this.py, 0);
                go.GetComponent<DokutamaController>().Setspeed(0.1f, -165 - i * 15);
            }
            GameObject go1 = Instantiate(Tama) as GameObject;
            go1.transform.position = new Vector3(this.px, this.py + Random.Range(-2, 2), 0);
            go1.GetComponent<TamaController>().Setspeed(0.1f, 180);
        }
        if (this.hp <= 0)
        {
            GameObject explo = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            explo.GetComponent<Transform>().localScale = new Vector3(8, 8, 0);
            GameObject.Find("Canvas").GetComponent<UIController>().AddScore2();
            //gene.GetComponent<GameSceneManager>().swicth = 0;
            Destroy(gameObject);
            this.hp = 80;
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag == "Bullet")
        {
            GameObject explo1 = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            explo1.GetComponent<Transform>().localScale = new Vector3(0.2f, 0.2f, 0);
            Destroy(other.gameObject);
            this.hp--;
            //Debug.Log(this.hp);
        }
    }
}
