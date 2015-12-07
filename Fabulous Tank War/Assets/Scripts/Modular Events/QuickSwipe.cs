using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class QuickSwipe : MonoBehaviour
{

    //List of positions for mouse to detect
    public List<Transform> patternList = new List<Transform>();    
    //How close you must get to the point to detect
    public float radiusDetection;    
    //For list of points
    private Queue<Transform> currentTemp = new Queue<Transform>();

    public bool isRunning = false;
	public bool wonLast = false;
    public bool tie = false;

	public float bonusTime;

    //Script to move tank if successful
    public PlayerReacts playerReactScript;

    void Start ()
    {
        GameObject player = GameObject.Find("PlayerTank");
        playerReactScript = player.GetComponent<PlayerReacts>();
    }


    public IEnumerator StartQuickSwipeEvent(float timer)
    {
		wonLast = false;
        tie = false;
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
        yield return null;
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
            else //if they finished the shape end the coroutines
            {
				//if the player completes quickly
				if (time <= timer - bonusTime)
				{
                    wonLast = true;
                    FinalJudgement.bonusPts++;
                    //Add more to time window to increase difficulty next round
					bonusTime++;
				} else
                {
                    //A "tie" condition, does not increase difficulty
                    tie = true;
                }
				StopAllCoroutines();
				isRunning = false;
				GetComponent<Image> ().enabled = false;
                playerReactScript.QuickMove();
				NewProtoGamehandler.eventRunning = false;

			}
			//yield return new WaitForSeconds(Time.deltaTime);
			yield return null;
		}
		wonLast = false;
        FinalJudgement.bonusPts--;
        isRunning = false;
		GetComponent<Image> ().enabled = false;
		NewProtoGamehandler.eventRunning = false;
		foreach (Transform pos in patternList)
		{
			currentTemp.Enqueue(pos);
			pos.GetComponent<Image>().enabled = false;
		}
    }
}
