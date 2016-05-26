using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;

public class Options : MonoBehaviour {
	private AudioSource source;
	public void SetLabels()
	{
		source.Play();
		int label = 0;
		Text[] txt_objects = GetComponentsInChildren<Text>();
		for (; txt_objects[label].name != "ColorLabels"; label++) ;

		if (PlayerPrefs.GetInt("labels") == 1)
		{
			txt_objects[label].text = "Color Labels: Off";
			PlayerPrefs.SetInt("labels", 0);
		}
		else
		{
			txt_objects[label].text = "Color Labels: On";
			PlayerPrefs.SetInt("labels", 1);
		}
	}

	public void SetSounds()
	{
		int label = 0;
		Text[] txt_objects = GetComponentsInChildren<Text>();
		for (; txt_objects[label].name != "Sounds"; label++) ;

		if (PlayerPrefs.GetInt("sound") == 1)
		{
			txt_objects[label].text = "Sound: Off";
			PlayerPrefs.SetInt("sound", 0);
			source.mute = true;
		}
		else
		{
			txt_objects[label].text = "Sound: On";
			PlayerPrefs.SetInt("sound", 1);
			source.mute = false;
		}

		source.Play();
	}

	public void ResetProgress()
	{
		LevelPath[] leveldatas = new LevelPath[15];
		leveldatas[0] = new LevelPath("Regular/", "5x5/", string.Empty);
		leveldatas[1] = new LevelPath("Regular/", "6x6/", string.Empty);
		leveldatas[2] = new LevelPath("Regular/", "7x7/", string.Empty);
		leveldatas[3] = new LevelPath("Regular/", "8x8/", string.Empty);
		leveldatas[4] = new LevelPath("Regular/", "9x9/", string.Empty);
		leveldatas[5] = new LevelPath("Bonus/", "5x5/", string.Empty);
		leveldatas[6] = new LevelPath("Bonus/", "6x6/", string.Empty);
		leveldatas[7] = new LevelPath("Bonus/", "7x7/", string.Empty);
		leveldatas[8] = new LevelPath("Bonus/", "8x8/", string.Empty);
		leveldatas[9] = new LevelPath("Bonus/", "9x9/", string.Empty);
		leveldatas[10] = new LevelPath("10x10/", string.Empty, string.Empty);
		leveldatas[11] = new LevelPath("11x11/", string.Empty, string.Empty);
		leveldatas[12] = new LevelPath("12x12/", string.Empty, string.Empty);
		leveldatas[13] = new LevelPath("13x13/", string.Empty, string.Empty);
		leveldatas[14] = new LevelPath("14x14/", string.Empty, string.Empty);
		string reset = "000000000000000000000000000000";

		try
		{
			foreach (LevelPath leveldata in leveldatas)
			{
				StreamWriter swr = new StreamWriter(leveldata.CreateLevelDataPath());

				using (swr)
				{
					swr.Write(reset);
					swr.Close();
				}
			}
		}
		catch (Exception except)
		{
			Debug.Log(except);
		}
	}

	void Start()
	{
		GameObject txt_object = GameObject.Find("ColorLabels");

		if (PlayerPrefs.GetInt("labels") == 1)
			txt_object.GetComponent<Text>().text = "Color Labels: On";
		else
			txt_object.GetComponent<Text>().text = "Color Labels: Off";

		txt_object = GameObject.Find("Sounds");

		if (PlayerPrefs.GetInt("sound") == 1)
		{
			txt_object.GetComponent<Text>().text = "Sound: On";
			source = GameObject.Find("OnClick Source").GetComponent<AudioSource>();
			source.mute = false;
		}
		else
		{
			txt_object.GetComponent<Text>().text = "Sound: Off";
			source = GameObject.Find("OnClick Source").GetComponent<AudioSource>();
			source.mute = true;
		}
	}
}