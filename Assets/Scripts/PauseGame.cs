using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseGame : MonoBehaviour {

    public Transform canvas;
    public GameObject gameObject;
    public Text timeBox;

    private string timeOldValue;

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
                timeOldValue = timeBox.text;
                timeBox.text = "PAUSED";
            } else
            {
                canvas.gameObject.SetActive(false);
                gameObject.gameObject.SetActive(true);
                timeBox.text = timeOldValue;
            }
        }
	}
}
