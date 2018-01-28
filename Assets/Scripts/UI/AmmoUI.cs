using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoUI : MonoBehaviour {

	private GunController gunController;


	// Use this for initialization
	void Awake () {
		gunController = GameObject.FindGameObjectWithTag ("Player").transform.GetChild (0).GetComponent<GunController> ();
	}
	
	// Update is called once per frame
	void Update () {


		Debug.Log (gunController.equippedGunType == GunController.gunType.pistol);

		#region Updating pistol UI
		if (gunController.PistolObtained /*&& gunController.equippedGunType == GunController.gunType.pistol*/) {																//if you have the pistol
			if (!transform.GetChild (2).GetComponent<Image> ().enabled) {								//and if it is not enable in the UI
				transform.GetChild (2).GetComponent<Image> ().enabled = true;							//enable the icon
				transform.GetChild (3).GetComponent<Text> ().enabled = true;							//and enable the text
			}


			if (gunController.PistolAmmo < 10) {
				transform.GetChild (3).GetComponent<Text> ().text = "0" + gunController.PistolAmmo.ToString ();	//then update the ammo count
			} else if (gunController.PistolAmmo < 100) {
				transform.GetChild (3).GetComponent<Text> ().text = /*"0" +*/ gunController.PistolAmmo.ToString ();	//then update the ammo count
			} else  {
				transform.GetChild (3).GetComponent<Text> ().text = gunController.PistolAmmo.ToString ();	//then update the ammo count
			}


			if (gunController.PistolAmmo >= 10){														//if you have a good amount of ammo
				transform.GetChild (3).GetComponent<Text> ().color = new Color32 (255, 255, 255, 255);	//make the text white

				if ( gunController.equippedGunType == GunController.gunType.pistol) {						
					transform.parent.GetChild(2).GetChild(0).gameObject.GetComponent<Text>().text = "";							//and disable the text reminder that you have no ammo
				}
			}
			else if (gunController.PistolAmmo < 10 && gunController.PistolAmmo > 0) {					//else if you have less than 10 ammo
				transform.GetChild (3).GetComponent<Text> ().color = new Color32 (255, 122, 122, 255);	//make the text a whitey red

				if ( gunController.equippedGunType == GunController.gunType.pistol) {

					transform.parent.GetChild(2).GetChild(0).gameObject.GetComponent<Text>().text = "Low Ammo";
					transform.parent.GetChild(2).GetChild(0).gameObject.GetComponent<Text>().color = new Color32 (255, 122, 122, 255);
			}
			} else {
				transform.GetChild (3).GetComponent<Text> ().color = new Color32 (255, 0, 0, 255);		//else you have no ammo - so make the text red

				if ( gunController.equippedGunType == GunController.gunType.pistol) {
	
					transform.parent.GetChild(2).GetChild(0).gameObject.GetComponent<Text>().text = "No Ammo!";
					transform.parent.GetChild(2).GetChild(0).gameObject.GetComponent<Text>().color = new Color32 (255, 0, 0, 255);
				}
			}

		} else if (transform.GetChild (2).GetComponent<Image> ().enabled && !gunController.PistolObtained) {								//else, if it is enabled but you have not obtained it
				transform.GetChild (2).GetComponent<Image> ().enabled = false;							//disable the icon
				transform.GetChild (3).GetComponent<Text> ().enabled = false;							//and the text
		}
		#endregion


		#region Updating shotgun UI
		if (gunController.ShotgunObtained /*&& gunController.equippedGunType == GunController.gunType.shotgun*/) {															//if you have the pistol
			if (!transform.GetChild (4).GetComponent<Image> ().enabled) {								//and if it is not enable in the UI
				transform.GetChild (4).GetComponent<Image> ().enabled = true;							//enable the icon
				transform.GetChild (5).GetComponent<Text> ().enabled = true;							//and enable the text
			}

			if (gunController.ShotgunAmmo < 10) {
				string u = "0" + gunController.ShotgunAmmo.ToString ();
				Debug.Log("u: " + u);
				transform.GetChild (5).GetComponent<Text> ().text = "0" + gunController.ShotgunAmmo.ToString ();	//then update the ammo count
			} else if (gunController.ShotgunAmmo < 100) {
				transform.GetChild (5).GetComponent<Text> ().text = /*"0" +*/ gunController.ShotgunAmmo.ToString ();	//then update the ammo count
			} else  {
				transform.GetChild (5).GetComponent<Text> ().text = gunController.ShotgunAmmo.ToString ();	//then update the ammo count
			}


			if (gunController.ShotgunAmmo >= 10){														//if you have a good amount of ammo
				transform.GetChild (5).GetComponent<Text> ().color = new Color32 (255, 255, 255, 255);	//make the text white

				if ( gunController.equippedGunType == GunController.gunType.shotgun) {
					
					transform.parent.GetChild(2).GetChild(0).gameObject.GetComponent<Text>().text = "";							//and disable the text reminder that you have no ammo
				}
			}
			else if (gunController.ShotgunAmmo < 10 && gunController.ShotgunAmmo > 0) {					//else if you have less than 10 ammo
				transform.GetChild (5).GetComponent<Text> ().color = new Color32 (255, 122, 122, 255);	//make the text a whitey red

				if ( gunController.equippedGunType == GunController.gunType.shotgun) {
					transform.parent.GetChild(2).GetChild(0).gameObject.GetComponent<Text>().text = "Low Ammo";
					transform.parent.GetChild(2).GetChild(0).gameObject.GetComponent<Text>().color = new Color32 (255, 122, 122, 255);
				}
			} else {
				transform.GetChild (5).GetComponent<Text> ().color = new Color32 (255, 0, 0, 255);		//else you have no ammo - so make the text red

				if ( gunController.equippedGunType == GunController.gunType.shotgun) {
					transform.parent.GetChild(2).GetChild(0).gameObject.GetComponent<Text>().text = "No Ammo!";
					transform.parent.GetChild(2).GetChild(0).gameObject.GetComponent<Text>().color = new Color32 (255, 0, 0, 255);
				}
			}

		} else if (transform.GetChild (4).GetComponent<Image> ().enabled) {								//else, if it is enable but you have not obtained it
			transform.GetChild (4).GetComponent<Image> ().enabled = false;								//disable the icon
			transform.GetChild (5).GetComponent<Text> ().enabled = false;								//and the text
		}
		#endregion


		if (gunController.ShotgunObtained) {
			
			transform.GetChild (4).GetComponent<Image> ().enabled = true;
			transform.GetChild (5).GetComponent<Text> ().enabled = true;

			//transform.GetChild (5).GetComponent<Text> ().text = gunController.ShotgunAmmo.ToString ();
		} else {
			transform.GetChild (4).GetComponent<Image> ().enabled = false;
			transform.GetChild (5).GetComponent<Text> ().enabled = false;
		}
	}
}
