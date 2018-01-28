using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEditor;
using UnityEngine;
using UnityEngine.Networking;
using WebSocketSharp;

public class ServerHandler : MonoBehaviour {

	//https://reqres.in/api/users?page=2
	
	// Use this for initialization
	public string url = "https://api.github.com/users/joshsylvan";
	private string urlUpload = "https://gamejamserver.herokuapp.com/command";
	private WWW response;
	private ServerResponce sr;
	private WebSocket ws;
	private GameManager gm;

	private void Awake()
	{
		gm = this.GetComponent<GameManager>();
	}

	void Start () 
	{
//		GetServerInformation();
	}

	private void Update()
	{
//		throw new System.NotImplementedException();
	}

	public void GetServerInformation(string message)
	{
//		WWW www = new WWW(url);
//		StartCoroutine(UploadData(message));
	}


	public IEnumerator UploadData()
	{
		using (ws = new WebSocket("wss://gamejamserverwebsocket.herokuapp.com/ws"))
		{
			ws.OnMessage += (sender, e) => gm.GetResponse(e.Data);

			ws.Connect();
//			ws.Send("{\"handle\": \"Josh\", \"text\": \"Also Fuck Dave\"}");
			
			while (true)
			{
				if (!ws.IsAlive)
				{
					ws.Connect();
				}
				string msg = this.GetComponent<GameManager>().CreateJson();
				ws.Send(msg);
				Debug.Log(msg + " \n " + System.DateTime.Now);
				yield return new WaitForSeconds(5);
			}
//			Debug.Log(System.DateTime.Now);
		}
	}

}
