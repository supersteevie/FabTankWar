using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ColorCustom : MonoBehaviour {
	public int iterator = 0;

	public void buttonClick () {
		iterator += 1;

		if (iterator == 1) 
			setPink ();

		if (iterator == 2) 
			setMagenta ();

		if (iterator == 2)
			iterator = 0; 

	}


	public void setPink () {

		foreach (Renderer rend in GetComponentsInChildren<Renderer>()) 
		{
			rend.material.color = Color.red + Color.white;
		}
	}

	public void setMagenta () {
		foreach (Renderer rend in GetComponentsInChildren<Renderer>()) 
		{
			rend.material.color = Color.magenta;
		}
	}
	
	}



