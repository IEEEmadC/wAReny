using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TransfromChange : MonoBehaviour {

    [SerializeField] private Text m_sliderTextX;
    [SerializeField] private Text m_sliderTextY;
    [SerializeField] private Text m_sliderTextZ;
    [SerializeField] private Slider m_sliderX;
    [SerializeField] private Slider m_sliderY;
    [SerializeField] private Slider m_sliderZ;

   // [SerializeField]
   // private GameObject SelectedObject;

    void Awake()
    {
        //onSliderXValueChanged();
        // onSliderYValueChanged();
        //onSliderZValueChanged();
        
    }

    public void onSliderXValueChanged()
    {
        m_sliderTextX.text = m_sliderX.value.ToString();
        
        switch (gameObject.tag)
        {
            case "Move":
                if (m_sliderX.direction == Slider.Direction.LeftToRight)
                    Arrows.DraggedObject.transform.localPosition += new Vector3(m_sliderX.value, 0, 0);
                else
                     Arrows.DraggedObject.transform.localPosition -= new Vector3(m_sliderX.value, 0, 0); 
                break;
            case "Rotate":
                if (m_sliderX.direction == Slider.Direction.LeftToRight)
                    Arrows.DraggedObject.transform.localEulerAngles += new Vector3(m_sliderX.value, 0, 0);
                else
                    Arrows.DraggedObject.transform.localEulerAngles -= new Vector3(m_sliderX.value, 0, 0);
                break;
            case "Scale":
                if (m_sliderX.direction == Slider.Direction.LeftToRight)
                    Arrows.DraggedObject.transform.localScale += new Vector3(m_sliderX.value, 0, 0);
                else
                    Arrows.DraggedObject.transform.localScale -= new Vector3(m_sliderX.value, 0, 0);
                break;
            default:
                break;
        }
    }

    public void onSliderYValueChanged()
    {
        m_sliderTextY.text = m_sliderY.value.ToString();
        switch (gameObject.tag)
        {
            case "Move":
                if (m_sliderX.direction == Slider.Direction.LeftToRight)
                    Arrows.DraggedObject.transform.localPosition += new Vector3(0, m_sliderY.value, 0);
                else
                    Arrows.DraggedObject.transform.localPosition -= new Vector3(0, m_sliderY.value, 0);
                break;
            case "Rotate":
                if (m_sliderX.direction == Slider.Direction.LeftToRight)
                    Arrows.DraggedObject.transform.localEulerAngles += new Vector3(0, m_sliderY.value, 0);
                else
                    Arrows.DraggedObject.transform.localEulerAngles -= new Vector3(0, m_sliderY.value, 0);
                break;
            case "Scale":
                if (m_sliderX.direction == Slider.Direction.LeftToRight)
                    Arrows.DraggedObject.transform.localScale += new Vector3(0, m_sliderY.value, 0);
                else
                    Arrows.DraggedObject.transform.localScale -= new Vector3(0, m_sliderY.value, 0);

                break;
            default:
                break;
        }
    }

    public void onSliderZValueChanged()
    {
        m_sliderTextZ.text = m_sliderZ.value.ToString();
        switch (gameObject.tag)
        {
            case "Move":
                if (m_sliderX.direction == Slider.Direction.LeftToRight)
                    Arrows.DraggedObject.transform.localPosition += new Vector3(0, 0, m_sliderZ.value);
                else
                    Arrows.DraggedObject.transform.localPosition -= new Vector3(0, 0, m_sliderZ.value);
                break;
            case "Rotate":
                if (m_sliderX.direction == Slider.Direction.LeftToRight)
                    Arrows.DraggedObject.transform.localEulerAngles += new Vector3(0,0, m_sliderZ.value);
                else
                    Arrows.DraggedObject.transform.localEulerAngles -= new Vector3(0, 0, m_sliderZ.value);
                break;
            case "Scale":
                if (m_sliderX.direction == Slider.Direction.LeftToRight)
                    Arrows.DraggedObject.transform.localScale += new Vector3(0,0, m_sliderZ.value);
                else
                    Arrows.DraggedObject.transform.localScale -= new Vector3(0, 0, m_sliderZ.value);
                break;
            default:
                break;
              
        }
    }

}
