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
	public TankAttributes tankPlayer;

    // Use this for initialization
    void Start()
    {
        finalPos = new Vector3(-6, 0, -1);
        calledMethod = false;
        camFollower = GameObject.Find("Main Camera");
        swipeCircle = GameObject.Find("Response Swipe Button");

        camFollower.GetComponent<AnimFollow>().GoCamera();
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
        if (Vector3.Distance(transform.position, spinPos) <= 0.05f && stage < 2)
        {
            if (!swipeCircle.GetComponent<QuickTimeResponse>().hasStarted)
            {
                swipeCircle.GetComponent<QuickTimeResponse>().WhenActive();
            }
            if (swipeCircle.GetComponent<QuickTimeResponse>().isFinished)
            {
                StartCoroutine( NextStage());
                //StopAllCoroutines();
                swipeCircle.GetComponent<QuickTimeResponse>().isFinished = false;
            }
        }

        if (stage > 2)
        {
            Debug.Log("Stage: " + stage);
            if (!GameObject.Find("#Gamehandler").GetComponent<QuickDraw>().hasShot)
            {
                camFollower.GetComponent<AnimFollow>().GoCamera();
                StartCoroutine( RunwayRoll(finalPos));
            }

            if (Vector3.Distance(transform.position, finalPos) <= 0.05f && !calledMethod)
            {
                GetComponent<Animator>().enabled = false;
                GameObject.Find("#Gamehandler").GetComponent<QuickDraw>().StartTimer();
                calledMethod = true;
            }

            if (calledMethod && GameObject.Find("#Gamehandler").GetComponent<QuickDraw>().hasShot)
            {
                GameObject.Find("#Gamehandler").GetComponent<QuickDraw>().panel.SetActive(true);
            }
        }


    }

    IEnumerator RunwayRoll(Vector3 target)
    {
        //moving the tank
        while (Vector3.Distance(transform.position, target) > 0.05f)
        {
            transform.position = Vector3.Lerp(transform.position, target, smoothing * Time.deltaTime);

            yield return null;
        }
        //transform.position = target;

        yield return null;
    }


    public void TimeToJudge()
    {
        for (int i = 0; i < judgeNPCs.Length; i++)
        {
			judgeNPCs[i].SetActive(true);
            judgeNPCs[i].GetComponent<JudgeTalk>().StartCoroutine("JudgeEvaluate", stage);
        }
    }

    IEnumerator NextStage()
    {
        TimeToJudge();
        yield return new WaitForSeconds(3f);

        stage += 2;

        yield return null;

    }

}
