using UnityEngine;
using System.Collections;

public class BulletHit : MonoBehaviour {

	public GameObject particle;
	public AudioSource boom;

	void OnCollisionEnter(Collision col)
	{
		GameObject part = Instantiate (particle, transform.position, transform.rotation) as GameObject;
		boom.Play ();
		Destroy (part, part.GetComponent<ParticleSystem>().startLifetime);
	}
}
