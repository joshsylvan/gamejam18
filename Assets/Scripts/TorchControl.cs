using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchControl : MonoBehaviour
{
	private Quaternion lastRotation;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
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
		
//		rightStick = Vector2.ClampMagnitude(rightStick, 0.5f);
//		leftStick = Vector2.ClampMagnitude(leftStick, 0.5f);
//		float xJoyStixDirection2 = leftStick.x;
//		float yJoyStixDirection2 = leftStick.y;


		if (Mathf.Abs(inputCircleRight.x) > 0.5f || Mathf.Abs(inputCircleRight.y) >0.5f) {	//if the player is holding the joystick to shoot
			Debug.Log(inputCircleRight);
		
			float angle = Mathf.Atan2 (inputCircleRight.y, inputCircleRight.x);			//then calculate the angle at which the right joystick is rotated towards
			lastRotation = Quaternion.Euler(0, angle * Mathf.Rad2Deg + 90, 0);
			transform.localRotation = lastRotation; //and as the player is currently shooting rotate the gun to this angle
		}
		else if(Mathf.Abs(inputCircleLeft.x) > 0.5f || Mathf.Abs(inputCircleLeft.y) >0.5f )
		{	
			float angle =
				Mathf.Atan2(-inputCircleLeft.y,
					inputCircleLeft.x); //then calculate the angle at which the right joystick is rotated towards
				
			lastRotation = Quaternion.Euler(0, angle * Mathf.Rad2Deg + 90, 0);
			transform.localRotation = lastRotation;	
		} 
		else 
		{
			transform.localRotation = lastRotation;
		}
		
	}
}
