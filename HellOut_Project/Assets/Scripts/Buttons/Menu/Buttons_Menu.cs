using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons_Menu : MonoBehaviour
{
	private void Start()
	{
		Time.timeScale = 0;
	}

	public void Play()
	{
		SceneManager.LoadScene("Main");
	}

	public void Continuegame()
	{
		Time.timeScale = 1;
	}

	public void Quit()
	{
		Application.Quit();
	}

	public void Play_Again()
	{
		SceneManager.LoadScene("Main");
		Time.timeScale = 1;
	}

	
}
