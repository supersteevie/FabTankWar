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

    public float laneLeft;      // -3
    public float laneCenter;    // 0
    public float laneRight;     // 3

    public Vector3 endPostion;
    public float moveSpeed;

	// Use this for initialization
	void Start () {


	}
	
	// Update is called once per frame
	void Update () {
	
	}

    IEnumerator BeginShow(GameObject thePlayer, Vector3 target)
    {
        while (Vector3.Distance(thePlayer.transform.position, target) > 0.05f)
        {
            thePlayer.transform.position = Vector3.Lerp(thePlayer.transform.position, target, moveSpeed * Time.deltaTime);

            yield return null;
        }
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
