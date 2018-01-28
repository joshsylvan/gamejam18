using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour {

	public Sprite healthFullHeart;
	public Sprite healthHalfHeart;
	public Sprite healthEmptyHeart;
	public Sprite armourFullHeart;
	public Sprite armourHalfHeart;


//	// Use this for initialization
//	void Start () {
//		
//	}
	
	// Update is called once per frame
	public void UpdateHealth (int health, int armour) {

		Debug.Log ("armour: " + armour);

		if (armour >= 0) {
			switch (armour) {
			case 6:
				transform.GetChild (3).GetComponent<Image> ().enabled = true;
				transform.GetChild (4).GetComponent<Image> ().enabled = true;
				transform.GetChild (5).GetComponent<Image> ().enabled = true;

				transform.GetChild (3).GetComponent<Image> ().sprite = armourFullHeart;
				transform.GetChild (4).GetComponent<Image> ().sprite = armourFullHeart;
				transform.GetChild (5).GetComponent<Image> ().sprite = armourFullHeart;
				break;

			case 5:
				transform.GetChild (3).GetComponent<Image> ().enabled = true;
				transform.GetChild (4).GetComponent<Image> ().enabled = true;
				transform.GetChild (5).GetComponent<Image> ().enabled = true;

				transform.GetChild (3).GetComponent<Image> ().sprite = armourFullHeart;
				transform.GetChild (4).GetComponent<Image> ().sprite = armourFullHeart;
				transform.GetChild (5).GetComponent<Image> ().sprite = armourHalfHeart;
				break;

			case 4: 
				transform.GetChild (3).GetComponent<Image> ().enabled = true;
				transform.GetChild (4).GetComponent<Image> ().enabled = true;

				transform.GetChild (3).GetComponent<Image> ().sprite = armourFullHeart;
				transform.GetChild (4).GetComponent<Image> ().sprite = armourFullHeart;
				transform.GetChild (5).GetComponent<Image> ().enabled = false;
				break;
			
			case 3:
				transform.GetChild (3).GetComponent<Image> ().enabled = true;
				transform.GetChild (4).GetComponent<Image> ().enabled = true;

				transform.GetChild (3).GetComponent<Image> ().sprite = armourFullHeart;
				transform.GetChild (4).GetComponent<Image> ().sprite = armourHalfHeart;
				transform.GetChild (5).GetComponent<Image> ().enabled = false;
				break;

			case 2:
				transform.GetChild (3).GetComponent<Image> ().enabled = true;

				transform.GetChild (3).GetComponent<Image> ().sprite = armourFullHeart;
				transform.GetChild (4).GetComponent<Image> ().enabled = false;
				transform.GetChild (5).GetComponent<Image> ().enabled = false;
				break;

			case 1:
				transform.GetChild (3).GetComponent<Image> ().enabled = true;

				transform.GetChild (3).GetComponent<Image> ().sprite = armourHalfHeart;
				transform.GetChild (4).GetComponent<Image> ().enabled = false;
				transform.GetChild (5).GetComponent<Image> ().enabled = false;
				break;

			case 0:
				transform.GetChild (3).GetComponent<Image> ().enabled = false;
				transform.GetChild (4).GetComponent<Image> ().enabled = false;
				transform.GetChild (5).GetComponent<Image> ().enabled = false;
				break;
			}

			if (health >= 0) {
				switch (health) {
				case 6:
					transform.GetChild (0).GetComponent<Image> ().sprite = healthFullHeart;
					transform.GetChild (1).GetComponent<Image> ().sprite = healthFullHeart;
					transform.GetChild (2).GetComponent<Image> ().sprite = healthFullHeart;
					break;

				case 5:
					transform.GetChild (0).GetComponent<Image> ().sprite = healthFullHeart;
					transform.GetChild (1).GetComponent<Image> ().sprite = healthFullHeart;
					transform.GetChild (2).GetComponent<Image> ().sprite = healthHalfHeart;
					break;

				case 4: 
					transform.GetChild (0).GetComponent<Image> ().sprite = healthFullHeart;
					transform.GetChild (1).GetComponent<Image> ().sprite = healthFullHeart;
					transform.GetChild (2).GetComponent<Image> ().sprite = healthEmptyHeart;
					break;

				case 3:
					transform.GetChild (0).GetComponent<Image> ().sprite = healthFullHeart;
					transform.GetChild (1).GetComponent<Image> ().sprite = healthHalfHeart;
					transform.GetChild (2).GetComponent<Image> ().sprite = healthEmptyHeart;
					break;

				case 2:
					transform.GetChild (0).GetComponent<Image> ().sprite = healthFullHeart;
					transform.GetChild (1).GetComponent<Image> ().sprite = healthEmptyHeart;
					transform.GetChild (2).GetComponent<Image> ().sprite = healthEmptyHeart;
					break;

				case 1:
					transform.GetChild (0).GetComponent<Image> ().sprite = healthHalfHeart;
					transform.GetChild (1).GetComponent<Image> ().sprite = healthEmptyHeart;
					transform.GetChild (2).GetComponent<Image> ().sprite = healthEmptyHeart;
					break;

				case 0:
					transform.GetChild (0).GetComponent<Image> ().sprite = healthEmptyHeart;
					transform.GetChild (1).GetComponent<Image> ().sprite = healthEmptyHeart;
					transform.GetChild (2).GetComponent<Image> ().sprite = healthEmptyHeart;
					break;
				}
			}
		}
	}

	public IEnumerator FlashHealth() {

		transform.GetChild (0).GetComponent<Image> ().color = new Color32 (255, 0, 0, 255);
		transform.GetChild (1).GetComponent<Image> ().color = new Color32 (255, 0, 0, 255);
		transform.GetChild (2).GetComponent<Image> ().color = new Color32 (255, 0, 0, 255);

		yield return new WaitForSeconds (0.1f);
		transform.GetChild (0).GetComponent<Image> ().color = new Color32 (255, 255, 255, 255);
		transform.GetChild (1).GetComponent<Image> ().color = new Color32 (255, 255, 255, 255);
		transform.GetChild (2).GetComponent<Image> ().color = new Color32 (255, 255, 255, 255);

		yield return new WaitForSeconds (0.1f);
		transform.GetChild (0).GetComponent<Image> ().color = new Color32 (255, 0, 0, 255);
		transform.GetChild (1).GetComponent<Image> ().color = new Color32 (255, 0, 0, 255);
		transform.GetChild (2).GetComponent<Image> ().color = new Color32 (255, 0, 0, 255);

		yield return new WaitForSeconds (0.1f);
		transform.GetChild (0).GetComponent<Image> ().color = new Color32 (255, 255, 255, 255);
		transform.GetChild (1).GetComponent<Image> ().color = new Color32 (255, 255, 255, 255);
		transform.GetChild (2).GetComponent<Image> ().color = new Color32 (255, 255, 255, 255);

		yield return new WaitForSeconds (0.1f);
		transform.GetChild (0).GetComponent<Image> ().color = new Color32 (255, 0, 0, 255);
		transform.GetChild (1).GetComponent<Image> ().color = new Color32 (255, 0, 0, 255);
		transform.GetChild (2).GetComponent<Image> ().color = new Color32 (255, 0, 0, 255);

		yield return new WaitForSeconds (0.1f);
		transform.GetChild (0).GetComponent<Image> ().color = new Color32 (255, 255, 255, 255);
		transform.GetChild (1).GetComponent<Image> ().color = new Color32 (255, 255, 255, 255);
		transform.GetChild (2).GetComponent<Image> ().color = new Color32 (255, 255, 255, 255);
	}

	public IEnumerator FlashArmour() {

		transform.GetChild (3).GetComponent<Image> ().color = new Color32 (255, 0, 0, 255);
		transform.GetChild (4).GetComponent<Image> ().color = new Color32 (255, 0, 0, 255);
		transform.GetChild (5).GetComponent<Image> ().color = new Color32 (255, 0, 0, 255);

		yield return new WaitForSeconds (0.1f);
		transform.GetChild (3).GetComponent<Image> ().color = new Color32 (255, 255, 255, 255);
		transform.GetChild (4).GetComponent<Image> ().color = new Color32 (255, 255, 255, 255);
		transform.GetChild (5).GetComponent<Image> ().color = new Color32 (255, 255, 255, 255);

		yield return new WaitForSeconds (0.1f);
		transform.GetChild (3).GetComponent<Image> ().color = new Color32 (255, 0, 0, 255);
		transform.GetChild (4).GetComponent<Image> ().color = new Color32 (255, 0, 0, 255);
		transform.GetChild (5).GetComponent<Image> ().color = new Color32 (255, 0, 0, 255);

		yield return new WaitForSeconds (0.1f);
		transform.GetChild (3).GetComponent<Image> ().color = new Color32 (255, 255, 255, 255);
		transform.GetChild (4).GetComponent<Image> ().color = new Color32 (255, 255, 255, 255);
		transform.GetChild (5).GetComponent<Image> ().color = new Color32 (255, 255, 255, 255);

		yield return new WaitForSeconds (0.1f);
		transform.GetChild (3).GetComponent<Image> ().color = new Color32 (255, 0, 0, 255);
		transform.GetChild (4).GetComponent<Image> ().color = new Color32 (255, 0, 0, 255);
		transform.GetChild (5).GetComponent<Image> ().color = new Color32 (255, 0, 0, 255);

		yield return new WaitForSeconds (0.1f);
		transform.GetChild (3).GetComponent<Image> ().color = new Color32 (255, 255, 255, 255);
		transform.GetChild (4).GetComponent<Image> ().color = new Color32 (255, 255, 255, 255);
		transform.GetChild (5).GetComponent<Image> ().color = new Color32 (255, 255, 255, 255);
	}
}
