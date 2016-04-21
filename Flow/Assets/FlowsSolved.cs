using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FlowsSolved : MonoBehaviour {
	private int flows_solved = 0;

	// Use this for initialization
	void Start () {
		GetComponent<Text>().text = "Flows: " + flows_solved.ToString() + '/' + GetComponentInParent<Grid_2D>().NumberOfFlows.ToString();
	}
	
	public void Flows_Solved()
	{

	}
}
