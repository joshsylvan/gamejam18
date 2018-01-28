using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatMovement : MonoBehaviour
{
	private Animator anim;
	private Rigidbody2D rigidBody;
	private Transform target;
	private float speed = 25f;
	
	// Use this for initialization
	void Start ()
	{
		this.anim = GetComponent<Animator>();
		this.rigidBody = GetComponent<Rigidbody2D>();
		this.target = GameObject.FindGameObjectWithTag("Player").transform;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Vector3 targetPosition = target.position - transform.position;
		Vector3 magnitude = (target.position - transform.position).normalized * speed*Time.fixedDeltaTime;
		rigidBody.velocity = magnitude;
	}

	public void SetTarget(Transform target)
	{
		this.target = target;
	}
}
