using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class QuickBuff : MonoBehaviour
{
	public bool isRunning;
	public int desireTaps { set; get; }
	public int totalTaps = 0;
	public bool wonLast = false;
    public bool tie = false;
	
	public IEnumerator StartTimer (float timer)
	{
		wonLast = false;
        tie = false;
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
			yield return null;
		}
		if (totalTaps > desireTaps) {
			//Win
			FinalJudgement.bonusPts++;
			wonLast = true;
		} else if (totalTaps < desireTaps) {
			//Lost
			FinalJudgement.bonusPts--;
			wonLast = false;
		} else {
			//Tie
			tie = true;
		}
		isRunning = false;
		GetComponent<Image> ().enabled = false;
		NewProtoGamehandler.eventRunning = false;
	}
}
