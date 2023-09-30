using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text comboText;
    static int comboScore;
    public Text scoreText;
    static int scoreCount;
    
    void Start()
    {
        comboScore = 0;
        scoreCount = 0;
    }


    public void IncreaseComboScore()
    {
        comboScore += 1;
        GameManager.instance.audioFX.Hit();

    }
    public void ResetComboScore()
    {
        comboScore = 0;
        GameManager.instance.audioFX.Miss();
    }

    public void IncreaseScoreCount()
    {
        scoreCount += 1;
    }
    private void Update()
    {
        comboText.text = "Combo : " + comboScore.ToString();
        scoreText.text = "Score : " + scoreCount.ToString();
    }
}
