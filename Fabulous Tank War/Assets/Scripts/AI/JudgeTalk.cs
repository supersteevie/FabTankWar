using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class JudgeTalk : MonoBehaviour {

    public GameObject player;

    public string[] responses;
    /* 
    0 = Negative response to quickTimeResponse
    1 = Positive response to quickTimeResponse
    2 = Negative response to cannonfire
    3 = Positive response to cannonfire
    4 = Negative response to aftermath
    5 = Positive response to aftermath
    6 = Reporting score
    7 = Condolences
    8 = Congratulations
    */

    public Sprite[] emojis;
    /* 
    0 = Negative response to quickTimeResponse
    1 = Positive response to quickTimeResponse
    2 = Negative response to cannonfire
    3 = Positive response to cannonfire
    4 = Negative response to aftermath
    5 = Positive response to aftermath
    6 = Reporting score
    7 = Condolences
    8 = Congratulations
    */

    public int scrutiny;
    public int bias;

    public bool didSpin;

    private int score;
    public int result;

    public delegate void JudgesTalk(int num);
    public JudgesTalk judgesTalk;

	public Image mainEmoji;
    public Text speechBubble;

    // Use this for initialization
    void Start () {
        mainEmoji = gameObject.GetComponent<Image>();
        speechBubble = gameObject.GetComponentInChildren<Text>();
		gameObject.GetComponent<Image> ().enabled = false;
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    IEnumerator JudgeEvaluate (int stage)
    {
		gameObject.GetComponent<Image> ().enabled = true;
        switch (stage)
        {
			case 1:
				score = player.GetComponent<BeginShowdown>().tankPlayer.TnkBeauty;
                didSpin = GameObject.Find("Response Swipe Button").GetComponent<QuickTimeCircle>().circleCompleted;
                break;
            case 3:
				score = player.GetComponent<BeginShowdown>().tankPlayer.TnkPower;
                break;
            case 5:
				score = player.GetComponent<BeginShowdown>().tankPlayer.TnkDurability;
                break;
            case 7:
                result = result / 3;
                break;
        }

        EvaluateSpin(stage);

        yield return new WaitForSeconds(60f);
    }

    void EvaluateSpin (int i)
    {
        score = didSpin ? score + bias : score;
        i = score > scrutiny ? i : i-1;
        mainEmoji.sprite = emojis[i];
        speechBubble.text = responses[i];
        result += score;
        didSpin = false;
    }

    public void ClickContinue ()
    {
		gameObject.GetComponent<Image> ().enabled = false;
        StopCoroutine("JudgeEvaluate");
    }

}
