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

    public Image[] emojis;
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

    private Image mainEmoji;
    private Text speechBubble;

    // Use this for initialization
    void Start () {
        mainEmoji = gameObject.GetComponent<Image>();
        speechBubble = gameObject.GetComponentInChildren<Text>();
        gameObject.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    IEnumerator JudgeEvaluate (int stage)
    {
        switch (stage)
        {
            case 0:
                score = player.GetComponent<TankAttributes>().TnkBeauty;
                break;
            case 2:
                score = player.GetComponent<TankAttributes>().TnkPower;
                break;
            case 4:
                score = player.GetComponent<TankAttributes>().TnkDurability;
                break;
            case 6:
                result = result / 3;
                break;
        }

        EvaluateSpin(stage);

        yield return new WaitForSeconds(60f);
    }

    void EvaluateSpin (int i)
    {
        gameObject.SetActive(true);
        score = didSpin ? score + bias : score;
        i = score > scrutiny ? i : i-1;
        mainEmoji = emojis[i];
        speechBubble.text = responses[i];
        result += score;
    }

    void ClickContinue ()
    {
        gameObject.SetActive(false);
        StopCoroutine("JudgeEvaluate");
    }

}
