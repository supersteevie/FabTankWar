using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SplatEffectFade : MonoBehaviour {

	public Image splatterImage;
	public Color lerpedColor;

	public void DoSplatter()
	{
		lerpedColor = splatterImage.color;
		lerpedColor.a = 1;
		splatterImage.color = lerpedColor;
		StartCoroutine (SplatterFader());
	}

	IEnumerator SplatterFader ()
	{
		Color targetColor = lerpedColor;
		targetColor.a = 0;
		while (splatterImage.color.a > .001f) 
		{
			lerpedColor = Color.Lerp(lerpedColor, targetColor, Time.deltaTime);
			splatterImage.color = lerpedColor;
			yield return null;
		}
		lerpedColor.a = 0;
		splatterImage.color = lerpedColor;
		yield return null;
		gameObject.SetActive (false);
	}

}
