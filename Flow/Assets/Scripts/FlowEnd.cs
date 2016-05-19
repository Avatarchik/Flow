using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class FlowEnd : MonoBehaviour {
	private GameObject object_1;	//end sphere
	public bool connected;
	public GameObject label;
	public GameObject opposite;

	public void FlowEndSetter(Color32 _color, bool _connected)
	{
		object_1 = GameObject.CreatePrimitive(PrimitiveType.Sphere);
		object_1.transform.SetParent(GetComponentInParent<Square>().transform);
		object_1.transform.position = new Vector3(transform.position.x, transform.position.y, -0.1f);
		object_1.transform.localScale = new Vector3(6000 / Grid_2D.Width * 0.79f, 6000 / Grid_2D.Width * 0.79f, 1);
		object_1.GetComponent<MeshRenderer>().material = GetMaterial(_color);

		label = new GameObject();
		label.name = "Label";
		label.transform.SetParent(object_1.transform.parent);
		label.AddComponent<Text>();
		label.GetComponent<Text>().fontSize = 300;
		label.GetComponent<Text>().alignment = TextAnchor.MiddleCenter;
		label.GetComponent<Text>().color = Color.white;
		label.GetComponent<Text>().font = Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font;
		label.GetComponent<Text>().fontStyle = FontStyle.Bold;
		label.GetComponent<Text>().resizeTextForBestFit = true;
		label.GetComponent<Text>().resizeTextMaxSize = 300;
		label.GetComponent<Text>().resizeTextMinSize = 1;
		label.GetComponent<RectTransform>().anchoredPosition3D = new Vector3(0, 0, -1.5f);
		label.GetComponent<RectTransform>().sizeDelta = (object_1.transform.parent.gameObject.GetComponent<RectTransform>().sizeDelta * 0.29166f);
		label.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);

		connected = _connected;
	}

	private Material GetMaterial(Color32 _color)
	{
		Material[] materials = Resources.LoadAll<Material>("FlowColors");
		int index = 0;

		while (materials[index].color != _color)
			index++;

		return materials[index];
	}

	public GameObject GetSphere
	{
		get { return object_1; }
	}

	public void SetOpposite(GameObject sq)
	{
		opposite = sq;
		sq.GetComponent<FlowEnd>().opposite = gameObject;
	}
}
