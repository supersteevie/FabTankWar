using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class QuickTimePattern : MonoBehaviour {

    //List of positions for mouse to detecr
    public List<Transform> patternList = new List<Transform>();
    //How close you must get to the point to detect
    public float radiusDetection;
    //For list of points
    private Queue<Vector2> currentTemp = new Queue<Vector2>();

    void Start()
    {
        //Adds the list to queue
        foreach (Transform pos in patternList)
            currentTemp.Enqueue(GetComponent<Camera>().WorldToScreenPoint(pos.position));
    }

	void Update ()
    {
        //Stop once all points are hit
        if(currentTemp.Count > 0)
            if(Input.GetAxis("Fire1") > 0)  //Check if the button is pressed down
                if (Vector2.Distance(currentTemp.Peek(), Input.mousePosition) <= radiusDetection)   //See if it within the desired radius
                {
                    currentTemp.Dequeue(); //Remove from queue once it is detected
                }       
	}
}
