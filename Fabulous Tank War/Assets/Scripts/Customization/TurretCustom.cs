using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TurretCustom : MonoBehaviour {

	//allows the gun barrels to be switched//
	bool TurretSwap;
	public GameObject Turret01;
	public GameObject Turret02;
	public static int TurretNum = 1;
	public static int turretBeauty;
	public static int turretFire;
	public static int turretDurability;

	void Start(){

		if (GameInformation.PlayerName != "Empty") {
			TurretNum = GameInformation.HullID;
			
			if (TurretNum == 2) {
				Turret02.SetActive (true);
				Turret01.SetActive (false);
				TurretSwap = !TurretSwap;
			}
			if (TurretNum == 1) {
				Turret01.SetActive (true);
				Turret02.SetActive (false);
			}
		}
		if (Turret01.activeInHierarchy == true) {
			TurretNum = 1;
			turretBeauty = 10;
			turretFire = 25;
			turretDurability = 20;
			
			
		} else if (Turret02.activeInHierarchy == true) {
			TurretNum = 2;
			turretBeauty = 15;
			turretFire = 30;
			turretDurability = 10;	
		}

	}

	public void TurretSwitch()
	{
		TurretSwap = !TurretSwap;
		Turret01.SetActive(!TurretSwap);
		Turret02.SetActive(TurretSwap);

		if (Turret01.activeInHierarchy == true) {
			TurretNum = 1;
			turretBeauty = 10;
			turretFire = 25;
			turretDurability = 20;

			
		} else if (Turret02.activeInHierarchy == true) {
			TurretNum = 2;
			turretBeauty = 15;
			turretFire = 30;
			turretDurability = 10;
		
		}


	}
}
