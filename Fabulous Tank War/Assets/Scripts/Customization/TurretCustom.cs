using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TurretCustom : MonoBehaviour {

	//allows the gun barrels to be switched//
//	bool TurretSwap;
	public GameObject Turret01;
	public GameObject Turret02;
	public GameObject Turret03;
	public GameObject Turret04;
	public static int TurretNum;
	private int TurretChng;
	public static int turretBeauty;
	public static int turretFire;
	public static int turretDurability;

	void Start(){
			
		TurretNum = GameInformation.HullID;

		if (TurretNum == 1) {
			Turret01.SetActive (true);
			Turret02.SetActive (false);
			Turret03.SetActive (false);
			Turret04.SetActive (false);
			TurretNum = 1;

			// turret1 skills 
			turretBeauty = 12;
			turretFire = 20;
			turretDurability = 15;

			//change number
			TurretChng = 2;

		}
		if (TurretNum == 2) {
			Turret01.SetActive (false);
			Turret02.SetActive (true);
			Turret03.SetActive (false);
			Turret04.SetActive (false);
			TurretNum = 2;

			// Turret2 skills
			turretBeauty = 10;
			turretFire = 15;
			turretDurability = 18;	

			//change number
			TurretChng = 3;
		}
		if (TurretNum == 3) {
			Turret01.SetActive (false);
			Turret02.SetActive (false);
			Turret03.SetActive (true);
			Turret04.SetActive (false);
			TurretNum = 3;
			
			// Turret3 skills
			turretBeauty = 15;
			turretFire = 18;
			turretDurability = 16;	
			
			//change number
			TurretChng = 4;
		}
		if (TurretNum == 4) {
			Turret01.SetActive (false);
			Turret02.SetActive (false);
			Turret03.SetActive (false);
			Turret04.SetActive (true);
			TurretNum = 4;
			
			// Turret4 skills
			turretBeauty = 20;
			turretFire = 12;
			turretDurability = 11;	
			
			//change number
			TurretChng = 1;
		}


	}

	public void TurretSwitch()
	{
		if (TurretChng == 1) {
			Turret01.SetActive (true);
			Turret02.SetActive (false);
			Turret03.SetActive (false);
			Turret04.SetActive (false);
			TurretNum = 1;
			// Turret1 Skills
			turretBeauty = 12;
			turretFire = 20;
			turretDurability = 15;

			//change number
			TurretChng = 2;

		} else if (TurretChng == 2) {
			Turret01.SetActive(false);
			Turret02.SetActive(true);
			Turret03.SetActive (false);
			Turret04.SetActive (false);
			TurretNum = 2;
			//Turret2 Skills
			turretBeauty = 10;
			turretFire = 15;
			turretDurability = 18;	

			//change number
			TurretChng = 3;
			
		}else if (TurretChng == 3) {
			Turret01.SetActive(false);
			Turret02.SetActive(false);
			Turret03.SetActive (true);
			Turret04.SetActive (false);
			TurretNum = 3;
			//Turret3 Skills
			turretBeauty = 15;
			turretFire = 18;
			turretDurability = 16;		
			
			//change number
			TurretChng = 4;
			
		} else if (TurretChng == 4) {
			Turret01.SetActive(false);
			Turret02.SetActive(false);
			Turret03.SetActive(false);
			Turret04.SetActive (true);
			TurretNum = 4;
			//Turret4 Skills
			turretBeauty = 20;
			turretFire = 12;
			turretDurability = 11;	
			
			//change number
			TurretChng = 1;
			
		}


//		TurretSwap = !TurretSwap;
//		Turret01.SetActive(!TurretSwap);
//		Turret02.SetActive(TurretSwap);



	}



}
