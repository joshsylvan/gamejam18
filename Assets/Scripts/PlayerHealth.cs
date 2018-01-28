using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {

	public enum healthType {health, armour};

	public static bool isPlayerAlive = true;
	bool IsPlayerAlive{
		get { return isPlayerAlive; }
	}


	public HealthUI healthUI;

	public int health = 6;
	public int Health{
		get{ return health; }
	}

	public void IncreaseHealth(int amountToIncrease) {
		health += amountToIncrease;

		if (health > 6) {
			health = 6;
		}

		healthUI.UpdateHealth (health, armour);
	}

	public void DecreaseHealth(int amountToDecrease) {

		//remove armour first if you have

		if (armour > 0) {							//if you have armour deduct from this
			armour -= amountToDecrease;
			StartCoroutine(healthUI.FlashArmour ());

			if (armour < 0) {						//if there is any health left to remove
				int remainder = Mathf.Abs (armour);	//get the posive value of what is left to deduct

				health -= remainder;				//remove it from health
				armour = 0;							//and reset armour to 0
				StartCoroutine(healthUI.FlashHealth ());

			}
		} else {									//otherwise deduct from health
			health -= amountToDecrease;
			if (health < 0) {
				health = 0;
			}
			StartCoroutine(healthUI.FlashHealth ());
		}
		healthUI.UpdateHealth (health, armour);

		if (health == 0) {
			isPlayerAlive = false;
			EndGame ();
			//TODO: trigger end game
		}
	}


	public int armour = 0;

	public void IncreaseArmour(int amountToIncrease) {
		armour += amountToIncrease;

		if (armour > 6) {
			armour = 6;
		}

		healthUI.UpdateHealth (health, armour);
	}


	private void EndGame() {
		gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;	//stop playing from sliding
		gameObject.GetComponent<Animator> ().SetTrigger ("DeathAnimation");
		//death animation

		//instantiate new rect over screen

		//retry button

	}

}
