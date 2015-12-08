using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class JudgeProfile : MonoBehaviour {

    private Image mainEmoji;
    private Text npcText;

    public Sprite[] emoLose;    //sprites for a lose reaction from NPCs
    public Sprite[] emoTie;     //sprites for a tie reaction from NPCs
    public Sprite[] emoWin;     //sprites for a win reaction from NPCs
    public string[] rspLose;    //dialogue for a lose reaction from NPCs
    public string[] rspTie;     //dialogue for a tie reaction from NPCs
    public string[] rspWin;     //dialogue for a win reaction from NPCs

    public Vector3 locOnScrn;   //On screen locaton of prefab 
    public Vector3 locOffScrn;  //Off screen location of prefab

    public float smoothing;
    public float waitTime;

    public int scrutiny;
	public int beaBias;
	public int firBias;
	public int durBias;



	// Use this for initialization
	void Start () {
        mainEmoji = gameObject.GetComponent<Image>();
        npcText = gameObject.GetComponentInChildren<Text>();
        gameObject.transform.position = locOffScrn;

		scrutiny = (beaBias + firBias + durBias) / 3;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    //takes in int for which response the tank performed and a bool if it was completed
    void JudgeReaction(int num, bool win, bool tie)
    {
        if (win)
        {
            mainEmoji.sprite = emoWin[num];
            npcText.text = rspWin[num];
        } else if (tie)
        {
            mainEmoji.sprite = emoTie[num];
            npcText.text = rspTie[num];
        }
        else
        {
            mainEmoji.sprite = emoLose[num];
            npcText.text = rspLose[num];
        }
        StartCoroutine(JudgePops (locOnScrn, locOffScrn));

    }

    //Judge graphic pops onto screen
    //Will need to 
    IEnumerator JudgePops(Vector3 newPos, Vector3 oldPos)
    {
        while (Vector3.Distance(transform.position, newPos) > 0.05f)
        {
            transform.position = Vector3.MoveTowards(transform.position, newPos, smoothing * Time.deltaTime);

            yield return null;
        }

        yield return new WaitForSeconds(waitTime);

        while (Vector3.Distance(transform.position, oldPos) > 0.05f)
        {
            transform.position = Vector3.MoveTowards(transform.position, oldPos, smoothing * Time.deltaTime);

            yield return null;
        }
    }
}
