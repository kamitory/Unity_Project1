using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; //텍스트메시프로이용시

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    private void Awake() => Instance = this;

    public Text scoreTxt;
    public Text highScoreTxt;
    public TextMeshProUGUI textTxt;

    int score = 0;
    int highScore = 0;

    private void Start()
    {
        highScore = PlayerPrefs.GetInt("HighScoree");
        highScoreTxt.text = "HighScore : " + highScore;
    }

    private void Update()
    {
        SaveHighScore();
    }

    private void SaveHighScore()
    {
        if(score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("HighScore", highScore);
            highScoreTxt.text = "HighScore" + highScore;
        }
    }

    public void AddScore()
    {
        score++;
        scoreTxt.text = "Score : " + score;
        //텍스트메시프로는 안됨
        textTxt.text = "test......";
    }
}
