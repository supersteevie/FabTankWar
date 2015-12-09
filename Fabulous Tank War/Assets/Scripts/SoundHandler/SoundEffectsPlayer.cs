using UnityEngine;
using System.Collections;

public static class SoundEffectsPlayer {

	public static void PlayAudio(SoundEffects a)
	{
		GameObject go = GameObject.Find ("SFXHandler");
		if (a == SoundEffects.TankFire)
			go.GetComponent<SFXHandler> ().GunFire (0);
		else if (a == SoundEffects.TurretFire)
			go.GetComponent<SFXHandler> ().GunFire (1);
		else if (a == SoundEffects.TankSounds)
			go.GetComponent<SFXHandler> ().PlayAmbience ();
		else if (a == SoundEffects.SplatA)
			go.GetComponent<SFXHandler> ().PlaySplat ();
	}

}

public enum SoundEffects
{
	TankFire,
	TurretFire,
	TankSounds,
	SplatA,
}
