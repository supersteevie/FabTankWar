using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;

public class FinalJudgement : MonoBehaviour {

	//UI for the end game messages

	public GameObject endgameUI;
	public Text header;
	public Text body;
	public Image starsImg;
	public GameObject kissMark;
	public Text stats;
	public GameObject statsHUD;

	private string statsText;

	//Header for responses
	public string calcHdr;
	public string winHdr;
	public string mehHdr;
	public string loseHdr;

	//Text for responses
	public string calcMsg;
	public string winMsg; //3 star result
	public string mehMsg; //2 star result
	public string loseMsg; //1 star result

	public Sprite star3;
	public Sprite star2;
	public Sprite star1;


	//Overall winning conditions
	private int threeStar;
	private int twoStar;
	private int oneStar;

	//Tank's Star Rating
	public static int tnkStar;

	//Judge npc prefabs
	public GameObject[] judges;

	private int avgBiasB;
	private int avgBiasF;
	private int avgBiasD;
	private int avgScrutiny; //Average of all of the Judge's scrutiny
	private int avgTnkScore; //Average of tank's 3 attributes + bonus points

	private int beaScore;
	private int firScore;
	private int durScore;

	public static int bonusPts;
	public static int beaBnsPts;
	public static int firBnsPts;
	public static int durBnsPts;

	//Master of Ceremonies Text
	//public Text npcText;
	
	// Use this for initialization
	void Start () {
		//npcText = gameObject.GetComponentInChildren<Text> ();
		avgScrutiny = 0;
		JudgeScrutiny ();
		bonusPts = 0;


		avgTnkScore = (GameInformation.BeautyRating + GameInformation.DurabilityRating + GameInformation.FirePowerRating) / 3;
		threeStar = 3;
		twoStar = 2;
		oneStar = 1;
	
		print ("Tank Average: " + avgTnkScore);
		print ("Tank Beauty: " + GameInformation.BeautyRating);
		print ("Tank Firepower: " + GameInformation.FirePowerRating);
		print ("Tank Durability: " + GameInformation.DurabilityRating);
	
	}
	
	void JudgeScrutiny () 
	{
		for (int i = 0; i < judges.Length; i++)
		{
			avgScrutiny += judges[i].GetComponent<JudgeProfile>().scrutiny;
			print ("Judge " + i + " has: " + judges[i].GetComponent<JudgeProfile>().scrutiny + 
			       "\n Beauty Bias: " + judges[i].GetComponent<JudgeProfile>().beaBias +
			       "\n Firepower Bias: " + judges[i].GetComponent<JudgeProfile>().firBias + 
			       "\n Durability Bias: " + judges[i].GetComponent<JudgeProfile>().durBias);
			avgBiasB += judges[i].GetComponent<JudgeProfile>().beaBias;
			avgBiasF += judges[i].GetComponent<JudgeProfile>().firBias;
			avgBiasD += judges[i].GetComponent<JudgeProfile>().durBias;
		}
		print (avgScrutiny + " divided by " + judges.Length + " equals...");
		avgScrutiny /= judges.Length;
		print (avgScrutiny);
		avgBiasB /= judges.Length;
		print ("Judges' Beauty Bias: " + avgBiasB);
		avgBiasF /= judges.Length;
		print ("Judges' Firepower Bias: " + avgBiasF);
		avgBiasD /= judges.Length;
		print ("Judges' Durability Bias: " + avgBiasD);
	}


	IEnumerator CalculateScore () 
	{
		endgameUI.SetActive (true);
		header.text = calcHdr;
		body.text = calcMsg;

		yield return new WaitForSeconds (2);

		bonusPts = beaBnsPts + firBnsPts + durBnsPts;
		avgTnkScore += bonusPts;
		avgScrutiny = 53;
		if (avgTnkScore > avgScrutiny) 
		{
			tnkStar = 3;
			header.text = winHdr;
			body.text = winMsg;
			starsImg.sprite = star3;
			kissMark.SetActive(true);
		}
		else if (avgTnkScore > 49) {
			tnkStar = 2;
			header.text = mehHdr;
			body.text = mehMsg;
			starsImg.sprite = star2;
		} else 
		{
			tnkStar = 1;
			header.text = loseHdr;
			body.text = loseMsg;
			starsImg.sprite = star1;
		}


		statsText = GameInformation.BeautyRating + "\n\n" + GameInformation.FirePowerRating + "\n\n" + GameInformation.DurabilityRating + "\n\n" + bonusPts;
		stats.text = statsText;
		statsHUD.SetActive (true);

		SaveInformation.StarRatingInformationStore (TankButtons.selectedTank, tnkStar);

		yield return new WaitForSeconds (1);

		gameObject.GetComponent<RunwayHandler> ().exitButton.SetActive (true);

		yield return null;
	}

	void ShowResults () 
	{

	}

	public void EndGame () 
	{
		gameObject.GetComponent<RunwayHandler> ().StopAllCoroutines ();
		StartCoroutine(CalculateScore());
	}
}
