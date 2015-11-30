using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;


public class NewProtoGamehandler : MonoBehaviour {

    //Communicates between scripts
    //

    public PlayerReacts playerReactScript;
    //Delegate for quick time responses
    delegate IEnumerator QuickTimeEvents();
    QuickTimeEvents quickTimeEvents;
    QuickTimeEvents startQuickEvent;

    public GameObject playerObj;
    public GameObject towerObj;


    public GameObject[] quickSwipeUI;
	public GameObject quickDrawUI;
    public GameObject quickTapUI;
    public Transform mainCanvas;

    public float laneLeft;      // -3
    public float laneCenter;    // 0
    public float laneRight;     // 3

    //move speed and the end position of the lane
    public Vector3 endPostion;
    public float moveSpeed;

    //random number of seconds between quick time events
	private float timeBetweenEvents;
	public float timeMin;
	public float timeMax;

    //Timers for events
	public float quickDrawTimer;
	public float quickTapsTimer;
	public float quickPatternTimer;
    public int requiredTaps;

    //the number of times one event may occur
    public int limitQuickDraw;
    public int limitQuickTaps;
    public int limitQuickPattern;

    private int nbrQuickDraw;
    private int nbrQuickTaps;
    private int nbrQuickPattern;

	// Use this for initialization
	void Start () {
		StartCoroutine (BeginShow());
		StartCoroutine (RunShow());

        nbrQuickDraw = 0;
        nbrQuickPattern = 0;
        nbrQuickTaps = 0;

        playerReactScript = playerObj.GetComponent<PlayerReacts>();

        quickTapUI.GetComponent<QuickTaps>().desireTaps = requiredTaps;

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
            //playerObj.transform.position = Vector3.Lerp(playerObj.transform.position, endPostion, moveSpeed * Time.deltaTime);
			endPostion.x = playerObj.transform.position.x;

            yield return null;
        }
    }

	IEnumerator RunShow ()
	{
		while (Vector3.Distance(playerObj.transform.position, endPostion) > 0.05f)
		{
			timeBetweenEvents = Random.Range(timeMin, timeMax);
			yield return new WaitForSeconds (timeBetweenEvents);
			//quickDrawUI.GetComponent<QuickDraw>().StartTimer(quickDrawTimer);
			QuicktimeSwitcher();
            if (quickTimeEvents != null)
            {
                yield return StartCoroutine(quickTimeEvents());
                yield return new WaitForSeconds(timeMax);
            }
            yield return null;
		}
	}


    //Switches between different quick time events
    IEnumerator QuicktimeSwitcher() {
		int rand = Random.Range (0, 3);
		quickTimeEvents = null;

        if (rand == 0 && nbrQuickDraw <= limitQuickDraw)
        {
            quickTimeEvents = CallQuickdraw;
            Debug.Log("Switched to quick draw.");
        }
        else if (rand == 1 && nbrQuickPattern <= limitQuickPattern)
        {
            quickTimeEvents = CallSwipe;
            Debug.Log("Switched to quick swipe.");
        }
        else if (rand == 2 && nbrQuickTaps <= limitQuickTaps)
        {
            quickTimeEvents = CallBuff;
            Debug.Log("Switched to quick tap.");
        }
        else
        {
            quickTimeEvents = null;
        }

        /*
        switch (rand) {
		case 0:
                if (nbrQuickDraw < limitQuickDraw)
                {
                    quickTimeEvents = CallQuickdraw;
                    Debug.Log("Switched to quick draw.");
                }
                break;
		case 1:
                if (nbrQuickPattern < limitQuickPattern)
                {
                    quickTimeEvents = CallSwipe;
                    Debug.Log("Switched to quick swipe.");
                }
                break;
		case 2:
                if (nbrQuickTaps < limitQuickTaps)
                {
                    quickTimeEvents = CallBuff;
                    Debug.Log("Switched to quick tap.");
                }
                break;
		}*/

        Debug.Log("Random number is " + rand);
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

        //GameObject quickSwipeClone = Instantiate(quickSwipeUI[swipeObj]);
        //quickSwipeClone.transform.SetParent(mainCanvas);

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
        yield return quickSwipeUI[swipeObj].GetComponent<QuickTimePattern>().StartCoroutine("StartQuickTimePattern", quickPatternTimer);

        nbrQuickPattern++;
        //Destroy(quickSwipeClone);

        Debug.Log("executed to quick swipe");
        yield return null;

    }

    IEnumerator CallQuickdraw()
    {
       //GameObject quickDrawClone = Instantiate(quickDrawUI);
        //quickDrawClone.transform.SetParent(mainCanvas);
        yield return quickDrawUI.GetComponent<QuickDraw>().StartCoroutine("StartTimer", quickDrawTimer);

        nbrQuickDraw++;
        //Destroy(quickDrawClone);
        Debug.Log("executed to quick draw");
        yield return null;
    }

    IEnumerator CallBuff()
    {
        //GameObject quickTapClone = Instantiate(quickTapUI);
        //quickTapClone.transform.SetParent(mainCanvas);
        yield return quickTapUI.GetComponent<QuickTaps>().StartCoroutine("StartTimer", quickTapsTimer);

        nbrQuickTaps++;
        //Destroy(quickTapClone);
        quickTapUI.GetComponent<QuickTaps>().desireTaps += (int) quickTapsTimer;
        Debug.Log("executed to quick taps");
        yield return null;
    }


    /*
    void QuicktimeSwitcher(int num)
    {
        switch (num)
        {
            case 0:
                quickTimeEvents() = playerReactScript.QuickMove();
                break;
            case 1:
                quickTimeEvents() = playerReactScript.Quickfire();
                break;
            case 2:
                quickTimeEvents() = playerReactScript.ShieldBuff();
                break;
            default:
                break;
        }
    }
    */



}
