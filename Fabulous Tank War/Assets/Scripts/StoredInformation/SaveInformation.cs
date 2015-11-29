using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SaveInformation {

	//Saveing Of Information

	public static void GameInformationStore(int TurretID, int HullID, int WheelsID, int Slot, string PlayerName,int ColorID, int DecalID, int BeautyRating, int FirePowerRating, int DurabilityRating ){

		PlayerPrefs.SetInt (Slot.ToString() + "TURRETID", TurretID);
		PlayerPrefs.SetInt (Slot.ToString() + "HULLID", HullID);
		PlayerPrefs.SetInt (Slot.ToString() + "WHEELSID", WheelsID);
		PlayerPrefs.SetString(Slot.ToString() + "PLAYERNAME", PlayerName);
		PlayerPrefs.SetInt (Slot.ToString() + "COLORID", ColorID);
		PlayerPrefs.SetInt (Slot.ToString () + "DECALID", DecalID);
		PlayerPrefs.SetInt (Slot.ToString() + "BEAUTYRATING",BeautyRating);
		PlayerPrefs.SetInt (Slot.ToString() + "FIREPOWERRATING",FirePowerRating);
		PlayerPrefs.SetInt (Slot.ToString() + "DURABILITYRATING", DurabilityRating);


	}
	public static void StarRatingInformationStore(int Slot, int StarRating){

		PlayerPrefs.SetInt (Slot.ToString() + "STARRATING", StarRating);
	}




}
