﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverTrapHandler : MonoBehaviour
{

	public RoomManager rm;
	public bool trapActive = false;
	private GameObject player;

	public bool playOnce = false, lcoked = false;

	private bool playerHere;

	private float countDown = .3f;
	// Use this for initialization
	void Start () {
		player = GameObject.FindWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
		if (playerHere)
		{
				if (trapActive)
				{
					if (playOnce)
					{
						countDown -= Time.deltaTime;
					}
					if (!player.GetComponent<PlayerCollisionDetection>().IsPlayerInvincible())
					{
						if (playOnce)
						{
							if (countDown <= 0 && !lcoked)
							{
								player.GetComponent<PlayerHealth>().DecreaseHealth(1); //apply damage to player
								StartCoroutine(player.GetComponent<PlayerCollisionDetection>().TriggerImmunity());
								lcoked = true;
							}
						}
						else
						{
							player.GetComponent<PlayerHealth>().DecreaseHealth(1); //apply damage to player
							StartCoroutine(player.GetComponent<PlayerCollisionDetection>().TriggerImmunity());
						}
					}
				}
			}
	}

	public void SetTrapActive()
	{
		playerHere = true;
	}

	private void OnTriggerStay2D(Collider2D other)
	{
		if (other.transform.CompareTag("Player"))
		{
			playerHere = true;
		}
	}

	private void OnTriggerExit2D(Collider2D other)
	{
		if (other.transform.CompareTag("Player"))
		{
			playerHere = false;
		}
	}
}
