using UnityEngine;
using System.Collections.Generic;

public class Square : MonoBehaviour
{
	private bool endpoint = false;

	public bool GetEndpoint
	{
		get { return endpoint; }
		set { endpoint = value; }
	}

	void OnMouseOver()
	{
		Grid_2D.current = this;
	}
}
