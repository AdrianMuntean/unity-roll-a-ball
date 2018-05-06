using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour {

    public Transform canvas;
    public GameObject gameObject;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (canvas.gameObject.activeInHierarchy == false)
            {
                canvas.gameObject.SetActive(true);
                gameObject.gameObject.SetActive(false);
            } else
            {
                canvas.gameObject.SetActive(false);
                gameObject.gameObject.SetActive(true);
            }
        }
	}
}
