using UnityEngine;
using System.Collections;

public class LoadInformation  {

	public static void LoadAllInfomation(){

		GameInformation.PlayerName = PlayerPrefs.GetString("PLAYERNAME");
		GameInformation.StareRating = PlayerPrefs.GetInt ("STARRATING");
		GameInformation.BeautyRating = PlayerPrefs.GetInt ("BEAUTYRATING");
		GameInformation.FirePowerRating = PlayerPrefs.GetInt ("FIREPOWERRATING");
		GameInformation.DurabilityRating = PlayerPrefs.GetInt ("DURABILITYRATING");
	}
}
