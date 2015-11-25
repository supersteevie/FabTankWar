using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DecalCustom : MonoBehaviour {


	public static int DecalNum = 0;


	
	void Start(){
		if (GameInformation.PlayerName != "Empty") {
			DecalNum = GameInformation.DecalID;
		}
	
	}



	public void ChooseNone(){
		DecalNum = 0;

	}

	public void ChooseGhetto(){
		DecalNum = 1;
		
	}
	public void ChooseRichKid(){
		DecalNum = 2;
		
	}
	public void ChooseCrazy(){
		DecalNum = 3;
		
	}

}
