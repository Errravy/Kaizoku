using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBG : MonoBehaviour
{
    [SerializeField] float multiplier;
    Transform cameraPos;
    Vector3 lastCameraPosition;
    void Start()
    {
        cameraPos = Camera.main.transform; 
        lastCameraPosition = cameraPos.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 deltaMov = cameraPos.position - lastCameraPosition;
        transform.position += deltaMov * multiplier;
        lastCameraPosition = cameraPos.position;
    }
}
