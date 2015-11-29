using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HullCustom : MonoBehaviour {

	//allows the gun barrels to be switched//
//	bool HullSwap;
	public GameObject Hull01;
	public GameObject Hull02;
	public static int HullNum;
	private int HullChng;
	public static int hullBeauty;
	public static int hullFire;
	public static int hullDurability;

	void Start(){

			HullNum = GameInformation.HullID;

		if (HullNum == 1) {
			Hull01.SetActive (true);
			Hull02.SetActive (false);
			HullNum = 1;
			
			//Hull1 Skills 
			hullBeauty = 10;
			hullFire = 20;
			hullDurability = 33;

			// change number
			HullChng = 2;
		}


		if (HullNum == 2) {
			Hull02.SetActive (true);
			Hull01.SetActive (false);
			HullNum = 2;

			// Hull2 Skills
			hullBeauty = 30;
			hullFire = 15;
			hullDurability = 25;

			// change number
			HullChng = 1;
		}
			

	}

	public void HullSwitch()
	{
		if (HullChng == 1) {
			Hull01.SetActive (true);
			Hull02.SetActive (false);
			HullNum = 1;
			// Hull1 skills
			hullBeauty = 10;
			hullFire = 20;
			hullDurability = 33;

			// change to next number
			HullChng = 2;

		} else if (HullChng == 2) {
			Hull01.SetActive(false);
			Hull02.SetActive(true);
			HullNum = 2;
			// Hull2 skills
			hullBeauty = 30;
			hullFire = 15;
			hullDurability = 25;

			// change to next number
			HullChng = 1;

			
		}

//		HullSwap = !HullSwap;
//		Hull01.SetActive(!HullSwap);
//		Hull02.SetActive(HullSwap);

	}



}
