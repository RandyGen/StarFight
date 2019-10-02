using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RockController : MonoBehaviour
{
    float fallSpeed;
    float rotSpeed;
    public GameObject explosionPrefab;
    public GameObject Player;

    void Start()
    {
        this.fallSpeed = 0.08f + 0.1f * Random.value;
        this.rotSpeed = 5.0f + 3.0f * Random.value;
        this.Player = GameObject.Find("Player");
    }
    
    void Update()
    {
        transform.Translate(-fallSpeed, 0, 0, Space.World);
        transform.Rotate(0, 0, rotSpeed);

        if(transform.position.x < -11.0f)
        {
            Destroy(gameObject);
        }
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
            GameObject.Find("Canvas").GetComponent<UIController>().AddScore();
            Destroy(gameObject);
            Destroy(other.gameObject);
            
        }
    }
}
