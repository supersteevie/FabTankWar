using UnityEngine;
using System.Collections;

public class DontNoDestroy : MonoBehaviour {

	private bool isOn = true;
	// Use this for initialization
	void Start () {
		DontDestroyOnLoad(this.gameObject);
	}
}
