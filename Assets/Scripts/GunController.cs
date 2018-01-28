using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunController : MonoBehaviour {

	public enum gunType {pistol, shotgun};

	public gunType equippedGunType = gunType.pistol;

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

	private int pistolAmmo = 10;
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

	public Sprite pistol;
	public Sprite shotgun;

	private Quaternion lastRotation;

	public float pistolSpeed = 100f, shotgunSpeed = 100f;
	
	// Use this for initialization
//	void Start () {
//		
//	}
	
	// Update is called once per frame
	void Update () {

		timeElapsedSinceLastShot += Time.deltaTime;

		float xJoyStixDirection = XboxCtrlrInput.XCI.GetAxis(XboxCtrlrInput.XboxAxis.RightStickX);
		float yJoyStixDirection = XboxCtrlrInput.XCI.GetAxis(XboxCtrlrInput.XboxAxis.RightStickY);

		
		Vector2 rightStick = new Vector2(XboxCtrlrInput.XCI.GetAxis(XboxCtrlrInput.XboxAxis.RightStickX), XboxCtrlrInput.XCI.GetAxis(XboxCtrlrInput.XboxAxis.RightStickY));
		Vector2 leftStick = new Vector2(XboxCtrlrInput.XCI.GetAxis(XboxCtrlrInput.XboxAxis.LeftStickX), XboxCtrlrInput.XCI.GetAxis(XboxCtrlrInput.XboxAxis.LeftStickY));

		
		Vector2 inputCircleRight = new Vector2(
			rightStick.x * Mathf.Sqrt(1 - rightStick.y * rightStick.y * 0.5f),
			rightStick.y * Mathf.Sqrt(1 - rightStick.x * rightStick.x * 0.5f)
		);
		Vector2 inputCircleLeft = new Vector2(
			leftStick.x * Mathf.Sqrt(1 - leftStick.y * leftStick.y * 0.5f),
			leftStick.y * Mathf.Sqrt(1 - leftStick.x * leftStick.x * 0.5f)
		);

		float rightTriggerPressed = XboxCtrlrInput.XCI.GetAxis (XboxCtrlrInput.XboxAxis.RightTrigger);

//		Debug.Log ("rightTriggerPressed: " + rightTriggerPressed);

			//and as the player is currently shooting rotate the gun to this angle


		if (rightTriggerPressed > 0.3f) {																						//if the player is holding down the right trigger
			if (yJoyStixDirection > 0.5 || yJoyStixDirection < -0.5 || xJoyStixDirection > 0.5 || xJoyStixDirection < -0.5) {	//and if the player is holding the joystick to shoot


				FireGun ();
			}
		}
			
			if (Mathf.Abs(inputCircleRight.x) > 0.5f || Mathf.Abs(inputCircleRight.y) >0.5f) {	//if the player is holding the joystick to shoot
//				Debug.Log(inputCircleRight);
		
				float angle = Mathf.Atan2 (inputCircleRight.y, inputCircleRight.x);			//then calculate the angle at which the right joystick is rotated towards
				lastRotation = Quaternion.Euler (0, 0, angle * Mathf.Rad2Deg + 90);
				transform.localRotation = lastRotation; //and as the player is currently shooting rotate the gun to this angle
			}
			else if(Mathf.Abs(inputCircleLeft.x) > 0.5f || Mathf.Abs(inputCircleLeft.y) >0.5f )
			{	
				float angle =
					Mathf.Atan2(-inputCircleLeft.y,
						inputCircleLeft.x); //then calculate the angle at which the right joystick is rotated towards
				
				lastRotation =Quaternion.Euler (0, 0, angle * Mathf.Rad2Deg + 90);
				transform.localRotation = lastRotation;	
			} 
			else 
			{
				transform.localRotation = lastRotation;
			}

		if (XboxCtrlrInput.XCI.GetButtonDown (XboxCtrlrInput.XboxButton.Y)) {		//if Y button is pressed

			if (equippedGunType == gunType.pistol && shotgunObtained) {		//if pistol is equipped and also have a shotgun

				equippedGunType = gunType.shotgun;

				ammoUI.transform.GetChild (0).gameObject.SetActive (false);
				ammoUI.transform.GetChild (1).gameObject.SetActive (true);

				this.transform.GetChild (0).transform.localScale = new Vector3 (0.6f, 0.8f, 0.6f);
				this.transform.GetChild (0).GetComponent<SpriteRenderer> ().sprite = shotgun;
			} else if (equippedGunType == gunType.shotgun && pistolObtained) {

				equippedGunType = gunType.pistol;

				ammoUI.transform.GetChild (1).gameObject.SetActive (false);
				ammoUI.transform.GetChild (0).gameObject.SetActive (true);

				this.transform.GetChild (0).transform.localScale = new Vector3 (0.6f, 0.6f, 0.6f);

				this.transform.GetChild (0).GetComponent<SpriteRenderer> ().sprite = pistol;

			}
				
			//equippedGunType

		}


	}




	private void FireGun() {
		switch (equippedGunType) {

		case gunType.pistol:
			if (pistolAmmo > 0) {											//if you have remaining pistol ammo
				if (timeElapsedSinceLastShot > pistolFireRateSeconds) {		//and if enough time has passed that you can shoot again

					GameObject newBullet = Instantiate (pistolBullet, transform.GetChild(1).position, Quaternion.identity) as GameObject;	//instantiate a new bullet
					Rigidbody2D bulletRigidBody = newBullet.GetComponent<Rigidbody2D> ();				//get the rigidbody so force can be applied to it
					bulletRigidBody.AddForce (-this.transform.up * pistolSpeed);

					pistolAmmo--;
					timeElapsedSinceLastShot = 0;														//reset the time counter
				}
			}
			break;

			case gunType.shotgun:
				if (shotgunAmmo > 0) {                                            //if you have remaining pistol ammo
					if (timeElapsedSinceLastShot > shotgunFireRateSeconds) {        //and if enough time has passed that you can shoot again

						//forwards bullet
						GameObject newBullet = Instantiate (shotgunBullet, transform.GetChild(1).position, Quaternion.identity) as GameObject;    //instantiate a new bullet
						Rigidbody2D bulletRigidBody = newBullet.GetComponent<Rigidbody2D> ();                //get the rigidbody so force can be applied to it
						bulletRigidBody.AddForce (-this.transform.up * shotgunSpeed*2);
//						Debug.Log (transform.up);

						GameObject newBullet1 = Instantiate (shotgunBullet, transform.GetChild(1).position, Quaternion.identity) as GameObject;    //instantiate a new bullet
						Rigidbody2D bulletRigidBody1 = newBullet1.GetComponent<Rigidbody2D> ();                //get the rigidbody so force can be applied to it
						bulletRigidBody1.AddForce ((-this.transform.right - (this.transform.up) - this.transform.up/2) * shotgunSpeed);
//						Debug.Log (transform.right);

						GameObject newBullet2 = Instantiate (shotgunBullet, transform.GetChild(1).position, Quaternion.identity) as GameObject;    //instantiate a new bullet
						Rigidbody2D bulletRigidBody2 = newBullet2.GetComponent<Rigidbody2D> ();                //get the rigidbody so force can be applied to it
						bulletRigidBody2.AddForce ((this.transform.right - this.transform.up - this.transform.up/2) * shotgunSpeed);
//						Debug.Log (-transform.right);

						shotgunAmmo--;
						timeElapsedSinceLastShot = 0;    
					}
				
				}

			break;

		}
	}
}
