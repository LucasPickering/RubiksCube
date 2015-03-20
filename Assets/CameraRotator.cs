using System;
using UnityEngine;
using System.Collections;

public class CameraRotator : MonoBehaviour
{

	/// <summary>
	/// The camera's constant distance from the origin, in meters
	/// </summary>
	private const float DISTANCE = 250;

	/// <summary>
	/// The angular velocity that the camera moves at, in deg/s
	/// </summary>
	private const float VELOCITY = 90;
	private const float INCLINATION_RANGE = 60;
	private float inclinationAngle = 90;
	private float azimuthAngle = 0;

	void Update ()
	{
		bool changed = false;
		if (Input.GetKey (KeyCode.LeftArrow)) {
			azimuthAngle -= VELOCITY * Time.deltaTime;
			azimuthAngle %= 360;
			changed = true;
		}
		if (Input.GetKey (KeyCode.RightArrow)) {
			azimuthAngle += VELOCITY * Time.deltaTime;
			azimuthAngle %= 360;
			changed = true;
		}
		if (Input.GetKey (KeyCode.UpArrow)) {
			inclinationAngle -= VELOCITY * Time.deltaTime;
			inclinationAngle = Math.Max (inclinationAngle, 90 - INCLINATION_RANGE);
			changed = true;
		}
		if (Input.GetKey (KeyCode.DownArrow)) {
			inclinationAngle += VELOCITY * Time.deltaTime;
			inclinationAngle = Math.Min (inclinationAngle, 90 + INCLINATION_RANGE);
			changed = true;
		}
		if (changed) {
			UpdatePositionAndAngle ();
		}
	}

	private void UpdatePositionAndAngle ()
	{
		float sinInclination = (float)Math.Sin (ToRadians (inclinationAngle));
		float cosInclination = (float)Math.Cos (ToRadians (inclinationAngle));
		float sinAzimuth = (float)Math.Sin (ToRadians (azimuthAngle));
		float cosAzimuth = (float)Math.Cos (ToRadians (azimuthAngle));

		float x = DISTANCE * sinInclination * cosAzimuth;
		float y = DISTANCE * cosInclination;
		float z = DISTANCE * sinInclination * sinAzimuth;

		transform.position = new Vector3 (x, y, z);
		transform.LookAt (GameObject.Find ("Cube").transform);
	}

	private float ToRadians (float degrees)
	{
		return degrees * (float)Math.PI / 180F;
	}
}
