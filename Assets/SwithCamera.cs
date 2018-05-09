using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwithCamera : MonoBehaviour {

    [SerializeField]
    Camera camera1;
    [SerializeField]
    Camera camera2;
    [SerializeField]
    Camera camera3;
    [SerializeField]
    Camera camera4;

    AudioListener camera1Listener1;
    AudioListener camera1Listener2;
    AudioListener camera1Listener3;
    AudioListener camera1Listener4;
    AudioListener camera1Listener5;

    // Use this for initialization
    void Start()
    {
        camera1.GetComponent<Camera>().enabled = true;
        camera2.GetComponent<Camera>().enabled = false;
        camera3.GetComponent<Camera>().enabled = false;
        camera4.GetComponent<Camera>().enabled = false;
      
        camera1Listener1 = camera1.GetComponent<AudioListener>();
        camera1Listener2 = camera2.GetComponent<AudioListener>();
        camera1Listener3 = camera3.GetComponent<AudioListener>();
        camera1Listener4 = camera3.GetComponent<AudioListener>();
      
        camera1Listener1.enabled = true;
        camera1Listener2.enabled = false;
        camera1Listener3.enabled = false;
        camera1Listener4.enabled = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            camera1.enabled = true;
            camera2.enabled = false;
            camera3.enabled = false;
            camera4.enabled = false;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            camera1.enabled = false;
            camera2.enabled = true;
            camera3.enabled = false;
            camera4.enabled = false;

        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            camera1.enabled = false;
            camera2.enabled = false;
            camera3.enabled = true;
            camera4.enabled = false;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            camera1.enabled = false;
            camera2.enabled = false;
            camera3.enabled = false;
            camera4.enabled = true;
        }
    }
}
