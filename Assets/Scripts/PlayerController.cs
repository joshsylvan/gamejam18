using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	private enum playerDirection {front, back, left, right};

	playerDirection direction = playerDirection.front;

	public float movementSpeed = 7;

	private SpriteRenderer spriteRenderer;
	//private Animator animator;
	private Rigidbody2D rigidBody;

	private bool moving;						//true if moving - used to change sprite to moving animation

	public Sprite[] idleFacingFrontSprites = new Sprite[8];
	public Sprite[] idleFacingBackSprites = new Sprite[8];
	public Sprite[] idleFacingLeftSprites = new Sprite[8];
	public Sprite[] idleFacingRightSprites = new Sprite[8];

	public Sprite[] movementFacingFrontSprites = new Sprite[8];
	public Sprite[] movementFacingBackSprites = new Sprite[8];
	public Sprite[] movementFacingLeftSprites = new Sprite[8];
	public Sprite[] movementFacingRightSprites = new Sprite[8];

	private int currentIdleSpriteIndex;
	private int currentMovementSpriteIndex;


	// Use this for initialization
	void Awake () {
		spriteRenderer = GetComponent<SpriteRenderer> (); 
		//animator = GetComponent<Animator> ();
		rigidBody = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
//		Debug.Log (XboxCtrlrInput.XCI.GetAxis(XboxCtrlrInput.XboxAxis.LeftStickX));
//		Debug.Log (XboxCtrlrInput.XboxAxis.LeftTrigger);

//		XboxCtrlrInput.XCI.GetAxisRaw(

		float movementHorizontal = Input.GetAxis ("Horizontal");
//		Debug.Log (movementHorizontal);
		float movementVertical = Input.GetAxis ("Vertical");

		Vector2 movement = new Vector2(movementHorizontal, movementVertical);

		#region Work out direction player is be facing

		if (movementHorizontal > 0 && movementVertical < 0.2 && movementVertical > -0.2) {
			direction = playerDirection.right;
		} else if (movementHorizontal < 0 && movementHorizontal < 0.2 && movementHorizontal > -0.2) {
			direction = playerDirection.left;
		} else if (movementVertical > 0 && movementHorizontal < 0.2 && movementHorizontal > -0.2) {
			direction = playerDirection.back;
		} else if (movementVertical < 0 && movementHorizontal < 0.2 && movementHorizontal > -0.2) {
			direction = playerDirection.front;
		} 


		#endregion


		#region Update sprite according to whether idle or moving
		if (movementHorizontal != 0 || movementVertical != 0) {			//if the player is moving
			UpdateSpriteToMoving ();									//then call method to update sprite to moving
			currentIdleSpriteIndex = 0;
		} else {														//else 
			UpdateSpriteIdle ();										//
		}

		#endregion

		rigidBody.AddForce (movement * movementSpeed);

	}


	private void UpdateSpriteToMoving() {
		switch (direction) {
		case playerDirection.front:
			spriteRenderer.sprite = movementFacingFrontSprites [currentMovementSpriteIndex];
			if (currentMovementSpriteIndex < 7) {
				currentMovementSpriteIndex++;
			} else {
				currentMovementSpriteIndex = 0;
			}
			break;
		case playerDirection.back:
			spriteRenderer.sprite = movementFacingBackSprites [currentMovementSpriteIndex];
			if (currentMovementSpriteIndex < 7) {
				currentMovementSpriteIndex++;
			} else {
				currentMovementSpriteIndex = 0;
			}
			break;
		case playerDirection.left:
			spriteRenderer.sprite = movementFacingLeftSprites [currentMovementSpriteIndex];
			if (currentMovementSpriteIndex < 7) {
				currentMovementSpriteIndex++;
			} else {
				currentMovementSpriteIndex = 0;
			}
			break;
		case playerDirection.right:
			spriteRenderer.sprite = movementFacingRightSprites [currentMovementSpriteIndex];
			if (currentMovementSpriteIndex < 7) {
				currentMovementSpriteIndex++;
			} else {
				currentMovementSpriteIndex = 0;
			}
			break;
		}

	}

	private void UpdateSpriteIdle() {

		switch (direction) {
		case playerDirection.front:
			spriteRenderer.sprite = idleFacingFrontSprites [currentIdleSpriteIndex];
			if (currentIdleSpriteIndex < 7) {
				currentIdleSpriteIndex++;
			} else {
				currentIdleSpriteIndex = 0;
			}
			break;
		case playerDirection.back:
			spriteRenderer.sprite = idleFacingBackSprites [currentIdleSpriteIndex];
			if (currentIdleSpriteIndex < 7) {
				currentIdleSpriteIndex++;
			} else {
				currentIdleSpriteIndex = 0;
			}
			break;
		case playerDirection.left:
			spriteRenderer.sprite = idleFacingLeftSprites [currentIdleSpriteIndex];
			if (currentIdleSpriteIndex < 7) {
				currentIdleSpriteIndex++;
			} else {
				currentIdleSpriteIndex = 0;
			}
			break;
		case playerDirection.right:
			spriteRenderer.sprite = idleFacingRightSprites [currentIdleSpriteIndex];
			if (currentIdleSpriteIndex < 7) {
				currentIdleSpriteIndex++;
			} else {
				currentIdleSpriteIndex = 0;
			}
			break;
		}


	}

}
