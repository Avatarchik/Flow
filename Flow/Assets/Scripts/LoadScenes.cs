using UnityEngine;
using UnityEngine.SceneManagement;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class LoadScenes : MonoBehaviour {
	private AudioSource source;
	private static GameObject instance;
	private AudioClip clip;

	public void LoadPlayboard()
	{
		source = GameObject.Find("OnClick Source").GetComponent<AudioSource>();
#if UNITY_EDITOR
		clip = AssetDatabase.LoadAssetAtPath<AudioClip>("Assets/Resources/Audio/OnClick.wav");
#endif
		source.clip = clip;

		if (!source.mute)
		{
			source.Play();
			if (instance == null)
			{
				instance = source.gameObject;
				DontDestroyOnLoad(source);
			}
			else
				Destroy(GameObject.Find("OnClick Source"));
		}

		SceneManager.LoadScene("5x5 Board");
	}

	public void LoadSplashScreen()
	{
		source = GameObject.Find("OnClick Source").GetComponent<AudioSource>();
#if UNITY_EDITOR
		clip = AssetDatabase.LoadAssetAtPath<AudioClip>("Assets/Resources/Audio/OnClick.wav");
#endif
		source.clip = clip;
		if (!source.mute)
		{
			source.Play();
			if (instance == null)
			{
				instance = source.gameObject;
				DontDestroyOnLoad(source);
			}
			else
				Destroy(GameObject.Find("OnClick Source"));
		}

		SceneManager.LoadScene("SplashScreen");
	}

	public void LoadOptionsScreen()
	{
		source = GameObject.Find("OnClick Source").GetComponent<AudioSource>();
#if UNITY_EDITOR
		clip = AssetDatabase.LoadAssetAtPath<AudioClip>("Assets/Resources/Audio/OnClick.wav");
#endif
		source.clip = clip;
		if (!source.mute)
		{
			source.Play();
			if (instance == null)
			{
				instance = source.gameObject;
				DontDestroyOnLoad(source);
			}
			else
				Destroy(GameObject.Find("OnClick Source"));
		}

		SceneManager.LoadScene("OptionsScreen");
	}

	public void Quit()
	{
		source = GameObject.Find("OnClick Source").GetComponent<AudioSource>();
#if UNITY_EDITOR
		clip = AssetDatabase.LoadAssetAtPath<AudioClip>("Assets/Resources/Audio/OnClick.wav");
#endif
		source.clip = clip;
		if (!source.mute)
		{
			source.Play();
			if (instance == null)
			{
				instance = source.gameObject;
				DontDestroyOnLoad(source);
			}
			else
				Destroy(GameObject.Find("OnClick Source"));
		}

		PlayerPrefs.Save();
		Application.Quit();
	}

	// Use this for initialization
	void Start()
	{
		source = GameObject.Find("OnClick Source").GetComponent<AudioSource>();
		if (PlayerPrefs.GetInt("sound") == 1)
			source.mute = false;
		else
			source.mute = true;
	}
}
