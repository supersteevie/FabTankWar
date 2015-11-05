using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class JudgesDatabase : MonoBehaviour {

    //Toughness of judge's scrutiny
    public int easy = 10;
    public int firm = 15;
    public int tough = 20;
    public int brutal = 25;

    public GameObject[] aJudge;

    public List<JudgeAI> judges = new List<JudgeAI>();

    // Use this for initialization
    void Start () {
        judges.Add(new JudgeAI(aJudge[0], "Holly", "You're fabulous!", firm, 3));
        judges.Add(new JudgeAI(aJudge[1], "Todd", "That's... AMAZING!!", tough, 1));
        judges.Add(new JudgeAI(aJudge[2], "Synthia", "Hmmm, well done.", brutal, 0));
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
