using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PhotonARManager : Photon.MonoBehaviour {

    public static PhotonARManager manager;
    public static string roomName;
    private GenerateQRCode generate;
    public Text sts;
    bool canCreate;
    private void Awake()
    {
        manager = this;
        if(gameObject.tag=="ARScene")
        generate = GetComponent<GenerateQRCode>();
        PhotonNetwork.automaticallySyncScene = true;
       // DontDestroyOnLoad(gameObject);
    }
    // Use this for initialization
    public void StartConnect()
    {
        PhotonNetwork.ConnectUsingSettings("wAReny1.0");
        Debug.Log(PhotonNetwork.connectionStateDetailed.ToString());
    }
    

    public void ConnectToRoomCreate()
    {
        
        canCreate = true;
       
        //PhotonNetwork.LoadLevel("ARScene");
        Debug.Log(PhotonNetwork.connectionStateDetailed.ToString());
    }
    public virtual void OnConnectedToMaster()
    {
        RandomizeRoomName();
        if (gameObject.tag == "ARScene")
            generate.Txt = roomName;

        if (canCreate)
        {
            PhotonNetwork.CreateRoom(roomName, null, null);
            generate.ShowQR();
        }
        else
        {
            PhotonNetwork.JoinRoom(QRCodeScan.QR_result.Text);
           // PhotonNetwork.LoadLevel("ARScene");
        }
    }


    public void ConnectToRoomJoin()
    {
        canCreate = false;     
        //PhotonNetwork.LoadLevel("ARScene");
        Debug.Log(PhotonNetwork.connectionStateDetailed.ToString());
    }

    private void RandomizeRoomName()
    {
        int temp = Random.Range(0, 9);
        roomName = "Room" + temp.ToString();
    }
    [PunRPC]
    public void LoadNetworkScene()
    {
        PhotonNetwork.LoadLevel(SceneManager.GetActiveScene().name);
    }
    public void LoadPhotonLevel()
    {
        //photonView.RPC("LoadNetworkScene", PhotonTargets.All);
        PhotonNetwork.LoadLevel(SceneManager.GetActiveScene().name);
    }

    // Update is called once per frame
    void Update () {
        if (gameObject.tag != "ARScene")
        {
            if (PhotonNetwork.room != null)
                sts.text = PhotonNetwork.connectionStateDetailed.ToString() + "\n" + PhotonNetwork.room.Name;
            else
                sts.text = PhotonNetwork.connectionStateDetailed.ToString();
        }

    }
    

}
