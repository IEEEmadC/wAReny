using UnityEngine;
using System.Collections;
using EasyAR;
using UnityEngine.UI;
using Image = EasyAR.Image;

namespace Sample
{
    public class TargetOnTheFly : MonoBehaviour
    {


        [HideInInspector]
        public bool StartShowMessage = false;
        private bool isShowing = false;
        private ImageTargetManager imageManager;
        private FilesManager imageCreater;
        public UnityEngine.UI.Button confirm;
        public UnityEngine.UI.Button  delete;
        public RawImage img;
        
        public GUISkin skin;
        private void Awake()
        {         
            imageManager = FindObjectOfType<ImageTargetManager>();
            imageCreater = FindObjectOfType<FilesManager>();
        }

        private void Start()
        {
            
            
        }
        void OnGUI()
        {
           /* if (StartShowMessage)
            {
                if (!isShowing)
                    StartCoroutine(showMessage());
                StartShowMessage = false;
            }*/
    
            //GUI.Box(new Rect(Screen.width / 2 - 250, 30, 500, 60), "The box area will be used as ImageTarget. Take photo!", skin.GetStyle("Box"));
            GUI.Box(new Rect(Screen.width / 4, Screen.height / 4, Screen.width / 2, Screen.height / 2), "", skin.GetStyle("Box"));

            //if (isShowing)
              //  GUI.Box(new Rect(Screen.width / 2 - 65, Screen.height / 2, 130, 60), "Photo Saved", skin.GetStyle("Box"));
           

            /*if (GUI.Button(new Rect(Screen.width - 160, Screen.height - 85, 150, 80), "Clear Targets", skin.GetStyle("Button")))
            {
                imageCreater.ClearTexture();
                imageManager.ClearAllTarget();
            }*/
        }

        /*IEnumerator showMessage()
        {
            isShowing = true;
            yield return new WaitForSeconds(2f);
            isShowing = false;
        }*/

        private void OnDestroy()
        {
            imageCreater.ClearTexture();
            imageManager.ClearAllTarget();
        }
    }
}
