using UnityEngine;
using UnityEngine.SceneManagement;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class LoadScenes : MonoBehaviour {
	private AudioSource source;
	private AudioClip clip;
	public void LoadPlayboard()
	{
		source = GameObject.Find("OnClick Source").GetComponent<AudioSource>();
#if UNITY_EDITOR
		clip = AssetDatabase.LoadAssetAtPath<AudioClip>("Assets/OnClick.wav");
#endif
		source.clip = clip;
		source.Play();
		if (!source.isPlaying)	//wait for sound to play
			SceneManager.LoadScene("5x5 Board");
	}

	public void LoadSplashScreen()
	{
		source = GameObject.Find("Back Button").GetComponent<AudioSource>();
#if UNITY_EDITOR
		clip = AssetDatabase.LoadAssetAtPath<AudioClip>("Assets/Resources/Audio/OnClick.wav");
#endif
		source.clip = clip;
		source.Play();
		if (!source.isPlaying)	//wait for sound to play
			SceneManager.LoadScene("SplashScreen");
	}

	public void LoadOptionsScreen()
	{
		source = GameObject.Find("OnClick Source").GetComponent<AudioSource>();
#if UNITY_EDITOR
		clip = AssetDatabase.LoadAssetAtPath<AudioClip>("Assets/Resources/Audio/OnClick.wav");
#endif
		source.clip = clip;
		source.Play();
		if (!source.isPlaying)	//wait for sound to play
			SceneManager.LoadScene("OptionsScreen");
	}

	public void Quit()
	{
		source = GameObject.Find("OnClick Source").GetComponent<AudioSource>();
#if UNITY_EDITOR
		clip = AssetDatabase.LoadAssetAtPath<AudioClip>("Assets/Resources/Audio/OnClick.wav");
#endif
		source.clip = clip;
		source.Play();
		if (!source.isPlaying)  //wait for sound to play
		{
			PlayerPrefs.Save();
			Application.Quit();
		}
	}
}
