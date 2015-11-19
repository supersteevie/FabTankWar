using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class QuickTimeResponse : MonoBehaviour {

    private List<Vector2> swirlPoints = new List<Vector2>();    //List of points
    private Vector2 swirlStart;                                 //Beginning of touch
    private float startTime;                                    //Start time when object is set to active

    public float swipeTime;                                     //Time alloted for player to create circle
    public float requiredRadius;                                //Required size of circle
    public bool circleCompleted;                                //Bool if the circle was completed
    public bool hasStarted = false;                             //If script is running
    public bool isFinished = false;                             //Is the script finished?

    public GameObject plyrTank;
    
    public void Start ()
    {
        plyrTank = GameObject.Find("Player Tank");
        circleCompleted = false;

    } 

    //Method called to start the quicktime event	
    public void StartCircleQuickTime()
    {
        StartCoroutine( DoCircleQuicktime(circleCompleted, requiredRadius, swirlPoints));
        StopCircleQuickTime();
    }

    //Method called to stop circle event
    public void StopCircleQuickTime()
    {
        StopAllCoroutines();
        gameObject.SetActive(false);
        isFinished = true;
    }

    public void WhenActive()
    {
        StartCoroutine(StartCountdown(swipeTime));
        gameObject.GetComponent<Image>().enabled = true;
        gameObject.GetComponent<Button>().enabled = true;
        hasStarted = true;

    }
    

    IEnumerator DoCircleQuicktime(bool completed, float targetRadius, List<Vector2> swirlPoints)
    {
        swirlPoints = new List<Vector2>();
        if (Input.touchCount > 0)
        {
            var swirl = Input.GetTouch(0);

            while (swirl.phase == TouchPhase.Moved)
            {
                swirlPoints.Add(swirl.position);
            }

            if (swirl.phase == TouchPhase.Ended)
            {
                //keep sure list was populated
                if (swirlPoints.Count != 0)
                {
                    // Starting values for cetner and number of points
                    Vector2 center = Vector2.zero;
                    int count = 0;
                    //Foreach pos in the list of points add to the average
                    foreach (Vector2 pos in swirlPoints)
                    {
                        center += pos;
                        count++;
                    }
                    //Find the average point to find middle
                    Vector2 centerPoint;
                    centerPoint = center / count;

                    //Finding radius starting value
                    float totalDistance = 0;
                    //Find distance from center to each point
                    foreach (Vector2 pos in swirlPoints)
                    {
                        totalDistance += Vector2.Distance(pos, centerPoint);
                    }
                    //Find the average radius
                    float averageRadius;
                    averageRadius = totalDistance / count;
                    //clear the list
                    swirlPoints.Clear();
                    //Check if circle was complete
                    if (averageRadius > targetRadius)
                    {
                        completed = true;
                        yield return null;
                    }
                }
            }
        }
    }

    IEnumerator StartCountdown(float time)
    {
        while (startTime < time)
        {
            startTime += Time.deltaTime;

            yield return null;
        }

        StopCircleQuickTime();
        yield return null;
    }
}
