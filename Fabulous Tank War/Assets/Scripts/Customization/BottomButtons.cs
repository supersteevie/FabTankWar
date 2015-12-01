using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BottomButtons : MonoBehaviour {


	public InputField NameInput;
	public Text InputNameText;
	public Text NameText;
	public GameObject TankHolder;
	public GameObject ColorHolder;
	public GameObject DecalHolder;
	private Vector3 PressedPos = new Vector3 (0,128,0);
	private Vector3 UnpressedPos = new Vector3 (0,0,0);
	public static string TankSavedName;
	



	// Use this for initialization
	void Start () {

		print ("PlayerID" + TankButtons.selectedTank);
		print ("PlayerName" + GameInformation.PlayerName);
		if (GameInformation.PlayerName != "Empty") {
			NameText.text = GameInformation.PlayerName;
			InputNameText.text = GameInformation.PlayerName;
		} else {
			NameText.text = "Player";
		}
	}

	public void NameButtonPressed(){


		NameInput.gameObject.SetActive (true);
		TouchScreenKeyboard.Open("", TouchScreenKeyboardType.Default, false, false, true, true);
		TankHolder.transform.position = UnpressedPos;
		ColorHolder.transform.position = UnpressedPos;
		DecalHolder.transform.position = UnpressedPos;
	
		
		
	}

	public void TankButtonPressed(){

		NameInput.gameObject.SetActive (false);
		StartCoroutine(LerpButtonsMove(ColorHolder.transform, UnpressedPos));
		StartCoroutine(LerpButtonsMove(TankHolder.transform, PressedPos));
		StartCoroutine(LerpButtonsMove(DecalHolder.transform, UnpressedPos));


	}
	

	public void ColorButtonPressed(){
		
		NameInput.gameObject.SetActive (false);
		StartCoroutine(LerpButtonsMove(ColorHolder.transform, PressedPos));
		StartCoroutine(LerpButtonsMove(TankHolder.transform, UnpressedPos));
		StartCoroutine(LerpButtonsMove(DecalHolder.transform, UnpressedPos));



		
	}

	public void DecalButtonPressed(){
		
		NameInput.gameObject.SetActive (false);
		StartCoroutine(LerpButtonsMove(ColorHolder.transform, UnpressedPos));
		StartCoroutine(LerpButtonsMove(TankHolder.transform, UnpressedPos));
		StartCoroutine(LerpButtonsMove(DecalHolder.transform, PressedPos));

	
			
	}	


	IEnumerator LerpButtonsMove(Transform UPHolder, Vector3 NewPos)
	{
		float time = 0; // measure our current time
		float duration = .7f; // duration of the lerp
			float rate = 1/duration;
				
			Vector3 startPos = UPHolder.position;
		while(time<1)
		{
			time += Time.deltaTime*rate;
			UPHolder.transform.position = Vector3.Lerp(startPos, NewPos, time);
			yield return null;
			
		}
	}
	







	// saving the name 
	void Update(){
		if (InputNameText.text != "") {
			NameText.text = InputNameText.text;
		}
		TankSavedName = NameText.text;



	}








	
}
