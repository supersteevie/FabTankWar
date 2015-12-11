using UnityEngine;
using System.Collections;

public class TankSpin : MonoBehaviour {
	
	public float rotationSpeed = 10.0f;
	public float lerpSpeed = 1.0f;
	private bool dragging;
	
	private Vector3 speed;
	private Vector3 avgSpeed;
	private Vector3 targetSpeedX;

	private Vector2 lastTouch;

	
	void Update () 
	{
		float inputX = 0;
		if (Input.mousePosition.y > Screen.height * .3333f) 
		{
			if (lastTouch.x > Input.mousePosition.x)
				inputX = -1;
			if (lastTouch.x < Input.mousePosition.x)
				inputX = 1;
		}
		//Globe rotates according to user
		if (Input.GetMouseButton(0)) {
			speed = new Vector3(-inputX, 0, 0);
			avgSpeed = Vector3.Lerp(avgSpeed,speed,Time.deltaTime * 5);
		} 
		else 
		{
			speed = avgSpeed;
			dragging = false;
			float i = Time.deltaTime * lerpSpeed;
			speed = Vector3.Lerp( speed, Vector3.zero, i);   
		}
		
		transform.Rotate( Vector3.up * speed.x * rotationSpeed);
		
		//Globe rotates on own when it's lost all friction from rotating from user
		if (speed.x <= 1 )
			transform.Rotate(0, Time.smoothDeltaTime * 5, 0, Space.Self);
		
		lastTouch = Input.mousePosition;
		
	}
	
}

