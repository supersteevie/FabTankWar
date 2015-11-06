using UnityEngine;
using System.Collections;

public class BeginShowdown : MonoBehaviour {

    public int beauty;
    public int firepower;
    public int durability;

    public bool calledMethod;
    public float smoothing = 1f;
    public Vector3 spinPos;
    public Vector3 finalPos;

    public GameObject[] judgeNPCs;
    public int stage;
    public int totalScore;
    public int finalScore;

    public GameObject swipeCircle;
    public GameObject camFollower;
    public int swipeTime;
	public TankAttributes tankPlayer;

    // Use this for initialization
    void Start()
    {
        finalPos = new Vector3(-6, 0, -1);
        calledMethod = false;
        camFollower = GameObject.Find("Main Camera");

        camFollower.GetComponent<AnimFollow>().StartCoroutine("CameraMoving", camFollower.GetComponent<AnimFollow>().midpoint);
        StartCoroutine( RunwayRoll(spinPos));
        stage = 1;

        //This tank's attributes
        tankPlayer = new TankAttributes();
        tankPlayer.TnkBeauty = beauty;
        tankPlayer.TnkDurability = durability;
        tankPlayer.TnkPower = firepower;


    }

    // Update is called once per frame
    void Update()
    {
        if (stage >=2 && !GameObject.Find("#Gamehandler").GetComponent<QuickDraw>().hasShot)
        {
            camFollower.GetComponent<AnimFollow>().StartCoroutine("CameraMoving", camFollower.GetComponent<AnimFollow>().end);
            RunwayRoll(finalPos);
        }
        if (transform.position == finalPos && !calledMethod)
        {
            GetComponent<Animator>().enabled = false;
            GameObject.Find("#Gamehandler").GetComponent<QuickDraw>().StartTimer();
            calledMethod = true;
        }
        if (calledMethod && GameObject.Find("#Gamehandler").GetComponent<QuickDraw>().hasShot)
        {
            RunwayRoll(finalPos);
            GameObject.Find("#Gamehandler").GetComponent<QuickDraw>().panel.SetActive(true);
        }

    }

    IEnumerator RunwayRoll(Vector3 target)
    {
        while (Vector3.Distance(transform.position, target) > 0.05f)
        {
            transform.position = Vector3.Lerp(transform.position, target, smoothing * Time.deltaTime);

            yield return null;
        }

        //Function where judging begins. While loop of judges.
        if (stage < 2)
        {
            swipeCircle.GetComponent<QuickTimeCircle>().StartCircleQuickTime(swipeTime);
            yield return new WaitForSeconds(swipeTime);
        }

        TimeToJudge(stage);

        yield return null;
    }

    void TimeToJudge(int num)
    {
        for (int i = 0; i < judgeNPCs.Length; i++)
        {
			judgeNPCs[i].SetActive(true);
            judgeNPCs[i].GetComponent<JudgeTalk>().StartCoroutine("JudgeEvaluate", num);
        }
        num += 2;
    }

}
