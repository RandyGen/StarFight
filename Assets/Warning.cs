using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warning : MonoBehaviour
{
    private int time = 0;
    private float speed = 0.05f;
    private float alpha = 1.0f;
    SpriteRenderer warning;
    void Start()
    {
        this.warning = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        time++;
        if (alpha >= 1)
            speed *= -1.0f;
        if (alpha <= 0)
            speed *= -1.0f;
        alpha += speed;
        this.warning.color = new Color(1, 1, 1, alpha);
        if (time > 200 && alpha <= 0)
        {
            Destroy(gameObject);
        }
    }
}
