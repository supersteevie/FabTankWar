using UnityEngine;
using System.Collections;

public class DelegateExample : MonoBehaviour
{

	// Use this for initialization
	void Start ()
	{
		StartCoroutine (BaseCoroutine ());
	}

	IEnumerator BaseCoroutine ()
	{

		for(int i = 0; i<3 ; i++)
		{
			CoroutineDelegate del = GetFunction();
			yield return StartCoroutine(del());
		}

		print ("Done");
	}

	CoroutineDelegate GetFunction ()
	{
		int rand = Random.Range (0, 2);
		CoroutineDelegate del = null;
		switch (rand) {
		case 0:
			del = Action1;
			break;
		case 1:
			del = Action2;
			break;
		case 2:
			del = Action3;
			break;
		}

		return del;

	}




	delegate IEnumerator CoroutineDelegate ();

	IEnumerator Action1 ()
	{
		print ("Action1");
		yield return new WaitForSeconds (3);
		print ("Action1 Done");
	}

	IEnumerator Action2 ()
	{
		print ("Action2");
		yield return new WaitForSeconds (3);
		print ("Action2 Done");
	}

	IEnumerator Action3 ()
	{
		print ("Action3");
		yield return new WaitForSeconds (3);
		print ("Action3 Done");
	}


}
