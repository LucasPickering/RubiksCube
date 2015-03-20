using UnityEngine;
using System.Collections;

public class CubeInput : MonoBehaviour
{

	void OnMouseOver ()
	{
		CubeRotator.Side side;
		switch (name) {
		case "Yellow Plane":
			side = CubeRotator.Side.Right;
			break;
		case "White Plane":
			side = CubeRotator.Side.Left;
			break;
		case "Red Plane":
			side = CubeRotator.Side.Forward;
			break;
		case "Orange Plane":
			side = CubeRotator.Side.Back;
			break;
		case "Green Plane":
			side = CubeRotator.Side.Top;
			break;
		default:
			side = CubeRotator.Side.Bottom;
			break;
		}
		if (Input.GetMouseButtonDown (0)) {
			GameObject.Find ("Cube").GetComponent<CubeRotator> ().Rotate (side, true);
		} else if (Input.GetMouseButtonDown (1)) {
			GameObject.Find ("Cube").GetComponent<CubeRotator> ().Rotate (side, false);
		}
	}
}
