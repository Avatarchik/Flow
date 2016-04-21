using UnityEngine;
using System.Collections;

public class FlowEnd : MonoBehaviour {
	private Color32 color;
	private bool connected;

	public void FlowEndSetter(Color32 _color, bool _connected)
	{
		color = _color;
		connected = _connected;
		enabled = false;
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
