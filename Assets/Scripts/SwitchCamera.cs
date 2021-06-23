using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchCamera : MonoBehaviour
{
    public GameObject[] cameras;
    public Text cameraText;
    public int enabledCamera = 0;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < cameras.Length; i++)
        {
            cameras[i].SetActive(false);
        }
        cameras[enabledCamera].SetActive(true);
        if (cameras[enabledCamera].transform.parent != null) cameraText.text = cameras[enabledCamera].transform.parent.gameObject.name;
        else cameraText.text = cameras[enabledCamera].name;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            switchCameraUp();
        }
    }

    public void switchCameraUp(){
        cameras[enabledCamera].SetActive(false);
        enabledCamera += 1;
        if (enabledCamera == cameras.Length) enabledCamera = 0;
        cameras[enabledCamera].SetActive(true);
        if (cameras[enabledCamera].transform.parent != null) cameraText.text = cameras[enabledCamera].transform.parent.gameObject.name;
        else cameraText.text = cameras[enabledCamera].name;
    }
}
