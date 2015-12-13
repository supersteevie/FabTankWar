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


	//QUICK SWIPE
    public GameObject[] uiSwipeL;   	//Left swipes from easy to impossible
	public GameObject[] uiSwipeR;		//Right swipes from easy to impossible
	private GameObject[] allSwipes;		//Adds swipes when used for center lane
	public float timerSwipe; 			//3 seconds
	public float swpIncr; 				//.5 seconds
	public static float swpBonus;
	static public bool swipeWin;		//True if last event was a win
	static public bool swipeTie;		//True if last event was a tie
	private int swipeMin;				//Min value for array
	private int swipeMax;				//Max value for array
	public int limitSwipe;				//6 Events


	//QUICK FIRE EVENT
	public GameObject uiFire;
	public float timerFire; 	//3 seconds
	public float firBonus;		//2 seconds
	public float firIncr;		//.75 seconds
	public int limitFire;		//5 Events


	//QUICK BUFF
    public GameObject uiBuff;
	public float timerBuff; 	//3 seconds
	public int rqrdTaps; 		//Taps needed to pass
	public int bonusTaps;		//Bonus taps for win condition
	public int tapsIncr; 		//Currently 3
	public int limitBuff;		//4 Events

	//CHARACTER LOCATION
    public float laneLeft;      // -3
    public float laneCenter;    // 0
    public float laneRight;     // 3

    //CHARACTER MOVE SPEED
    public Vector3 endPostion;
    public float moveSpeed;

    //random number of seconds between quick time events
	private float timeBtwnEvents;
	public float timeMin;
	public float timeMax;


    //Total event limits.
	private int limitTotal;

	//The current number of finished events
	private int nbrTotal;

	public static bool eventRunning = false;

	public GameObject PrefabBullet;

	public GameObject exitButton;
	// Use this for initialization
	void Start () {
		StartCoroutine (BeginShow());
		StartCoroutine (RunShow());

        playerReactScript = playerObj.GetComponent<PlayerReacts>();

        uiBuff.GetComponent<QuickBuff>().desireTaps = rqrdTaps;
		uiBuff.GetComponent<QuickBuff> ().bonusTaps = bonusTaps;

		limitTotal = limitBuff + limitSwipe + limitFire;

		swipeMin = 0;
		swipeMax = 1;

		quickTimeEvents = CallBuff;

		allSwipes = new GameObject[4];

		swpBonus = swpIncr;
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
				print ("Current Bonus Points: " + FinalJudgement.bonusPts);
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
		//quickTimeEvents = null;

        if (rand == 0)
        {
			if (limitFire > 0 && quickTimeEvents != CallQuickFire)
			{
				quickTimeEvents = CallQuickFire;
            	//Debug.Log("Switched to quick draw.");
			}
			else if (limitFire > 0 && nbrTotal > 9)
			{
				quickTimeEvents = CallQuickFire;
			}
			else 
			{
				QuicktimeSwitcher ();
			}
        }
        else if (rand == 1)
        {
			if (limitSwipe > 0)
			{
				quickTimeEvents = CallSwipe;
            	//Debug.Log("Switched to quick swipe.");
			}
			else 
			{
				QuicktimeSwitcher();
			}
        }
        else if (rand == 2)
        {
			if (limitBuff > 0 && quickTimeEvents != CallBuff) 
			{
				quickTimeEvents = CallBuff;
            	//Debug.Log("Switched to quick tap.");
			}
			else if (limitBuff > 0 && nbrTotal > 9)
			{
				quickTimeEvents = CallBuff;
			}
			else 
			{
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

        if (playerObj.transform.position.x >= 3) 		//Player is in the right lane, call only swipe left events
        {
			for (int i= 0; i < 2; i++) 
			{
				allSwipes[i] = uiSwipeL[swipeMin + i];
			}
			swipeObj = Random.Range(0, 2);
			CalcMovement(1);
        }
		else if (playerObj.transform.position.x <= -3) //Player is in the left lane, call only swipe right events
        {
			for (int i= 0; i < 2; i++) 
			{
				allSwipes[i] = uiSwipeR[swipeMin + i];
			}
			swipeObj = Random.Range(0, 2);
			CalcMovement(2);
        }
		else 											//Player is in the center lane, call all swipe events
        {
			for (int i = 0; i <2; i++)
			{
				allSwipes[i] = uiSwipeL[swipeMin + i];
				allSwipes[i+2] = uiSwipeR[swipeMin + i];
			}
			swipeObj = Random.Range(0, allSwipes.Length);
			CalcMovement(swipeObj);
        }
		
		GameObject clone;
		clone = Instantiate (PrefabBullet, GameObject.Find ("Cannon").transform.position, GameObject.Find ("Cannon").transform.rotation) as GameObject;
		clone.GetComponent<JudgeProjectiles> ().FireProjectile (playerObj.transform, timerBuff / 1.3f, ProjectileType.Missle, false);
		SoundEffectsPlayer.PlayAudio (SoundEffects.TurretFire);
        yield return allSwipes[swipeObj].GetComponent<QuickSwipe>().StartCoroutine("StartQuickSwipeEvent", timerSwipe);

		//If player won last swipe event 
		if (swipeWin) 
		{
			//increase the range for higher difficulty events
			swipeMin += swipeMin < uiSwipeL.Length - 2 ? 1 : 0;
			swipeMax += swipeMax < uiSwipeL.Length - 1 ? 1 : 0;

			//decrease time window for the win condition
			swpBonus += swpIncr;
		}

		//If pplayer lost last swipe event
		if (!swipeWin && !swipeTie) 
		{
			//decrease the range for lower difficulty events
			swipeMax -= swipeMin != 0 ? 1 : 0;
			swipeMin -= swipeMin >= 1 ? 1 : 0;

			//increase time window for the win condition
			swpBonus -= swpBonus <.5 ? swpIncr : 0;
		}


        limitSwipe--;
		nbrTotal++;

        //Debug.Log("executed to quick swipe");
        yield return null;

    }

	//Calls the quick draw event
    IEnumerator CallQuickFire()
    {
		yield return new WaitForSeconds (firIncr);
        yield return uiFire.GetComponent<QuickFire>().StartCoroutine("StartTimer", timerFire);

		//PLAYER WINS
		if (uiFire.GetComponent<QuickFire>().wonLast) 
		{
			//decreases allotted time for bonus points and pass time
			timerFire *= firIncr;
			firBonus *= firIncr;
		}
		//PLAYER LOSES
		else if (!uiFire.GetComponent<QuickFire>().wonLast && !!uiFire.GetComponent<QuickFire>().tie)
		{
			//increases allotted time for bonus points and pass time
			timerFire /= firIncr;
			firBonus /= firIncr;
		}

        limitFire--;
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

		limitBuff--;
		nbrTotal++;
        yield return null;
    }

	public void LeaveRunway () {
		Application.LoadLevel (1);
	}

	public void CalcMovement (int num)
	{
		//Determines which lane the player will move into based off the random pop up
		switch (num)
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
		default:
			playerReactScript.direction = 0;
			break;
		}
	}
}
