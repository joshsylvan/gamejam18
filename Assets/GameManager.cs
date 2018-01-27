using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	private RoomManager roomManager;

	private string jsonToSend = "";
	// Use this for initialization
	void Start () {
		this.roomManager = GetComponent<RoomManager>();
		CreateJson();
		Debug.Log(jsonToSend);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void CreateJson()
	{
		jsonToSend = "{ Rooms: [";
		for (int i = 0; i < roomManager.GetRooms().Length; i++)
		{
			jsonToSend += "{ type:" + roomManager.GetRooms()[i].GetComponent<RoomStats>().GetRoomName() + ",";
			jsonToSend += "startX:" + roomManager.GetRooms()[i].GetComponent<RoomStats>().startX + ",";
			jsonToSend += "startY:" + roomManager.GetRooms()[i].GetComponent<RoomStats>().startY + ",";
			jsonToSend += "endX:" + roomManager.GetRooms()[i].GetComponent<RoomStats>().endX + ",";
			jsonToSend += "endY:" + roomManager.GetRooms()[i].GetComponent<RoomStats>().endY + ",";
			jsonToSend += "trap1Name:" + roomManager.GetRooms()[i].GetComponent<RoomStats>().GetTrap1Name() + ",";
			jsonToSend += "trap2Name:" + roomManager.GetRooms()[i].GetComponent<RoomStats>().GetTrap2Name() + ",";
			jsonToSend += "trap1:" + roomManager.GetRooms()[i].GetComponent<RoomStats>().HasTrap1BeenUsed() + ",";
			jsonToSend += "trap2:" + roomManager.GetRooms()[i].GetComponent<RoomStats>().HasTrap2BeenUsed() + ",";
			jsonToSend += "isPlayerHere:" + roomManager.GetRooms()[i].GetComponent<RoomStats>().IsPlayerHere() + "},";
		}
		jsonToSend += "]}";
		JsonUtility.
		JsonUtility.ToJson(jsonToSend);
	}
}
