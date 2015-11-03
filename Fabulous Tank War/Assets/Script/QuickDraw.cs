using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class QuickDraw : MonoBehaviour {

	public Image exclaim;
	public GameObject bulletPrefab;
	public bool hasShot;
	public GameObject player;
	public GameObject enemy;
	public Text resultText;
	public GameObject panel;
	public bool firedEarly;

	void Start () 
	{
		Invoke ("ExclaimShow", Random.Range(5f,10f));
	}
	void ExclaimShow()
	{
		exclaim.enabled = true;
	}

	void Update()
	{
		if (exclaim.isActiveAndEnabled && Input.GetAxis("Fire1") > 0 && !hasShot && !firedEarly) 
		{
			GameObject bullet = Instantiate (bulletPrefab, transform.position, transform.rotation) as GameObject; 
			Physics.IgnoreCollision(bullet.GetComponent<Collider>(), player.GetComponent<Collider>());
			bullet.GetComponent<Rigidbody> ().AddForce (bullet.transform.forward * 2000f);
			Destroy(bullet, .5f);
			hasShot = true;
			exclaim.enabled = false;
			panel.SetActive(true);
			resultText.text = "You Won! :D";
		}

		if (exclaim.isActiveAndEnabled) 
		{
			StartCoroutine(EnemyDelay(Random.Range(0.25f, 0.5f)));
		}

		if (!exclaim.isActiveAndEnabled && Input.GetAxis("Fire1") > 0 && !hasShot) 
		{
			GameObject bullet = Instantiate (bulletPrefab, transform.position - transform.forward * 10, transform.rotation) as GameObject;
			bullet.GetComponent<Rigidbody> ().AddForce (bullet.transform.forward * 2000f);
			bullet.GetComponent<MeshRenderer>().enabled = false;
			Destroy(bullet, .5f);
			hasShot = true;
			exclaim.enabled = false;			
			panel.SetActive(true);
			resultText.text = "You shot too soon, You Lost!";
			firedEarly = true;
		}
	}

	IEnumerator EnemyDelay(float t)
	{
		yield return new WaitForSeconds (t);
		if (!hasShot) 
		{
			GameObject bullet = Instantiate (bulletPrefab, new Vector3(-transform.position.x, transform.position.y, transform.position.z), Quaternion.Euler(0,-90,0)) as GameObject; 
			Physics.IgnoreCollision (bullet.GetComponent<Collider> (), enemy.GetComponent<Collider> ());
			bullet.GetComponent<Rigidbody> ().AddForce (bullet.transform.forward * 2000f);
			Destroy (bullet, .5f);
			hasShot = true;
			exclaim.enabled = false;			
			panel.SetActive(true);
			resultText.text = "You Lost! :(";
		}
	}

	public void Restart()
	{
		Application.LoadLevel (0);
	}
}
