using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class QuickDraw : MonoBehaviour
{
	public bool isRunning;
	public bool wonLast  = false;

	public GameObject playerObj;
	public GameObject PrefabBullet;

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
				//Player wins
				StopAllCoroutines ();
				isRunning = false;
				wonLast = true;
				FinalJudgement.bonusPts++;
				GetComponent<Image> ().enabled = false;
				NewProtoGamehandler.eventRunning = false;
				FireMissle();
				break;
			}
			//yield return new WaitForSeconds(Time.deltaTime);
			yield return null;
		}

		FinalJudgement.bonusPts--;
		wonLast = false;
		isRunning = false;
		GetComponent<Image> ().enabled = false;
		NewProtoGamehandler.eventRunning = false;
	}

	void FireMissle() 
	{
		GameObject clone;
		clone = Instantiate (PrefabBullet, playerObj.transform.position + (Vector3.up * 1.5f), playerObj.transform.rotation) as GameObject;
		clone.GetComponent<JudgeProjectiles> ().FireProjectile (GameObject.Find ("Cannon").transform, GameObject.Find ("GameHandler").GetComponent<NewProtoGamehandler>().quickTapsTimer, ProjectileType.Missle, true);
		clone.transform.localScale = new Vector3(1,1,1);
	}
}
