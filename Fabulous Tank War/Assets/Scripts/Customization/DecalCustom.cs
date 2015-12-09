﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DecalCustom : MonoBehaviour {

	public Texture getto;
	public Texture richKid;
	public Texture Crazy;
	public static int DecalNum;

	
	void Start(){

		DecalNum = GameInformation.DecalID;


		if (DecalNum == 0) {
			this.gameObject.GetComponent<SkinnedMeshRenderer>().material.SetTexture("_Decal", null);

		}
		if (DecalNum == 1) {
			this.gameObject.GetComponent<SkinnedMeshRenderer>().material.SetTexture ("_Decal", getto);
				

		}
		if (DecalNum == 2) {
			this.gameObject.GetComponent<SkinnedMeshRenderer>().material.SetTexture ("_Decal", richKid);
			
			
		}
		if (DecalNum == 3) {
			this.gameObject.GetComponent<SkinnedMeshRenderer>().material.SetTexture ("_Decal", Crazy);
			
			
		}


	}



	public void ChooseNone(){

		DecalNum = 0;
		this.gameObject.GetComponent<SkinnedMeshRenderer>().material.SetTexture("_Decal", null);

	}

	public void ChooseGhetto(){

		DecalNum = 1;
		this.gameObject.GetComponent<SkinnedMeshRenderer>().material.SetTexture ("_Decal", getto);

	}

	public void ChooseRichKid(){

		DecalNum = 2;
		this.gameObject.GetComponent<SkinnedMeshRenderer>().material.SetTexture ("_Decal", richKid);
		
	}
	public void ChooseCrazy(){

		DecalNum = 3;
		this.gameObject.GetComponent<SkinnedMeshRenderer>().material.SetTexture ("_Decal", Crazy);
	}

}
