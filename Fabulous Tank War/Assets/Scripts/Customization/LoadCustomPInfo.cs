using UnityEngine;
using System.Collections;

public class LoadCustomPInfo : MonoBehaviour {

	// Use this for initialization
	void Start () {
		LoadInformation.LoadAllInfomation (TankButtons.selectedTank);

	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
