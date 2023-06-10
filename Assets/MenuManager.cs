using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
	public GameObject StartGameMenu;
	public GameObject SelectMenu;

	public void StartGame()
	{
		StartGameMenu.active = false;
		SelectMenu.active = true;
	}
}
