using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LoadScenes : MonoBehaviour {
	public void LoadPlayboard()
	{
		SceneManager.LoadScene("Playboard");
	}

	public void LoadSplashScreen()
	{
		SceneManager.LoadScene("SplashScreen");
	}

	public void LoadOptionsScreen()
	{
		SceneManager.LoadScene("OptionsScreen");
	}

	public void Quit()
	{
		PlayerPrefs.Save();
		Application.Quit();
	}
}
