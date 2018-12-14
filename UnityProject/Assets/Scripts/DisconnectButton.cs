using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class DisconnectButton : Photon.MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

	public void StopConnection()
	{
		PhotonNetwork.Disconnect();
		SceneManager.LoadScene("StartScene");
	}
	
	// Update is called once per frame
	void Update () {
		if (PhotonNetwork.inRoom)
		{			
			GetComponent<Image>().enabled = true;
			GetComponent<Button>().enabled = true;			
		}

	}
	
}
