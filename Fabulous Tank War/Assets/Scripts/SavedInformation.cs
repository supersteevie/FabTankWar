using UnityEngine;
using System.Collections;

public class SavedInformation {

	public static void SaveAllInformation(){

		PlayerPrefs.SetString("PLAYERNAME", GameInformation.PlayerName);
		PlayerPrefs.SetInt ("STARRATING", GameInformation.StareRating);
		PlayerPrefs.SetInt ("BEAUTYRATING",GameInformation.BeautyRating);
		PlayerPrefs.SetInt ("FIREPOWERRATING",GameInformation.FirePowerRating);
		PlayerPrefs.SetInt ("DURABILITYRATING",GameInformation.DurabilityRating);


	}

}
