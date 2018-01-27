using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour {

	private enum gunType {pistol, shotgun};

	private gunType thisGunType = gunType.pistol;

	public GameObject pistolBullet;



	private float pistolFireRateSeconds = 0.5f;

	private float timeElapsedSinceLastShot;

	// Use this for initialization
//	void Start () {
//		
//	}
	
	// Update is called once per frame
	void Update () {

		timeElapsedSinceLastShot += Time.deltaTime;

		float xJoyStixDirection = XboxCtrlrInput.XCI.GetAxis(XboxCtrlrInput.XboxAxis.RightStickX);
		float yJoyStixDirection = XboxCtrlrInput.XCI.GetAxis(XboxCtrlrInput.XboxAxis.RightStickY);




		if (yJoyStixDirection > 0.5 || yJoyStixDirection < -0.5 || xJoyStixDirection > 0.5 || xJoyStixDirection < -0.5) {	//if the player is holding the joystick to shoot

			float angle = Mathf.Atan2 (yJoyStixDirection, xJoyStixDirection);			//then calculate the angle at which the right joystick is rotated towards
			Vector3 gunRotation = new Vector3 (0,0,angle * Mathf.Rad2Deg + 90);

			transform.rotation = Quaternion.Euler (0, 0, angle * Mathf.Rad2Deg + 90);	//and as the player is currently shooting rotate the gun to this angle


			FireGun ();
		} else {
			//TODO: turn torch on
		}
	}



	private void FireGun() {
		switch (thisGunType) {

		case gunType.pistol:

			if (timeElapsedSinceLastShot > pistolFireRateSeconds) {

				GameObject newBullet = Instantiate (pistolBullet, this.transform.GetChild(0).transform) as GameObject;	//instantiate a new bullet
				Rigidbody2D bulletRigidBody = newBullet.GetComponent<Rigidbody2D> ();				//get the rigidbody so force can be applied to it
				bulletRigidBody.AddForce (-this.transform.up * 400f);
				timeElapsedSinceLastShot = 0;														//reset the time counter
			}
			break;

		case gunType.shotgun:


			break;

		}
	}
}
