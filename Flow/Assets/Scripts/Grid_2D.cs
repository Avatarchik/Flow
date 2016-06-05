using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Collections.Generic;
using System;

public class Grid_2D : MonoBehaviour
{
	private AudioSource sound;
	private List<GameObject> grid;
	public GameObject win_screen;
	private static int width;
	private int number_of_flows = 0;
	public static LevelPath level_path;
	public List<Line> paths;
	private Square source;
	private Square previous;
	public static Square current;
	private Text flow_counter;
	private int flows_completed = 0;

	//blue, red, yellow, green, white, orange, cyan, purple, forest green, navy blue, dark red, grey, pink (magenta), dark cyan, tan, light purple
	public static Color32[] possible_colors = new Color32[16] { Color.blue, Color.red, Color.yellow, Color.green, Color.white, new Color32(255, 102, 0, 255), Color.cyan, new Color32(102, 0, 102, 255),
											new Color32(0, 102, 0, 255), new Color32(0, 0, 102, 255), new Color32(102, 0, 0, 255), Color.grey, Color.magenta, new Color32(0, 102, 153, 255),
											new Color32(200, 200, 50, 255), new Color32(102, 0, 255, 255) };

	private bool can_add_squares = true;


	public int NumberOfFlows
	{
		get { return number_of_flows; }
	}

	public List<GameObject> GetGrid
	{
		get { return grid; }
	}

	public static int Width
	{
		get { return width; }
		set { width = value; }
	}

	public static LevelPath Path
	{
		get { return level_path; }
	}

	// Use this for initialization
	void Start ()
	{
		sound = GameObject.Find("OnClick Source").GetComponent<AudioSource>();
		if (PlayerPrefs.GetInt("sound") == 1)
			sound.mute = false;

		SetSquareDimensions();
		PlaceFlowEnds();

		flow_counter = GameObject.Find("SolvedFlowCounter").GetComponent<Text>();
		UpdateFlowCounter();

		paths = new List<Line>(number_of_flows);

		for (int i = 0; i < number_of_flows; i++)
			paths.Add(gameObject.AddComponent<Line>());
	}

	void SetSquareDimensions()
	{
		Rect rt = GameObject.Find("Board").GetComponent<RectTransform>().rect;
		Vector2 square_dimensions = new Vector2(rt.width / width, rt.height / width);

		GameObject sq = GameObject.Find("Square");

		grid = new List<GameObject>(width * width);
		sq.GetComponent<RectTransform>().sizeDelta = square_dimensions;

		float x = -6000 / width * (0.5f * (width - 1)), y = 6000 / width * (0.5f * (width - 1));

		for (int i = 0, j = i; i < width * width; i++, j++)
		{
			grid.Add(Instantiate(sq));
			grid[i].name = "Square (" + i + ")";
			grid[i].transform.SetParent(GameObject.Find("Board").transform);
			grid[i].transform.localScale = new Vector3(1, 1, 1);

			if (i % width != 0)
				grid[i].GetComponent<RectTransform>().anchoredPosition3D = new Vector3(x + (sq.GetComponent<RectTransform>().rect.width * j), y, 0);
			else
			{
				y -= sq.GetComponent<RectTransform>().rect.width * (j / width);
				grid[i].GetComponent<RectTransform>().anchoredPosition3D = new Vector3(x, y, 0);
				j = 0;
			}

			grid[i].GetComponent<BoxCollider2D>().size = grid[i].GetComponent<RectTransform>().sizeDelta;
		}
	}

	void PlaceFlowEnds()
	{
		try
		{
			string line = string.Empty;
			int x = 0, y = 0;
			StreamReader reader = new StreamReader(level_path.Create());

			using (reader)
			{
				line = reader.ReadLine();

				for (int i = 0; line != null; i++, number_of_flows++)
				{
					for (int j = 0; j < 2 && line != null; j++)
					{
						x = int.Parse(line);

						grid[x].GetComponent<Square>().GetEndpoint = true;
						grid[x].gameObject.AddComponent<FlowEnd>().FlowEndSetter(possible_colors[i], false);

						if (PlayerPrefs.GetInt("labels") == 1)
							grid[x].GetComponent<FlowEnd>().label.GetComponent<Text>().text = ((char)(65 + i)).ToString();

						line = reader.ReadLine();

						if (j == 1)
							grid[x].GetComponent<FlowEnd>().SetOpposite(grid[y]);
						else
							y = x;
					}
				}

				reader.Close();
			}
		}
		catch (Exception except)
		{
			Debug.Log(except.Message);
		}
	}

	void ClickBegin()
	{
		if (current.GetComponent<Collider2D>() != null)
		{
			bool found = false;
			source = current;
			previous = current;

			for (int i = 0; i < number_of_flows && !found; i++)
			{
				if (paths[i].ConnectedSquares.Contains(current) || paths[i].ConnectedSquares.Contains(current.GetComponent<FlowEnd>().opposite.GetComponent<Square>()))
				{
					paths[i].Clear();
					flows_completed--;
					UpdateFlowCounter();
					found = true;
				}
			}

			if (source.name == current.name)
			{
				int index = 0;
				while (paths[index].ConnectedSquares.Count != 0)
					index++;

				paths[index].ConnectedSquares.Add(current);
			}
		}
	}

