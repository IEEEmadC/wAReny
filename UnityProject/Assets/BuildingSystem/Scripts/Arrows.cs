using UnityEngine;
using System.Collections;

public class Arrows : MonoBehaviour
{
    // Used in DraggedObj Class
    public static GameObject DraggedObject; // The Dragged object (DraggedObj Class)
    public static GameObject arrowx;
    public static GameObject arrowy;
    public static GameObject arrowz;
    public static GameObject ArrowsParent;
    public static Vector3 FixPostion;      //Fixing Arrows postion relative to ArrowsParent 
   

    // Use this for initialization
    void Start()
    {
        ArrowsParent = GameObject.FindGameObjectWithTag("Arrows");
        arrowx= GameObject.FindGameObjectWithTag("Xarrow");
        arrowy= GameObject.FindGameObjectWithTag("Yarrow");
        arrowz= GameObject.FindGameObjectWithTag("Zarrow");
        FixPostion = transform.localPosition;
    }
    void Update()
    {
        
    }

    void OnMouseDrag()
    {

        Vector3 MousePostion;
        Vector3 ObjectPostion;

        MousePostion = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10f);
        ObjectPostion = Camera.main.ScreenToWorldPoint(MousePostion);
      
            if (gameObject.tag == "Xarrow")
            {
                transform.position = new Vector3(ObjectPostion.x, transform.position.y, transform.position.z);
            }
            if (gameObject.tag == "Yarrow")
            {
                transform.position = new Vector3(transform.position.x, ObjectPostion.y, transform.position.z);
            }
            if (gameObject.tag == "Zarrow")
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, ObjectPostion.z);
            }
    }

    void OnMouseDown()
    {
            if (gameObject.tag == "Xarrow")
            {
                arrowz.transform.parent = transform;
                arrowy.transform.parent = transform;
                DraggedObject.transform.parent = transform;
            }
            if (gameObject.tag == "Yarrow")
            {
                arrowz.transform.parent = transform;
                arrowx.transform.parent = transform;
                DraggedObject.transform.parent = transform;
            }
            if (gameObject.tag == "Zarrow")
            {
                arrowx.transform.parent = transform;
                arrowy.transform.parent = transform;
                DraggedObject.transform.parent = transform;
            }
    }

    void OnMouseUp()
    {
       
            if (gameObject.tag == "Xarrow")
            {
                DraggedObject.transform.parent = null;
                arrowz.transform.parent = null;
                arrowy.transform.parent = null;
                arrowz.transform.parent = ArrowsParent.transform;
                arrowy.transform.parent = ArrowsParent.transform;
            }
            if (gameObject.tag == "Yarrow")
            {
                DraggedObject.transform.parent = null;
                arrowz.transform.parent = null;
                arrowx.transform.parent = null;
                arrowz.transform.parent = ArrowsParent.transform;
                arrowx.transform.parent = ArrowsParent.transform;
            }
            if (gameObject.tag == "Zarrow")
            {
                DraggedObject.transform.parent = null;
                arrowx.transform.parent = null;
                arrowy.transform.parent = null;
                arrowx.transform.parent = ArrowsParent.transform;
                arrowy.transform.parent = ArrowsParent.transform;
            }
    }
}
