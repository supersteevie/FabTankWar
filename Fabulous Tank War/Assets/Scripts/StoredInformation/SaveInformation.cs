using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SaveInformation {

	//Saveing Of Information

	public static void GameInformationStore(int TurretID, int HullID, int WheelsID, int Slot, string PlayerName,int StarRating, int BeautyRating, int FirePowerRating, int DurabilityRating ){

		PlayerPrefs.SetInt (Slot.ToString() + "TURRETID", TurretID);
		PlayerPrefs.SetInt (Slot.ToString() + "HULLID", HullID);
		PlayerPrefs.SetInt (Slot.ToString() + "WHEELSID", WheelsID);
		PlayerPrefs.SetString(Slot.ToString() + "PLAYERNAME", PlayerName);
		PlayerPrefs.SetInt (Slot.ToString() + "STARRATING", StarRating);
		PlayerPrefs.SetInt (Slot.ToString() + "BEAUTYRATING",BeautyRating);
		PlayerPrefs.SetInt (Slot.ToString() + "FIREPOWERRATING",FirePowerRating);
		PlayerPrefs.SetInt (Slot.ToString() + "DURABILITYRATING", DurabilityRating);


	}



}
