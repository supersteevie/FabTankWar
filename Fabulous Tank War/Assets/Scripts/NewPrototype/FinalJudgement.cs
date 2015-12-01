using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FinalJudgement : MonoBehaviour {

	//Text for responses
	public string calcMsg;
	public string winMsg; //3 star result
	public string mehMsg; //2 star result
	public string loseMsg; //1 star result

	//Overall winning conditions
	public int threeStar;
	public int twoStar;
	public int oneStar;

	//Judge npc prefabs
	public GameObject[] judges;
	
	private int[] judgeScores;

	//Master of Ceremonies Text
	public Text npcText;

	// Use this for initialization
	void Start () {
		npcText = gameObject.GetComponentInChildren<Text> ();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void CalculateScore () {

	}

	void ShowResults () {

	}

	public void Win () {
		gameObject.GetComponent<Image> ().enabled = true;
		gameObject.GetComponentInChildren<Image> ().enabled = true;
		npcText.text = winMsg;
		npcText.enabled = true;
	}
}
