using UnityEngine;
using System.Collections;

public class DontNoDestroy : MonoBehaviour {

	private bool isOn = true;
	public AudioClip titleMusic;
	public AudioClip GarageMusic;
	public AudioClip RunwayMusic;
	// Use this for initialization
	void Start () {
		DontDestroyOnLoad(this.gameObject);
	}

	void Update()
	{
		if (Application.loadedLevel == 0) 
		{
			GetComponent<AudioSource>().clip = GarageMusic;
		}
		else if (Application.loadedLevel == 1 || Application.loadedLevel == 4) 
		{
			GetComponent<AudioSource>().clip = titleMusic;
		}
		else if (Application.loadedLevel == 2) 
		{
			GetComponent<AudioSource>().clip = RunwayMusic;
		}

		if(!GetComponent<AudioSource>().isPlaying)
			GetComponent<AudioSource>().Play();
	}
}
