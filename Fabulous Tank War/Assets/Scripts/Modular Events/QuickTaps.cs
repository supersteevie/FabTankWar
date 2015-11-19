using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class QuickTaps : MonoBehaviour
{
	public bool isRunning;
	public int desireTaps { set; get; }
	public int totalTaps = 0;
	
	public void StartTimer (float timer)
	{
		totalTaps = 0;
		StartCoroutine (StartEvent (timer));
	}
	
	IEnumerator StartEvent (float timer)
	{
		//trigger event
		isRunning = true;
		yield return new WaitForSeconds (timer);
		isRunning = false;
		print (totalTaps  + " out of " + desireTaps);
	}
	
	void Update ()
	{
		if (isRunning) {
			if (Input.GetButtonDown ("Fire1") && totalTaps < desireTaps)
				totalTaps++;
			if (totalTaps >= desireTaps) {
				StopAllCoroutines ();
				isRunning = false;
				print (totalTaps + " out of " + desireTaps);
			}		
		}
	}
}
