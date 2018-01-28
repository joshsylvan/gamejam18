﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	private RoomManager roomManager;
	private ServerResponce sr;

	public RoomStats dungeon, bathroom, corridor1, playroom; 

	private string jsonToSend = "";
	// Use this for initialization
	void Start () {
		this.roomManager = GetComponent<RoomManager>();
		CreateJson();
		Debug.Log(jsonToSend);
		StartCoroutine(this.GetComponent<ServerHandler>().UploadData());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void GetResponse(string data)
	{
		sr = JsonUtility.FromJson<ServerResponce>(data);
		if (sr.room != null)
		{
			switch (sr.room)
			{
				case "dungeon":
					UpdateRoom(dungeon);
					break;
				case "bathroom":
					UpdateRoom(bathroom);
					break;
				case "corridor":
					UpdateRoom(corridor1);
					break;
				case "playroom":
					UpdateRoom(playroom);
					break;
			}
		}
	}
	
	public void UpdateRoom(RoomStats room)
	{
		Debug.Log(sr.trap1);
		if (sr.trap1.Equals("true"))
		{
			room.TriggerTrap1();
		}

		Debug.Log(sr.trap2);
		if (sr.trap2.Equals("true"))
		{
			room.TriggerTrap2();
		}

		Debug.Log(sr.monster);
		if (sr.monster.Equals("true"))
		{
			room.SpawnMonster();
		}
		
	}	
	
	public string CreateJson()
	{
		jsonToSend = "{ \"rooms\": [";
		for (int i = 0; i < roomManager.GetRooms().Length; i++)
		{
			jsonToSend += "{ \"type\":" + "\"" + roomManager.GetRooms()[i].GetComponent<RoomStats>().GetRoomName() + "\"," ;
			
			jsonToSend += "\"startX\":" + "\"" + roomManager.GetRooms()[i].GetComponent<RoomStats>().startX + "\",";
			jsonToSend += "\"startY\":" + "\"" + roomManager.GetRooms()[i].GetComponent<RoomStats>().startY + "\",";
			jsonToSend += "\"endX\":" + "\"" + roomManager.GetRooms()[i].GetComponent<RoomStats>().endX + "\",";
			jsonToSend += "\"endY\":" + "\"" + roomManager.GetRooms()[i].GetComponent<RoomStats>().endY + "\",";
			jsonToSend += "\"trap1Name\":" + "\"" + roomManager.GetRooms()[i].GetComponent<RoomStats>().GetTrap1Name() + "\",";
			jsonToSend += "\"trap2Name\":" + "\"" + roomManager.GetRooms()[i].GetComponent<RoomStats>().GetTrap2Name() + "\",";
			jsonToSend += "\"trap1\":" + "\"" + roomManager.GetRooms()[i].GetComponent<RoomStats>().HasTrap1BeenUsed() + "\",";
			jsonToSend += "\"trap2\":" + "\"" + roomManager.GetRooms()[i].GetComponent<RoomStats>().HasTrap2BeenUsed() + "\",";
			jsonToSend += "\"isPlayerHere\":" + "\"" + roomManager.GetRooms()[i].GetComponent<RoomStats>().IsPlayerHere() + "\"}";
			
			if (i < roomManager.GetRooms().Length - 1)
			{
				jsonToSend += ",";
			}
		}
		jsonToSend += "]}";

		return jsonToSend;
	}
}
