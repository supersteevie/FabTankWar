using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class QuickTimeCircle : MonoBehaviour {

    private List<Vector2> mousePoints = new List<Vector2>();    //List of points
    private bool hasStarted = false;                            //If script is running
    private Vector2 centerPoint;                                //Center of circle
    private float averageRadius;                                //Radius of circle

    public float requiredRadius;                                //Required size of circle
    public bool circleCompleted;                                //Bool if the circle was completed
    
    //Method called to start the quicktime event	
    public void StartCircleQuickTime(float time)
    {
		Invoke("StopCircleQuickTime", time);
        hasStarted = true;
    }

    //Method called to stop it early
    public void StopCircleQuickTime()
    {
        hasStarted = false;
		gameObject.GetComponent<Image> ().enabled = true;
    }

	public void Start () {
		gameObject.GetComponent<Image> ().enabled = false;
	}

	void Update ()
    {
        //Check if started
        if (hasStarted)
        {
            //Check if input is held down
            if (Input.GetAxis("Fire1") > 0)
                mousePoints.Add(Input.mousePosition);
            //Check if the input was released
            else if (Input.GetAxis("Fire1") == 0)
                {
                //keep sure list was populated
                    if (mousePoints.Count != 0)
                    {
                    // Starting values for cetner and number of points
                        Vector2 center = Vector2.zero;
                        int count = 0;
                        //Foreach pos in the list of points add to the average
                        foreach (Vector2 pos in mousePoints)
                        {
                            center += pos;
                            count++;
                        }
                        //Find the average point to find middle
                        centerPoint = center / count;

                        //Finding radius starting value
                        float totalDistance = 0;
                        //Find distance from center to each point
                        foreach (Vector2 pos in mousePoints)
                        {
                            totalDistance += Vector2.Distance(pos, centerPoint);
                        }
                        //Find the average radius
                        averageRadius = totalDistance / count;
                        //clear the list
                        mousePoints.Clear();
                        //Check if circle was complete
                        if (averageRadius > requiredRadius)
                        {
                            circleCompleted = true;
                            StopCircleQuickTime();
							gameObject.GetComponent<Image>().enabled=false;
                        }
                }
            }
        }
	
	}

    IEnumerator DoCircleQuicktime ()
    {
        //Check if input is held down
        if (Input.GetAxis("Fire1") > 0)
            mousePoints.Add(Input.mousePosition);

        while (Input.GetAxis("Fire1") > 0) {
            mousePoints.Add(Input.mousePosition);
            yield return null;
        }

        //Check if the input was released
        if (Input.GetAxis("Fire1") == 0)
        {
            //keep sure list was populated
            if (mousePoints.Count != 0)
            {
                // Starting values for cetner and number of points
                Vector2 center = Vector2.zero;
                int count = 0;
                //Foreach pos in the list of points add to the average
                foreach (Vector2 pos in mousePoints)
                {
                    center += pos;
                    count++;
                }
                //Find the average point to find middle
                centerPoint = center / count;

                //Finding radius starting value
                float totalDistance = 0;
                //Find distance from center to each point
                foreach (Vector2 pos in mousePoints)
                {
                    totalDistance += Vector2.Distance(pos, centerPoint);
                }
                //Find the average radius
                averageRadius = totalDistance / count;
                //clear the list
                mousePoints.Clear();
                //Check if circle was complete
                if (averageRadius > requiredRadius)
                {
                    circleCompleted = true;
                    StopCircleQuickTime();
                    gameObject.GetComponent<Image>().enabled = false;
                }
            }
        }

        yield return null;
    }
}
