using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeModelRotation : MonoBehaviour
{

	public Vector3 rotation;
	// Use this for initialization
	void Awake ()
	{
		transform.eulerAngles = rotation;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
