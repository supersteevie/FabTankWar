using UnityEngine;
using System.Collections;

public class LoadInformation  {

	public static void LoadAllInfomation(int Slot){

		GameInformation.TurretID = PlayerPrefs.GetInt (Slot.ToString() + "TURRETID", 0);
		GameInformation.HullID = PlayerPrefs.GetInt (Slot.ToString() + "HULLID", 0);
		GameInformation.WheelsID = PlayerPrefs.GetInt (Slot.ToString() + "WHEELSID", 0);
		GameInformation.PlayerName = PlayerPrefs.GetString(Slot.ToString() + "PLAYERNAME", "Player");
		GameInformation.StareRating = PlayerPrefs.GetInt (Slot.ToString() + "STARRATING", 0);
		GameInformation.BeautyRating = PlayerPrefs.GetInt (Slot.ToString() + "BEAUTYRATING", 0);
		GameInformation.FirePowerRating = PlayerPrefs.GetInt (Slot.ToString() + "FIREPOWERRATING", 0);
		GameInformation.DurabilityRating = PlayerPrefs.GetInt (Slot.ToString() + "DURABILITYRATING", 0);
	}
	//public static GameObject Tank(int playerID){

		// return null;

//	}
}
