using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MasterCheckPhoton : Photon.MonoBehaviour {

    private void Awake()
    {
        if (PhotonNetwork.inRoom)
        {
            if (!PhotonNetwork.isMasterClient)
            {
                GetComponent<Button>().interactable = false;
            }
        }
    }


}
