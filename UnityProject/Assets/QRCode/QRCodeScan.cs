using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZXing;
using ZXing.QrCode;
using UnityEngine.UI;

public class QRCodeScan : MonoBehaviour {



    // Reading QR code Code
    private WebCamTexture camTexture;
    private Rect screenRect;
    [SerializeField] private RawImage Tex;
    private Quaternion baseRotation;
    bool canRead = false;
    public RawImage cam_Texture;
    public AspectRatioFitter fitter;
    public static Result QR_result;
    public PhotonARManager photonmanager;
    public Image JoinConfirmation;
    private void Start()
    {
        //photonmanager = GetComponent<PhotonARManager>();
        screenRect = new Rect(Screen.width/2, Screen.height/2, 200, 200);
        WebCamDevice[] devices = WebCamTexture.devices;
        if (devices.Length == 0)
        {
            Debug.Log("Can't find Camera Device");
            return;
        }
     #if UNITY_EDITOR
        camTexture = new WebCamTexture();
        camTexture.requestedWidth = 480;
        camTexture.requestedHeight=640;
        camTexture.deviceName = devices[0].name;
        camTexture.requestedFPS = 30f;
      #endif
        for (int i = 0; i < devices.Length; i++)
        {
            if (!devices[i].isFrontFacing)
            {
                camTexture = new WebCamTexture();
                camTexture.requestedWidth = 480;
                camTexture.requestedHeight=640;
                camTexture.deviceName = devices[i].name;
                camTexture.requestedFPS = 30f;
                
            }
            
        }
        
        if (camTexture != null)
        {
            canRead = true;           
            camTexture.Play();         
            cam_Texture.texture = camTexture;
            Tex.texture = camTexture;
        }

    }
    
     
     void Update()
     {

        if (canRead)
        {
               
            float ratio = (float) camTexture.width / (float) camTexture.height;
            fitter.aspectRatio = ratio;

            float ScaleY = camTexture.videoVerticallyMirrored ? -1f : 1f;
            cam_Texture.rectTransform.localScale=new Vector3(1,ScaleY,1);

            int angle = -camTexture.videoRotationAngle;
            cam_Texture.rectTransform.localEulerAngles=new Vector3(0,0,angle);
            
            
            try
            {
                // do the reading
               IBarcodeReader barcodeReader = new BarcodeReader();
                // decode the current frame
                QR_result = barcodeReader.Decode(camTexture.GetPixels32(), camTexture.width, camTexture.height);
                photonmanager.sts.text = "QR: " + QR_result;
                if (QR_result != null)
                {
                    Debug.Log("DECODED TEXT FROM QR: " + QR_result.Text);
                    JoinConfirmation.gameObject.SetActive(true);
                    JoinConfirmation.GetComponentInChildren<Text>().text =
                       PhotonNetwork.playerList.Length.ToString() + " Users are in room, Confirm join ?";
                    canRead = false;
                }
            }
            catch (MissingReferenceException ex)
            {
                Debug.LogWarning(ex.Message);
                photonmanager.sts.text = ex.Message;
            }
            }
       
     }

    public void JoinRoom()
    {
        photonmanager.StartConnect();
        canRead = false;
        camTexture.Stop();
        photonmanager.ConnectToRoomJoin();
    }

    public void CancelJoinRoom()
    {
        canRead = true;
    }
    
    private void OnDestroy()
    {
        camTexture.Stop();
        canRead = false;
    }
}
