using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class QuickTimePattern : MonoBehaviour
{

    //List of positions for mouse to detect
    public List<Transform> patternList = new List<Transform>();
    
    //How close you must get to the point to detect
    public float radiusDetection;
    
    //For list of points
    private Queue<Transform> currentTemp = new Queue<Transform>();

    public bool isRunning = false;

    public void StartQuickTimePattern(float timer)
    {
        //Runs and clears the queue
        currentTemp.Clear();
        //Fills the queue
        foreach (Transform pos in patternList)
        {
            currentTemp.Enqueue(pos);
            pos.GetComponent<MeshRenderer>().enabled = true;
        }
        //Starts the event
        StartCoroutine(StartEvent(timer));
    }

    IEnumerator StartEvent(float timer)
    {
        //trigger event
        isRunning = true;
        yield return new WaitForSeconds(timer);
        isRunning = false;
    }

    void Update()
    {
        //detect positions and clear the queue
        if (isRunning)
            if (currentTemp.Count > 0)
            {
                if (Input.GetAxis("Fire1") > 0)
                {
                    if ((Vector2.Distance(Camera.main.GetComponent<Camera>().WorldToScreenPoint(currentTemp.Peek().position), Input.mousePosition)) <= radiusDetection)
                    {
                        currentTemp.Peek().GetComponent<MeshRenderer>().enabled = false;
                        currentTemp.Dequeue();
                    }
                }
            }
            else
            {
                //if they finished the shape end the coroutines
                StopAllCoroutines();
                isRunning = false;
            }
    }
}
