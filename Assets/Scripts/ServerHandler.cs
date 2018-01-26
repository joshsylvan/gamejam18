using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

public class ServerHandler : MonoBehaviour {

	//https://reqres.in/api/users?page=2
	
	// Use this for initialization
	public string url = "https://api.github.com/users/joshsylvan";
	private WWW response;
	
	void Start () 
	{
		GetServerInformation();
	}

	public void GetServerInformation()
	{
		WWW www = new WWW(url);
		StartCoroutine(WaitForRequest(www));
	}
	
	IEnumerator WaitForRequest(WWW www)
	{
		yield return www;
		// check for errors
		if (www.error == null)
		{
			response = www;
			Debug.Log( response);
			Debug.Log( response.text);
			Debug.Log( response.bytes);
			string jsonString;
			try
			{
				jsonString = System.Text.Encoding.UTF8.GetString(response.bytes, 3, response.bytes.Length - 3);
			

//			ServerResponce json = JsonUtility.FromJson<ServerResponce>(jsonString);
			ServerResponce sr = JsonUtility.FromJson<ServerResponce>(jsonString);
			Debug.Log("WWW Ok!: " + sr.login);
			}
			catch (Exception e)
			{
			}
		} 
		else
		{
			Debug.Log("WWW Error: "+ www.error);
		}    
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
