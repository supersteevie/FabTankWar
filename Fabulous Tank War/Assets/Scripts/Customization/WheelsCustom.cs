using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WheelsCustom : MonoBehaviour {

	//allows the gun barrels to be switched//
	// bool WheelSwap;
	public GameObject wheels01;
	public GameObject wheels02;
	public GameObject wheels03;
	public GameObject wheels04;
	public static int WheelNum;
	private int WheelChng;
	public static int wheelsBeauty;
	public static int wheelsFire;
	public static int wheelsDurability;

	void Start(){

			WheelNum = GameInformation.WheelsID;
			
			if (WheelNum == 1) {
				wheels01.SetActive (true);
				wheels02.SetActive (false);
				wheels03.SetActive (false);
				wheels04.SetActive (false);
				WheelNum = 1;

				// wheel1 skills
				wheelsBeauty = 15;
				wheelsFire = 18;
				wheelsDurability = 20;

				//change num
				WheelChng = 2;

			} else if (WheelNum == 2) {
				wheels01.SetActive (false);
				wheels02.SetActive (true);
				wheels03.SetActive (false);
				wheels04.SetActive (false);
				WheelNum = 2;

				// wheel2 skills
				wheelsBeauty = 10;
				wheelsFire = 17;
				wheelsDurability = 13;

				//change num
				WheelChng = 3;
				
			}  else if (WheelNum == 3) {
				wheels01.SetActive (false);
				wheels02.SetActive (false);
				wheels03.SetActive (true);
				wheels04.SetActive (false);
				WheelNum = 3;
			
				// wheel2 skills
				wheelsBeauty = 14;
				wheelsFire = 12;
				wheelsDurability = 18;
			
				//change num
				WheelChng = 4;
			
			} else if (WheelNum == 4) {
				wheels01.SetActive (false);
				wheels02.SetActive (false);
				wheels03.SetActive (false);
				wheels04.SetActive (true);
				WheelNum = 4;
			
				// wheel2 skills
				wheelsBeauty = 20;
				wheelsFire = 12;
				wheelsDurability = 14;
			
				//change num
				WheelChng = 1;
			
		}
			
	
	}
	
	public void WheelSwitch()
	{
		if (WheelChng == 1) {
			wheels01.SetActive (true);
			wheels02.SetActive (false);
			wheels03.SetActive (false);
			wheels04.SetActive (false);
			WheelNum = 1;
			// wheel1 skills
			wheelsBeauty = 15;
			wheelsFire = 18;
			wheelsDurability = 20;

			//change num
			WheelChng = 2;

			print(WheelNum);

		} else if (WheelChng == 2) {
			wheels01.SetActive(false);
			wheels02.SetActive(true);
			wheels03.SetActive (false);
			wheels04.SetActive (false);
			WheelNum = 2;
			// wheel2 skills
			wheelsBeauty = 10;
			wheelsFire = 17;
			wheelsDurability = 13;

			// change num
			WheelChng = 3;
		
		} else if (WheelChng == 3) {
			wheels01.SetActive(false);
			wheels02.SetActive(false);
			wheels03.SetActive (true);
			wheels04.SetActive (false);
			WheelNum = 3;
			// wheel2 skills
			wheelsBeauty = 14;
			wheelsFire = 12;
			wheelsDurability = 18;
			
			// change num
			WheelChng = 4;
			
		} else if (WheelChng == 4) {
			wheels01.SetActive(false);
			wheels02.SetActive(false);
			wheels03.SetActive (false);
			wheels04.SetActive (true);
			WheelNum = 4;
			// wheel2 skills
			wheelsBeauty = 20;
			wheelsFire = 12;
			wheelsDurability = 14;
			
			// change num
			WheelChng = 1;
			
		} 

	//	WheelSwap = !WheelSwap;
	//	wheels01.SetActive(!WheelSwap);
	//	wheels02.SetActive(WheelSwap);


	}



}

