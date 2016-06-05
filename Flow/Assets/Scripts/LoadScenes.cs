using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;
using System;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class LoadScenes : MonoBehaviour {
	private AudioSource source;
	private LevelPath level_path;

	// Use this for initialization
	void Start()
	{
		source = GameObject.Find("OnClick Source").GetComponent<AudioSource>();

		if (PlayerPrefs.GetInt("sound") == 1)
		{
			source.mute = false;
			source.Play();
		}
		else
			source.mute = true;

		level_path = new LevelPath();
	}

	public LevelPath Path
	{
		get { return level_path; }
	}

	public void SetLevel(Button path)
	{
		level_path.Level = path.GetComponentInChildren<Text>().name + "/";
	}

	public void SetSubLevel(Button path)
	{
		level_path.SubLevel = path.GetComponentInChildren<Text>().name + "/";
		ShowCompletedLevels();
	}

	public void LoadPlayboard(Button level)
	{
		level_path.LevelName = level.name + ".txt";
		Grid_2D.level_path = level_path;
		Grid_2D.Width = int.Parse(GameObject.Find("Pack Type").GetComponent<Text>().text[0].ToString());
		DontDestroyOnLoad(source);
		SceneManager.LoadScene("Playboard");
	}

	public void LoadSplashScreen()
	{
		Destroy(source.gameObject);
		level_path.Reset();
		SceneManager.LoadScene("SplashScreen");
	}

	public void Quit()
	{
		PlayerPrefs.Save();
		Application.Quit();
	}

	public void ShowCompletedLevels()
	{
		try
		{
			StreamReader leveldata = new StreamReader(level_path.CreateLevelDataPath());

			using (leveldata)
			{
				string levels_complete = leveldata.ReadToEnd();
				int level_number = 1;

				foreach (char complete in levels_complete)
				{
					if (complete == '1')
					{
#if UNITY_EDITOR
						GameObject _object = Instantiate(AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Resources/StarCompleted.prefab"));
						_object.transform.SetParent(GameObject.Find("Level " + level_number).transform);
						_object.transform.localScale = Vector3.one;
						_object.transform.localPosition = Vector3.zero;
						_object.tag = "LevelComplete";
						_object.transform.SetAsFirstSibling();
#endif
					}

					level_number++;
				}

				leveldata.Close();
			}
		}
		catch (Exception except)
		{
			Debug.Log(except);
		}
	}

	public void DeleteCompletedLevelIcons()
	{
		GameObject[] objects = GameObject.FindGameObjectsWithTag("LevelComplete");
		foreach (GameObject _object in objects)
			Destroy(_object);
	}
}