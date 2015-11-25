using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WheelsCustom : MonoBehaviour {

	//allows the gun barrels to be switched//
	// bool WheelSwap;
	public GameObject wheels01;
	public GameObject wheels02;
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
				WheelNum = 1;

				// wheel1 skills
				wheelsBeauty = 10;
				wheelsFire = 20;
				wheelsDurability = 30;

				//change num
				WheelChng = 2;

			} else if (WheelNum == 2) {
				wheels02.SetActive (true);
				wheels01.SetActive (false);
				WheelNum = 2;

				// wheel2 skills
				wheelsBeauty = 25;
				wheelsFire = 15;
				wheelsDurability = 20;

				//change num
				WheelChng = 1;
				
			}
			
	
	}
	
	public void WheelSwitch()
	{
		if (WheelChng == 1) {
			wheels01.SetActive (true);
			wheels02.SetActive (false);
			WheelNum = 1;
			// wheel1 skills
			wheelsBeauty = 10;
			wheelsFire = 20;
			wheelsDurability = 30;

			//change num
			WheelChng = 2;

			print(WheelNum);

		} else if (WheelChng == 2) {
			wheels01.SetActive(false);
			wheels02.SetActive(true);
			WheelNum = 2;
			// wheel2 skills
			wheelsBeauty = 25;
			wheelsFire = 15;
			wheelsDurability = 20;

			// change num
			WheelChng = 1;
		
		}
	//	WheelSwap = !WheelSwap;
	//	wheels01.SetActive(!WheelSwap);
	//	wheels02.SetActive(WheelSwap);


	}



}

