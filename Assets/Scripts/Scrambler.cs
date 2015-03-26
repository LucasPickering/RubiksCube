using UnityEngine;

public class Scrambler : MonoBehaviour
{
	private int iterations;

	void Update ()
	{
		if (iterations > 0 && !GetComponent<CubeletRotator> ().IsRotating ()) {
			GameObject.Find ("Timer").GetComponent<Timer> ().ReadyTimer ();
			Vector3 axis;
			switch (Random.Range (0, 6)) {
			case 0:
				axis = Vector3.left;
				break;
			case 1:
				axis = Vector3.right;
				break;
			case 2:
				axis = Vector3.up;
				break;
			case 3:
				axis = Vector3.down;
				break;
			case 4:
				axis = Vector3.forward;
				break;
			default:
				axis = Vector3.back;
				break;
			}
			GetComponent<CubeletRotator> ().Rotate (axis, Random.Range (0, 2) == 1, 2000);
			iterations--;
		} 
	}

	public void Scramble ()
	{
		iterations = Random.Range (45, 55);
	}
}
