using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	private enum playerDirection {up, down, left, right};

	playerDirection direction = playerDirection.up;
	
	public float movementSpeed = 7;

	private Animator anim;
	private Rigidbody2D rigidBody;
	private float xAxis, yAxis;
	
	// Use this for initialization
	void Start ()
	{
		this.anim = GetComponent<Animator>();
		this.rigidBody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update ()
	{

		xAxis = XboxCtrlrInput.XCI.GetAxis(XboxCtrlrInput.XboxAxis.LeftStickX);
		
		yAxis = XboxCtrlrInput.XCI.GetAxis(XboxCtrlrInput.XboxAxis.LeftStickY);
		
		this.anim.SetFloat("xAxis", xAxis);
		
		this.anim.SetFloat("yAxis", yAxis);

		// Detects when player is idle
		if (xAxis == 0 && yAxis == 0)
		{
			this.anim.SetBool("Idle", true);
		}
		else
		{
			this.anim.SetBool("Idle", false);
		}
		
		// Detects player direction
		if (xAxis == 1)
		{
			this.anim.SetFloat("idleX", 1);
			this.anim.SetFloat("idleY", 0);
			direction = playerDirection.right;
		}
		else if (xAxis == -1)
		{
			this.anim.SetFloat("idleX", -1);
			this.anim.SetFloat("idleY", 0);
			direction = playerDirection.left;
		}
		else if (yAxis == 1)
		{
			this.anim.SetFloat("idleX", 0);
			this.anim.SetFloat("idleY", 1);
			direction = playerDirection.down;
		} 
		else if (yAxis == -1)
		{
			this.anim.SetFloat("idleX", 0);
			this.anim.SetFloat("idleY", -1);
			direction = playerDirection.up;
		}
	}

	private void FixedUpdate(){
		
//		Debug.Log(xAxis + " : " + -yAxis);
		this.rigidBody.velocity = new Vector2(xAxis, -yAxis);
		
		
	}
}
