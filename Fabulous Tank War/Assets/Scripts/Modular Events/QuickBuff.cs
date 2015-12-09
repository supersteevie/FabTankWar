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
	public GameObject player;
	public GameObject splatter;
	
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
		GameObject clone;
		clone = Instantiate (Resources.Load ("Shield"), player.transform.position, player.transform.rotation) as GameObject;
		clone.transform.parent = player.transform;
		Destroy (clone, timer + 1f);		
		Color alpha = clone.GetComponent<MeshRenderer>().material.color;

		//trigger event
		while (time <= timer) 
		{
			float a = (float)totalTaps;
			float b = (float)desireTaps;
			alpha.a = a/b /5f ;
			clone.GetComponent<MeshRenderer>().material.color = alpha;
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
			GameObject splat;
			splatter.GetComponent<SplatEffectFade>().DoSplatter();
			splatter.GetComponent<AudioSource>().Play();
			wonLast = false;
		} else {
			//Tie
			tie = true;
		}
		isRunning = false;
		GetComponent<Image> ().enabled = false;
		RunwayHandler.eventRunning = false;
	}
}
