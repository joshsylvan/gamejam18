using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.Networking;

public class ServerHandler : MonoBehaviour {

	//https://reqres.in/api/users?page=2
	
	// Use this for initialization
	public string url = "https://api.github.com/users/joshsylvan";
	private string urlUpload = "https://api.github.com/users/joshsylvan";
	private WWW response;
	private ServerResponce sr;
	
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
//			string jsonString;
//			jsonString = System.Text.Encoding.UTF8.GetString(response.bytes, 3, response.bytes.Length - 3);

//			ServerResponce json = JsonUtility.FromJson<ServerResponce>(jsonString);
			sr = JsonUtility.FromJson<ServerResponce>(response.text);
			Debug.Log("WWW Ok!: " + sr.login);
			
		} 
		else
		{
			Debug.Log("WWW Error: "+ www.error);
		}    
	}
	
	IEnumerator UploadData(int health, float x, float y) {
		WWWForm form = new WWWForm();
		form.AddField("myField", "myData");

		using (UnityWebRequest www = UnityWebRequest.Post("http://www.my-server.com/myform?health=" + health, form))
		{
			yield return www.Send();

			if (www.isNetworkError || www.isHttpError)
			{
				Debug.Log(www.error);
			}
			else
			{
				Debug.Log("Form upload complete!");
			}
		}
	}

	
	// Update is called once per frame
	void Update () {
		
	}
}
