using UnityEngine;
using System.Collections;

public class MoveCamera : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	if (Drag_DropSystem.CameraMove)
        {
            Camera.main.transform.Translate(Vector3.forward * Time.deltaTime*10);
        }
    if (Drag_DropSystem.CameraMoveBack)
        {
            Camera.main.transform.Translate(Vector3.back * Time.deltaTime * 10);
        }
        if (Drag_DropSystem.CameraMoveRight)
        {
            Camera.main.transform.Translate(Vector3.right * Time.deltaTime * 10);
        }
        if (Drag_DropSystem.CameraMoveLeft)
        {
            Camera.main.transform.Translate(Vector3.left * Time.deltaTime * 10);
        }
    }
 
}
