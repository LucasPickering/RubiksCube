using System;
using UnityEngine;
using System.Collections;

public class CubeletRotator : MonoBehaviour
{
	
	// cubelets[0][0][0] is the cube with the lowest x, y, and z
	private GameObject[,,] cubelets = new GameObject[3, 3, 3];
	private readonly GameObject[,,] tempCubelets = new GameObject[3, 3, 3];
	private Vector3 rotatingAxis = Vector3.zero;
	private float rotatingAngle;
	private bool rotatingCW;
	private float rotatingRate;

	void Start ()
	{
		cubelets [0, 0, 0] = GameObject.Find ("Block000");
		cubelets [0, 0, 1] = GameObject.Find ("Block001");
		cubelets [0, 0, 2] = GameObject.Find ("Block002");
		cubelets [0, 1, 0] = GameObject.Find ("Block010");
		cubelets [0, 1, 1] = GameObject.Find ("Block011");
		cubelets [0, 1, 2] = GameObject.Find ("Block012");
		cubelets [0, 2, 0] = GameObject.Find ("Block020");
		cubelets [0, 2, 1] = GameObject.Find ("Block021");
		cubelets [0, 2, 2] = GameObject.Find ("Block022");

		cubelets [1, 0, 0] = GameObject.Find ("Block100");
		cubelets [1, 0, 1] = GameObject.Find ("Block101");
		cubelets [1, 0, 2] = GameObject.Find ("Block102");
		cubelets [1, 1, 0] = GameObject.Find ("Block110");
		cubelets [1, 1, 1] = GameObject.Find ("Block111");
		cubelets [1, 1, 2] = GameObject.Find ("Block112");
		cubelets [1, 2, 0] = GameObject.Find ("Block120");
		cubelets [1, 2, 1] = GameObject.Find ("Block121");
		cubelets [1, 2, 2] = GameObject.Find ("Block122");

		cubelets [2, 0, 0] = GameObject.Find ("Block200");
		cubelets [2, 0, 1] = GameObject.Find ("Block201");
		cubelets [2, 0, 2] = GameObject.Find ("Block202");
		cubelets [2, 1, 0] = GameObject.Find ("Block210");
		cubelets [2, 1, 1] = GameObject.Find ("Block211");
		cubelets [2, 1, 2] = GameObject.Find ("Block212");
		cubelets [2, 2, 0] = GameObject.Find ("Block220");
		cubelets [2, 2, 1] = GameObject.Find ("Block221");
		cubelets [2, 2, 2] = GameObject.Find ("Block222");
	}

	void Update ()
	{
		if (Math.Abs (rotatingAngle) >= 90) {
			FinishRotation ();
		} else if (rotatingAxis != Vector3.zero) {
			float deltaAngle;
			if (rotatingCW) {
				deltaAngle = Math.Min (rotatingRate * Time.deltaTime, 90 - rotatingAngle);
			} else {
				deltaAngle = Math.Max (-rotatingRate * Time.deltaTime, -90 - rotatingAngle);
			}
			rotatingAngle += deltaAngle;

			for (int i = 0; i < 27; i++) {
				int x = i / 9;
				int y = i / 3 % 3;
				int z = i % 3;
				if ((rotatingAxis.x == 0 || x == rotatingAxis.x + 1)
					&& (rotatingAxis.y == 0 || y == rotatingAxis.y + 1) 
					&& (rotatingAxis.z == 0 || z == rotatingAxis.z + 1)) {
					cubelets [x, y, z].transform.RotateAround (Vector3.zero, transform.TransformVector (rotatingAxis), deltaAngle);
				}
			}
		}
	}
	
	/// <summary>
	/// Rotate a side 90 degrees around the specified axis in the specified direction.
	/// </summary>
	/// <param name="side">Axis to rotate around</param>
	/// <param name="clockwise">If true, rotate clockwise, otherwise rotate counter-clockwise</param>
	/// <param name="rate">Rate of rotation, in deg/s</param> 
	public void Rotate (Vector3 axis, bool clockwise, float rate)
	{
		if (!IsRotating ()) {
			rotatingAxis = axis;
			rotatingCW = clockwise;
			rotatingRate = rate;
		}
	}

	public bool IsRotating ()
	{
		return rotatingAxis != Vector3.zero;
	}

	private void FinishRotation ()
	{
		Array.Copy (cubelets, 0, tempCubelets, 0, cubelets.Length);
		for (int i = 0; i < 27; i++) {
			int x = i / 9;
			int y = i / 3 % 3;
			int z = i % 3;
			if ((rotatingAxis.x == 0 || x == rotatingAxis.x + 1)
				&& (rotatingAxis.y == 0 || y == rotatingAxis.y + 1) 
				&& (rotatingAxis.z == 0 || z == rotatingAxis.z + 1)) {
				Vector3 newIndex = Quaternion.AngleAxis (rotatingCW ? 90 : -90, rotatingAxis) * (new Vector3 (x, y, z) - Vector3.one) + Vector3.one;
				tempCubelets [(int)(newIndex.x + 0.5F), (int)(newIndex.y + 0.5F), (int)(newIndex.z + 0.5F)] = cubelets [x, y, z];
			} 
		}
		Array.Copy (tempCubelets, 0, cubelets, 0, cubelets.Length);
		
		rotatingAxis = Vector3.zero;
		rotatingAngle = 0;
		rotatingRate = 0;
	}
}
