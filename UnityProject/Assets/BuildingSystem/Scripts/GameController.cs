using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
    public string Gender;
    public GameObject male;
    public GameObject female;
	// Use this for initialization
	void Start () {
        male.SetActive(false);
        female.SetActive(false);
        GameObject.DontDestroyOnLoad(gameObject);
	}
	
	// Update is called once per frame
	void Update () {
        if (Gender == "Male")
        {
            male.SetActive(true);
        }
        else if (Gender=="Female")
        {
            female.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            print(Gender);
        }
	}
}
