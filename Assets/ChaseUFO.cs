using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseUFO : MonoBehaviour
{
    public GameObject Player;
    public Vector2 prev;
    public GameObject explosionPrefab;

    void Start()
    {
        this.Player = GameObject.Find("Player");
        prev = transform.position;
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        Vector2 Predetor = this.Player.transform.position;

        float px = Predetor.x;
        float py = Predetor.y;

        Vector2 direction = new Vector2(px - transform.position.x, py - transform.position.y).normalized;
        GetComponent<Rigidbody2D>().velocity = (direction * 4);
    }
}
