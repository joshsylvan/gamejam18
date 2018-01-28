using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsPlayerHereChecker : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnTriggerEnter2D(Collider2D col)
	{
		if (col.CompareTag("Player"))
		{
			this.transform.parent.GetComponent<RoomStats>().SetIsPlayerHere(true);
		}
	}
	
	private void OnTriggerExit2D(Collider2D col)
	{
		if (col.CompareTag("Player"))
		{
			this.transform.parent.GetComponent<RoomStats>().SetIsPlayerHere(false);
		}
	}
}
