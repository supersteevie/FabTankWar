using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class QuickDraw : MonoBehaviour
{
	public bool isRunning;
	public bool wonLast  = false;

	public IEnumerator StartTimer (float timer)
	{
		wonLast = false;	
		StartCoroutine (StartEvent (timer));	
		isRunning = true;
		GetComponent<Image> ().enabled = true;
        yield return null;
	}

	IEnumerator StartEvent (float timer)
	{
		float time = 0;
		//trigger event
		while (time <= timer) 
		{
			time += Time.deltaTime;
			if (Input.GetAxis ("Fire1") > 0)
			{
				StopAllCoroutines ();
				isRunning = false;
				wonLast = true;
				GetComponent<Image> ().enabled = false;
				NewProtoGamehandler.eventRunning = false;
				break;
			}
			//yield return new WaitForSeconds(Time.deltaTime);
			yield return null;
		}
		wonLast = false;
		isRunning = false;
		GetComponent<Image> ().enabled = false;
		NewProtoGamehandler.eventRunning = false;
	}
	
}
