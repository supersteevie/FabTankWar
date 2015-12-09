using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HullCustom : MonoBehaviour {

	//allows the gun barrels to be switched//
//	bool HullSwap;
	public GameObject Hull01;
	public GameObject Hull02;
	public GameObject Hull03;
	public GameObject Hull04;
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
			Hull03.SetActive (false);
			Hull04.SetActive (false);
			HullNum = 1;
			
			//Hull1 Skills 
			hullBeauty = 10;
			hullFire = 15;
			hullDurability = 20;

			// change number
			HullChng = 2;
		}


		if (HullNum == 2) {
			Hull01.SetActive (false);
			Hull02.SetActive (true);
			Hull03.SetActive (false);
			Hull04.SetActive (false);
			HullNum = 2;

			// Hull2 Skills
			hullBeauty = 15;
			hullFire = 12;
			hullDurability = 10;

			// change number
			HullChng = 3;
		}

		if (HullNum == 3) {
			Hull01.SetActive (false);
			Hull02.SetActive (false);
			Hull03.SetActive (true);
			Hull04.SetActive (false);

			HullNum = 3;
			
			// Hull3 Skills
			hullBeauty = 15;
			hullFire = 17;
			hullDurability = 12;
			
			// change number
			HullChng = 4;
		}


		if (HullNum == 4) {
			Hull01.SetActive (false);
			Hull02.SetActive (false);
			Hull03.SetActive (false);
			Hull04.SetActive (true);
			HullNum = 4;
			
			// Hull4 Skills
			hullBeauty = 20;
			hullFire = 16;
			hullDurability = 10;
			
			// change number
			HullChng = 1;
		}
			

	}

	public void HullSwitch()
	{
		if (HullChng == 1) {
			Hull01.SetActive (true);
			Hull02.SetActive (false);
			Hull03.SetActive (false);
			Hull04.SetActive (false);
			HullNum = 1;
			// Hull1 skills
			hullBeauty = 10;
			hullFire = 15;
			hullDurability = 20;


			// change to next number
			HullChng = 2;

		} else if (HullChng == 2) {
			Hull01.SetActive(false);
			Hull02.SetActive(true);
			Hull03.SetActive (false);
			Hull04.SetActive (false);
			HullNum = 2;
			// Hull2 skills
			hullBeauty = 15;
			hullFire = 12;
			hullDurability = 10;

			// change to next number
			HullChng = 3;
			
		} else if (HullChng == 3) {
			Hull02.SetActive(false);
			Hull03.SetActive (true);
			Hull04.SetActive (false);
			HullNum = 3;
			// Hull3 skills
			hullBeauty = 15;
			hullFire = 17;
			hullDurability = 12;
			
			// change to next number
			HullChng = 4;
			
		} else if (HullChng == 4) {
			Hull01.SetActive(false);
			Hull02.SetActive(false);
			Hull03.SetActive (false);
			Hull04.SetActive (true);
			HullNum = 4;
			// Hull4 skills
			hullBeauty = 20;
			hullFire = 16;
			hullDurability = 10;
			
			// change to next number
			HullChng = 1;
			
		}


//		HullSwap = !HullSwap;
//		Hull01.SetActive(!HullSwap);
//		Hull02.SetActive(HullSwap);

	}



}
