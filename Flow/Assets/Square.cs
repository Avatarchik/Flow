using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;
using System.Collections;
using System.Collections.Generic;

public class Square : MonoBehaviour
{
	private FlowEnd flow;
	private bool endpoint = false;

	public Square(FlowEnd end)
	{
		flow = end;
		endpoint = true;
	}

	// Use this for initialization
	void Start()
	{
		if (endpoint)
			flow.enabled = true;
	}

	// Update is called once per frame
	void Update()
	{

	}
}
