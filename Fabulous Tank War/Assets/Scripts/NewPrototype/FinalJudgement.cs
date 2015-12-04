using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;

public class FinalJudgement : MonoBehaviour {

	/*
	//Text for responses
	public string calcMsg;
	public string winMsg; //3 star result
	public string mehMsg; //2 star result
	public string loseMsg; //1 star result
	*/

	//Overall winning conditions
	private int threeStar;
	private int twoStar;
	private int oneStar;

	//Tank's Star Rating
	public static int tnkStar;

	//Judge npc prefabs
	public GameObject[] judges;

	private int avgScrutiny; //Average of all of the Judge's scrutiny
	private int avgTnkScore; //Average of tank's 3 attributes + bonus points
	public static int bonusPts;

	//Master of Ceremonies Text
	//public Text npcText;
	
	// Use this for initialization
	void Start () {
		//npcText = gameObject.GetComponentInChildren<Text> ();
		for (int i = 0; i < judges.Length; i++)
		{
			avgScrutiny += judges[i].GetComponent<JudgeProfile>().scrutiny;
		}
		avgScrutiny /= judges.Length;
		avgTnkScore = (GameInformation.BeautyRating + GameInformation.DurabilityRating + GameInformation.FirePowerRating) / 3;
		threeStar = 3;
		twoStar = 2;
		oneStar = 1;
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	void CalculateScore () 
	{
		avgTnkScore += bonusPts;
		if (avgTnkScore > avgScrutiny) 
		{
			tnkStar = threeStar;
		}
		if (avgTnkScore == avgScrutiny) {
			tnkStar = twoStar;
		} else 
		{
			tnkStar = oneStar;
		}

		SaveInformation.StarRatingInformationStore (TankButtons.selectedTank, tnkStar);
	}

	void ShowResults () 
	{

	}

	public void EndGame () 
	{
		CalculateScore ();
	}
}
