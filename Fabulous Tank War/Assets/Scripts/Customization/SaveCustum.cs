using UnityEngine;
using System.Collections;

public class SaveCustum : MonoBehaviour {


	public void SaveCustumTank(){
	
		SaveInformation.GameInformationStore (TurretCustom.TurretNum, HullCustom.HullNum, WheelsCustom.WheelNum, TankButtons.selectedTank, BottomButtons.TankSavedName, ChooseColor.ColorNum, DecalCustom.DecalNum, SkilsSet.BeautyNum, SkilsSet.FirePowerNum, SkilsSet.DurabilityNum);
		//public static void GameInformationStore(int TurretID, int HullID, int WheelsID, int Slot, string PlayerName,int StarRating, int BeautyRating, int FirePowerRating, int DurabilityRating )

		Application.LoadLevel ("ChooseTank");

	}
	

}
