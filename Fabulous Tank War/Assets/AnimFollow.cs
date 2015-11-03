using UnityEngine;
using System.Collections;

public class AnimFollow : MonoBehaviour {

	public bool lookAtPlyr;
	public bool animPlay;
	public Transform player;

	// Use this for initialization
	void Start () {
		lookAtPlyr = true;
		animPlay = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (lookAtPlyr == true)
			transform.LookAt (player);
		//if (animPlay == false)

	}
}
