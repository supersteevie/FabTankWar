using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;


public class NewProtoGamehandler : MonoBehaviour {

    //Communicates between scripts
    //

    public PlayerReacts playerReactScript;
    //Delegate for quick time responses
    delegate void QuickTimeEvents();
    QuickTimeEvents quickTimeEvents;

    public GameObject playerObj;
    public GameObject towerObj;

	public GameObject quickDrawUI;

    public float laneLeft;      // -3
    public float laneCenter;    // 0
    public float laneRight;     // 3

    public Vector3 endPostion;
    public float moveSpeed;

	private float timeBetweenEvents;
	public float timeMin;
	public float timeMax;

	public float quickDrawTimer;
	public float quickTapsTimer;
	public float quickPatternTimer;

	// Use this for initialization
	void Start () {
		StartCoroutine (BeginShow());
		StartCoroutine (RunShow());

	}
	
	// Update is called once per frame
	void Update () {
	
	}

    IEnumerator BeginShow()
    {
        while (Vector3.Distance(playerObj.transform.position, endPostion) > 0.05f)
        {
            playerObj.transform.position = Vector3.Lerp(playerObj.transform.position, endPostion, moveSpeed * Time.deltaTime);
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
			quickDrawUI.GetComponent<QuickDraw>().StartTimer(quickDrawTimer);
			//quickTimeEvents();
			yield return null;
		}
	}


	/*
	QuickTimeEvents QuicktimeSwitcher() {
		int rand = Random.Range (0, 2);
		quickTimeEvents = null;
		switch (rand) {
		case 0:
			quickTimeEvents = quickDrawUI.GetComponent<QuickDraw>().StartTimer(quickDrawTimer);
			break;
		case 1:
			quickTimeEvents = QuickTaps.StartTimer(quickTapsTimer);
			break;
		case 2:
			quickTimeEvents = QuickTimePattern.StartQuickTimePattern(quickPatternTimer);
			break;
		}
		
		return quickTimeEvents;

	}*/


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
