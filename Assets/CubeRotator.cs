using System;
using UnityEngine;
using System.Collections;

public class CubeRotator : MonoBehaviour
{
	public enum Side
	{
		Top,
		Bottom,
		Forward,
		Back,
		Left,
		Right
	}

	/// <summary>
	/// Rate of rotation for the animations, in degrees/second
	/// </summary>
	private const int ROTATE_RATE = 360;

	// cubelets[0][0][0] is the cube with the lowest x, y, and z
	private GameObject[,,] cubelets = new GameObject[3, 3, 3];
	private readonly GameObject[,,] tempCubelets = new GameObject[3, 3, 3];
	private Vector3 rotatingAxis = Vector3.zero;
	private float rotatingAngle;
	private bool rotatingCW;

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
			float deltaAngle = 0;
			if (rotatingCW) {
				deltaAngle = Math.Min (ROTATE_RATE * Time.deltaTime, 90 - rotatingAngle);
			} else {
				deltaAngle = Math.Max (-ROTATE_RATE * Time.deltaTime, -90 - rotatingAngle);
			}
			rotatingAngle += deltaAngle;

			for (int i = 0; i < 27; i++) {
				int x = i / 9;
				int y = i / 3 % 3;
				int z = i % 3;
				if ((rotatingAxis.x == 0 || x == rotatingAxis.x + 1)
					&& (rotatingAxis.y == 0 || y == rotatingAxis.y + 1) 
					&& (rotatingAxis.z == 0 || z == rotatingAxis.z + 1)) {
					cubelets [x, y, z].transform.RotateAround (Vector3.zero, rotatingAxis, deltaAngle);
				}
			}
		}
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
	}

	/// <summary>
	/// Rotate the specified side 90 degrees in the specified direction.
	/// </summary>
	/// <param name="side">Side of the cube</param>
	/// <param name="clockwise">If true, rotate clockwise, otherwise rotate counter-clockwise</param>
	public void Rotate (Side side, bool clockwise)
	{
		if (rotatingAxis == Vector3.zero) {
			rotatingCW = clockwise;

			switch (side) {
			case Side.Top:
				rotatingAxis = Vector3.up;
				break;
			case Side.Bottom:
				rotatingAxis = Vector3.down;
				break;

			case Side.Forward:
				rotatingAxis = Vector3.forward;
				break;
			case Side.Back:
				rotatingAxis = Vector3.back;
				break;

			case Side.Left:
				rotatingAxis = Vector3.left;
				break;
			case Side.Right:
				rotatingAxis = Vector3.right;
				break;
			}
		}
	}
}
