using UnityEngine;
using System.Collections;

public class PlayerReacts : MonoBehaviour {

    //x position for the three lanes on the runway: Left = -3, Center = 0, Right = 3

    //Delegate for quick time responses
    delegate void QuickTimeEvents();
    QuickTimeEvents quickTimeEvents;

    //Speed that tank moves between lanes
    public float smoothingSpeed = 2;

	// Use this for initialization
	void Start () {
	
	}
	

    //Method to run quicktime events
    IEnumerator TankResponds()
    {

        yield return null;
    }

    //RESPONSES
    //
    //-Beauty (QuickMove)
    //--> Style animations
    //--> Moves Tank
    //--> Success: Bonus points to beauty
    //
    //-Firepower (QuickFire)
    //--> Must tap before opponent
    //--> Fires at enemies
    //--> Success: Bonus points to firepower
    //
    //-Durability (BuffShield)
    //--> Tap repeatedly
    //--> More taps in allotted time = +bonus points to durability

    //Moves tank between lanes and offers bonus points for accuracy
    void QuickMove(float locLane, GameObject playerTank, bool success)
    {
        //if button = swipeRight move player 1 lane to the right
        //if button = swipeLeft move player 1 lane to the left
        //if player in left lane do not show swipeLeft events
        //if player in right lane do not show swipeRight events

        //if successful response to button then +points and show response

        StartCoroutine(BarrelRoll(locLane, playerTank));
    }

    IEnumerator BarrelRoll(float target, GameObject playerTank)
    {
        Vector3 newLoc;
        newLoc = new Vector3(target, playerTank.transform.position.y, playerTank.transform.position.z);
        while (playerTank.transform.position.x != target)
        {
            playerTank.transform.position = Vector3.Lerp(playerTank.transform.position, newLoc, smoothingSpeed * Time.deltaTime);

            yield return null;
        }
    }

    //Tank fires in response to image shown
    void Quickfire()
    {

    }

    //Players taps rapidly to buff shield of tank when they see an incoming bomb
    void BuffShield()
    {

    }
}
