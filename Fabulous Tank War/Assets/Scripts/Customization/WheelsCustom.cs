using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WheelsCustom : MonoBehaviour {

	//allows the gun barrels to be switched//
	bool WheelSwap;
	public GameObject wheels01;
	public GameObject wheels02;
	
	public void WheelSwitch()
	{
		WheelSwap = !WheelSwap;
		wheels01.SetActive(!WheelSwap);
		wheels02.SetActive(WheelSwap);
	}
}

