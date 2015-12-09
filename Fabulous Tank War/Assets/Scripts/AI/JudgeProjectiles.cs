using UnityEngine;
using System.Collections;

//This script is attacted to projectile prefab
//There will be a single prefab for ALL projectiles
//This script will also handle the graphics
public class JudgeProjectiles : MonoBehaviour {

    //Target
    Transform target;
	Vector3 targetPositionAtFire;
    //Bullet's Orgin
    Vector3 orgin;
    //How long it stays airborune;
    float transitTime;
    //Variable to record how far its currently traveled
    float distanceCovered;
    //Control point for the arch
    Vector3 controlPoint;
    //Destory if projectile been alive too long
    float deathTimer;

	public void FireProjectile (Transform tar, float time, ProjectileType type, bool isHoming)
	{
		GameObject particle;
		particle = Instantiate (Resources.Load ("FireParticle") as GameObject, transform.position + Vector3.forward * 2, transform.rotation) as GameObject;
        //Saved values i
		GameObject cloneTarget;
		cloneTarget = new GameObject ();
		cloneTarget.transform.position = tar.position;
		if (!isHoming)
			tar = cloneTarget.transform;
        orgin = transform.position;
		targetPositionAtFire = transform.position;
        target = tar;
        transitTime = time + 1;
		Destroy (particle, time);
        distanceCovered = 0;
        transform.LookAt(tar);
        //Calulate control point based on information given
        controlPoint = Vector3.Lerp(orgin, target.position, 0.5f);
        controlPoint += Vector3.up * (Vector3.Distance(orgin, tar.position) / 2);
        //Start the Event
		StartCoroutine (StartEvent (type));
        deathTimer = transitTime;
	}

	IEnumerator StartEvent (ProjectileType type)
	{
        //While traveling towards the target
        while (Vector3.Distance(transform.position, target.position) >= .25f)
        {
            //If its a missle type
            if (type == ProjectileType.Missle)
            {
				distanceCovered += Time.deltaTime;
                float fracJour = distanceCovered / transitTime;
                transform.position = Vector3.Lerp(orgin, target.position, fracJour);
                yield return null;
            }
            //If its a bomb type
            else if (type == ProjectileType.Bomb)
            {
				distanceCovered += Time.deltaTime;
                float fracJour = distanceCovered / transitTime;
                transform.position = BezierVec3(orgin, controlPoint, target.position, fracJour);
                yield return null;
            }
            //Or if its not yet programmed, destory the object
            else
            {
                print("Projectile type has not algorithm.");
                Destroy(this.gameObject);
            }

            deathTimer -= Time.deltaTime;
            if (deathTimer <= 0)
            {
                print("Projectile has lived too long.");
                Destroy(this.gameObject);
            }

            if(Vector3.Dot(transform.forward, target.position - transform.position) < 0)
            {
                print("Projectile passed its target");
                Destroy(this.gameObject);
            }
        }
        ResolveProjectile();
	}

    //The command to resolve the projectile if an event happens
    //Can be expanded upon once graphics are added
    public void ResolveProjectile()
    {
        Destroy(this.gameObject);
    }

     public Vector3 BezierVec3(Vector3 start, Vector3 height, Vector3 end , float time)
     {
         return (((1-time)*(1-time)) * start) + (2 * time * (1 - time) * height) + ((time * time) * end);
     }
}
