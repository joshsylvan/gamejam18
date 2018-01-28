using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlobMovement : MonoBehaviour {
	private Animator anim;
	private Rigidbody2D rigidBody;
	private Transform target;
	private float speed = 50f;

	// Use this for initialization
	void Start ()
	{
		this.anim = GetComponent<Animator>();
		this.rigidBody = GetComponent<Rigidbody2D>();
		this.target = GameObject.FindGameObjectWithTag("Player").transform;

		StartCoroutine (MoveTowardsPlayer());
	}

	// Update is called once per frame
//	void FixedUpdate () {
//
//	}

	private IEnumerator MoveTowardsPlayer() {

		while (true) {
			float timeElapsed = 0f;
			while (timeElapsed < 0.5f){
				timeElapsed += Time.deltaTime;
//				Vector3 targetPosition = target.position - transform.position;
				Vector3 magnitude = (target.position - transform.position).normalized * speed * Time.fixedDeltaTime;
				rigidBody.velocity = magnitude;
				yield return new WaitForFixedUpdate ();
			}
		yield return new WaitForSeconds (1f);

		}
	}

	public void SetTarget(Transform target)
	{
		this.target = target;
	}
}
