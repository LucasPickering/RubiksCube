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
			transform.parent.gameObject.GetComponent<CubeletRotator> ().Rotate (axis, true, 360);
		} else if (Input.GetMouseButtonDown (1)) {
			transform.parent.gameObject.GetComponent<CubeletRotator> ().Rotate (axis, false, 360);
		}
	}

	void Update ()
	{
		Vector3 axis;
		if (Input.GetKeyDown (KeyCode.Q)) {
			axis = Vector3.forward;
		} else if (Input.GetKeyDown (KeyCode.E)) {
			axis = Vector3.back;
		} else if (Input.GetKeyDown (KeyCode.A)) {
			axis = Vector3.left;
		} else if (Input.GetKeyDown (KeyCode.D)) {
			axis = Vector3.right;
		} else if (Input.GetKeyDown (KeyCode.W)) {
			axis = Vector3.up;
		} else if (Input.GetKeyDown (KeyCode.S)) {
			axis = Vector3.down;
		} else {
			return;
		}
		transform.parent.gameObject.GetComponent<CubeletRotator> ()
				.Rotate (axis, !Input.GetKey (KeyCode.LeftShift) && !Input.GetKey (KeyCode.RightShift), 360);

	}
}
