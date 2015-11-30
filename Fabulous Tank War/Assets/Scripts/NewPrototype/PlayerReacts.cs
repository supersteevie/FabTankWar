using UnityEngine;
using System.Collections;

public class PlayerReacts : MonoBehaviour {

    //x position for the three lanes on the runway: Left = -3, Center = 0, Right = 3

    //Speed that tank moves between lanes
    public float moveSpeed = 2;
    //private Vector3 velocity = Vector3.zero;

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
            destinationLane = value;
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
            lanePosition = value;
        }
    }

    // Use this for initialization
    void Start () {

    }
	
    //Moves tank between lanes and offers bonus points for accuracy
    public void QuickMove()
    {

        lanePosition = transform.position.x;
        if (lanePosition >= 3 || lanePosition <= -3)
        {
            destinationLane = 0;
        }
        else
        {
            destinationLane = direction;
            //Debug.Log("Destination lane is set to " + direction);
        }


        StartCoroutine(BarrelRoll(DestinationLane));
        //Debug.Log("Starting quick move.");
    }


    //Moves tank in a barrel roll to the target lan position
    IEnumerator BarrelRoll(float target)
    {
        //Debug.Log("Starting barrel roll.");
        Vector3 newLoc;
        newLoc = new Vector3(target, transform.position.y, transform.position.z);
        while (transform.position.x != target)
        {
            float step = moveSpeed * Time.deltaTime;
            //transform.position = Vector3.Lerp(transform.position, newLoc, smoothingSpeed * Time.deltaTime);

            transform.position = Vector3.MoveTowards(transform.position, newLoc, step);

            //transform.position = Vector3.SmoothDamp(transform.position, newLoc, ref velocity, 0.5f);

            yield return null;
        }
    }
}
