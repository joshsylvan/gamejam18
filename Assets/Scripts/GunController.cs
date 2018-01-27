using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour {

	public enum gunType {pistol, shotgun};

	private gunType equippedGunType = gunType.pistol;

	public GameObject pistolBullet;
	public GameObject shotgunBullet;

	private bool pistolObtained = true;
	public bool PistolObtained {
		get {return pistolObtained;}
		set {pistolObtained = value;}
	}
	private bool shotgunObtained;
	public bool ShotgunObtained {
		get {return shotgunObtained;}
		set {shotgunObtained = value;}
	}

	private int pistolAmmo = 3;
	public int PistolAmmo {
		get {return pistolAmmo;}
		set {pistolAmmo = value;}

	}
	private int shotgunAmmo = 0;
	public int ShotgunAmmo {
		get {return shotgunAmmo;}
		set {shotgunAmmo = shotgunAmmo + value;}
	}

	private float pistolFireRateSeconds = 0.5f;		//how often you can fire a bullet
	private float shotgunFireRateSeconds = 0.9f;


	private float timeElapsedSinceLastShot;

	public GameObject ammoUI;


	// Use this for initialization
//	void Start () {
//		
//	}
	
	// Update is called once per frame
	void Update () {

		timeElapsedSinceLastShot += Time.deltaTime;

		float xJoyStixDirection = XboxCtrlrInput.XCI.GetAxis(XboxCtrlrInput.XboxAxis.RightStickX);
		float yJoyStixDirection = XboxCtrlrInput.XCI.GetAxis(XboxCtrlrInput.XboxAxis.RightStickY);

		float rightTriggerPressed = XboxCtrlrInput.XCI.GetAxis (XboxCtrlrInput.XboxAxis.RightTrigger);

//		Debug.Log ("rightTriggerPressed: " + rightTriggerPressed);

		if (rightTriggerPressed > 0.3f) {																						//if the player is holding down the right trigger
			if (yJoyStixDirection > 0.5 || yJoyStixDirection < -0.5 || xJoyStixDirection > 0.5 || xJoyStixDirection < -0.5) {	//and if the player is holding the joystick to shoot

				float angle = Mathf.Atan2 (yJoyStixDirection, xJoyStixDirection);			//then calculate the angle at which the right joystick is rotated towards
				Vector3 gunRotation = new Vector3 (0, 0, angle * Mathf.Rad2Deg + 90);

				transform.rotation = Quaternion.Euler (0, 0, angle * Mathf.Rad2Deg + 90);	//and as the player is currently shooting rotate the gun to this angle


				FireGun ();
			}
		}
		else {
			//TODO: turn torch on
		}


		Debug.Log("y: " + XboxCtrlrInput.XCI.GetButtonDown(XboxCtrlrInput.XboxButton.Y));

		if (XboxCtrlrInput.XCI.GetButtonDown (XboxCtrlrInput.XboxButton.Y)) {		//if Y button is pressed

			if (equippedGunType == gunType.pistol && shotgunObtained) {		//if pistol is equipped and also have a shotgun

				equippedGunType = gunType.shotgun;

				ammoUI.transform.GetChild (0).gameObject.SetActive (false);
				ammoUI.transform.GetChild (1).gameObject.SetActive (true);
			} else if (equippedGunType == gunType.shotgun && pistolObtained) {

				equippedGunType = gunType.pistol;

				ammoUI.transform.GetChild (1).gameObject.SetActive (false);
				ammoUI.transform.GetChild (0).gameObject.SetActive (true);

			}


			//equippedGunType

		}


	}




	private void FireGun() {
		switch (equippedGunType) {

		case gunType.pistol:
			if (pistolAmmo > 0) {											//if you have remaining pistol ammo
				if (timeElapsedSinceLastShot > pistolFireRateSeconds) {		//and if enough time has passed that you can shoot again

					GameObject newBullet = Instantiate (pistolBullet, /*this.transform.GetChild (0).transform*/this.transform.root) as GameObject;	//instantiate a new bullet
					Rigidbody2D bulletRigidBody = newBullet.GetComponent<Rigidbody2D> ();				//get the rigidbody so force can be applied to it
					bulletRigidBody.AddForce (-this.transform.up * 400f);

					pistolAmmo--;
					timeElapsedSinceLastShot = 0;														//reset the time counter
				}
			}
			break;

		case gunType.shotgun:
			if (shotgunAmmo > 0) {											//if you have remaining pistol ammo
				if (timeElapsedSinceLastShot > shotgunFireRateSeconds) {		//and if enough time has passed that you can shoot again




				}
			}

			break;

		}
	}
}
