using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadScenes : MonoBehaviour {
	private AudioSource source;

	// Use this for initialization
	void Start()
	{
		source = GameObject.Find("OnClick Source").GetComponent<AudioSource>();

		if (PlayerPrefs.GetInt("sound") == 1)
			source.mute = false;
		else
			source.mute = true;
	}

	public void SetPath(Button path)
	{
		Grid_2D.Path += path.GetComponentInChildren<Text>().name + "/";
	}

	public void ResetPath()
	{
		Grid_2D.Path = "Assets/Resources/Puzzle Setups/";
	}

	public void LoadPlayboard(Button level)
	{
		Grid_2D.Path += level.name + ".txt";
		Grid_2D.Width = int.Parse(GameObject.Find("Pack Type").GetComponent<Text>().text[0].ToString());
		SceneManager.LoadScene("Playboard");
	}

	public void LoadSplashScreen()
	{
		ResetPath();
		SceneManager.LoadScene("SplashScreen");
	}

	public void Quit()
	{
		PlayerPrefs.Save();
		Application.Quit();
	}

	public void LoadNextLevel()
	{
		
	}

	public void LoadPreviousLevel()
	{

	}
}