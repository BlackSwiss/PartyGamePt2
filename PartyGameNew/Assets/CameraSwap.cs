using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwap : MonoBehaviour
{
    public Camera MainCamera;
    public Camera PlayerAreaCam;
    // Start is called before the first frame update
    void Start()
    {
        PlayerAreaCam.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void swap()
    {
        MainCamera.enabled = false;
        MainCamera.GetComponent<AudioListener>().enabled = false;
        PlayerAreaCam.enabled = true;
        Debug.Log("This script is running");
    }
}
