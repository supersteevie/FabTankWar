using UnityEngine;
using System.Collections;

public class AnimationHandler : MonoBehaviour {
		
	public Animator tanka;
	public Animator tankb;
	public Animator tankc;
	public Animator tankd;

	public void JumpLeft()
	{
		tanka.SetBool ("Left", true);
		tankb.SetBool ("Left", true);
		tankc.SetBool ("Left", true);
		tankd.SetBool ("Left", true);
		StartCoroutine (RunJumps ());
	}
	public void JumpRight()
	{
		tanka.SetBool ("Right", true);
		tankb.SetBool ("Right", true);
		tankc.SetBool ("Right", true);
		tankd.SetBool ("Right", true);
		StartCoroutine (RunJumps ());
	}
	public void isForward()
	{
		tanka.SetBool ("isMoving", true);
		tankb.SetBool ("isMoving", true);
		tankc.SetBool ("isMoving", true);
		tankd.SetBool ("isMoving", true);
	}

	public void isIdle()
	{
		tanka.SetBool ("isMoving", false);
		tankb.SetBool ("isMoving", false);
		tankc.SetBool ("isMoving", false);
		tankd.SetBool ("isMoving", false);
	}

	public IEnumerator RunJumps()
	{
		yield return new WaitForSeconds(.5f);
		tanka.SetBool ("Right", false);
		tankb.SetBool ("Right", false);
		tankc.SetBool ("Right", false);
		tankd.SetBool ("Right", false);
		tanka.SetBool ("Left", false);
		tankb.SetBool ("Left", false);
		tankc.SetBool ("Left", false);
		tankd.SetBool ("Left", false);
	}
}
