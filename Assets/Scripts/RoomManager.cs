using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
	private GameObject[] rooms;
	private GameObject map;

	void Awake()
	{
		this.map = GameObject.FindWithTag("Map");
		rooms = new GameObject[map.transform.childCount];

		for (int i = 0; i < map.transform.childCount; i++)
		{
			this.rooms[i] = map.transform.GetChild(i).gameObject;
			this.rooms[i].GetComponent<RoomStats>().Init();
		}
	}
	
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public GameObject[] GetRooms()
	{
		return rooms;
	}
}
