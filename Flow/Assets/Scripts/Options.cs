using UnityEngine;
using UnityEngine.UI;

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
			source = GameObject.Find("OnClick Source").GetComponent<AudioSource>();
			source.mute = false;
		}
		else
		{
			txt_objects[label].text = "Sound: Off";
			source = GameObject.Find("OnClick Source").GetComponent<AudioSource>();
			source.mute = true;
		}
	}
}