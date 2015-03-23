using UnityEngine;
using System.Collections;

public class CubeRotator : MonoBehaviour
{

	private float ROTATE_RATE = 180;

	void Update ()
	{
		/*
		if (Input.GetKey (KeyCode.LeftArrow)) {
			Rotate (Vector3.down);
		}
		if (Input.GetKey (KeyCode.RightArrow)) {
			Rotate (Vector3.up);
		}

		if (Input.GetKey (KeyCode.UpArrow)) {
			Rotate (Vector3.back);
		}
		if (Input.GetKey (KeyCode.DownArrow)) {
			Rotate (Vector3.forward);
		}


		if (Input.GetKey (KeyCode.Q)) {
			Rotate (Vector3.left);
		}
		if (Input.GetKey (KeyCode.E)) {
			Rotate (Vector3.right);
		}
		*/

		if (Input.GetKeyDown (KeyCode.Space)) {
			GetComponent<Scrambler> ().Scramble ();
		}
	}

	private void Rotate (Vector3 axis)
	{
		transform.RotateAround (Vector3.zero, axis, ROTATE_RATE * Time.deltaTime); 
	}
}
