using UnityEngine;
using System.Collections;

public class Sounds : MonoBehaviour {
	private AudioSource source;
	// Use this for initialization
	void Start () {
		source = GameObject.Find("OnClick Source").GetComponent<AudioSource>();
		if (PlayerPrefs.GetInt("sound") == 1)
			source.mute = false;
		else
			source.mute = true;
	}
}
