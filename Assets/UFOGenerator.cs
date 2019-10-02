using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UFOGenerator : MonoBehaviour
{
    public GameObject UFOPrefab;
    public GameObject Player;
    public GameObject explosionPrefab;
    float span = 5.0f;
    float delta = 0;

    public Vector2 prev;

    void Start()
    {
        prev = transform.position;
        this.Player = GameObject.Find("Player");
    }

    void Update()
    {
        if ((GameObject.FindGameObjectWithTag("Warning") || GameObject.FindGameObjectWithTag("Boss")) != true)
        {
            this.delta += Time.deltaTime;
            if (this.delta > this.span)
            {
                this.delta = 0;
                GameObject go = Instantiate(UFOPrefab) as GameObject;
                int py = Random.Range(-5, 6);
                go.transform.position = new Vector3(12, py, 0);
            }
            Move();
        }
    }

    void Move()
    {
        Vector2 Predetor = this.Player.transform.position;

        float x = Predetor.x;
        float y = Predetor.y;

        Vector2 direction = new Vector2(x - transform.position.x, y - transform.position.y).normalized;
        GetComponent<Rigidbody2D>().velocity = (direction * 4);

    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag == "Player")
        {
            SceneManager.LoadScene("GameOverScene");
        }
        else
        {
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            GameObject.Find("Canvas").GetComponent<UIController>().AddScore2();
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
    }
}