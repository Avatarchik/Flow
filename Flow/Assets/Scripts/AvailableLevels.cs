using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AvailableLevels : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	public void SetPackType(Text pack_name)
	{
		GetComponent<Text>().text = pack_name.name;
		GetComponent<Text>().color = pack_name.color;

		CompletedLevels();
	}

	void CompletedLevels()
	{

	}
}
