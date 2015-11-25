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
	private Vector3 PressedPos = new Vector3 (0,125,0);
	private Vector3 UnpressedPos = new Vector3 (0,0,0);
	public static string TankSavedName;



	// Use this for initialization
	void Start () {
		if (GameInformation.PlayerName != "Empty") {
			NameText.text = GameInformation.PlayerName;
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
		TankHolder.transform.position = PressedPos;
		ColorHolder.transform.position = UnpressedPos;
		DecalHolder.transform.position = UnpressedPos;


// 		lerp way cant figure out
//		Vector3 ColorHPos = new Vector3(ColorHolder.transform.position.x, ColorHolder.transform.position.y, ColorHolder.transform.position.z);
//		Vector3 newColorHPos = new Vector3(0, 0, 0);
//		TankHolder.transform.position = Vector3.Lerp (ColorHPos, newColorHPos, Time.deltaTime * 2.0f);
//

	}

	public void ColorButtonPressed(){
		
		NameInput.gameObject.SetActive (false);
		TankHolder.transform.position = UnpressedPos;
		ColorHolder.transform.position = PressedPos;
		DecalHolder.transform.position = UnpressedPos;

		
	}

	public void DecalButtonPressed(){
		
		NameInput.gameObject.SetActive (false);
		TankHolder.transform.position = UnpressedPos;
		ColorHolder.transform.position = UnpressedPos;
		DecalHolder.transform.position = PressedPos;
		
			
	}	
	

	void Update(){
		if (InputNameText.text != "") {
			NameText.text = InputNameText.text;
		}
		TankSavedName = NameText.text;

	}








	
}
