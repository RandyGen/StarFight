using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerContrller : MonoBehaviour
{
    public float speed;
    private int time = 150;
    public int flag = 0;
    SpriteRenderer player;

    void Start()
    {
        this.player = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        //Debug.Log(this.speed);

        if(Input.GetKey(KeyCode.LeftArrow) && transform.position.x > -8.7f)
        {
            transform.Translate(- this.speed, 0, 0);
        }
        if(Input.GetKey(KeyCode.RightArrow) && transform.position.x < 8.7f)
        {
            transform.Translate(this.speed, 0, 0);
        }
        if(Input.GetKey(KeyCode.UpArrow) && transform.position.y < 4.5f)
        {
            transform.Translate(0, this.speed, 0);
        }
        if(Input.GetKey(KeyCode.DownArrow) && transform.position.y > -4.5f)
        {
            transform.Translate(0, - this.speed, 0);
        }
        switch (flag)
        {
            case 0:
                this.speed = 0.1f;
                this.player.color = new Color(1, 1, 1, 1);
                break;
            case 1:
                this.speed = 0.06f;
                this.player.color = new Color(0.85f, 0.56f, 0.85f, 1);
                break;
            case 2:
                this.speed = 0.03f;
                this.player.color = new Color(0.8f, 0.32f, 0.8f, 1);
                break;
            default:
                this.speed = 0.01f;
                this.player.color = new Color(0.75f, 0.145f, 0.8f, 1);
                break;
        }
        if (this.speed < 0.1f)
        {
            this.time--;
        }
        if(this.time <= 0 && this.flag > 0)
        {
            this.flag--;
            this.time = 150;
        }
    }
}
