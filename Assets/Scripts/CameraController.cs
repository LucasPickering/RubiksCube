using UnityEngine;

public class CameraController : MonoBehaviour
{
	
	private const float DISTANCE = 250;
	private const float VELOCITY = 2400;
	private int corner = 4;
	private bool flipped;

	void Start ()
	{
		transform.position = new Vector3 (DISTANCE, DISTANCE, DISTANCE);
		transform.LookAt (Vector3.zero);
	}

	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.LeftArrow)) {
			corner = mod (corner + (flipped ? -1 : 1), 4) + corner / 4 * 4;
		} else if (Input.GetKeyDown (KeyCode.RightArrow)) {
			corner = mod (corner + (flipped ? 1 : -1), 4) + corner / 4 * 4;
		} else if (Input.GetKeyDown (KeyCode.UpArrow)) {
			corner = mod (corner + 4, 8);
		} else if (Input.GetKeyDown (KeyCode.DownArrow)) {
			corner = mod (corner - 4, 8);
		} else if (Input.GetKeyDown (KeyCode.Q) || Input.GetKeyDown (KeyCode.E)) {
			flipped = !flipped;
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
		if (flipped) {
			transform.RotateAround (Vector3.zero, transform.forward, 180);
		}
	}

	public int GetCorner ()
	{
		return corner;
	}

	private int mod (int a, int n)
	{
		return (a % n + n) % n;
	}
}
