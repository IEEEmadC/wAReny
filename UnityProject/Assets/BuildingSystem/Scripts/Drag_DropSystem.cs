using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;


public class Drag_DropSystem : MonoBehaviour
{
   
    public GameObject AppearPostion;
    public Text SelectText;
    public static bool CameraMove;
    public static bool CameraMoveBack;
    public static bool CameraMoveRight;
    public static bool CameraMoveLeft;
    public static bool canattach;        
    [SerializeField] private Image[] Shadowimages;
    [SerializeField] private RectTransform[] panels;
    public bool canDeattach;
    public static Drag_DropSystem D_System;

    public Text status;
    private void Awake()
    {
        D_System = this;
    }

    void Start()
    {
        SelectText.text = "";
    }
    void Update()
    {
        if (DraggedObj.SelectDetect)
        {
            SelectText.text = "Object is selected";
           
        }
        if (!DraggedObj.SelectDetect)

        {
            if (Arrows.DraggedObject != null)
            {
               
                
            }
            SelectText.text = "";
        }

    }

    public void ShowObject(GameObject draggedobject)
    {

        Instantiate(draggedobject, AppearPostion.transform.position, draggedobject.transform.rotation);
        
    }

    public void Attach(Image g)
    {
       DraggedObj.canDrag = !g.enabled;
        canattach = g.enabled;
        canDeattach = false;

    }
    public void DeAttach(Image g)
    {
        DraggedObj.canDrag = !g.enabled;
        canDeattach = g.enabled;
        canattach = false;

    }

    public void Delete()
    {
        Destroy(Arrows.DraggedObject);
    }

    public void ResetCamera()
    {
        Camera.main.transform.eulerAngles = Vector3.zero;
    }
    public void ActivateMeshHoles(Image g)
    {
        if (Arrows.DraggedObject != null)
        {
            Arrows.DraggedObject.GetComponent<cutHole>().enabled = g.enabled;
            print(Arrows.DraggedObject.gameObject.GetComponent<cutHole>().enabled);
            DraggedObj.canDrag = !g.enabled;
        }
    }


    public void ButtonShadow(Image g)
    {
        foreach (Image i in Shadowimages)
        {
            if(i!=g)
            i.enabled = false;
           
        }
        g.enabled = !g.enabled;
       
    }
    public void EnableDisablePanels(RectTransform panel)
    {
        foreach (RectTransform p in panels)
        {
            if (panel != null)
            {
                if (p != panel)
                    p.gameObject.SetActive(false);
            }
            else
            {
                p.gameObject.SetActive(false);
            }

        }

        if (panel != null)
        {
            panel.gameObject.SetActive(!panel.gameObject.activeSelf);
        }
    }
    //****************************************************************************************************//

    public void MoveCamera()
    {
        CameraMove = true;
    }
    public void StopCameraMove()
    {
        CameraMove = false;
        CameraMoveBack = false;
        CameraMoveLeft = false;
        CameraMoveRight = false;
    }
    public void BackMoveCamera()
    {
        CameraMoveBack = true;
    }
    public void RightMoveCamera()
    {
        CameraMoveRight = true;
    }
    public void LeftMoveCamera()
    {
        CameraMoveLeft = true;
    }
    //*****************************************************************************************************//
    // Scale Functions
     public void IncreaseScaleX()
      {
        Arrows.DraggedObject.transform.localScale = Arrows.DraggedObject.transform.localScale + new Vector3(0.01f,0f,0f);
      }
      public void IncreaseScaleY()
      {
           Arrows.DraggedObject.transform.localScale = Arrows.DraggedObject.transform.localScale + new Vector3(0f,0.01f,0f);
    }
      public void IncreaseScaleZ()
      {
           Arrows.DraggedObject.transform.localScale = Arrows.DraggedObject.transform.localScale + new Vector3(0f,0f,0.01f);
    }
      public void DecreaseScaleX()
      {
        Arrows.DraggedObject.transform.localScale = Arrows.DraggedObject.transform.localScale - new Vector3(0.01f,0f,0f);
    }
     public void DecreaseScaleY()
      {
        Arrows.DraggedObject.transform.localScale = Arrows.DraggedObject.transform.localScale - new Vector3(0f,0.01f,0f);
    }
     public void DecreaseScaleZ()
      {
        Arrows.DraggedObject.transform.localScale = Arrows.DraggedObject.transform.localScale - new Vector3(0f,0f,0.01f);
    }
 //**************************************************************************************************************//  
 public void MoveXPostive()
    {
        Arrows.DraggedObject.transform.position = Arrows.DraggedObject.transform.position + new Vector3(0.1f,0f,0f);
    }
    public void MoveYPostive()
    {
        Arrows.DraggedObject.transform.position = Arrows.DraggedObject.transform.position + new Vector3(0f,0.1f,0f);
    }
    public void MoveZPostive()
    {
        Arrows.DraggedObject.transform.position = Arrows.DraggedObject.transform.position + new Vector3(0f,0f,0.1f);
    }
    public void MoveXNegative()
    {
        Arrows.DraggedObject.transform.position = Arrows.DraggedObject.transform.position - new Vector3(0.1f, 0f, 0f);
    }
    public void MoveYNegative()
    {
        Arrows.DraggedObject.transform.position = Arrows.DraggedObject.transform.position - new Vector3(0f, 0.1f, 0f);
    }
    public void MoveZNegative()
    {
        Arrows.DraggedObject.transform.position = Arrows.DraggedObject.transform.position - new Vector3(0f, 0f, 0.1f);
    }
//*********************************************************************************************************************//
//Rotation Functions
public void RotateX()
    {
        Arrows.DraggedObject.transform.Rotate(10f, 0f, 0f);
    }
    public void RotateY()
    {
        Arrows.DraggedObject.transform.Rotate(0f, 10f, 0f);
    }
    public void RotateZ()
    {
        Arrows.DraggedObject.transform.Rotate(0f, 0f, 10f);
    }
}


