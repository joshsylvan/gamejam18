using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour {

	public float health;
	public float Health {
		get { return health; }
		set { health = value; }
	}

	public int damage;
	
	private bool wallCrushLeft, wallCrushRight;


	public void TriggerDeathAnimation() {
		StartCoroutine (DeathAnimation ());
	}

	private void Update()
	{
		if (wallCrushLeft && wallCrushRight)
		{
			TriggerDeathAnimation();
			wallCrushLeft = false;
			wallCrushRight = false;
		}
	}

	private IEnumerator DeathAnimation() {

		float reduceScaleByPerFrame = gameObject.transform.localScale.x/20;

		while (gameObject.transform.localScale.x > 0.001) {

			transform.GetComponent<CircleCollider2D> ().enabled = false;

			transform.localScale = new Vector3 (gameObject.transform.localScale.x - reduceScaleByPerFrame, gameObject.transform.localScale.y - reduceScaleByPerFrame, gameObject.transform.localScale.z - reduceScaleByPerFrame);

			yield return 0;

		}

		Destroy (this.gameObject);
	}

	private void OnCollisionEnter2D(Collision2D other)
	{
		switch (other.transform.tag)
		{
			case "LeftCrush":
				wallCrushLeft = true;
				break;
			case "RightCrush":
				wallCrushRight = true;
				break;	
		}
	}
	
	private void OnCollisionExit2D(Collision2D other)
	{
		switch (other.transform.tag)
		{
			case "LeftCrush":
				wallCrushLeft = false;
				break;
			case "RightCrush":
				wallCrushRight = false;
				break;	
		}
	}

//	// Use this for initialization
//	void Start () {
//		
//	}
//	
//	// Update is called once per frame
//	void Update () {
//		
//	}
}
