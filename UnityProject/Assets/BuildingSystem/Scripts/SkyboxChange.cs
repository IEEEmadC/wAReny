using UnityEngine;
using System.Collections;

public class SkyboxChange : MonoBehaviour
{

    public Material SpaceSkybox;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerExit(Collider col)
    {
        if (col.tag == "SpaceShip")
        {
            RenderSettings.skybox = SpaceSkybox;
        }
    }
}
