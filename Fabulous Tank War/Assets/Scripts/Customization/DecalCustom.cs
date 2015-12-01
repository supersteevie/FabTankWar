using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DecalCustom : MonoBehaviour {

	public Texture getto;
	public static int DecalNum = 0;

	
	void Start(){

		DecalNum = GameInformation.DecalID;


		if (DecalNum == 0) {
			this.gameObject.GetComponent<MeshRenderer>().material.SetTexture("_Decal", null);

		}
		if (DecalNum == 1) {
			this.gameObject.GetComponent<MeshRenderer>().material.SetTexture ("_Decal", getto);
				

		}


	}



	public void ChooseNone(){

		DecalNum = 0;
		this.gameObject.GetComponent<MeshRenderer>().material.SetTexture("_Decal", null);

	}

	public void ChooseGhetto(){

		DecalNum = 1;
		this.gameObject.GetComponent<MeshRenderer>().material.SetTexture ("_Decal", getto);

	}

	public void ChooseRichKid(){

		DecalNum = 2;
		
	}
	public void ChooseCrazy(){

		DecalNum = 3;
		
	}

}
