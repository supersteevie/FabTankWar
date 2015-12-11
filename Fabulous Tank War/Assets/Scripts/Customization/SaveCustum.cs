using UnityEngine;
using System.Collections;

public class SaveCustum : MonoBehaviour {


	public void SaveCustumTank(){
	
		SaveInformation.GameInformationStore (TurretCustom.TurretNum, HullCustom.HullNum, WheelsCustom.WheelNum, TankButtons.selectedTank, BottomButtons.TankSavedName, ChooseColor.ColorNum, DecalCustom.DecalNum, SkilsSet.BeautyNum, SkilsSet.FirePowerNum, SkilsSet.DurabilityNum);
// 			GameInformationStore(int TurretID, int HullID, int WheelsID, int Slot, string PlayerName,int ColorID, int DecalID, int BeautyRating, int FirePowerRating, int DurabilityRating )
		SaveInformation.StarRatingInformationStore (TankButtons.selectedTank, 0);

		Application.LoadLevel ("ChooseTank");

	}
	

}
