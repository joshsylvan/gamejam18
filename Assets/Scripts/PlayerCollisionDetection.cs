using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionDetection : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {



	}


	void OnCollisionEnter2D(Collision2D coll) {

		switch (coll.gameObject.tag) {

		case "Collectable": 
			Collectable collectedCollectable = coll.gameObject.GetComponent<Collectable> ();

			if (collectedCollectable.collectableType == Collectable.CollectableType.ammo) {
				CollectedAmmo (coll.gameObject);
				Debug.Log ("collected ammo");
				Destroy (coll.gameObject);
			}

			break;


		case "Enemy":

			break;

		}


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
