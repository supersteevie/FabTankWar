using UnityEngine;
using System.Collections;

public class PlayerReacts : MonoBehaviour {

    //x position for the three lanes on the runway: Left = -3, Center = 0, Right = 3

    //Speed that tank moves between lanes
    public float smoothingSpeed = 2;

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
        playerTank = GameObject.Find("PlayerTank");

    }
	
    //Moves tank between lanes and offers bonus points for accuracy
    IEnumerator QuickMove()
    {

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
}
