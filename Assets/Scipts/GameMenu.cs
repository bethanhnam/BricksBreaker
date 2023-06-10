using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameMenu : MonoBehaviour
{
	public static GameMenu instance;

	[SerializeField] private GameObject winPopuP;
	[SerializeField] private GameObject losePopUp;
	[SerializeField] private GameObject pausePopUp;
	[SerializeField] private GameObject Bricks;
	[SerializeField] private GameObject Balls;
	int on = -1;

	private void Awake()
	{
		instance = this;
	}
	private void Start()
	{
		Balls = GameObject.Find("BallSpawner");
		Bricks = GameObject.Find("BrickSpawner");

	}
	public void Pause()
	{
		GameManager.instance.Pause();
		on *= -1;	
		ShowPause(on);
	}

	public void Resume()
	{
		ShowPause(-1);
		GameManager.instance.Resume();
	}
	public void Restart()
	{
		GameManager.instance.Restart();
	}

	public void Back()
	{
		//Pause();
		GameManager.instance.Back();
	}
	public void Next()
	{
		//Pause();
		LevelSelector.StartLevel(PlayerDataManager.currentLevel + 1);
	}

	public void ShowPause(int on)
	{
		if (on ==1)
		{
			pausePopUp.SetActive(true);
		}

		if(on == -1)
		{
			pausePopUp.SetActive(false);
			GameManager.instance.Resume();
		}
	}

	public void ShowWin()
	{
		winPopuP.SetActive(true);
	}

	public void ShowLose()
	{
		losePopUp.SetActive(true);
	}
}
