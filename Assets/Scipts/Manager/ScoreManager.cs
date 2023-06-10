using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public int score;
    [SerializeField] private TMP_Text scoreText;

    private void Awake()
    {
        instance = this;
        scoreText = GetComponentInChildren<TMP_Text>();
    }

    public void UpdateScore()
    {
        score++;
        scoreText.text = "Score: " + score.ToString() ;
    }

}
