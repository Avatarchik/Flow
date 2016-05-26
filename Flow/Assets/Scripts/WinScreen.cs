using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinScreen : MonoBehaviour
{
	public Text level_text;

	// Use this for initialization
	void OnEnable()
	{
		level_text.text = Grid_2D.level_path.LevelName.Substring(0, 7) + " Complete!";
	}

	public void LoadNextLevel()
	{
		if (Grid_2D.level_path.LevelName != "Level 30.txt")
		{
			int level_number = int.Parse(Grid_2D.level_path.LevelName[6].ToString());
			if (char.IsDigit(Grid_2D.level_path.LevelName[7]))
				level_number += int.Parse(Grid_2D.level_path.LevelName[7].ToString());

			level_number++;

			Grid_2D.level_path.LevelName = "Level " + level_number + ".txt";
			SceneManager.LoadScene("Playboard");
		}
		else
			LoadSplashScreen();
	}

	public void LoadPreviousLevel()
	{
		if (Grid_2D.level_path.LevelName != "Level 1.txt")
		{
			int level_number = int.Parse(Grid_2D.level_path.LevelName[6].ToString());
			if (char.IsDigit(Grid_2D.level_path.LevelName[7]))
				level_number += int.Parse(Grid_2D.level_path.LevelName[7].ToString());

			level_number--;

			Grid_2D.level_path.LevelName = "Level " + level_number + ".txt";
			SceneManager.LoadScene("Playboard");
		}
		else
			LoadSplashScreen();
	}

	public void LoadSplashScreen()
	{
		Destroy(GameObject.Find("OnClick Source"));
		Grid_2D.level_path.Reset();
		SceneManager.LoadScene("SplashScreen");
	}
}
