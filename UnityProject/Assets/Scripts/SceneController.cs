using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class SceneController : Photon.MonoBehaviour
{
    public Button pakgBtn;
    public Button savesBtn;
    public Color inistateColor;
    public Color ClickedColor;
    private string activatedBtn = "packages";
    private Text pakgBtnText;
    private Text savesBtnText;
    public GameObject packagesUI;
    public GameObject spaceUI;
    public GameObject furnUI;
    public GameObject packView;
    public GameObject savesView;
    private GameObject tmp;

    private void Awake()
    {
        pakgBtnText = pakgBtn.GetComponentInChildren<Text>(true);
        savesBtnText = savesBtn.GetComponentInChildren<Text>(true);
    }
    void Start()
    {
        pakgBtnText.color = ClickedColor;
        savesBtnText.color = inistateColor;
        savesView.SetActive(false);
        packView.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {


    }

    public void setBtn(string btnName)
    {
        if (btnName == "packages")
        {
            pakgBtnText.color = ClickedColor;
            savesBtnText.color = inistateColor;
            savesView.SetActive(false);
            packView.SetActive(true);
        }
        else if (btnName == "saves")
        {
            pakgBtnText.color = inistateColor;
            savesBtnText.color = ClickedColor;
            savesView.SetActive(true);
            packView.SetActive(false);
        }
    }

    public void load_UI(string nameUI)
    {
        if (nameUI == "packages")
        {
            furnUI.SetActive(false);
            spaceUI.SetActive(false);
            packagesUI.SetActive(true);
        }
        else if (nameUI == "space")
        {
            /*  furnUI.SetActive(false);
              spaceUI.SetActive(true);
              packagesUI.SetActive(false);*/
            //cam.GetComponent<XRCameraController>().enabled = true;
            SceneManager.LoadScene("SpaceScene");

        }
        else if (nameUI == "furniture")
        {
            /* furnUI.SetActive(true);
             spaceUI.SetActive(false);
             packagesUI.SetActive(false);*/
            //cam.GetComponent<XRCameraController>().enabled = true;

            SceneManager.LoadScene("FurintureScene");
        }
        else if(nameUI == "Marketing")
        {
            SceneManager.LoadScene("Marketing");
        }
    }
    [PunRPC]
    public void CreatePlayer(GameObject m)
    {
        if (tmp !=null)
        {
            PhotonNetwork.Destroy(tmp);
        }
        tmp=PhotonNetwork.Instantiate(m.name, Camera.main.transform.position+(15 * Vector3.forward), Quaternion.identity, 0);
       
    }
    public void InstatiateModels(GameObject model)
    {
        if (PhotonNetwork.inRoom)
            CreatePlayer(model);
        else
        {
            if (tmp !=null)
            {
                Destroy(tmp);
            }
            tmp=Instantiate(model, Camera.main.transform.position + (15 * Vector3.forward), Quaternion.identity);
           
            //Destroy(GameObject.FindObjectOfType<MeshRenderer>().gameObject);
        }
    }

    public virtual void OnConnectedToMaster()
    {
        Destroy(tmp);
    }

    

    [PunRPC]
    public void PunActivate(GameObject o)
    {
        o.SetActive(!o.activeSelf);
        
    }

    public void ActivateModel(GameObject model)
    {
        photonView.RPC("PunActivate", PhotonTargets.All, model);
    }

}
