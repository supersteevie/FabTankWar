using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WheelsCustom : MonoBehaviour {

	//allows the gun barrels to be switched//
	bool WheelSwap;
	public GameObject wheels01;
	public GameObject wheels02;
	public static int WheelNum =1;
	public static int wheelsBeauty;
	public static int wheelsFire;
	public static int wheelsDurability;

	void Start(){
		if (GameInformation.PlayerName != "Empty") {
			WheelNum = GameInformation.HullID;
			
			if (WheelNum == 2) {
				wheels02.SetActive (true);
				wheels01.SetActive (false);
				WheelSwap = !WheelSwap;
			}
			if (WheelNum == 1) {
				wheels01.SetActive (true);
				wheels02.SetActive (false);
			}
		}

		if (wheels01.activeInHierarchy == true) {
			WheelNum = 1;
			wheelsBeauty = 10;
			wheelsFire = 20;
			wheelsDurability = 30;
			//	print(WheelNum);
			
		} else if (wheels02.activeInHierarchy == true) {
			WheelNum = 2;
			wheelsBeauty = 25;
			wheelsFire = 15;
			wheelsDurability = 20;
			//	print(WheelNum);
		}
	}
	
	public void WheelSwitch()
	{
		WheelSwap = !WheelSwap;
		wheels01.SetActive(!WheelSwap);
		wheels02.SetActive(WheelSwap);

		if (wheels01.activeInHierarchy == true) {
			WheelNum = 1;
			wheelsBeauty = 10;
			wheelsFire = 20;
			wheelsDurability = 30;
		//	print(WheelNum);
	
		} else if (wheels02.activeInHierarchy == true) {
			WheelNum = 2;
			wheelsBeauty = 25;
			wheelsFire = 15;
			wheelsDurability = 20;
		//	print(WheelNum);
		}
	}
}

