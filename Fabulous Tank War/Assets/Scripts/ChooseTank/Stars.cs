using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Stars : MonoBehaviour {

	private int Star1Num;
	private int Star2Num;
	private int Star3Num;
	private int Star4Num;
	private int Star5Num;

	public Image Star1;
	public Image Star2;
	public Image Star3;
	public Image Star4;
	public Image Star5;

	public Sprite NoneS;
	public Sprite oneS;
	public Sprite twoS;
	public Sprite threeS;

	// Use this for initialization
	void Start () {
		Star1Num = PlayerPrefs.GetInt("1" + "STARRATING", 0);
		Star2Num = PlayerPrefs.GetInt("2" + "STARRATING", 0);
		Star3Num = PlayerPrefs.GetInt("3" + "STARRATING", 0);
		Star4Num = PlayerPrefs.GetInt("4" + "STARRATING", 0);
		Star4Num = PlayerPrefs.GetInt("5" + "STARRATING", 0);

		// gather starreatings
		if (PlayerPrefs.GetString ("1" + "PLAYERNAME", " ") == " ") {
			Star1.gameObject.SetActive(false);
		}
		if (PlayerPrefs.GetString ("2" + "PLAYERNAME", " ") == " ") {
			Star2.gameObject.SetActive(false);
		}
		if (PlayerPrefs.GetString ("3" + "PLAYERNAME", " ") == " ") {
			Star3.gameObject.SetActive(false);
		}
		if (PlayerPrefs.GetString ("4" + "PLAYERNAME", " ") == " ") {
			Star4.gameObject.SetActive(false);
		}
		if (PlayerPrefs.GetString ("5" + "PLAYERNAME", " ") == " ") {
			Star5.gameObject.SetActive(false);
		}

		// first slot
		if (Star1Num == 0) {
			Star1.sprite = NoneS;

		} else if (Star1Num == 1) {

			Star1.sprite = oneS;
		} else if (Star1Num == 2) {

			Star1.sprite = twoS;
		} else {
			Star1.sprite = threeS;
		}

		// 2nd slot
		if (Star2Num == 0) {
			Star2.sprite = NoneS;
			
		} else if (Star2Num == 1) {
			Star2.sprite = oneS;

		} else if (Star2Num == 2) {		
			Star2.sprite = twoS;

		} else {
			Star2.sprite = threeS;
		}

		// 3rd slot
		if (Star3Num == 0) {
			Star3.sprite = NoneS;
			
		} else if (Star3Num == 1) {
			Star3.sprite = oneS;
			
		} else if (Star3Num == 2) {		
			Star3.sprite = twoS;
			
		} else {
			Star3.sprite = threeS;
		}

		// 4th slot
		if (Star4Num == 0) {
			Star4.sprite = NoneS;
			
		} else if (Star4Num == 1) {
			Star4.sprite = oneS;
			
		} else if (Star4Num == 2) {		
			Star4.sprite = twoS;
			
		} else {
			Star4.sprite = threeS;
		}

		// 5th slot
		if (Star5Num == 0) {
			Star5.sprite = NoneS;
			
		} else if (Star5Num == 1) {
			Star5.sprite = oneS;
			
		} else if (Star5Num == 2) {		
			Star5.sprite = twoS;
			
		} else {
			Star5.sprite = threeS;
		}






	}

	void Update(){
		if (PlayerPrefs.GetString ("1" + "PLAYERNAME", " ") == " ") {
			Star1.gameObject.SetActive(false);
		}
		if (PlayerPrefs.GetString ("2" + "PLAYERNAME", " ") == " ") {
			Star2.gameObject.SetActive(false);
		}
		if (PlayerPrefs.GetString ("3" + "PLAYERNAME", " ") == " ") {
			Star3.gameObject.SetActive(false);
		}
		if (PlayerPrefs.GetString ("4" + "PLAYERNAME", " ") == " ") {
			Star4.gameObject.SetActive(false);
		}
		if (PlayerPrefs.GetString ("5" + "PLAYERNAME", " ") == " ") {
			Star5.gameObject.SetActive(false);
		}


	}
}
