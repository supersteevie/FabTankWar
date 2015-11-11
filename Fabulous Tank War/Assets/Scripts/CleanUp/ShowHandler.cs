using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ShowHandler : MonoBehaviour {
	//_________Script Info_________
	//...This script is for the show stage of Fabulous Tank War. This is the second part of the game where most of the gameplay is.


	//NPCs
	//...MC
	//...3 Judges


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//First Stage
	//...Judges evaluate beauty as tank goes down the runway


	//Second Stage
	//...MC says "Fire when you see the '!' before your opponent!"
	//...! symbol shows. Player presses button.
	//...Slow mo and close up of tank blast.
	//...Judge response during slow motion

	//Third Stage
	//...Animation of collision
	//...Judges evaluate durability

	//Final Stage
	//...MC "And now the judges will choose the victor!
	//...Drum roll sound effect
	//...Judges reveal winner

	//Post Show
	//...Store points in associate tank file
	//...Award cash to player based on their score




	//_________Needed Databases_________
	//...Here are some databases we need for Fabulous Tank War

	//NPC Database
	//...Name
	//...Nationality
	//...Scrutiny (Difficulty level to pass their judgement)
	//...Bias (Variable that increases scrutiny for a tank attribute or decreases scrutiny based on component, colors, etc.)
	//...Dialogue [] (String array of responses for how the player does)
	//...FaceExpression [] (Sprite array of graphic responses)

	//Tank Components Database
	//...Name
	//...Cost
	//...Attribute Level[] (Array of integers representing points to a tank's beauty, firepower, and durability
	//...Type (Is it a turret, hull, or wheels)
	//...Texture (What textures does this component use?)

	//Tank Database (Player and NPC tanks)
	//...Name
	//...Components Used
	//...Colors used
	//...Attribute levels[] (Total levels of beauty, firepower, and durability)
	//...Stars (Null if the tank has not entered a show)
	//...bool playerOwned (returns true if it is owned by the player)



}
