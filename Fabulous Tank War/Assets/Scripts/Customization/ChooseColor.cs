using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ChooseColor : MonoBehaviour {

	public static int ColorNum;
	// Use this for initialization
	void Start () {
		if (GameInformation.PlayerName != "Empty") {
			ColorNum = GameInformation.ColorID;

			if(ColorNum == 1){
				foreach (Renderer rend in GetComponentsInChildren<Renderer>(true)) 
				{
					rend.material.color = Color.red + Color.white;
				}
			}
			if(ColorNum == 2){
				foreach (Renderer rend in GetComponentsInChildren<Renderer>(true)) 
				{
					rend.material.color = Color.magenta;
				}
			}
			if(ColorNum == 3){
				foreach (Renderer rend in GetComponentsInChildren<Renderer>(true)) 
				{
					rend.material.color = Color.red + Color.yellow;
				}
			}
		
			if(ColorNum == 4){
				foreach (Renderer rend in GetComponentsInChildren<Renderer>(true)) 
				{
					rend.material.color = Color.blue;
				}
			}
			if(ColorNum == 5){
				foreach (Renderer rend in GetComponentsInChildren<Renderer>(true)) 
				{
					rend.material.color = Color.green;
				}
			}
		}
	}

	public void changeColorPink(){
		ColorNum = 1;
		foreach (Renderer rend in GetComponentsInChildren<Renderer>(true)) 
		{
			rend.material.color = Color.red + Color.white;
		}
	}

	public void changeColorMagenta(){
		ColorNum = 2;
		foreach (Renderer rend in GetComponentsInChildren<Renderer>(true)) 
		{
			rend.material.color = Color.magenta;
		}
	}
	public void changeColorOrange(){
		ColorNum = 3;
		foreach (Renderer rend in GetComponentsInChildren<Renderer>(true)) 
		{
			rend.material.color = Color.red + Color.yellow;
		}
	}

	public void changeColorBlue(){
		ColorNum = 4;
		foreach (Renderer rend in GetComponentsInChildren<Renderer>(true)) 
		{
			rend.material.color = Color.blue;
		}
	}

	public void changeColorGreen(){
		ColorNum = 5;
		foreach (Renderer rend in GetComponentsInChildren<Renderer>(true)) 
		{
			rend.material.color = Color.green;
		}
	}
	

}
