using System;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
	public enum Mode
	{
		off,
		ready,
		running}
	;

	private Mode mode;
	private float time;

	void Update ()
	{
		if (mode == Mode.running) {
			time += Time.deltaTime;
			UpdateText ();
		}
	}

	public void ReadyTimer ()
	{
		if (mode != Mode.ready) {
			mode = Mode.ready;
			time = 0;
			UpdateText ();
		}
	}

	public void StartTimer ()
	{
		if (mode == Mode.ready) {
			mode = Mode.running;
		}
	}

	public void StopTimer ()
	{
		if (mode == Mode.running) {
			mode = Mode.off;
		}
	}

	private void UpdateText ()
	{
		TimeSpan timeSpan = TimeSpan.FromSeconds (time);
		GetComponent<Text> ().text = string.Format ("{0:D2}:{1:D2}.{2:D2}", timeSpan.Minutes, timeSpan.Seconds, timeSpan.Milliseconds);
	}
}
