using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; //TMP TEXT 사용하려면 선언해줘야함

public class ScoreManager : MonoBehaviour
{
    // Start is called before the first frame update
    //made singletone 
    public static ScoreManager Instance;
    private void Awake() => Instance = this;
    public Text scoreText;
    public Text hiScoreText;
    //public TextMeshProUGUI textTxt; //TMP text 변수

    int score = 0;
    int hiScore = 0;

    void Start()
    {
        hiScore = PlayerPrefs.GetInt("hiScore2");
        hiScoreText.text = "HighScore : " + hiScore;
    }

    // Update is called once per frame
    void Update()
    {
        SaveHiScore();
      
    }

    private void SaveHiScore()
    {
        if(score>hiScore)
        {
            hiScore = score;
            PlayerPrefs.SetInt("hiScore2", hiScore);
            hiScoreText.text = "HighScore : " + hiScore;
        }
    }

    public void AddScore()
    {
        score++;
        scoreText.text = "Score : " + score;

    
    }
}
