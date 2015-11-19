using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class QuickDraw : MonoBehaviour
{
	public bool isRunning;

	public void StartTimer (float timer)
	{
		StartCoroutine (StartEvent (timer));
	}

	IEnumerator StartEvent (float timer)
	{
		//trigger event
		isRunning = true;
		yield return new WaitForSeconds (timer);
		isRunning = false;
	}
	
	void Update ()
	{
		if (isRunning)
			if (Input.GetAxis ("Fire1") > 0)
				{
					StopAllCoroutines ();
					isRunning = false;
					print ("Clicked in time");
				}
	}
}