	void ClickMove()
	{
		if (current.GetComponent<Collider2D>() != null && can_add_squares)
		{
			bool found = false;

			for (int i = 0; i < number_of_flows && !found; i++)
			{
				if (paths[i].ConnectedSquares.Contains(source) && !paths[i].ConnectedSquares.Contains(current))
				{
					if (current.GetComponent<FlowEnd>() == null)
					{
						for (int j = 0; j < number_of_flows && !found; j++)
						{
							if (paths[j].ConnectedSquares.Contains(current))
							{
								paths[j].Clear();
								flows_completed--;
								UpdateFlowCounter();
								found = true;
							}
						}

						paths[i].ConnectedSquares.Add(current);
						paths[i].CreateLine(current, previous);
						previous = current;
					}
					else if (current.GetComponent<FlowEnd>().GetSphere.GetComponent<MeshRenderer>().material.color == source.GetComponent<FlowEnd>().GetSphere.GetComponent<MeshRenderer>().material.color)
					{
						paths[i].ConnectedSquares.Add(current);
						paths[i].CreateLine(current, previous);
						can_add_squares = false;
					}
					else
						can_add_squares = false;
				}
			}
		}
		else if (!can_add_squares)
		{
			bool found = false;

			for (int i = 0; i < number_of_flows && !found; i++)
			{
				if (paths[i].ConnectedSquares.Contains(current) && paths[i].ConnectedSquares.Contains(previous))
					can_add_squares = true;
			}
		}
	}

	void Release()
	{
		if (current.GetComponent<Collider2D>() != null && current.GetComponent<FlowEnd>() != null)
		{
			if (current.GetComponent<FlowEnd>().opposite.name == source.name)
			{
				current.GetComponent<FlowEnd>().connected = true;
				current.GetComponent<FlowEnd>().opposite.gameObject.GetComponent<FlowEnd>().connected = true;
				flows_completed++;
				UpdateFlowCounter();
			}
			else
			{
				int index = 0;
				while (!paths[index].ConnectedSquares.Contains(current) && index < paths.Count)
					index++;

				if (index != paths.Count)
				{
					try
					{
						paths[index].ConnectedSquares.RemoveAt(paths[index].ConnectedSquares.Count - 1);
						paths[index].GetLine.RemoveAt(paths[index].GetLine.Count - 1);
					}
					catch (Exception except)
					{
						Debug.Log(except);
					}
				}
			}
		}

		can_add_squares = true;
		CheckIfLevelWon();
	}

	void UpdateFlowCounter()
	{
		flow_counter.text = "Flows: " + flows_completed.ToString() + '/' + number_of_flows.ToString();
	}

	void CheckIfLevelWon()
	{
		bool won = true;
		int filled_square_count = 0;
		int connected_count = 0;

		for (int i = 0; i < width * width && won; i++)
		{
			bool found = false;

			for (int j = 0; j < number_of_flows && !found; j++)
			{
				if (paths[j].ConnectedSquares.Contains(grid[i].GetComponent<Square>()))
				{
					filled_square_count++;
					found = true;
				}
			}

			if (found)
			{
				if (grid[i].GetComponent<FlowEnd>() != null)
				{
					if (grid[i].GetComponent<FlowEnd>().connected)
						connected_count++;
					else
						won = false;
				}
			}
			else
				won = false;
		}

		if (won && (connected_count == (number_of_flows * 2)) && (filled_square_count == (width * width)))
		{
			Debug.Log("We won!!");

			try
			{
				string oldcontents, newcontents;

				StreamReader oldfile = new StreamReader(level_path.CreateLevelDataPath());
				using (oldfile)
				{
					oldcontents = oldfile.ReadToEnd();
					oldfile.Close();
				}

				//write completed level to file
				StreamWriter newfile = new StreamWriter(level_path.CreateLevelDataPath());

				using (newfile)
				{
					int level_number = int.Parse(level_path.LevelName[6].ToString());
					if (char.IsDigit(level_path.LevelName[7]))
						level_number += int.Parse(level_path.LevelName[7].ToString());

					newcontents = oldcontents.Substring(0, level_number - 1) + "1" + oldcontents.Substring(level_number);

					newfile.Write(newcontents);
					newfile.Close();
				}
			}
			catch (Exception except)
			{
				Debug.Log(except);
			}

			win_screen.SetActive(true);
			enabled = false;
		}
	}

	void Update()
	{
		if (Input.GetMouseButtonDown(0) && current.GetComponent<FlowEnd>() != null)
		{
			sound.Play();
			ClickBegin();
		}
		if (Input.GetMouseButton(0) && current.name != source.name)
			ClickMove();
		if (Input.GetMouseButtonUp(0))
		{
			sound.Play();
			Release();
		}
	}
}
