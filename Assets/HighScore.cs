using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{
    public Text highScoreText; //ハイスコアを表示するText
    private int highScore; //ハイスコア用変数
    private string key = "HIGH SCORE"; //ハイスコアの保存先キー
    //GameObject gene;
    //int score ;

    void Start()
    {

    }
    void Update()
    {
        highScore = PlayerPrefs.GetInt(key, 0);
        //保存しておいたハイスコアをキーで呼び出し取得し保存されていなければ0になる
        highScoreText.text = "HighScore: " + highScore.ToString("D6");
        //ハイスコアの表示

        if (Input.GetKeyDown(KeyCode.C))
        {
            PlayerPrefs.SetInt(key, 0);
            highScore = 0;
        }
        if (Input.GetKey(KeyCode.Escape)) Quit();
    }
    void Quit()
    {
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #elif UNITY_STANDALONE
                UnityEngine.Application.Quit();
        #endif
    }
}
