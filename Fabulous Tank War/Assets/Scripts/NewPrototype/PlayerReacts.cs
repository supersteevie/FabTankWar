using UnityEngine;
using System.Collections;

public class PlayerReacts : MonoBehaviour {

    //x position for the three lanes on the runway: Left = -3, Center = 0, Right = 3

    private int taps;
    public int Taps()
    {
        taps++;
        return taps;
    }

    //Speed that tank moves between lanes
    public float smoothingSpeed = 2;

    delegate IEnumerator QuickTimeDelegate();

    QuickTimeDelegate receiveTouch;

    GameObject playerTank;

    public float direction; //Must be either 3 or -3. 3 if the image points to the right. -3 if the image points to the left.

    private float destinationLane;
    public float DestinationLane
    {
        get
        {
            return destinationLane;
        }
        set
        {
            if (lanePosition >= 3 || lanePosition <= -3)
            {
                destinationLane = 0;
            } else
            {
                destinationLane = direction;
            }
        }
    }

    //Current lane of tank
    private float lanePosition;
    public float LanePosition
    {
        get
        {
            return lanePosition;
        }
        set
        {
            lanePosition = playerTank.transform.position.x;
        }
    }

    // Use this for initialization
    void Start () {
        receiveTouch = null;
        playerTank = GameObject.Find("PlayerTank");

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
    IEnumerator QuickMove()
    {

        //if button = swipeRight move player 1 lane to the right
        //if button = swipeLeft move player 1 lane to the left
        //if player in left lane do not show swipeLeft events
        //if player in right lane do not show swipeRight events

        //if successful response to button then +points and show response

        lanePosition = playerTank.transform.position.x;
        

        yield return StartCoroutine(BarrelRoll(destinationLane));
    }


    //Moves tank in a barrel roll to the target lan position
    IEnumerator BarrelRoll(float target)
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
    public void Quickfire()
    {

    }

    //Players taps rapidly to buff shield of tank when they see an incoming bomb
    IEnumerator BuffsShield(int num, int pulse, int tapTime, bool buffed)
    {
        yield return new WaitForSeconds(tapTime);
        if (num >= pulse)
        {
            buffed = true;
        }
        else
        {
            buffed = false;
        }

        yield return null;
    }
}
