using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneManager : MonoBehaviour
{
    public GameObject warning;
    public GameObject LsWarning;
    public GameObject Boss;
    public GameObject Goost;
    public GameObject Mouse;
    public GameObject Monster;
    public GameObject Eye;
    public GameObject LsBoss;
    public GameObject EnemyHp;
    public GameObject alarm;
    public AudioClip audioClip1;
    public AudioClip audioClip2;
    private AudioSource audioSource;
    private int time = 0;
    private float flag = 0;
    private int scene = 0;
    private int phase = 3;
    public int swicth = 0;

    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.clip = audioClip1;
        audioSource.Play();
        //GameObject bgm1 = Instantiate(Bgm1) as GameObject;
    }

    void Update()
    {
        //Debug.Log(swicth);
        time ++;
        if (time == 2000 && this.scene < this.phase && this.swicth == 0)
        {
            GameObject war = Instantiate(warning, new Vector3(0, 0, 0), Quaternion.identity);
            GameObject play = Instantiate(alarm, transform.position, Quaternion.identity);
            this.flag = Random.Range(-10f, 10f);
            
            //Debug.Log(flag);
        }
        else if (time == 2000 && this.scene == this.phase && this.swicth == 0)
        {
            GameObject war = Instantiate(warning, new Vector3(0, 0, 0), Quaternion.identity);
            GameObject lswar = Instantiate(LsWarning, new Vector3(0, 0, 0), Quaternion.identity);
            GameObject play = Instantiate(alarm, transform.position, Quaternion.identity);
            audioSource.Stop();
            //Destroy(GameObject.FindGameObjectWithTag("BGM"));
            //Debug.Log(flag);
        }
        else if (this.time == 2150 && this.flag > 6 && this.scene < this.phase && this.swicth == 0)
        {
            GameObject eye = Instantiate(Eye, new Vector3(11.0f, 0, 0), Quaternion.identity);
            this.scene++;
            time = -500;
            //this.swicth++;
        }
        else if(this.time == 2150 && this.flag > 2 && this.scene < this.phase && this.swicth == 0)
        {
            GameObject goost = Instantiate(Goost, new Vector3(11.0f, 0, 0), Quaternion.identity);
            this.scene++;
            time = -500;
            //this.swicth++;
        }
        else if(this.time == 2150 && this.flag > -2 && this.scene < this.phase && this.swicth == 0)
        {
            GameObject boss = Instantiate(Boss, new Vector3(11.0f, 0, 0), Quaternion.identity);
            this.scene++;
            time = -500;
            //this.swicth++;
        }
        else if(this.time == 2150 && this.flag > -6 && this.scene < this.phase && this.swicth == 0)
        {
            GameObject mouse = Instantiate(Mouse, new Vector3(11.0f, 0, 0), Quaternion.identity);
            this.scene++;
            time = -500;
            //this.swicth++;
        }
        else if (this.time == 2150 && this.flag > -10 && this.scene < this.phase && this.swicth == 0)
        {
            GameObject monster = Instantiate(Monster, new Vector3(11.0f, 0, 0), Quaternion.identity);
            this.scene++;
            time = -500;
            //this.swicth++;
        }
        else if (this.time == 2150 && this.scene == this.phase && this.swicth == 0)
        {
            GameObject lsboss = Instantiate(LsBoss, new Vector3(11.0f, 0, 0), Quaternion.identity);
            //GameObject bgm2 = Instantiate(Bgm2) as GameObject;
            audioSource.clip = audioClip2;
            audioSource.Play();
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            SceneManager.LoadScene("StartScene");
        }
    }
}
