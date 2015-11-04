using UnityEngine;
using System.Collections;

public class BeginShowdown : MonoBehaviour {

	public Vector3 finalPos;
	public bool calledMethod;

	// Use this for initialization
	void Start () {
		finalPos = new Vector3 (-6, 0, -1);
		calledMethod = false;
	
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position == finalPos && !calledMethod) {
			GetComponent<Animator>().enabled = false;
			GameObject.Find("#Gamehandler").GetComponent<QuickDraw>().StartTimer();
			calledMethod = true;
		}
	
	}
}
