using System.Collections;
using System.Collections.Generic;
using EasyAR;
using Sample;
using UnityEngine;
using UnityEngine.UI;

public class LoadShow : MonoBehaviour
{

	public SaveLoadUtility slu;
	
	public Button saveButton;
	public float distance;
	private List<SaveGame> saves;

	public GameObject ARCamera;
	
	public bool isInAR;
	// Use this for initialization
	void Start ()
	{
		saves = SaveLoad.GetSaveGames(slu.saveGamePath, slu.usePersistentDataPath);
		distance = Screen.height / 8;
		int n = 0;
		foreach (var  s in saves)
		{		
			GetComponent<RectTransform>().sizeDelta+=new Vector2(0,distance);
			var inst = Instantiate(saveButton, transform);
			inst.GetComponent<RectTransform>().sizeDelta=new Vector2(Screen.width,distance-10);
			inst.transform.localPosition-=new Vector3(0,distance*n);
			inst.GetComponentInChildren<Text>().text = s.savegameName;
			if(!isInAR)
				inst.onClick.AddListener(() => LoadGame(s.savegameName));
			else
				inst.onClick.AddListener(() => LoadSavesinAR(s.savegameName));
			n++;
		}
	}
	
	public void LoadGame(string savename)
	{
		ARCamera.SetActive(true);
		ARCamera.GetComponent<TargetOnTheFly>().enabled = false;
		
		slu.LoadGame(savename);
		
		foreach (ObjectIdentifier o in GameObject.FindObjectsOfType<ObjectIdentifier>())
		{
			if (o.transform.parent == null)
			{
				print(o.name);
				print(o.gameObject.name);
				GameObject.FindObjectOfType<DynamicImageTagetBehaviour>().subGameObject =
					o.gameObject;
			}
		}
		/*if(GameObject.FindObjectOfType<ObjectIdentifier>().transform.parent!=null)
			GameObject.FindObjectOfType<DynamicImageTagetBehaviour>().subGameObject =
				GameObject.FindObjectOfType<ObjectIdentifier>().transform.parent.gameObject;
		else 
			GameObject.FindObjectOfType<DynamicImageTagetBehaviour>().subGameObject =
				GameObject.FindObjectOfType<ObjectIdentifier>().gameObject;*/

		ARCamera.GetComponentInChildren<ARCameraBehaviour>().CenterTarget =
			GameObject.FindObjectOfType<DynamicImageTagetBehaviour>();
		
		GameObject.FindObjectOfType<DynamicImageTagetBehaviour>().subGameObject.transform.position =
			GameObject.FindObjectOfType<DynamicImageTagetBehaviour>().gameObject.transform.position;
		
		GameObject.FindObjectOfType<DynamicImageTagetBehaviour>().subGameObject.transform.parent =
			GameObject.FindObjectOfType<DynamicImageTagetBehaviour>().gameObject.transform;
	}

	public void LoadSavesinAR(string svename)
	{
		slu.LoadGame(svename);
		Camera.main.gameObject.SetActive(false);
		ARCamera.SetActive(true);

		if (GameObject.FindObjectOfType<ObjectIdentifier>().transform.parent != null)
		{
			ARCamera.transform.eulerAngles=new Vector3(-108,0,0);
			ARCamera.transform.position = GameObject.FindObjectOfType<ObjectIdentifier>().transform.position +
			                                   new Vector3(0,3,8);
				
			print("Doine");
		}
		else
			ARCamera.transform.eulerAngles=new Vector3(-108,0,0);
		ARCamera.transform.position = GameObject.FindObjectOfType<ObjectIdentifier>().transform.position +
		                              new Vector3(0,3,8);

	}
	
}
