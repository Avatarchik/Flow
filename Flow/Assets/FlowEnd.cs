using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

public class FlowEnd : MonoBehaviour {
	private GameObject _object;
	private bool connected;

	public void FlowEndSetter(Color32 _color, bool _connected)
	{
		_object = GameObject.CreatePrimitive(PrimitiveType.Sphere);
		_object.transform.parent = GetComponentInParent<Square>().transform;
		_object.transform.position = transform.position;
		_object.transform.localScale = new Vector3(_object.transform.localScale.x * 15, _object.transform.localScale.y * 15, 1);
		_object.GetComponent<MeshRenderer>().material = GetMaterial(_color);
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
}
