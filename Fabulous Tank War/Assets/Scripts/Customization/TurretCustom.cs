using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TurretCustom : MonoBehaviour {

	//allows the gun barrels to be switched//
//	bool TurretSwap;
	public GameObject Turret01;
	public GameObject Turret02;
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
			TurretNum = 1;

			// turret1 skills 
			turretBeauty = 10;
			turretFire = 25;
			turretDurability = 20;

			//change number
			TurretChng = 2;

		}
		if (TurretNum == 2) {
			Turret01.SetActive (false);
			Turret02.SetActive (true);
			TurretNum = 2;

			// Turret2 skills
			turretBeauty = 15;
			turretFire = 30;
			turretDurability = 10;	

			//change number
			TurretChng = 1;
		}


	}

	public void TurretSwitch()
	{
		if (TurretChng == 1) {
			Turret01.SetActive (true);
			Turret02.SetActive (false);
			TurretNum = 1;
			// Turret1 Skills
			turretBeauty = 10;
			turretFire = 25;
			turretDurability = 20;

			//change number
			TurretChng = 2;

			print ("t1" + TurretNum);


		} else if (TurretChng == 2) {
			Turret01.SetActive(false);
			Turret02.SetActive(true);
			TurretNum = 2;
			//Turret2 Skills
			turretBeauty = 15;
			turretFire = 30;
			turretDurability = 10;

			//change number
			TurretChng = 1;
			print ("t2" + TurretNum);
			
		}

//		TurretSwap = !TurretSwap;
//		Turret01.SetActive(!TurretSwap);
//		Turret02.SetActive(TurretSwap);



	}



}
