using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;


public class RunwayHandler : MonoBehaviour {

    //Communicates between scripts
    //

    public PlayerReacts playerReactScript;
    //Delegate for quick time responses
    delegate IEnumerator QuickTimeEvents();
    QuickTimeEvents quickTimeEvents;
    QuickTimeEvents startQuickEvent;

    public GameObject playerObj;
    public GameObject towerObj;


    public GameObject[] uiSwipe;   //
	public GameObject uiFire;
    public GameObject uiBuff;
    public Transform mainCanvas;

    public float laneLeft;      // -3
    public float laneCenter;    // 0
    public float laneRight;     // 3

    //move speed and the end position of the lane
    public Vector3 endPostion;
    public float moveSpeed;

    //random number of seconds between quick time events
	private float timeBtwnEvents;
	public float timeMin;
	public float timeMax;

    //Timers for events
	public float timerFire;
	public float timerBuff;
	public float timerSwipe;
    public int rqrdTaps;
	public int tapsIncr;

    //the number of times one event may occur
    public int limitFire;
    public int limitBuff;
    public int limitSwipe;
	private int limitTotal;

	//The current number of finished events
    private int nbrFire;
    private int nbrBuff;
    private int nbrSwipe;
	private int nbrTotal;

	public static bool eventRunning = false;

	public GameObject PrefabBullet;

	public GameObject exitButton;
	// Use this for initialization
	void Start () {
		StartCoroutine (BeginShow());
		StartCoroutine (RunShow());

        nbrFire = 0;
        nbrSwipe = 0;
        nbrBuff = 0;

        playerReactScript = playerObj.GetComponent<PlayerReacts>();

        uiBuff.GetComponent<QuickBuff>().desireTaps = rqrdTaps;

		limitTotal = limitBuff + limitSwipe + limitFire;



	}
	
	// Update is called once per frame
	void Update () {
	
	}

    IEnumerator BeginShow()
    {
        while (Vector3.Distance(playerObj.transform.position, endPostion) > 0.05f)
        {
            float step = moveSpeed * Time.deltaTime;
            playerObj.transform.position = Vector3.MoveTowards(playerObj.transform.position, endPostion, step);
			endPostion.x = playerObj.transform.position.x;

            yield return null;
        }
    }

	IEnumerator RunShow ()
	{
		while (Vector3.Distance(playerObj.transform.position, endPostion) > 0.05f)
		{
			timeBtwnEvents = Random.Range(timeMin, timeMax);
			yield return new WaitForSeconds (timeBtwnEvents);
			if (nbrTotal < limitTotal) 
			{
				QuicktimeSwitcher();
	            yield return StartCoroutine(quickTimeEvents());
				eventRunning=true;
				while (eventRunning) //Prevents events from overlapping
				{ 
					yield return new WaitForSeconds(0.1f);
				}
				//print ("Current Bonus Points: " + FinalJudgement.bonusPts);
	        }
			else 
			{
				gameObject.GetComponent<FinalJudgement>().EndGame();
			}
		}
	}


    //Switches between different quick time events
    IEnumerator QuicktimeSwitcher() {
		int rand = Random.Range (0, 3);
		quickTimeEvents = null;

        if (rand == 0)
        {
			if (nbrFire <= limitFire){
				quickTimeEvents = CallQuickFire;
            	//Debug.Log("Switched to quick draw.");
			} else {
				QuicktimeSwitcher ();
			}
        }
        else if (rand == 1)
        {
			if (nbrSwipe <= limitSwipe){
				quickTimeEvents = CallSwipe;
            	//Debug.Log("Switched to quick swipe.");
			} else {
				QuicktimeSwitcher();
			}
        }
        else if (rand == 2)
        {
			if (nbrBuff <= limitBuff) {
				quickTimeEvents = CallBuff;
            	//Debug.Log("Switched to quick tap.");
			} else {
				QuicktimeSwitcher ();
			}
        }
        else
        {
            quickTimeEvents = null;
        }

        //Debug.Log("Random number is " + rand);
		return quickTimeEvents();

	}

    //Determines which quick pattern event to call depending on the lane of the player's tank
    IEnumerator CallSwipe()
    {
        int swipeObj;
        if (playerObj.transform.position.x >= 3)
        {
            swipeObj = Random.Range(0, 1);
        }
        else if (playerObj.transform.position.x <= -3)
        {
            swipeObj = Random.Range(2, 3);
        }
        else
        {
            swipeObj = Random.Range(0, 3);
        }

        //Determines which lane the player will move into based off the random pop up
        switch (swipeObj)
        {
            case 0:
                playerReactScript.direction = laneLeft;
                break;
            case 1:
                playerReactScript.direction = laneLeft;
                break;
            case 2:
                playerReactScript.direction = laneRight;
                break;
            case 3:
                playerReactScript.direction = laneRight;
                break;
        }
		GameObject clone;
		clone = Instantiate (PrefabBullet, GameObject.Find ("Cannon").transform.position, GameObject.Find ("Cannon").transform.rotation) as GameObject;
		clone.GetComponent<JudgeProjectiles> ().FireProjectile (playerObj.transform, timerBuff / 1.3f, ProjectileType.Missle, false);
		SoundEffectsPlayer.PlayAudio (SoundEffects.TurretFire);
        yield return uiSwipe[swipeObj].GetComponent<QuickSwipe>().StartCoroutine("StartQuickSwipeEvent", timerSwipe);

        nbrSwipe++;
		nbrTotal++;

        //Debug.Log("executed to quick swipe");
        yield return null;

    }

	//Calls the quick draw event
    IEnumerator CallQuickFire()
    {
        yield return uiFire.GetComponent<QuickFire>().StartCoroutine("StartTimer", timerFire);

		/*
		if (quickDrawUI.GetComponent<QuickDraw> ().wonLast) 
		{
			GameObject clone;
			clone = Instantiate (PrefabBullet, playerObj.transform.position, playerObj.transform.rotation) as GameObject;
			clone.GetComponent<JudgeProjectiles> ().FireProjectile (GameObject.Find ("Cannon").transform, quickTapsTimer, ProjectileType.Missle, true);
			clone.transform.localScale = new Vector3(1,1,1);
		}
		else print ("Nope didnt win"); */

        nbrFire++;
		nbrTotal++;
        //Debug.Log("executed to quick draw");
        yield return null;
    }

	//Calls the buff shield quick time event
    IEnumerator CallBuff()
	{
		GameObject clone;
		clone = Instantiate (PrefabBullet, GameObject.Find ("Cannon").transform.position, GameObject.Find ("Cannon").transform.rotation) as GameObject;
		clone.GetComponent<JudgeProjectiles> ().FireProjectile (playerObj.transform, timerBuff / 1.3f, ProjectileType.Bomb, true);
		SoundEffectsPlayer.PlayAudio (SoundEffects.TurretFire);
        yield return uiBuff.GetComponent<QuickBuff>().StartCoroutine("StartTimer", timerBuff);

        nbrBuff++;
		nbrTotal++;
		if (uiBuff.GetComponent<QuickBuff> ().wonLast) 
		{
			uiBuff.GetComponent<QuickBuff> ().desireTaps += tapsIncr;
		}
        //Debug.Log("executed to quick taps");
        yield return null;
    }

	public void LeaveRunway () {
		Application.LoadLevel (1);
	}

}
