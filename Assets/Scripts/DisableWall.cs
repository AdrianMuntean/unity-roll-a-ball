using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisableWall : MonoBehaviour {
    public Text tutorial;
    public Text scoreAndTimeHintText;
    public GameObject wall;
    public GameObject wallTrigger;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if  (tutorial.text == "" && scoreAndTimeHintText.text == "")
        {
            wall.SetActive(false);
            wallTrigger.SetActive(false);
        }
	}
}
