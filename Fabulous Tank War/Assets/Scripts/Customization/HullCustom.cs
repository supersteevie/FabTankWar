using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HullCustom : MonoBehaviour {

	//allows the gun barrels to be switched//
	bool HullSwap;
	public GameObject Hull01;
	public GameObject Hull02;
	public static int HullNum;
	public static int hullBeauty;
	public static int hullFire;
	public static int hullDurability;

	void Start(){
		if (GameInformation.PlayerName != "Empty") {
			HullNum = GameInformation.HullID;

			if (HullNum == 2) {
				Hull02.SetActive (true);
				Hull01.SetActive (false);
				HullSwap = !HullSwap;
			}
			if (HullNum == 1) {
				Hull01.SetActive (true);
				Hull02.SetActive (false);
			}
		}
		if (Hull01.activeInHierarchy == true) {
			HullNum = 1;
			hullBeauty = 10;
			hullFire = 20;
			hullDurability = 33;
			
		} else if (Hull02.activeInHierarchy == true) {
			HullNum = 2;
			hullBeauty = 30;
			hullFire = 15;
			hullDurability = 25;


			
		}
	}

	public void HullSwitch()
	{
		HullSwap = !HullSwap;
		Hull01.SetActive(!HullSwap);
		Hull02.SetActive(HullSwap);

		if (Hull01.activeInHierarchy == true) {
			HullNum = 1;
			hullBeauty = 10;
			hullFire = 20;
			hullDurability = 33;
			
		} else if (Hull02.activeInHierarchy == true) {
			HullNum = 2;
			hullBeauty = 30;
			hullFire = 15;
			hullDurability = 25;

		
		}
	}
}
