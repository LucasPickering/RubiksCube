using UnityEngine;

public class CubeController : MonoBehaviour
{

	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.Space)) {
			GetComponent<Scrambler> ().Scramble ();
		}

		int corner = GameObject.Find ("Main Camera").GetComponent<CameraController> ().GetCorner ();
		Vector3 cubeletAxis;
		if (Input.GetKeyDown (KeyCode.A)) {
			cubeletAxis = GetVectorForCorner (corner + 1);
		} else if (Input.GetKeyDown (KeyCode.D)) {
			cubeletAxis = GetVectorForCorner (corner);
		} else if (Input.GetKeyDown (KeyCode.W)) {
			cubeletAxis = corner < 4 ? Vector3.down : Vector3.up;
		} else if (Input.GetKeyDown (KeyCode.S)) {
			cubeletAxis = corner < 4 ? Vector3.up : Vector3.down;
		} else {
			return;
		}

		GetComponent<CubeletRotator> ().Rotate (cubeletAxis, !Input.GetKey (KeyCode.LeftShift) && !Input.GetKey (KeyCode.RightShift), 720);	
	}

	/// <summary>
	/// Gets the vector that will rotate the right-hand side while focused on the given corner	
	/// </summary>
	/// <param name="corner">the corner that the camera is currently focused on
	/// <returns>The vector to rotate the right-hand side</returns>
	private Vector3 GetVectorForCorner (int corner)
	{
		switch (corner % 4) {
		case 0:
			return Vector3.forward;
		case 1:
			return Vector3.right;
		case 2:
			return Vector3.back;
		default:
			return Vector3.left;
		}
	}
}
