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
	public Text stats;

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

	public Sprite[] starSpr;


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

	private int beaScore;
	private int firScore;
	private int durScore;

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
		print ("Stars Amount: " + starSpr.Length);

		avgTnkScore = (GameInformation.BeautyRating + GameInformation.DurabilityRating + GameInformation.FirePowerRating) / 3;
		threeStar = 3;
		twoStar = 2;
		oneStar = 1;
	
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	IEnumerator CalculateScore () 
	{
		endgameUI.SetActive (true);
		starsImg.sprite = starSpr[0];
		header.text = calcHdr;
		body.text = calcMsg;

		yield return new WaitForSeconds (3);

		avgTnkScore += bonusPts;
		if (avgTnkScore > avgScrutiny) 
		{
			tnkStar = threeStar;
			header.text = winHdr;
			body.text = winMsg;
			starsImg.sprite = starSpr[threeStar];
		}
		if (avgTnkScore == avgScrutiny) {
			tnkStar = twoStar;
			header.text = winHdr;
			body.text = winMsg;
			starsImg.sprite = starSpr[twoStar];
		} else 
		{
			tnkStar = oneStar;
			header.text = winHdr;
			body.text = winMsg;
			starsImg.sprite = starSpr[oneStar];
		}


		statsText = GameInformation.BeautyRating + "\n\n" + GameInformation.FirePowerRating + "\n\n" + GameInformation.DurabilityRating + "\n\n" + bonusPts;
		stats.text = statsText;

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
