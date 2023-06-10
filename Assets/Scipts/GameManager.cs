using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int totalValue;
    public int turn;

    private void Awake()
    {
        instance = this;
    }

    public void Pause()
    {
        Time.timeScale = 0;
        //GameMenu.instance.ShowPause(true);
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        //GameMenu.instance.ShowPause(false);
    }

    public void Restart()
    {
        Resume();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void CheckStatus()
    {
        if(turn == 0 && ScoreManager.instance.score != totalValue)
        {
            Pause();
            GameMenu.instance.ShowLose();
        }
        else if (turn >= 0 && ScoreManager.instance.score >= totalValue)
        {
            Pause();
            GameMenu.instance.ShowWin();
            LevelManager.UnlockLevel();

        }
    }

    public void Back()
    {
        SceneManager.LoadScene("SelectLevelScene");
        Time.timeScale = 1f;
    }
    
}
