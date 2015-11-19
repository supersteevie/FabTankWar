using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HullCustom : MonoBehaviour {

	//allows the gun barrels to be switched//
	bool HullSwap;
	public GameObject Hull01;
	public GameObject Hull02;
	
	public void HullSwitch()
	{
		HullSwap = !HullSwap;
		Hull01.SetActive(!HullSwap);
		Hull02.SetActive(HullSwap);
	}
}
