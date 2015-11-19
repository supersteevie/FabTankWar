using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ColorCustom : MonoBehaviour {
	public int iterator = 0;

	public void buttonClick () {
		iterator += 1;

		if (iterator == 1) 
			setGreen ();

		if (iterator == 2) 
			setBlue ();

		if (iterator == 3) 
			setMagenta ();

		if (iterator == 3)
			iterator = 0; 

	}


	public void setGreen () {

		foreach (Renderer rend in GetComponentsInChildren<Renderer>()) 
		{
			rend.material.color = Color.green;
		}
	}

	public void setMagenta () {
		foreach (Renderer rend in GetComponentsInChildren<Renderer>()) 
		{
			rend.material.color = Color.magenta;
		}
	}
	public void setBlue () {
		foreach (Renderer rend in GetComponentsInChildren<Renderer>()) 
		{
			rend.material.color = Color.blue;
		}
		
	}


}
