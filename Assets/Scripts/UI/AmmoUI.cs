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

		#region Updating pistol UI
		if (gunController.PistolObtained) {																//if you have the pistol
			if (!transform.GetChild (0).GetComponent<Image> ().enabled) {								//and if it is not enable in the UI
				transform.GetChild (0).GetComponent<Image> ().enabled = true;							//enable the icon
				transform.GetChild (1).GetComponent<Text> ().enabled = true;							//and enable the text
			}
			transform.GetChild (1).GetComponent<Text> ().text = gunController.PistolAmmo.ToString ();	//then update the ammo count

			if (gunController.PistolAmmo >= 10){														//if you have a good amount of ammo
				transform.GetChild (1).GetComponent<Text> ().color = new Color32 (255, 255, 255, 255);	//make the text white
				if (transform.parent.GetChild(2).gameObject.activeInHierarchy) {
					transform.parent.GetChild(2).gameObject.SetActive(false);							//and disable the text reminder that you have no ammo
				}
			}
			else if (gunController.PistolAmmo < 10 && gunController.PistolAmmo > 0) {					//else if you have less than 10 ammo
				transform.GetChild (1).GetComponent<Text> ().color = new Color32 (255, 122, 122, 255);	//make the text a whitey red
				if (transform.parent.GetChild(2).gameObject.activeInHierarchy) {
					transform.parent.GetChild(2).gameObject.SetActive(false);							//and disable the text reminder that you have no ammo
				}
			} else {
				transform.GetChild (1).GetComponent<Text> ().color = new Color32 (255, 0, 0, 255);		//else you have no ammo - so make the text red
				if (!transform.parent.GetChild(2).gameObject.activeInHierarchy) {
					transform.parent.GetChild(2).gameObject.SetActive(true);							//and enable the text reminder that you have no ammo
				}
			}

		} else if (transform.GetChild (0).GetComponent<Image> ().enabled) {								//else, if it is enable but you have not obtained it
				transform.GetChild (0).GetComponent<Image> ().enabled = false;							//disable the icon
				transform.GetChild (1).GetComponent<Text> ().enabled = false;							//and the text
		}
		#endregion

		#region Updating shotgun UI
		if (gunController.ShotgunObtained) {															//if you have the pistol
			if (!transform.GetChild (2).GetComponent<Image> ().enabled) {								//and if it is not enable in the UI
				transform.GetChild (2).GetComponent<Image> ().enabled = true;							//enable the icon
				transform.GetChild (3).GetComponent<Text> ().enabled = true;							//and enable the text
			}
			transform.GetChild (3).GetComponent<Text> ().text = gunController.ShotgunAmmo.ToString ();	//then update the ammo count

			if (gunController.ShotgunAmmo >= 10){														//if you have a good amount of ammo
				transform.GetChild (3).GetComponent<Text> ().color = new Color32 (255, 255, 255, 255);	//make the text white
				if (transform.parent.GetChild(2).gameObject.activeInHierarchy) {
					transform.parent.GetChild(2).gameObject.SetActive(false);							//and disable the text reminder that you have no ammo
				}
			}
			else if (gunController.ShotgunAmmo < 10 && gunController.ShotgunAmmo > 0) {					//else if you have less than 10 ammo
				transform.GetChild (3).GetComponent<Text> ().color = new Color32 (255, 122, 122, 255);	//make the text a whitey red
				if (transform.parent.GetChild(2).gameObject.activeInHierarchy) {
					transform.parent.GetChild(2).gameObject.SetActive(false);							//and disable the text reminder that you have no ammo
				}
			} else {
				transform.GetChild (3).GetComponent<Text> ().color = new Color32 (255, 0, 0, 255);		//else you have no ammo - so make the text red
				if (!transform.parent.GetChild(2).gameObject.activeInHierarchy) {
					transform.parent.GetChild(2).gameObject.SetActive(true);							//and enable the text reminder that you have no ammo
				}
			}

		} else if (transform.GetChild (2).GetComponent<Image> ().enabled) {								//else, if it is enable but you have not obtained it
			transform.GetChild (2).GetComponent<Image> ().enabled = false;								//disable the icon
			transform.GetChild (3).GetComponent<Text> ().enabled = false;								//and the text
		}
		#endregion


		if (gunController.ShotgunObtained) {
			
			transform.GetChild (2).GetComponent<Image> ().enabled = true;
			transform.GetChild (3).GetComponent<Text> ().enabled = true;

			transform.GetChild (3).GetComponent<Text> ().text = gunController.ShotgunAmmo.ToString ();
		} else {
			transform.GetChild (2).GetComponent<Image> ().enabled = false;
			transform.GetChild (3).GetComponent<Text> ().enabled = false;
		}
	}
}
