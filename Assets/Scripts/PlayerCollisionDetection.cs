using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionDetection : MonoBehaviour {

	private bool playerInvincible;

	void OnCollisionEnter2D(Collision2D coll) {

		switch (coll.gameObject.tag) {

		case "Collectable": 
			Collectable collectedCollectable = coll.gameObject.GetComponent<Collectable> ();

			if (collectedCollectable.collectableType == Collectable.CollectableType.ammo) {
				CollectedAmmo (coll.gameObject);
				Debug.Log ("collected ammo");
				Destroy (coll.gameObject);
			} else if (collectedCollectable.collectableType == Collectable.CollectableType.health) {
				gameObject.GetComponent<PlayerHealth> ().IncreaseHealth (coll.gameObject.GetComponent<HealthArmourCollectable> ().healthCount);
				Debug.Log ("collected health");
				Destroy (coll.gameObject);
			} else if (collectedCollectable.collectableType == Collectable.CollectableType.armour) {
				gameObject.GetComponent<PlayerHealth> ().IncreaseArmour (coll.gameObject.GetComponent<HealthArmourCollectable> ().healthCount);
				Debug.Log ("collected armour");
				Destroy (coll.gameObject);
			}

			break;


		case "Enemy":

			if (!playerInvincible) {

				GetComponent<PlayerHealth> ().DecreaseHealth (coll.transform.GetComponent<EnemyStats> ().damage);	//apply damage to player
				StartCoroutine (TriggerImmunity ());

			}

				#region Push enemy that hit the player away
				var magnitude = 0.2f;
				var force = transform.position - coll.transform.position;
				force.Normalize ();
				coll.transform.GetComponent<Rigidbody2D> ().AddForce (-force * magnitude);
				#endregion

			break;

			}


		}




	private IEnumerator TriggerImmunity() {
		float timeElapsed = 0f;
		playerInvincible = true;
		while (timeElapsed < 1.0f) {
			if (PlayerHealth.isPlayerAlive) {
				transform.GetComponent<SpriteRenderer> ().color = new Color32 (255, 0, 0, 255);

				yield return new WaitForSeconds (0.1f);

				transform.GetComponent<SpriteRenderer> ().color = new Color32 (255, 255, 255, 255);

				yield return new WaitForSeconds (0.1f);

				timeElapsed += 0.2f;
			} else {
				timeElapsed = 1f;
			}
		}

		transform.GetComponent<SpriteRenderer> ().color = new Color32 (255, 255, 255, 255);
		playerInvincible = false;
	}


	private void CollectedAmmo(GameObject CollectedItem) {
		GunController gunController = gameObject.transform.GetChild(0).GetComponent<GunController> ();		//the class the ammo will be added to
		CollectableAmmo colAmmo = CollectedItem.GetComponent<CollectableAmmo>();	//the collectable's class containing the amount of ammo and gun type


		if (CollectedItem.GetComponent<CollectableAmmo>().type == GunController.gunType.pistol) {
				gunController.PistolAmmo += colAmmo.ammoCount;
				gunController.PistolObtained = true;
		}
		else if (CollectedItem.GetComponent<CollectableAmmo>().type == GunController.gunType.shotgun) {
			gunController.ShotgunAmmo += colAmmo.ammoCount;
			gunController.ShotgunObtained = true;
		}

	}

}
