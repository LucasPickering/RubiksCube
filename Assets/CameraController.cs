using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{

	private int position;

	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.LeftArrow)) {
			position = (position + 1) % 4 + position / 4 * 4;
			UpdateCamera ();
		} else if (Input.GetKeyDown (KeyCode.RightArrow)) {
			position = (position - 1) % 4 + position / 4 * 4;
			UpdateCamera ();
		} else if (Input.GetKeyDown (KeyCode.UpArrow)) {
			position = position + 4 % 8;
			UpdateCamera ();
		} else if (Input.GetKeyDown (KeyCode.DownArrow)) {
			position = position - 4 % 8;
			UpdateCamera ();
		}
	}

	private void UpdateCamera ()
	{
		int x = (position == 0 || position == 1 || position == 4 || position == 5) ? 1 : -1;
		int y = position > 3 ? 1 : -1;
		int z = (position == 0 || position == 3 || position == 4 || position == 7) ? 1 : -1;
		transform.position = new Vector3 (250 * x, 250 * y, 250 * z);
		transform.rotation = Quaternion.Euler (new Vector3 (-45 * x, -45 * y, -45 * z));
	}
}
