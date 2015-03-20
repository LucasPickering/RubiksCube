using UnityEngine;
using System.Collections;

public class CubeInput : MonoBehaviour
{

	void Update ()
	{
		bool shiftUp = !(Input.GetKey (KeyCode.LeftShift) || Input.GetKey (KeyCode.RightShift));
		if (Input.GetKeyDown (KeyCode.W)) {
			CubeRotator rotator = GetComponent<CubeRotator> ();
			rotator.Rotate (CubeRotator.Side.Top, shiftUp);
		} else if (Input.GetKeyDown (KeyCode.S)) {
			CubeRotator rotator = GetComponent<CubeRotator> ();
			rotator.Rotate (CubeRotator.Side.Bottom, shiftUp);
		} else 	if (Input.GetKeyDown (KeyCode.Q)) {
			CubeRotator rotator = GetComponent<CubeRotator> ();
			rotator.Rotate (CubeRotator.Side.Forward, shiftUp);
		} else 	if (Input.GetKeyDown (KeyCode.E)) {
			CubeRotator rotator = GetComponent<CubeRotator> ();
			rotator.Rotate (CubeRotator.Side.Back, shiftUp);
		} else 	if (Input.GetKeyDown (KeyCode.A)) {
			CubeRotator rotator = GetComponent<CubeRotator> ();
			rotator.Rotate (CubeRotator.Side.Left, shiftUp);
		} else 	if (Input.GetKeyDown (KeyCode.D)) {
			CubeRotator rotator = GetComponent<CubeRotator> ();
			rotator.Rotate (CubeRotator.Side.Right, shiftUp);
		} 
	}
}
