using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

	private Transform target;
	public float cameraSpeed = 5f;
	
	// Use this for initialization
	void Start ()
	{
		target = GameObject.FindWithTag("Player").transform;
	}
	
	// Update is called once per frame
	void Update ()
	{

		Vector3 newPos = Vector3.Lerp(this.transform.position, this.target.transform.position, Time.deltaTime*this.cameraSpeed);
		
		this.transform.position = new Vector3(newPos.x, newPos.y, -10);
			
	}
	
	
	
}
