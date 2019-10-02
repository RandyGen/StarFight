using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LsBossController : MonoBehaviour
{
    private int hp = 800;
    public GameObject explosionPrefab;
    public GameObject LsBoss;
    public GameObject Tama;
    public GameObject Dokutama;
    public GameObject Player;
    public GameObject Hp;
    private GameObject canvas;
    public GameObject Bgm;
    float span = 0.6f;
    float delta = 0;
    float flag = 0;
    float Espan = 0.5f;
    float time = 0;
    int i = 0;
    float px;
    float py;
    int routine = 0;
    Vector2 pp;
    Vector2 pe;

    void Start()
    {
        this.Player = GameObject.Find("Player");
        canvas = GameObject.FindGameObjectWithTag("Canvas");
        GameObject hp = Instantiate(Hp, new Vector3(-0, 0, 0), Quaternion.identity, canvas.transform);
        //GameObject bgm = Instantiate(Bgm) as GameObject;
    }

    void Update()
    {

        this.pp = new Vector2(this.Player.transform.position.x, this.Player.transform.position.y);
        this.pe = new Vector2(this.LsBoss.transform.position.x, this.LsBoss.transform.position.y);
        if (transform.position.x > 5.0f)
        {
            transform.Translate(-0.1f, 0, 0);
        }
        this.delta += Time.deltaTime;
        this.flag += Time.deltaTime;
        if (this.delta > this.span && this.flag < 10)
        {
            this.delta = 0;
            this.span = 0.3f;
            this.px = this.LsBoss.transform.position.x + 3;
            this.py = this.LsBoss.transform.position.y;
            for (int i = 0; i < 12; i++)
            {
                GameObject go = Instantiate(Tama) as GameObject;
                go.transform.position = new Vector3(this.px, this.py, 0);
                go.GetComponent<TamaController>().Setspeed(0.3f, -135 - i * 10);
            }
        }
        else if (this.delta > this.span && this.flag > 10 && this.flag < 25)
        {
            this.delta = 0;
            this.span = 0.6f;
            for (int i = 0; i < 5; i++)
            {
                GameObject go = Instantiate(Dokutama) as GameObject;
                go.transform.position = new Vector3(this.px, this.py + Random.Range(-2f, 2f), 0);
                go.GetComponent<DokutamaController>().Setspeed(0.1f, -135 - i * 18);
            }
            for (int i = 0; i < 2; i++)
            {
                GameObject go1 = Instantiate(Tama) as GameObject;
                go1.transform.position = new Vector3(this.px, this.py + Random.Range(-3.5f, 3.5f), 0);
                go1.GetComponent<TamaController>().Setspeed(0.1f, 180);
            }
        }
        else if (this.delta > this.span && this.flag > 30 && this.flag < 50)
        {
            this.delta = 0;
            this.span = 0.3f;
            GameObject go = Instantiate(Tama) as GameObject;
            go.transform.position = new Vector3(this.LsBoss.transform.position.x, this.LsBoss.transform.position.y, 0);
            go.GetComponent<TamaController>().Setspeed(0.2f, GetAim(pp, pe));
        }
        else if (this.delta > this.span && this.flag > 50 && this.flag < 60)
        {
            this.delta = 0;
            this.span = 0.1f;
            GameObject go = Instantiate(Tama) as GameObject;
            this.py = this.LsBoss.transform.position.y;
            go.transform.position = new Vector3(this.px, this.py, 0);
            go.GetComponent<TamaController>().Setspeed(0.3f, 180 + i);
            i += 30;
            this.routine = 1;
        }       
        else if (this.routine == 1 && this.flag > 60) this.flag = 0;
        if (this.hp <= 0)
        {
            this.time += Time.deltaTime;
            if(this.time > this.Espan && this.i <5)
            {
                this.time = 0;
                GameObject explo = Instantiate(explosionPrefab, new Vector2(transform.position.x + Random.Range(-2f, 2f), transform.position.y + Random.Range(-2f, 2f)), Quaternion.identity);
                explo.GetComponent<Transform>().localScale = new Vector3(8, 8, 0);
                i++;
            }
            GameObject.Find("Canvas").GetComponent<UIController>().AddScore7();
            if(this.i >= 6 && this.time > this.Espan)
            {
                Destroy(gameObject);
                SceneManager.LoadScene("StageClearScene");
            }
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
       
            GameObject explo1 = Instantiate(explosionPrefab, other.transform.position, Quaternion.identity);
            explo1.GetComponent<Transform>().localScale = new Vector3(0.2f, 0.2f, 0);
            Destroy(other.gameObject);
            this.hp--;
            //Debug.Log(this.hp);
        }
    }
}
