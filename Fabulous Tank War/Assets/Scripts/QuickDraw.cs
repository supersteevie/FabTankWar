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
	public bool hasStarted;

	public AudioSource music;
	public AudioSource ping;
	public AudioSource boom;
	public AudioSource dance;


	void Start()
	{
        hasShot = false;
	int a = Random.Range (0, 2);
		switch (a) 
		{
		case 0:
			music.Play();
			break;
		case 1:
			dance.Play();
			break;
		}
	}
	public void StartTimer () 
	{
		Invoke ("ExclaimShow", Random.Range(5f,10f));
		hasStarted = true;
        player.GetComponent<Rigidbody>().isKinematic = false;
	}
	void ExclaimShow()
	{
		if (!firedEarly) {
			ping.Play ();
			exclaim.enabled = true;
		}
	}

	void Update()
	{
		if (hasStarted) {

			if(music.volume >= 0.2f && !panel.activeSelf)
			{
				music.volume -= Time.deltaTime / 5f;
				dance.volume -= Time.deltaTime / 5f;
			}

			if(panel.activeSelf && boom.volume >= 0)
			{
				boom.volume -= Time.deltaTime / 5f;
				dance.volume -= Time.deltaTime / 5f;
			}
			
			
			if (exclaim.isActiveAndEnabled && Input.GetAxis ("Fire1") > 0 && !hasShot && !firedEarly) {
				GameObject bullet = Instantiate (bulletPrefab, transform.position, transform.rotation) as GameObject; 
				Physics.IgnoreCollision (bullet.GetComponent<Collider> (), player.GetComponent<Collider> ());
				bullet.GetComponent<Rigidbody> ().AddForce (bullet.transform.forward * 2000f);
				Destroy (bullet, .5f);
				hasShot = true;
				exclaim.enabled = false;
				resultText.text = "OH SNAP!";
                panel.SetActive(true);
                boom.Play();
			}

			if (exclaim.isActiveAndEnabled) {
				StartCoroutine (EnemyDelay (Random.Range (0.35f, 0.5f)));
			}

			if (!exclaim.isActiveAndEnabled && Input.GetAxis ("Fire1") > 0 && !hasShot) {
				GameObject bullet = Instantiate (bulletPrefab, transform.position - transform.forward * 10, transform.rotation) as GameObject;
				bullet.GetComponent<Rigidbody> ().AddForce (bullet.transform.forward * 2000f);
				bullet.GetComponent<MeshRenderer> ().enabled = false;
				Destroy (bullet, .5f);
				hasShot = true;
				exclaim.enabled = false;			
				resultText.text = "Got a little excited there, eh?";
				firedEarly = true;
				music.mute = true;
                panel.SetActive(true);
                boom.Play();
			}
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
			resultText.text = "Haha... loser.";
			boom.Play();
		}
	}

	public void Restart()
	{
		Application.LoadLevel (1);
	}
}
