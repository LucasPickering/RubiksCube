using UnityEngine;
using System;
using System.Collections;

public class CameraController : MonoBehaviour
{
	
	private const float DISTANCE = 250;
	private const float VELOCITY = 1600;
	private int corner = 4;

	void Start ()
	{
		transform.position = new Vector3 (DISTANCE, DISTANCE, DISTANCE);
		transform.LookAt (Vector3.zero);
	}

	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.LeftArrow)) {
			corner = mod (corner + 1, 4) + corner / 4 * 4;
			Debug.Log ("Left: " + corner);
		} else if (Input.GetKeyDown (KeyCode.RightArrow)) {
			corner = mod (corner - 1, 4) + corner / 4 * 4;
		} else if (Input.GetKeyDown (KeyCode.UpArrow)) {
			corner = mod (corner + 4, 8);
		} else if (Input.GetKeyDown (KeyCode.DownArrow)) {
			corner = mod (corner - 4, 8);
		}

		float delta = VELOCITY * Time.deltaTime;
		float x = corner % 4 <= 1 ? 
			Mathf.Min (transform.position.x + delta, DISTANCE) : Mathf.Max (transform.position.x - delta, -DISTANCE);
		float y = corner > 3 ? 
			Mathf.Min (transform.position.y + delta, DISTANCE) : Mathf.Max (transform.position.y - delta, -DISTANCE);
		float z = (corner == 0 || corner == 3 || corner == 4 || corner == 7) ? 
			Mathf.Min (transform.position.z + delta, DISTANCE) : Mathf.Max (transform.position.z - delta, -DISTANCE);
		transform.position = new Vector3 (x, y, z);
		transform.LookAt (Vector3.zero);
	}

	private int mod (int a, int n)
	{
		return (a % n + n) % n;
	}
}
