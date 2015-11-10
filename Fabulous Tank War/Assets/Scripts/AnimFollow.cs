﻿using UnityEngine;
using System.Collections;

public class AnimFollow : MonoBehaviour {

	public bool lookAtPlyr;
	public bool animPlay;
	public Transform player;

    public Vector3 start;
    public Vector3 midpoint;
    public Vector3 end;
    public float smoothing;

    public Vector3 newPos;

	// Use this for initialization
	void Start () {
        newPos = midpoint;
		animPlay = true;
        smoothing = GameObject.Find("PlayerTank").GetComponent<BeginShowdown>().smoothing;
        transform.position = start;
	}
	
	// Update is called once per frame
	void Update () {
		if (lookAtPlyr == true)
			transform.LookAt (player);
        //if (animPlay == false)
            
	}

    public void GoCamera ()
    {

        if (GameObject.Find("PlayerTank").GetComponent<BeginShowdown>().stage < 2)
        {
            newPos = midpoint;
        }
        StartCoroutine(CameraMoving(newPos));
    }

    IEnumerator CameraMoving (Vector3 target)
    {
        while (Vector3.Distance(transform.position, target) > 0.05f)
        {
            transform.position = Vector3.Lerp(transform.position, target, smoothing * Time.deltaTime);

            yield return null;
        }
        //transform.position = target;
        yield return null;
    }
}
