using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    private int hp = 100;
    public GameObject explosionPrefab;
    public GameObject Boss;
    public GameObject Tama;
    public GameObject Hp;
    private GameObject canvas;
    float span = 0.75f;
    float delta = 0;
    float px;
    float py;
    //private GameObject gene;

    void Start()
    {
        canvas = GameObject.FindGameObjectWithTag("Canvas");
        //gene = GameObject.FindGameObjectWithTag("Finish");
        GameObject hp = Instantiate(Hp, new Vector3(-0, 0, 0), Quaternion.identity,canvas.transform);
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
            this.px = this.Boss.transform.position.x;
            this.py = this.Boss.transform.position.y + Random.Range(-4, 5);
            for (int i = 0; i < 6; i++)
            {
                GameObject go = Instantiate(Tama) as GameObject;
                go.transform.position = new Vector3(this.px , this.py , 0);
                go.GetComponent<TamaController>().Setspeed(0.1f, -135 - i * 15);
            }
        }
        if (this.hp <= 0)
        {
            GameObject explo = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            explo.GetComponent<Transform>().localScale = new Vector3(8, 8, 0);
            GameObject.Find("Canvas").GetComponent<UIController>().AddScore6();
            //gene.GetComponent<GameSceneManager>().swicth = 0;
            Destroy(gameObject);
            this.hp = 100;
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
