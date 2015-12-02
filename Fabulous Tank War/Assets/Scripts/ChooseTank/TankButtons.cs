using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TankButtons : MonoBehaviour {

	public Button runway;
	public Button dressUp;
	public Button erase;
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
		erase.interactable = false;
		selectedTank = 0;
		Tank1Text.text = PlayerPrefs.GetString("1" + "PLAYERNAME", "Empty");
		Tank2Text.text = PlayerPrefs.GetString("2" + "PLAYERNAME", "Empty");
		Tank3Text.text = PlayerPrefs.GetString("3" + "PLAYERNAME", "Empty");
		Tank4Text.text = PlayerPrefs.GetString("4" + "PLAYERNAME", "Empty");
		Tank5Text.text = PlayerPrefs.GetString("5" + "PLAYERNAME", "Empty");

	}


	public void Tank1ButtonInfo(){
		if (Tank1Text.text == "Empty") {
			runway.interactable = false;
			erase.interactable = false;
		} else {
			runway.interactable = true;
			erase.interactable = true;
		}
		selectedTank = 1;
		dressUp.interactable = true;


	}

	public void Tank2ButtonInfo(){
		
		if (Tank2Text.text == "Empty") {
			runway.interactable = false;
			erase.interactable = false;
		} else {
			runway.interactable = true;
			erase.interactable = true;
		}

		selectedTank = 2;
		dressUp.interactable = true;
	}

	public void Tank3ButtonInfo(){
		
		if (Tank3Text.text == "Empty") {
			runway.interactable = false;
			erase.interactable = false;
		} else {
			runway.interactable = true;
			erase.interactable = true;
		}

		selectedTank = 3;
		dressUp.interactable = true;
	}

	public void Tank4ButtonInfo(){
		
		if (Tank4Text.text == "Empty") {
			runway.interactable = false;
			erase.interactable = false;
		} else {
			runway.interactable = true;
			erase.interactable = true;
		}
		selectedTank = 4;
		dressUp.interactable = true;
	}
	public void Tank5ButtonInfo(){
		
		if (Tank5Text.text == "Empty") {
			runway.interactable = false;
			erase.interactable = false;
		} else {
			runway.interactable = true;
			erase.interactable = true;
		}
	
		selectedTank = 5;
		dressUp.interactable = true;
	}
	public void Runway(){


		Application.LoadLevel ("newProto");
	
	}

	public void DressUp(){

		Application.LoadLevel ("GarageCustomizationKat");

	}


	public void EraseButton(){


		PlayerPrefs.DeleteKey (selectedTank.ToString() + "TURRETID");
		PlayerPrefs.DeleteKey (selectedTank.ToString() + "HULLID");
		PlayerPrefs.DeleteKey (selectedTank.ToString() + "WHEELSID");
		PlayerPrefs.DeleteKey (selectedTank.ToString() + "PLAYERNAME");
		PlayerPrefs.DeleteKey (selectedTank.ToString() + "COLORID");
		PlayerPrefs.DeleteKey (selectedTank.ToString () + "DECALID");
		PlayerPrefs.DeleteKey (selectedTank.ToString() + "BEAUTYRATING");
		PlayerPrefs.DeleteKey (selectedTank.ToString() + "FIREPOWERRATING");
		PlayerPrefs.DeleteKey (selectedTank.ToString() + "DURABILITYRATING");
		PlayerPrefs.DeleteKey (selectedTank.ToString() + "STARRATING");
		runway.interactable = false;
		erase.interactable = false;

		if (selectedTank == 1) {
			Tank1Text.text = PlayerPrefs.GetString("1" + "PLAYERNAME", "Empty");
		}
		if (selectedTank == 2) {
			Tank2Text.text = PlayerPrefs.GetString("2" + "PLAYERNAME", "Empty");
		}
		if (selectedTank == 3) {
			Tank3Text.text = PlayerPrefs.GetString("3" + "PLAYERNAME", "Empty");
		}
		if (selectedTank == 4) {
			Tank4Text.text = PlayerPrefs.GetString("4" + "PLAYERNAME", "Empty");
		}
		if (selectedTank == 5) {
			Tank5Text.text = PlayerPrefs.GetString("5" + "PLAYERNAME", "Empty");
		}




	}







}
