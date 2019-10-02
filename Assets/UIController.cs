using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public int score = 0;
    GameObject scoreText;
    public Text highScoreText; //ハイスコアを表示するText
    private int highScore; //ハイスコア用変数
    private string key = "HIGH SCORE";

    public void AddScore()
    {
        this.score += 10;
    }
    public void AddScore1()
    {
        this.score += 15;
    }
    public void AddScore2()
    {
        this.score += 2000;
    }
    public void AddScore3()
    {
        this.score += 3000;
    }
    public void AddScore4()
    {
        this.score += 4000;
    }
    public void AddScore5()
    {
        this.score += 5000;
    }
    public void AddScore6()
    {
        this.score += 6000;
    }
    public void AddScore7()
    {
        this.score += 8000;
    }

    void Start()
    {
        this.scoreText = GameObject.Find("Score");
        highScore = PlayerPrefs.GetInt(key, 0);
    }

    void Update()
    {
        scoreText.GetComponent<Text>().text = "Score:" + score.ToString("D6");

        if(highScore < this.score)
        {
            highScore = this.score;//ハイスコア更新

            PlayerPrefs.SetInt(key, highScore);//ハイスコアを保存
        }
    }
}
