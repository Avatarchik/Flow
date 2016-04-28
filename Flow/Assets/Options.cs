using UnityEngine;
using UnityEngine.UI;

public class Options : MonoBehaviour {
	public void SetLabels()
	{
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
			AudioSource[] sources = GetComponentsInChildren<AudioSource>();
			for (int i = 0; i < sources.Length; i++)
				sources[i].mute = true;
		}
		else
		{
			txt_objects[label].text = "Sound: On";
			PlayerPrefs.SetInt("sound", 1);
			AudioSource[] sources = GetComponentsInChildren<AudioSource>();
			for (int i = 0; i < sources.Length; i++)
				sources[i].mute = false;
		}
	}

	void Start()
	{
		int label = 0;
		Text[] txt_objects = GetComponentsInChildren<Text>();
		for (; txt_objects[label].name != "ColorLabels"; label++) ;

		if (PlayerPrefs.GetInt("labels") == 1)
			txt_objects[label].text = "Color Labels: On";
		else
			txt_objects[label].text = "Color Labels: Off";

		for (label = 0; txt_objects[label].name != "Sounds"; label++) ;

		if (PlayerPrefs.GetInt("sound") == 1)
		{
			txt_objects[label].text = "Sound: On";
			AudioSource[] sources = GetComponentsInChildren<AudioSource>();
			for (int i = 0; i < sources.Length; i++)
				sources[i].mute = false;
		}
		else
		{
			txt_objects[label].text = "Sound: Off";
			AudioSource[] sources = GetComponentsInChildren<AudioSource>();
			for (int i = 0; i < sources.Length; i++)
				sources[i].mute = true;
		}
	}
}