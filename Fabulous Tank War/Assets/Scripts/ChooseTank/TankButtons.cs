using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TankButtons : MonoBehaviour {

	public Button runway;
	public Button dressUp;
	public Text Tank1Text;
	public Text Tank2Text;
	public Text Tank3Text;
	public Text Tank4Text;
	public Text Tank5Text;
	public static int selectedTank = 0;


	void Start(){
		TankName ();
	}
	public void TankName(){

		runway.interactable = false;
		dressUp.interactable = false;
		Tank1Text.text = PlayerPrefs.GetString("1" + "PLAYERNAME", "Empty");
		Tank2Text.text = PlayerPrefs.GetString("2" + "PLAYERNAME", "Empty");
		Tank3Text.text = PlayerPrefs.GetString("3" + "PLAYERNAME", "Empty");
		Tank4Text.text = PlayerPrefs.GetString("4" + "PLAYERNAME", "Empty");
		Tank5Text.text = PlayerPrefs.GetString("5" + "PLAYERNAME", "Empty");

	}


	public void Tank1ButtonInfo(){
		if (Tank1Text.text == "Empty") {
			runway.interactable = false;
		} else {
			runway.interactable = true;
		}
		selectedTank = 1;
		dressUp.interactable = true;


	}

	public void Tank2uttonInfo(){
		
		if (Tank1Text.text == "Empty") {
			runway.interactable = false;
		} else {
			runway.interactable = true;
		}

		selectedTank = 2;
		dressUp.interactable = true;
	}

	public void Tank3ButtonInfo(){
		
		if (Tank1Text.text == "Empty") {
			runway.interactable = false;
		} else {
			runway.interactable = true;
		}

		selectedTank = 3;
		dressUp.interactable = true;
	}

	public void Tank4ButtonInfo(){
		
		if (Tank1Text.text == "Empty") {
			runway.interactable = false;
		} else {
			runway.interactable = true;
		}
		selectedTank = 4;
		dressUp.interactable = true;
	}
	public void Tank5ButtonInfo(){
		
		if (Tank1Text.text == "Empty") {
			runway.interactable = false;
		} else {
			runway.interactable = true;
		}
	
		selectedTank = 5;
		dressUp.interactable = true;
	}
	public void Runway(){


	//	Application.LoadLevel ("");
	
	}

	public void DressUp(){

	//	Application.LoadLevel ("");

	}





}
