using UnityEngine;
using System.Collections;

public class CubeRotator : MonoBehaviour
{

	private float ROTATE_RATE = 180;

	void Update ()
	{
		if (Input.GetKey (KeyCode.A)) {
			Rotate(Vector3.up);
		}
		if (Input.GetKey (KeyCode.D)) {
			Rotate(Vector3.down);
		}
		if (Input.GetKey (KeyCode.W)) {
			Rotate(Vector3.forward);
		}
		if (Input.GetKey (KeyCode.S)) {
            Rotate(Vector3.back);
        }
    }

	private void Rotate (Vector3 axis)
	{
		transform.RotateAround (Vector3.zero, axis, ROTATE_RATE * Time.deltaTime); 
	}
}
