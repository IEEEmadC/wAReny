using UnityEngine;
using UnityEngine.UI;

public class StartSceneCam : MonoBehaviour {

// Reading QR code Code
    private WebCamTexture camTexture;
    private Quaternion baseRotation;
    public RawImage cam_Texture;
    public AspectRatioFitter fitter;
    
    private void Start()
    {
        //photonmanager = GetComponent<PhotonARManager>();
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
            camTexture.Play();         
            cam_Texture.texture = camTexture;
        }

    }
    
     
     void Update()
     {
      
            float ratio = (float) camTexture.width / (float) camTexture.height;
            fitter.aspectRatio = ratio;

            float ScaleY = camTexture.videoVerticallyMirrored ? -1f : 1f;
            cam_Texture.rectTransform.localScale=new Vector3(1,ScaleY,1);

            int angle = -camTexture.videoRotationAngle;
            cam_Texture.rectTransform.localEulerAngles=new Vector3(0,0,angle);

     }

    private void OnDestroy()
    {
        camTexture.Stop();
    }
}
