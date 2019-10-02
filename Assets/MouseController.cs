using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : MonoBehaviour
{
    private int hp = 50;
    public GameObject explosionPrefab;
    public GameObject Mouse;
    public GameObject Tama;
    float span = 5.0f;
    float delta = 0;
    float px;
    float py;
    float flag = 0;
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
        this.flag += Time.deltaTime;
        transform.position = new Vector3(this.transform.position.x, Mathf.Sin(this.delta * 2f) * 3f, 0);
        if (this.flag > this.span)
        {
            this.flag = 0;
            this.px = this.Mouse.transform.position.x;
            this.py = this.Mouse.transform.position.y;
            GameObject go = Instantiate(Tama) as GameObject;
            go.GetComponent<Transform>().localScale = new Vector3(1f, 1f, 0);
            go.transform.position = new Vector3(this.px, this.py, 0);
            go.GetComponent<TamaController>().Setspeed(0.3f, 180);
        }
        if (this.hp <= 0)
        {
            GameObject explo = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            explo.GetComponent<Transform>().localScale = new Vector3(8, 8, 0);
            GameObject.Find("Canvas").GetComponent<UIController>().AddScore5();
            //gene.GetComponent<GameSceneManager>().swicth = 0;
            Destroy(gameObject);
            this.hp = 60;
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