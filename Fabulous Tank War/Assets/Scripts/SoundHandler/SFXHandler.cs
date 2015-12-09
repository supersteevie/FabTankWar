using UnityEngine;
using System.Collections;

public class SFXHandler : MonoBehaviour {

	public AudioSource fireSource;
	public AudioClip tankFire;
	public AudioClip turretFire;
	public AudioSource ambianceTank;
	public AudioClip tankSounds;
	public AudioClip splat;

	public void PlayAmbience()
	{
		ambianceTank.clip = tankSounds;
		ambianceTank.Play ();
	}
	public void GunFire(int i)
	{
		if (i == 0) 
		{
			fireSource.clip = tankFire;
			fireSource.Play ();
		}
		if (i == 1) 
		{
			fireSource.clip = turretFire;
			fireSource.Play ();
		}
	}
	public void PlaySplat()
	{
		fireSource.clip = splat;
		fireSource.Play ();
	}
}
