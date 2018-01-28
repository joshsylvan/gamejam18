using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolBullet : MonoBehaviour {

	public float damage;
	public bool isRocket;

	public GameObject explosion01;
	public GameObject explosion02;

	// Use this for initialization
	void Start () {
		Destroy (this.gameObject, 1.5f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	void OnCollisionEnter2D(Collision2D other) {

//		Debug.Log ("collided with something");

		switch (other.gameObject.tag) {

//		Vector3 transform = other.gameObject.

		case "Enemy": 
			other.gameObject.GetComponent<EnemyStats> ().Health -= damage;

			if (other.gameObject.GetComponent<EnemyStats> ().Health <= 0) {
				//TODO: play death animation then destroy
//				Destroy (other.gameObject);
				other.gameObject.GetComponent<EnemyStats> ().TriggerDeathAnimation();
			}
			Destroy (this.gameObject);

			break;

		case "Wall":
			Destroy (this.gameObject);		//hits the walls and breaks
			break;
		}

		if (isRocket) {
			int explosionSelect = Random.Range (0, 2);

			if (explosionSelect == 0) {
				GameObject explosion = Instantiate (explosion01, this.transform.position, Quaternion.identity) as GameObject;	//instantiate a new bullet
				Destroy (explosion, 1f);
			} else if (explosionSelect == 1) {
				GameObject explosion = Instantiate (explosion02, this.transform.position, Quaternion.identity) as GameObject;	//instantiate a new bullet
				Destroy (explosion, 1f);
			}
		}
	}


}
