using UnityEngine;
using System.Collections;

public class CubeletInput : MonoBehaviour
{
	void OnMouseOver ()
	{
		Vector3 axis;
		switch (name) {
		case "Yellow Plane":
			axis = Vector3.right;
			break;
		case "White Plane":
			axis = Vector3.left;
			break;
		case "Red Plane":
			axis = Vector3.forward;
			break;
		case "Orange Plane":
			axis = Vector3.back;
			break;
		case "Green Plane":
			axis = Vector3.up;
			break;
		default:
			axis = Vector3.down;
			break;
		}
		if (Input.GetMouseButtonDown (0)) {
			transform.parent.gameObject.GetComponent<CubeletRotator> ().Rotate (axis, true);
		} else if (Input.GetMouseButtonDown (1)) {
			transform.parent.gameObject.GetComponent<CubeletRotator> ().Rotate (axis, false);
		}
	}
}
