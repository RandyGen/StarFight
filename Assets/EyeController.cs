using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeController : MonoBehaviour
{
    private int hp = 40;
    public GameObject explosionPrefab;
    public GameObject Eye;
    public GameObject Player;
    public GameObject Tama;
    Vector2 pp;
    Vector2 pe;
    float span = 0.4f;
    float delta = 0;
    float px;
    float py;
    //private GameObject gene;

    void Start()
    {
        this.Player = GameObject.Find("Player");
        //gene = GameObject.FindGameObjectWithTag("Finish");
    }
    void Update()
    {
        this.pp = new Vector2(this.Player.transform.position.x, this.Player.transform.position.y);
        this.pe = new Vector2(this.Eye.transform.position.x - 0.5f, this.Eye.transform.position.y + 1.7f);
        if (transform.position.x > 5.0f)
        {
            transform.Translate(-0.1f, 0, 0);
        }
        this.delta += Time.deltaTime;
        if (this.delta > this.span)
        {
            this.delta = 0;
            GameObject go = Instantiate(Tama) as GameObject;
            go.transform.position = new Vector3(this.Eye.transform.position.x - 0.5f, this.Eye.transform.position.y + 1.7f, 0);
            go.GetComponent<TamaController>().Setspeed(0.2f, GetAim(pp,pe));
        }
        if (this.hp <= 0)
        {
            GameObject explo = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            explo.GetComponent<Transform>().localScale = new Vector3(8, 8, 0);
            GameObject.Find("Canvas").GetComponent<UIController>().AddScore4();
            Destroy(gameObject);
            this.hp = 60;
        }
    }
    public float GetAim(Vector2 p1, Vector2 p2)
    {
        float dx = p2.x - p1.x;
        float dy = p2.y - p1.y;
        float rad = Mathf.Atan2(dy, dx);
        return (Mathf.PI + rad) * Mathf.Rad2Deg;
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
