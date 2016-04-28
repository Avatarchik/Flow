using UnityEngine;
using UnityEngine.UI;

public class Square : MonoBehaviour
{
	private bool endpoint = false;
	public Text label;
	public AudioClip _audio;
	private AudioSource source;

	public bool GetEndpoint
	{
		get { return endpoint; }
		set { endpoint = value; }
	}

	// Use this for initialization
	void Awake()
	{
		source = gameObject.AddComponent<AudioSource>();
		source.clip = _audio;
		
		source.mute = true;
		source.playOnAwake = false;
	}

	// Update is called once per frame
	void Update()
	{

	}
}
