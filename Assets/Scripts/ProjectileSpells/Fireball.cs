using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;


public class Fireball : MonoBehaviour
{
	private ContactPoint point;
	private GameObject impactPrefab;
    public float damage = 10;
    public float speed = 7;
	//private float duration, radius, damage, projectileSpeed, explosionForce;

	void Start () {
		impactPrefab = Resources.Load ("FireImpactMega", typeof(GameObject))as GameObject;
	}

	void OnCollisionEnter(Collision col){
        //point = col.contacts [0];
        Debug.Log("Fireball Attacked");
        var hit = col.gameObject;
        var health = hit.GetComponent<HealthbarController>();
        if (health != null)
        {
            Debug.Log("Damaging player");
            health.TakeDamage(damage);
        }
        if (health == null)
        {
            Debug.Log("Cannot find healthbar");
        }
        Destroy (gameObject);
	}

	void OnDestroy(){
		GameObject go = (GameObject)Instantiate (impactPrefab, gameObject.transform.position, gameObject.transform.rotation);
		Vector3 explosionPoint;
		explosionPoint = gameObject.transform.position;
		//Collider[] colliders = Physics.OverlapSphere (explosionPoint,Radius);
		//Dictionary<string,float> messages = new Dictionary<string,float> ();
		//messages.Add ("TakeDamage", damage);
		//explosionScan (messages, colliders, explosionPoint);
		Destroy (go, 1);
	}

	// Update is called once per frame
	void Update () {
		transform.Translate (Vector3.forward*Time.deltaTime*speed);
    }
}
