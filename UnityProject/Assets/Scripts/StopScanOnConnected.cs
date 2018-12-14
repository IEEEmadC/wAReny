using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StopScanOnConnected : MonoBehaviour {

	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update () {
		if (PhotonNetwork.inRoom)
			GetComponent<Button>().interactable = false;
	}
}
