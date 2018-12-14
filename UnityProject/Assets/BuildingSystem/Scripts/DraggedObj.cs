using UnityEngine;
using System.Collections;


public class DraggedObj : MonoBehaviour
{
    //Used in Drag_DropSystem Class to show and hide the text
    public static bool SelectDetect;
    public static bool canDrag;
    public bool attached;
    public Canvas c;
    void OnMouseDrag()
     {
        if (canDrag)
        {
            Vector3 MousePostion;
            Vector3 ObjectPostion;

            MousePostion = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10f);
            ObjectPostion = Camera.main.ScreenToWorldPoint(MousePostion);
            transform.position = ObjectPostion;
            Arrows.ArrowsParent.transform.position = transform.position - new Vector3(9.3f, 7.5f, 4.6f);
        }
        if (Drag_DropSystem.canattach&&gameObject!=Arrows.DraggedObject)
        {
            gameObject.transform.parent = Arrows.DraggedObject.transform;
            this.enabled = false;
        }
    }

    void OnMouseDown()
    {
        if (!Drag_DropSystem.canattach&&!Drag_DropSystem.D_System.canDeattach)
        {
            Arrows.arrowx.transform.localPosition = Arrows.FixPostion + new Vector3(1, 0, 0);
            Arrows.arrowy.transform.localPosition = Arrows.FixPostion + new Vector3(0.9f, 0, 0);
            Arrows.arrowz.transform.localPosition = Arrows.FixPostion + new Vector3(0.9f, 0, 0);
            SelectDetect = true;
            Arrows.ArrowsParent.transform.parent = transform;
            Arrows.DraggedObject = gameObject;
        }
        else if(Drag_DropSystem.canattach)
        {
            Arrows.DraggedObject.transform.parent = transform;
            Arrows.DraggedObject.GetComponent<DraggedObj>().attached = true;
            Arrows.DraggedObject = gameObject;
            Drag_DropSystem.D_System.status.text = "Attached";
            Drag_DropSystem.D_System.status.GetComponent<Animator>().SetTrigger("Txt");
        }
        else if (Drag_DropSystem.D_System.canDeattach&&attached)
        {
            transform.parent = null;
            attached = false;
            Arrows.DraggedObject = gameObject;
            Drag_DropSystem.D_System.status.text = "Deattached";
            Drag_DropSystem.D_System.status.GetComponent<Animator>().SetTrigger("Txt");
        }

    }

    void OnMouseUp()
    {
        
       // print(arrows.transform.position);
        Arrows.ArrowsParent.transform.parent = null;
        SelectDetect = false;
    }
    private void Awake()
    {
        c = GetComponentInChildren<Canvas>();
        if(gameObject.tag!="Saw")
        c.gameObject.SetActive(false);
        canDrag = true;
    }
    private void Update()
    {
        if (gameObject == Arrows.DraggedObject)
        {
            if (gameObject.tag != "Saw")
                c.gameObject.SetActive(true);          
        }
        else
        {
            if (gameObject.tag != "Saw")
            {
                c.gameObject.SetActive(false);
                GetComponent<cutHole>().enabled = false;
            }
        }
    }
    
}
