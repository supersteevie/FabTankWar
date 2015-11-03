using UnityEngine;
using System.Collections;

public class BulletHit : MonoBehaviour {

	public GameObject particle;

	void OnCollisionEnter(Collision col)
	{
		GameObject part = Instantiate (particle, transform.position, transform.rotation) as GameObject;
		Destroy (part, part.GetComponent<ParticleSystem>().startLifetime);
	}
}
