using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class QuickTimePattern : MonoBehaviour
{

    //List of positions for mouse to detect
    public List<Transform> patternList = new List<Transform>();    
    //How close you must get to the point to detect
    public float radiusDetection;    
    //For list of points
    private Queue<Transform> currentTemp = new Queue<Transform>();

    public bool isRunning = false;
	public bool wonLast = false;


    public void StartQuickTimePattern(float timer)
    {
		wonLast = false;
        //Runs and clears the queue
        currentTemp.Clear();
        //Fills the queue
        foreach (Transform pos in patternList)
        {
            currentTemp.Enqueue(pos);
            pos.GetComponent<Image>().enabled = true;
        }
        //Starts the event
        StartCoroutine(StartEvent(timer));
		isRunning = true;
		GetComponent<Image> ().enabled = true;
    }

    IEnumerator StartEvent(float timer)
    {
		float time = 0;
		//trigger event
		while (time <= timer) 
		{
			time += Time.deltaTime;
			if (currentTemp.Count > 0)
			{
				if (Input.GetAxis ("Fire1") > 0)
				{
					if ((Vector2.Distance(Camera.main.GetComponent<Camera>().WorldToScreenPoint(currentTemp.Peek().position), Input.mousePosition)) <= radiusDetection)
					{
						currentTemp.Peek().GetComponent<Image>().enabled = false;
						currentTemp.Dequeue();
					}
				}
			}
			else
			{
				//if they finished the shape end the coroutines
				StopAllCoroutines();
				isRunning = false;
				GetComponent<Image> ().enabled = false;

			}
			yield return new WaitForSeconds(Time.deltaTime);
		}
		wonLast = false;
		isRunning = false;
		GetComponent<Image> ().enabled = false;
		foreach (Transform pos in patternList)
		{
			currentTemp.Enqueue(pos);
			pos.GetComponent<MeshRenderer>().enabled = false;
		}
    }
}
