using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SkilsSet : MonoBehaviour {

	public Slider BeautyBar;
	public Slider FirePowerBar;
	public Slider DurabilityBar;
	public static int BeautyNum;
	public static int FirePowerNum;
	public static int DurabilityNum;
	// Use this for initialization


	// Update is called once per frame
	void Update () {

		BeautyNum = TurretCustom.turretBeauty + HullCustom.hullBeauty + WheelsCustom.wheelsBeauty;
		FirePowerNum = TurretCustom.turretFire + HullCustom.hullFire + WheelsCustom.wheelsFire;
		DurabilityNum = TurretCustom.turretDurability + HullCustom.hullDurability + WheelsCustom.wheelsDurability;
		BeautyBar.value = BeautyNum;
		FirePowerBar.value = FirePowerNum;
		DurabilityBar.value = DurabilityNum;
	}
}
