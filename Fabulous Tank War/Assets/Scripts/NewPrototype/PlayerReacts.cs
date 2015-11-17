using UnityEngine;
using System.Collections;

public class PlayerReacts : MonoBehaviour {

    //if button = swipeRight move player 1 lane to the right
    //if button = swipeLeft move player 1 lane to the left
    //if player in left lane do not show swipeLeft events
    //if player in right lane do not show swipeRight events
    
    //if successful response to button then +points and show response
    

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    //RESPONSES
    //
    //-Beauty
    //--> Style animations
    //--> Moves Tank
    //--> Success: Bonus points to beauty
    //
    //-Firepower
    //--> Quickdraw event
    //--> Fires at enemies
    //--> Success: Bonus points to firepower
    //
    //-Durability
    //--> Tap fast
    //--> More taps in allotted time = +bonus points to durability
}
