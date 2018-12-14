using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbit_Motion : MonoBehaviour
{

    public Transform OrbitingObject;
    public Ellipse OrbitPath;

    [Range(0f, 1f)]
    public float OrbitProgress = 0f;
    public float OrbitPeriod = 3f;
    public bool OrbitActive = true;

    // Use this for initialization
    void Start()
    {
        if (OrbitingObject == null)
        {
            OrbitActive = false;
            return;
        }
        SetOrbitingObjectPosition();
        StartCoroutine(AnimateOrbit());
    }   //if (OrbitActive) star orbit animation

    void SetOrbitingObjectPosition()
    {
        Vector2 OrbitPos = OrbitPath.Evaluate(OrbitProgress);
        OrbitingObject.localPosition = new Vector3(OrbitPos.x, 0, OrbitPos.y);
    }

    IEnumerator AnimateOrbit()
    {
        if (OrbitPeriod < 0.1f)
        {
            OrbitPeriod = 0.1f;
        }
        float OrbitSpeed = 1f / OrbitPeriod;
        while (OrbitActive)
        {
            OrbitProgress += Time.deltaTime * OrbitSpeed;
            OrbitProgress %= 1f;
            SetOrbitingObjectPosition();
            yield return null;

        }
    }
}
