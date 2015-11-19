using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TurretCustom : MonoBehaviour {

	//allows the gun barrels to be switched//
	bool TurretSwap;
	public GameObject Turret01;
	public GameObject Turret02;
	
	public void TurretSwitch()
	{
		TurretSwap = !TurretSwap;
		Turret01.SetActive(!TurretSwap);
		Turret02.SetActive(TurretSwap);
	}
}
