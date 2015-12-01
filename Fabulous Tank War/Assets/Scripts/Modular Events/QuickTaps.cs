using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class QuickTaps : MonoBehaviour
{
	public bool isRunning;
	public int desireTaps { set; get; }
	public int totalTaps = 0;
	public bool wonLast = false;
	
	public IEnumerator StartTimer (float timer)
	{
		wonLast = false;
		totalTaps = 0;
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
			//print (time);
			//print (timer);
			//print (totalTaps);
			//print (desireTaps);
			time += Time.deltaTime;
			if (Input.GetAxis ("Fire1") > 0)
			{
				totalTaps++;
			}
			else if(totalTaps >= desireTaps)
			{
				StopAllCoroutines ();
				isRunning = false;
				GetComponent<Image> ().enabled = false;
				NewProtoGamehandler.eventRunning = false;
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
