using UnityEngine;
using System.Collections;

public class CameraInput : MonoBehaviour
{

	/// <summary>
	/// The highest or lowest the camera can go, in degrees above/below horizontal
	/// </summary>
	private const float VERTICAL_BOUND = 60;
	/// <summary>
	/// The speed of camera movement, in deg/s
	/// </summary>
	private const float SPEED = 10;

	void Update ()
	{
		if (Input.GetKey (KeyCode.LeftArrow)) {
			transform.Rotate (Vector3.zero);
		}
	}

	private void GetVerticalAngle(){

	}
}
