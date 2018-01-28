using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolBullet : MonoBehaviour {

	public float damage;

	// Use this for initialization
	void Start () {
		Destroy (this, 5f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	void OnCollisionEnter2D(Collision2D other) {

//		Debug.Log ("collided with something");

		switch (other.gameObject.tag) {

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
	}


}
