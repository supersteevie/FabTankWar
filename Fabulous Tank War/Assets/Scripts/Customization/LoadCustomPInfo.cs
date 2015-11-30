using UnityEngine;
using System.Collections;

public class LoadCustomPInfo : MonoBehaviour {

	// Use this for initialization
	void Awake(){
		LoadInformation.LoadAllInfomation (TankButtons.selectedTank);
	}
	
	
	void Start () {
		LoadInformation.LoadAllInfomation (TankButtons.selectedTank);



	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
