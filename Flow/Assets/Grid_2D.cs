using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Generic;

public class Grid_2D : MonoBehaviour
{
	public List<List<Square>> grid;
	public int width;
	private int number_of_flows;
	
	//blue, red, yellow, green, white, orange, cyan, purple, forest green, navy blue, dark red, grey, pink (magenta), dark cyan, tan, light purple
	public static Color32[] possible_colors = new Color32[16] { Color.blue, Color.red, Color.yellow, Color.green, Color.white, new Color32(255, 102, 0, 255), Color.cyan, new Color32(102, 0, 102, 255),
											new Color32(0, 102, 0, 255), new Color32(0, 0, 102, 255), new Color32(102, 0, 0, 255), Color.grey, Color.magenta, new Color32(0, 102, 153, 255),
											new Color32(200, 200, 50, 255), new Color32(102, 0, 255, 255) };


	public void PlaceEnds()
	{
		Vector2 coordinates;
		System.Random rand = new System.Random();

		for (short i = 0; i < number_of_flows; i++)
		{
			for (short j = 0; j < 2; j++)
			{
				coordinates.x = rand.Next(0, (int)Math.Sqrt(grid.Capacity));
				coordinates.y = rand.Next(0, (int)Math.Sqrt(grid.Capacity));
				grid[(int)coordinates.x][(int)coordinates.y].gameObject.AddComponent<FlowEnd>();
				grid[(int)coordinates.x][(int)coordinates.y].GetComponent<FlowEnd>().FlowEndSetter(possible_colors[i], false);
			}
		}
	}

	public int NumberOfFlows
	{
		get { return number_of_flows; }
	}

	// Use this for initialization
	void Start ()
	{
		System.Random rand = new System.Random();

		number_of_flows = (width * width) / rand.Next(width - 3, width + 3);
		grid = new List<List<Square>>(width * width);

		PlaceEnds();
	}

	// Update is called once per frame
	void Update ()
	{
	
	}
}
