using UnityEngine;
using System.Collections;
using System;

public class JudgeAI : IComparable<JudgeAI> {


    public GameObject judgeObject; //Object this judge is attached to
    
    public int judgeScrutiny; //Judge's scrutiny level

    public string judgeName; //Judge's name

    public string judgeResponse; //What a judge says in response to an action

    public int judgeBias; //Judge's bias

    public JudgeAI(GameObject judge, string name, string response, int scrutiny, int bias)
    {
        judgeObject = judge;
        judgeName = name;
        judgeResponse = response;
        judgeScrutiny = scrutiny;
        judgeBias = bias;
    }

    public int CompareTo(JudgeAI other)
    {
        if (other == null)
        {
            return 1;
        }

        return judgeScrutiny - other.judgeScrutiny;
    }


    /*
    //Function to evaluate a tank's durability
    void JudgeBeauty ()
    {
        //tnkBeauty > scrutiny? tnkBeauty += bonusPts : null;
    }


    //Function to evaluate a tank's durability
    void JudgeFirepower ()
    {

    }


    //Function to evaluate a tank's durability
    void JudgeDurablity ()
    {

    }


    //Called to evaluate a judge's score
    //  Average beauty, firepower, and durability
    //  Does average < judge's scrutiny?
    //      Yes: Score Card = random number (4-7)
    //      No: Score card = random number (7-9)

    //Called to evaluate tank's total score
    //  Average judge's score cards
    //  Return average

    //Determine's winning tank
    //  tank's total score > enemy total score ? PlayerWins : PlayerLoses


	// Use this for initialization
	void Start () {
	
	}
	

	// Update is called once per frame
	void Update () {
	
	}
    */
}
