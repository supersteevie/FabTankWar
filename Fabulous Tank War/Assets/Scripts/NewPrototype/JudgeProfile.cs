using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class JudgeProfile : MonoBehaviour {

    private Image mainEmoji;
    private Text npcText;

    public Sprite[] emojis;
    public string[] responses;
    
    public Vector3 locPopUp;
    public Vector3 locOffScreen;

    public float smoothing;
    public float waitTime;

    public int scrutiny;



	// Use this for initialization
	void Start () {
        mainEmoji = gameObject.GetComponent<Image>();
        npcText = gameObject.GetComponentInChildren<Text>();
        gameObject.transform.position = locOffScreen;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    //takes in int for which response the tank performed and a bool if it was completed
    void JudgeReaction(int num, bool complete)
    {
        int bonus;
        bonus = complete ? 1 : 0;
        mainEmoji.sprite = emojis[num + bonus];
        npcText.text = responses[num + bonus];
        StartCoroutine(JudgePops (locPopUp, locOffScreen));

    }

    //Judge graphic pops onto screen
    //Will need to 
    IEnumerator JudgePops(Vector3 newPos, Vector3 oldPos)
    {
        while (Vector3.Distance(transform.position, newPos) > 0.05f)
        {
            transform.position = Vector3.Lerp(transform.position, newPos, smoothing * Time.deltaTime);

            yield return null;
        }

        yield return new WaitForSeconds(waitTime);

        while (Vector3.Distance(transform.position, oldPos) > 0.05f)
        {
            transform.position = Vector3.Lerp(transform.position, oldPos, smoothing * Time.deltaTime);

            yield return null;
        }
    }
}
