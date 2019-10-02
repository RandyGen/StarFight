using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletGenerator : MonoBehaviour
{
    public GameObject BulletPrefab;
    public GameObject Player;
    float span = 1.0f;
    float delta = 0;
    public int power = 0;

    void Start()
    {
        this.Player = GameObject.Find("Player");
    }

    void Update()
    {
        this.delta += Time.deltaTime;
        if (this.delta > this.span)
        {
            this.delta = 0;
            float px = this.Player.transform.position.x;
            float py = this.Player.transform.position.y;
            

            switch(power)
            {
                case 0:
                    GameObject go1 = Instantiate(BulletPrefab) as GameObject;
                    go1.transform.position = new Vector3(px + 1, py + 0.2f, 0);
                    this.span = 1.0f;
                    break;
                case 1:
                    for(int i = 0; i < 2; i++)
                    {
                        GameObject go2 = Instantiate(BulletPrefab) as GameObject;
                        go2.transform.position = new Vector3(px + 1, py - 0.3f + i * 0.5f, 0);
                    }
                    break;
                case 2:
                    for (int i = 0; i < 2; i++)
                    {
                        GameObject go3 = Instantiate(BulletPrefab) as GameObject;
                        go3.transform.position = new Vector3(px + 1, py - 0.3f + i * 0.5f, 0);
                    }
                    this.span = 0.7f;
                    break;
                case 3:
                    for (int i = 0; i < 2; i++)
                    {
                        GameObject go3 = Instantiate(BulletPrefab) as GameObject;
                        go3.transform.position = new Vector3(px + 1, py - 0.3f + i * 0.5f, 0);
                    }
                    this.span = 0.45f;
                    break;
                case 4:
                    for (int i = 0; i < 3; i++)
                    {
                        GameObject go4 = Instantiate(BulletPrefab) as GameObject;
                        go4.transform.position = new Vector3(px + 1, py - 0.3f, 0);
                        go4.GetComponent<BulletController>().Setspeed(0.2f, -15 + i * 15);
                    }
                    this.span = 0.5f;
                    break;
                case 5:
                    for (int i = 0; i < 3; i++)
                    {
                        GameObject go4 = Instantiate(BulletPrefab) as GameObject;
                        go4.transform.position = new Vector3(px + 1, py - 0.3f, 0);
                        go4.GetComponent<BulletController>().Setspeed(0.2f, -15 + i * 15);
                    }
                    this.span = 0.45f;
                    break;
                default:
                    this.span = 0.4f;
                    for (int i = 0; i < 3; i++)
                    {
                        GameObject go5 = Instantiate(BulletPrefab) as GameObject;
                        go5.transform.position = new Vector3(px + 1, py - 0.3f, 0);
                        go5.GetComponent<BulletController>().Setspeed(0.2f, -15 + i * 15);
                    }
                    GameObject go6 = Instantiate(BulletPrefab) as GameObject;
                    go6.transform.position = new Vector3(px + 1, py + 0.2f, 0);
                    break;
            }
        }
    }
}